using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    public GameObject bullets;
    public float startTimeBetweenSpawn;
    private float timeBetweenSpawn;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //Instantiate(bullets, transform.position, transform.rotation);
        if (Input.GetKeyDown(KeyCode.Tab) && timeBetweenSpawn <= 0)
        {
            Instantiate(bullets, transform.position, Quaternion.identity);

            timeBetweenSpawn = startTimeBetweenSpawn;
        }
        else
        {
            timeBetweenSpawn -= Time.deltaTime;
        }

    }

}
