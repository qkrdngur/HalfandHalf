using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMark : MonoBehaviour
{
    Player1move p1;
    Player2move p2;
    Key key;
    public GameObject[] keys;
    // Start is called before the first frame update
    void Start()
    {
        p1 = GameObject.FindObjectOfType<Player1move>();
        p2 = GameObject.FindObjectOfType<Player2move>();
        key = GameObject.FindObjectOfType<Key>();
    }

    // Update is called once per frame
    void Update()
    {
        if(p1.transform.position == p1.spawn .position)
        {
            keys[0].SetActive(false);
        }
        if(p2.transform.position == p2.spawn .position)
        {
            keys[1].SetActive(false);
        }


        if(key.isKey1)
        {
            keys[0].SetActive(true);
        }
        else if(key.isKey2)
        {
            keys[1].SetActive(true);
        }
    }
}
