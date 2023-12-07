using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Key key;
    CameraMove ca;
    Player1move player1;
    Player2move player2;

    float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        key = GameObject.Find("Key").GetComponent<Key>();
        ca = GameObject.Find("Main Camera").GetComponent<CameraMove>();
        player1 = GameObject.Find("Player1").GetComponent<Player1move>();
        player2 = GameObject.Find("Player2").GetComponent<Player2move>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * speed*Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            player1.transform.position = player1.spawn.position;
            player2.transform.position = player1.spawn.position;
            ca.transform.position = player2.spawn.position;

            key.ren.enabled = true;
            key.isKey1 = false;
            key.isKey2 = false;

        }
        Destroy(gameObject);
    }
}
