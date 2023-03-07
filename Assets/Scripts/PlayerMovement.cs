using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;



    public Rigidbody2D rb;
    public float move_speed = 5f;
    public float jumpforce = 20f;

    public static bool facingRight = true;


    // Start is called before the first frame update
    void Start()
    {

        rb = this.GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        
        transform.eulerAngles = new Vector3(0, 0, 0);

        float hInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(hInput * move_speed, rb.velocity.y);
        //transform.position = transform.position + new Vector3(hInput * move_speed * Time.deltaTime, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            isGrounded = false;
            rb.AddForce(transform.up * jumpforce,ForceMode2D.Impulse);
        }



        if (facingRight == false && hInput > 0)
        {
            flip();
        }
        else if (facingRight == true && hInput < 0)
        {
            flip();
        }
    }
    void flip()
    {
        facingRight = !facingRight;
        Vector3 Scalar = transform.localScale;
        Scalar.x *= -1;
        transform.localScale = Scalar;

    }
}
