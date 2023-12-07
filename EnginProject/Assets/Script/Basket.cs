using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    AddSecond ad;

    bool isbool = false;
    // Start is called before the first frame update
    void Start()
    {
        ad = GameObject.FindObjectOfType<AddSecond>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isbool)
        {
            ad.add = 5;
        }
        if(isbool == false)
        {
            ad.add = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Fruits"))
        {
            Debug.Log("dfdsfdsfsdfsdfsfsf");
             isbool = true;
        }
    }
}
