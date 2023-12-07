using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour
{
    Player1move p1;
    Player2move p2;
    KeyMark km;
    Key key;

    public bool isP1;
    public bool isP2;
    public bool istimer;

    public GameObject Player1;
    public GameObject Player2;
    public GameObject Cleartext;

    public int i = 0;
    float timer = 0;
    string lasttimer;
    // Start is called before the first frame update
    void Start()
    {
        isP1 = true;  isP2 = true; istimer = true;
        p1 = GameObject.Find("Player1").GetComponent<Player1move>();
        p2 = GameObject.Find("Player2").GetComponent<Player2move>();
        key = GameObject.FindObjectOfType<Key>();
        km = GameObject.FindObjectOfType<KeyMark>();
        i = (PlayerPrefs.GetInt("ButtonManager"));
    }

    // Update is called once per frame
    void Update()
    {
        if(istimer == false)
        {
            timer += Time.deltaTime;
            if(timer > 2)
            {
                SceneManager.LoadSceneAsync("Menu");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(key.isKey1 == true)
        {
            if(collision.gameObject.CompareTag("Player1"))
            {
                km.keys[0].GetComponent<SpriteRenderer>().enabled = false;
                p1.ren.enabled = false;
                Player1.GetComponent<PolygonCollider2D>().enabled = false;
                isP1 = false;
            }
            if(isP1 == false && collision.gameObject.CompareTag("Player2"))
            {
                p2.ren.enabled = false;
                Player2.GetComponent<PolygonCollider2D>().enabled = false;
                Cleartext.SetActive(true);
                istimer = false;
                isP2 = false;

                i++;
               PlayerPrefs.SetInt("ButtonManager", i);
            }
        }


        if(key.isKey2 == true)
        {
            if (collision.gameObject.CompareTag("Player2"))
            {
                km.keys[0].GetComponent<SpriteRenderer>().enabled = false;
                p2.ren.enabled = false;
                Player2.GetComponent<PolygonCollider2D>().enabled = false;
                isP2 = false;
            }
            if (isP2 == false && collision.gameObject.CompareTag("Player1"))
            {
                p1.ren.enabled = false;
                Player1.GetComponent<PolygonCollider2D>().enabled = false;
                Cleartext.SetActive(true);
                istimer = false;
                isP1 = false;

                i++;
                PlayerPrefs.SetInt("ButtonManager", i);
            }
        }
    }
}
