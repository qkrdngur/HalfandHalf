using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    Empty em;
    Key key;
    CameraMove ca;
    Player1move p1;
    Player2move p2;
    public Transform[] player;
    public Transform respawn;

    Sprite sp;
    float timer = 0;
    float timer2 = 0;

    bool p1going = false;
    bool p2going = false;
    // Start is called before the first frame update
    void Start()
    {
        em = GameObject.FindObjectOfType<Empty>();
        ca = GameObject.FindObjectOfType<CameraMove>();
        p1 = GameObject.FindObjectOfType<Player1move>();
        p2 = GameObject.FindObjectOfType<Player2move>();
        key = GameObject.Find("Key").GetComponent<Key>();
        sp = em.sprite[0];
    }

    // Update is called once per frame
    void Update()
    {

        GetComponent<SpriteRenderer>().flipX = false;

        //Player1
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))
        {
            timer += Time.deltaTime;
            if (timer > 0.3f)
            {
                GetComponent<SpriteRenderer>().sprite = em.sprite[1];
            }
        }
        if (p2going == false)
        {
            if (timer > 0.47f)
            {
                em.ista = true;
                em.sprite[0] = em.sprite[1];
                gameObject.GetComponent<SpriteRenderer>().color = Color.red;

                if (transform.position.x - player[0].position.x < 0f)
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                p1going = true;
                transform.position = Vector3.MoveTowards(transform.position, player[0].position, 0.08f);

                p1.speed = 0;
                p2.speed = 0;
            }
        }


        //Player2
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow))
        {
            timer2 += Time.deltaTime;
            if (timer2 > 0.3f)
            {
                GetComponent<SpriteRenderer>().sprite = em.sprite[1];

            }
        }
        if (p1going == false)
        {
            if (timer2 > 0.47f)
            {
                em.ista = true;
                em.sprite[0] = em.sprite[1];
                gameObject.GetComponent<SpriteRenderer>().color = Color.red;

                if (transform.position.x - player[1].position.x < 0f)
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                p2going = true;
                transform.position = Vector3.MoveTowards(transform.position, player[1].position, 0.08f);

                p1.speed = 0;
                p2.speed = 0;
            }
        }


        if (Input.GetKeyUp(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow)|| Input.GetKeyUp(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            em.p2same = true;
        }
        if (p1going == false)
        {
            if (em.p2same)
            {
                GetComponent<SpriteRenderer>().sprite = em.sprite[1];
                em.ista = true;
                em.sprite[0] = em.sprite[1];
                gameObject.GetComponent<SpriteRenderer>().color = Color.red;

                if (transform.position.x - player[1].position.x < 0f)
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                p2going = true;
                transform.position = Vector3.MoveTowards(transform.position, player[1].position, 0.05f);

                p1.speed = 0;
                p2.speed = 0;

            }
        }

        if(Input.GetKeyUp(KeyCode.W)&& Input.GetKey(KeyCode.A)|| Input.GetKeyUp(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            em.p1same = true;
        }
        if (p2going == false)
        {
            if (em.p1same)
            {
                em.ista = true;
                em.sprite[0] = em.sprite[1];
                gameObject.GetComponent<SpriteRenderer>().color = Color.red;

                if (transform.position.x - player[0].position.x < 0f)
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                p1going = true;
                transform.position = Vector3.MoveTowards(transform.position, player[0].position, 0.05f);

                p1.speed = 0;
                p2.speed = 0;
            }
        }


            if (em.ista == false)
        {
            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.UpArrow)
                     || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.W))
            {
                GetComponent<SpriteRenderer>().color = Color.white;
                GetComponent<SpriteRenderer>().sprite = em.sprite[0];

                p1going = false;
                p2going = false;
                timer = 0;
                timer2 = 0;
            }
        }

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            ReStart();
        }
     }


    public void ReStart()
    {
        Debug.Log("dfdsdsgdssgdf");
        timer = 0;
        timer2 = 0;
        p1.transform.position = p1.spawn.position;
        p2.transform.position = p2.spawn.position;
        ca.transform.position = p2.spawn.position;
        em.sprite[0] = sp;
        em.ista = false;
        em.p2same = false;
        em.p1same = false;

        key.GetComponent<CapsuleCollider2D>().enabled = true;
        key.ren.enabled = true;
        key.isKey1 = false;
        key.isKey2 = false;

        p1.speed = 3;
        p2.speed = 3;
        transform.position = respawn.position;
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        gameObject.GetComponent<SpriteRenderer>().sprite = em.sprite[0];
    }
}
