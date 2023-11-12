using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Justmove : MonoBehaviour
{
    public float speed,jumptrimemax=1,HP;
    private Animator anim;
    private Rigidbody2D rb;
    private bool canjump,rejump;
    public bool bad;
    private float jumptime;
    public Transform jiekou;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(bad==false)
        {
     if (Input.GetAxis("Horizontal") != 0)
        {
            rb.velocity = new Vector3(10 * Input.GetAxis("Horizontal") * speed, rb.velocity.y, 0);
            speed = 0.8f;
            anim.SetBool("run", true);
            if (Input.GetAxis("Horizontal") > 0)
            {

                transform.localScale = new Vector3(1, 1, 1);
            }
            if (Input.GetAxis("Horizontal") < 0)
            {

                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else
        {
            anim.SetBool("run", false);
        }  
            if (Input.GetKeyDown(KeyCode.W) && rejump == true)
            {
                anim.Play("rejump"); 
                if(jumptime<jumptrimemax)
                {
                    jumptime += 1;
                }
                else
                { rejump = false;
                }
            }
        if (Input.GetKeyDown(KeyCode.W) && canjump == false)
            {
            anim.Play("jump"); canjump = true;
                rejump = true;
               
            }
     
        
        if (Input.GetKeyDown(KeyCode.K) )
        {
            anim.Play("forward");
           

        }

    }
}
    public void jump()
    {
        rb.velocity = new Vector3(0, 40, 0);

    }
    public void forward()
    {
        rb.velocity = new Vector3(30*transform.localScale.x,0, 0);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Finish")
        {
            canjump = false;
            anim.Play("fall"); jumptime = 0;
        }
    }
    public void dead()
    { 
        if(bad==true)
        {
 Instantiate(jiekou.Find("shiti").gameObject).transform.position=transform.position;
        Destroy(gameObject);    
        }
       
    }

}
