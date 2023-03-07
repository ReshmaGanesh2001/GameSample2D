using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieOnShoot : MonoBehaviour
{
    // Start is called before the first frame update
    public int Health = 5;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Health--;
            Destroy(collision.gameObject);
            if (Health == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
