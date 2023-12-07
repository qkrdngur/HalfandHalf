using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Elevator : MonoBehaviour
{
    public Transform target;
    public int Count = 2;
    public float speed = 2;
    public bool isgravity;
    public bool istext;

    // Start is called before the first frame update
    void Start()
    {
        isgravity = false;
        istext = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Count == 0)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
            isgravity = true;
        }
        
        if(Count > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, 0.007f);
            isgravity = false;
        }
    }

    //Player가 밀때
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            Count--;
        }

        if (collision.gameObject.CompareTag("Player2"))
        {
            Count--;
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            istext = true;
        }
    }
    //Player가 밀지 않을 때
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            Count++;
        }

        if (collision.gameObject.CompareTag("Player2"))
        {
            Count++;
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            istext = false;
        }
    }


    public void ReStart()
    {
        SceneManager.LoadScene("1");
    }
}
