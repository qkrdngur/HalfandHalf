using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownGround : MonoBehaviour
{
    Transformspawn tr;
    Rigidbody2D rb;

    float timer;
    bool isdown = false;
    bool isgr = false;

    public Transform pos;
    // Start is called before the first frame update
    void Start()
    {
        tr = GameObject.Find("DeadBox").GetComponent<Transformspawn>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isgr == false)
        {
            if (isdown)
            {
                timer += Time.deltaTime;
                if (timer > 0.55f)
                {
                    rb.constraints = ~RigidbodyConstraints2D.FreezePositionY;
                    timer = 0;
                    isdown = false;
                    isgr = true;
                }
            }
        }

        if(tr.isspawn == true)
        {
            rb.gravityScale = 0;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            transform.position = pos.position;
            isgr = false;
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            rb.gravityScale = 1;
            tr.isspawn = false;
            isdown = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            rb.gravityScale = 1;
            tr.isspawn = false;
            isdown = true;
        }
    }
}
