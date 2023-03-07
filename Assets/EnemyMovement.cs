using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public GameObject[] checkPoints;
    int i = 0;

    public static bool facingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        flip();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, checkPoints[i].transform.position, speed * Time.deltaTime);

        if (transform.position == checkPoints[i].transform.position) {
            if (i == 0)
            {
                i = 1;
                flip();
            }
            else if(i==1){
                i = 0;
                flip();
            }
            
        }
        //if (facingRight == false)
        //{
         //   flip();
        //}
        //else if (facingRight == true)
       // {
       //     flip();
       // }


    }
    void flip()
    {
        facingRight = !facingRight;
        Vector3 Scalar = transform.localScale;
        Scalar.x *= -1;
        transform.localScale = Scalar;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            Destroy(collision.gameObject);
        }
    }
}
