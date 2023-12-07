using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2move : MonoBehaviour
{
    public Transform spawn;

    public Animator anim;
    public SpriteRenderer ren;

    Elevator elevator;

    public Vector2 size;
    public Vector2 center;

    public float speed = 3;
    public float jumppower;
    public Rigidbody2D rb;
    public float JumpCount = 1;
    float Timer = 0;

    public bool isCoin = false;
    public bool iscol = false;
    public bool iscolSp = false;
    bool isjump;
    private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        anim = GameObject.Find("Player2").GetComponent<Animator>();
        ren = GetComponent<SpriteRenderer>();
        elevator = GameObject.Find("Elevator").GetComponent<Elevator>();
        rb = GetComponent<Rigidbody2D>();
        isjump = false;

        transform.position = new Vector3(spawn.position.x + 0.1f, spawn.position.y, spawn.position.z);
    }

    // Update is called once per frame
    void Update()
    {

            if (elevator.isgravity == true)
            {
                rb.gravityScale = 100;
            }
            else if (elevator.isgravity == false)
            {
                rb.gravityScale = 2.5f;
            }
        


        //카메라에 벗어너지 않게
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0.018f) pos.x = 0.018f;
        if (pos.x > 0.998f) pos.x = 0.998f;
        if (pos.y < 0.018f) pos.y = 0.018f;
        if (pos.y > 0.998f) pos.y = 0.998f;
        transform.position = Camera.main.ViewportToWorldPoint(pos);

        //플레이어2 움직임
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("walk", true);
            ren.flipX = false;
            transform.position += Vector3.left * speed * Time.deltaTime;
            elevator.isgravity = false;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("walk", true);
            ren.flipX = true;
            transform.position += Vector3.right * speed * Time.deltaTime;
            _audioSource.Play();
            elevator.isgravity = false;
        }
        else
        {
            anim.SetBool("walk", false);
        }
        
        Timer += Time.deltaTime;
        //점프(1번만)
        if (Timer > 0.5f)
        {
            if (JumpCount > 0)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow) && isjump == false)
                {
                    Timer = 0;
                    JumpCount--;
                    rb.AddForce(Vector3.up * jumppower, ForceMode2D.Impulse);
                    elevator.isgravity = false;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && isjump == false)
        {
            anim.SetBool("jump", true);
        }
        else
        {
            anim.SetBool("jump", false);
        }
    }



    //점프 카운트 세기
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BigCountBox") || collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Elevator") || collision.gameObject.CompareTag("Player1"))
        {
            JumpCount = 1;
        }
    }


    //Player가 머리 위에 있으면 점프 못하게
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cant2"))
        {
            isjump = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cant2"))
        {
            isjump = false;
        }
    }
}
