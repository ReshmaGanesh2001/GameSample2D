using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 2f;
    private Vector2 screenBounds;
    private PlayerMovement PlayerMovement;
    public Rigidbody2D rb;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        if (PlayerMovement.facingRight == true)
        {
            rb.velocity = new Vector2(speed, 0);
            //transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else if (PlayerMovement.facingRight == false)
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (transform.position.x > screenBounds.x)
        {
            Destroy(this.gameObject);
        }
        if (transform.position.x < -screenBounds.x)
        {
            Destroy(this.gameObject);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") {
            Destroy(this.gameObject);
        }
    }
}
