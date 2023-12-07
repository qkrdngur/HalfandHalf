using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WidthElevator : MonoBehaviour
{
    Stage stage;

    public int Count = 1;
    public float speed = 2f;
    public float backspeed = 3f;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Count <= 0)
        { 
            transform.position += Vector3.right * speed * Time.deltaTime;
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
            if (timer > 0.6f)
            {
                transform.position += Vector3.left * backspeed * Time.deltaTime;
            }
        }
    }

    //Player가 밀때
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            Count--;
            speed = 2f;
        }

        if (collision.gameObject.CompareTag("Player2"))
        {
            Count--;
            speed = 2f;
        }

        if(collision.gameObject.CompareTag("Ground"))
        {
            speed = 0; backspeed = 0;
        }
    }
    //Player가 밀지 않을 때
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            Count++;
           backspeed = 3f;
        }

        if (collision.gameObject.CompareTag("Player2"))
        {
            Count++;
            backspeed = 3f;
        }
    }
}
