using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class Spring : MonoBehaviour
{
    SpriteRenderer ren;
    public Sprite[] sprite;

    Player1move p1;
    Player2move p2;
    public float power = 10;
    // Start is called before the first frame update
    void Start()
    {
        ren = GetComponent<SpriteRenderer>();
        p1 = GameObject.Find("Player1").GetComponent<Player1move>();
        p2 = GameObject.Find("Player2").GetComponent <Player2move>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player1"))
        {
            p1.JumpCount = 0;
            ren.sprite = sprite[1];
            p1.rb.AddForce(Vector3.up * power, ForceMode2D.Impulse);

        }

        if (collision.gameObject.CompareTag("Player2"))
        {
            p2.JumpCount = 0;
            ren.sprite = sprite[1];
            p2.rb.AddForce(Vector3.up * power, ForceMode2D.Impulse);

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            ren.sprite = sprite[0];
        }
        if (collision.gameObject.CompareTag("Player2"))
        {
            ren.sprite = sprite[0];
        }
    }
}
