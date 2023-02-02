using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    public float jumpForce;
    public float speed;
    public Rigidbody2D body;
    public bool isGround = true;
    public bool JumpInput = false;
    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpInput = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            JumpInput = false;
        }
    }

    private void FixedUpdate()
    {
        walk();
        if (JumpInput &&isGround)
        {
            jump();
        }
    }

    void walk()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Time.deltaTime * speed;
            transform.localScale = new Vector3(1, 3, 1);
         

        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * Time.deltaTime * speed;
            transform.localScale = new Vector3(-1, 3, 1);

        }
    }

    void jump()
    {
        
            body.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        
            isGround = false;
    
       
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag=="Ground")
        {
            for (int i = 0; i < collision.contacts.Length; i++)
            {
                if (collision.contacts[i].normal.y >0.1)
                {
                    isGround = true;
                   
                }
            }
        }
    }
}
