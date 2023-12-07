using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountBox : MonoBehaviour
{
    CountTextBig ct;

    Player2move p2;
    public int Count;
    public int BigCount;
    Rigidbody2D rb;
    Rigidbody2D rb1;
    Rigidbody2D rb2;
    Rigidbody2D rb3;

    // Start is called before the first frame update
    void Start()
    {
        ct = GameObject.FindObjectOfType<CountTextBig>();
        rb = GameObject.Find("CountBox").GetComponent<Rigidbody2D>();
        rb1 = GameObject.Find("CountBox (1)").GetComponent<Rigidbody2D>();
        rb2 = GameObject.Find("CountBox (2)").GetComponent<Rigidbody2D>();
        rb3 = GameObject.Find("BigCountBox").GetComponent<Rigidbody2D>();

        p2 = GameObject.Find("Player2").GetComponent<Player2move>();
    }

    //움직임 막기와 풀기
    void Update()
    {
        if (ct.BigCount > 0)
        {
            rb3.constraints = ~RigidbodyConstraints2D.FreezePositionY;
        }
        if (ct.BigCount == 0)
        {
            rb3.constraints = RigidbodyConstraints2D.None;
            rb3.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }


    //Player가 밀때
    private void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.gameObject.CompareTag("Player1"))
            {
                Count--;
            }

            if(gameObject.CompareTag("BigCountBox"))
            {
                if (collision.gameObject.CompareTag("Player1"))
                {
                    ct.BigCount--;
                }
            }


            if (collision.gameObject.CompareTag("Player2"))
            {
                Count--;
             }

            if (gameObject.CompareTag("BigCountBox"))
            {
                if (collision.gameObject.CompareTag("Player2"))
                {
                    ct.BigCount--;
                }
            }

        if (Count == 0)
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            

            rb1.constraints = RigidbodyConstraints2D.None;
            rb1.constraints = RigidbodyConstraints2D.FreezeRotation;


            rb2.constraints = RigidbodyConstraints2D.None;
            rb2.constraints = RigidbodyConstraints2D.FreezeRotation;

        }

        if (ct.BigCount == 0)
        {
            rb3.constraints = RigidbodyConstraints2D.None;
            rb3.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        p2.iscol = true;
    }

    //Player가 밀지 않을 때
    private void OnCollisionExit2D(Collision2D collision)
    {
            if (collision.gameObject.CompareTag("Player1"))
            {
                Count++;
            }

            if (gameObject.CompareTag("BigCountBox"))
            {
                if (collision.gameObject.CompareTag("Player1"))
                {
                    ct.BigCount++;
                }
            }


        if (collision.gameObject.CompareTag("Player2"))
            {
                Count++;
            }

            if (gameObject.CompareTag("BigCountBox"))
            {
                if (collision.gameObject.CompareTag("Player2"))
                {
                    ct.BigCount++;
                }
            }

        if (Count > 0)
        {
            rb.constraints = ~RigidbodyConstraints2D.FreezePositionY;
            rb1.constraints = ~RigidbodyConstraints2D.FreezePositionY;
            rb2.constraints = ~RigidbodyConstraints2D.FreezePositionY;
        }

        if (ct.BigCount > 0)
        {
            rb3.constraints = ~RigidbodyConstraints2D.FreezePositionY;
        }
    }
}
