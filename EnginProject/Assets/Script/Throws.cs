using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throws : MonoBehaviour
{
    AddSecond ad;
    public float speed = 5;
    public GameObject[] obj;
    bool isbool = false;
    // Start is called before the first frame update
    void Start()
    {
        ad = GameObject.FindObjectOfType<AddSecond>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(CompareTag("Fruits"))
        {
            if (collision.gameObject.CompareTag("Player1")|| collision.gameObject.CompareTag("Player2"))
            {
                isbool = true;
            }
        }


        if(CompareTag("Boom"))
        {
            if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
            {

                ad.Life();
                ad.isboom = true;
                ad.Count--;

            }
        }



        if (isbool == true)
        {
            ad.add = 1.5f;
        }
        if (isbool == false)
        {
            ad.add = 1.5f;
        }

        Destroy(gameObject);
    }
}
