using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Justmove : MonoBehaviour
{
    private float speed;
    private Animator anim;
    private Rigidbody2D rb;
    private bool canjump;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            rb.velocity = new Vector3(5 * Input.GetAxis("Horizontal") * speed, rb.velocity.y, 0);
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
        if (Input.GetKeyDown(KeyCode.W) && canjump == false)
        {
            anim.Play("jump"); canjump = true;
        }
    }
    public void jump()
    {
        rb.AddForce(new Vector3(0,1600, 0));

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Finish")
        {
            canjump = false;
            anim.Play("fall");
        }
    }

}
