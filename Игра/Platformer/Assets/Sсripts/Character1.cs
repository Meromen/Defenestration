using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;



public class Character1 : MonoBehaviour
{
    public int lives = 3;
    public float speed = 4.0f;
    public SpriteRenderer sprite;
    private Rigidbody2D rb;

     void Start()
    {
        rb = GetComponentInChildren <Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    void Move()
    {
        Vector3 temp = Vector3.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position+temp, speed*Time.deltaTime);

        if (temp.x > 0)
            sprite.flipX = true;
        else
            sprite.flipX = false;
    }

    void Jump()
    {
        rb.AddForce(transform.up * 7f, ForceMode2D.Impulse);
    }

  
     void Update()
    {

 
        if(Input.GetButton("Horizontal"))
        {
            Move();
        }
        if ( Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
}

