using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zaxiang : MonoBehaviour
{
    public string type;
    private int num;
    // Start is called before the first frame update
    void Start()
    {
         if(type=="lizhi")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(-transform.parent.lossyScale.x*Random.Range(10,20), Random.Range(-10, 10),0);
            Invoke("dead", 1);
        }
        if (type == "dead")
        {
            Invoke("dead", 1);
        }
        if (type == "botton")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(transform.localScale.x * 60, 0, 0);
            Invoke("dead", 5);
        }
    }

    // Update is called once per frame
    void Update()
    {
       if(type=="armtoll")
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                transform.GetChild(num).GetComponent<Animator>().Play("noo");
                if(num<transform.childCount-1)
                {
                   num += 1;
                }
             else
                {
                    num = 0;
                }
                transform.GetChild(num).gameObject.SetActive(true);
                transform.GetChild(num).GetComponent<Animator>().Play("no");

            }
        }
    }
    public void dead()
    {
        Destroy(gameObject);
    }
}
