using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveTime : MonoBehaviour
{
    Key key;
    CameraMove ca;
    Player1move p1;
    Player2move p2;

    public Slider sd;
    public float timer = 5;
    // Start is called before the first frame update
    void Start()
    {
        ca = GameObject.FindObjectOfType<CameraMove>();
        p1 = GameObject.FindObjectOfType<Player1move>();
        p2 = GameObject.FindObjectOfType<Player2move>();
        key = GameObject.Find("Key").GetComponent<Key>();
    }

    // Update is called once per frame
    void Update()
    {

        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))&&
              (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow)))
        {
            timer -= Time.deltaTime * 2.6f;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))
        {
            timer -= Time.deltaTime * 1.8f;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow))
        {
            timer -= Time.deltaTime * 1.8f;
        }
        else if(timer <= 5)
        {
            timer += Time.deltaTime * 1.5f;
        }

        sd.value = timer;

        if (timer <= 0)
        {
            ReStart();
        }
    }

    public void ReStart()
    {
        timer = 5;

        p1.gameObject.SetActive(true);
        p2.gameObject.SetActive(true);

        key.GetComponent<CapsuleCollider2D>().enabled = true;
        key.ren.enabled = true;
        key.isKey1 = false;
        key.isKey2 = false;

        p1.transform.position = p1.spawn.position;
        p2.transform.position = p2.spawn.position;
        ca.transform.position = p2.spawn.position;
    }
}
