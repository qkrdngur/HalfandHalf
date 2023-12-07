using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallButton : MonoBehaviour
{
    Movewall wall;
    Movewall1 wall1;
    Movewall2 wall2;

    public GameObject button;
    public GameObject button1;
    public GameObject button2;

    SpriteRenderer ren;
    public Sprite[] sprite;

    public bool interactable { get; internal set; }

    // Start is called before the first frame update
    void Start()
    {
        wall = GameObject.Find("MoveWall").GetComponent<Movewall>();
        wall1 = GameObject.Find("MoveWall1").GetComponent<Movewall1>();
        wall2 = GameObject.Find("MoveWall2").GetComponent<Movewall2>();
        ren = GetComponent<SpriteRenderer>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player1")|| collision.gameObject.CompareTag("Player2"))
        {
            if (button)
            {
                wall.anim.SetTrigger("move");
            }
            if (button1)
            {
                wall1.anim.SetTrigger("move");
            }
            if(button2)
            {
                wall2.anim.SetTrigger("move");
            }
            ren.sprite = sprite[1];

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            if (button)
            {
                wall.anim.SetTrigger("move");
            }
            if (button1)
            { 
                 wall1.anim.SetTrigger("move");
             }
            if (button2)
            {
                wall2.anim.SetTrigger("move");
            }
            ren.sprite = sprite[1];

        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            if (button)
            {
                wall.anim.SetTrigger("back");
            }
            if (button1)
            {
                wall1.anim.SetTrigger("back");
            }
            if (button2)
            {
                wall2.anim.SetTrigger("back");
            }
            ren.sprite = sprite[0];
       }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
