using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class armchang : MonoBehaviour
{
    public Transform wei,aim,texiao;
    public bool arm;
    public float Force=5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(wei!=null)
        {
            transform.position = wei.transform.position;
            if(wei.parent.localScale==new Vector3(1,1,1))
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        if(arm==true)
        {
            if (Input.GetKeyDown(KeyCode.J))
                {
  GetComponent<Animator>().Play("attack");
            }
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="bad")
        {
            aim = collision.transform;
            attack();
            if(GetComponent<Zaxiang>()!=null)
            {
                if(GetComponent<Zaxiang>().type=="botton")
                {
                    Destroy(gameObject);
                }
            }
        }
    }
    public void attack()
    {
       if(aim!=null)
        {
            if(aim.position.x-transform.position.x>0)
            {
                aim.transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                aim.transform.localScale = new Vector3(1, 1, 1);
            }
            aim.GetComponent<Rigidbody2D>().AddForce(new Vector3(1200*-aim.localScale.x, 600, 0));
            Transform a=texiao.transform.Find("numsee");
            Debug.Log(a.name);
            a.GetChild(0).GetChild(0).GetComponent<Text>().text = Force.ToString();
            aim.GetComponent<Justmove>().HP -= Force;
            if (aim.GetComponent<Justmove>().HP<0)
            {
                aim.GetComponent<Justmove>().dead();
            }
            Instantiate(a.gameObject).transform.position = aim.Find("hurtpos").position;
            Transform b = texiao.transform.Find("blood");
            b.transform.localScale = aim.transform.localScale;
            Instantiate(b.gameObject).transform.position = aim.Find("hurtpos").position;
            aim = null;
        }
    }
    public void shoot()
    {
        texiao.GetComponent<armchang>().Force = Force;
        wei.transform.parent.GetComponent<Rigidbody2D>().velocity = new Vector3(Force*-transform.localScale.x, 0, 0);
      texiao.transform.localScale = transform.localScale;
        Instantiate(texiao.gameObject).transform.position=transform.Find("wei").position;

    }
}
