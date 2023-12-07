using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformspawn : MonoBehaviour
{
    Key key;
    CameraMove ca;
    Player1move player1;
    Player2move player2;
    public bool isspawn = false;
    public GameObject Key;
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
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            ReStart();
        }
    }

    public void ReStart()
    {
            player1.transform.position = player1.spawn.position;
            player2.transform.position = player2.spawn.position;
            ca.transform.position = player2.spawn.position;
            isspawn = true;

        key.GetComponent<CapsuleCollider2D>().enabled = true;
        key.ren.enabled = true;
            key.isKey1 = false;
            key.isKey2 = false;
    }
}
