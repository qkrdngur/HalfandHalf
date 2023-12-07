using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Key key;
    Player2move player2;

    // Start is called before the first frame update
    void Start()
    {
        player2 = GameObject.Find("Player2").GetComponent<Player2move>();
        key = GameObject.Find("Key").GetComponent<Key>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player2.isCoin == true)
        {
            gameObject.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
        gameObject.SetActive(false);
            key.Count--;
            player2.iscolSp = true;
        }

        if(key.Count == 0)
        {
            key.obj.GetComponent<CapsuleCollider2D>().enabled = true;
            key.obj.GetComponent<SpriteRenderer>().enabled = true;
        }
        else if(key.Count > 0)
        {
            key.obj.GetComponent<CapsuleCollider2D>().enabled = false;
            key.obj.GetComponent<SpriteRenderer>().enabled = false;
        }
        Debug.Log(key.Count);
    }
}
