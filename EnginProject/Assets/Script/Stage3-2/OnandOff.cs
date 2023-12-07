using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnandOff : MonoBehaviour
{
    Key key;
    CameraMove ca;
    Player1move p1;
    Player2move p2;

    public GameObject ReStartText;
    public GameObject[] obj;
    public GameObject[] CountBox;
    public GameObject[] CountBoxSpawn;
    float timer = 0;
    float cool = 0;

    // Start is called before the first frame update
    void Start()
    {
        key = GameObject.Find("Key").GetComponent<Key>();
        ca = GameObject.FindObjectOfType<CameraMove>();
        p1 = GameObject.FindObjectOfType<Player1move>();
        p2 = GameObject.FindObjectOfType<Player2move>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer <= 3)
        {
            obj[0].GetComponent<Image>().color = Color.white;
            obj[1].GetComponent<Image>().color = Color.blue;
            if(timer > 2.2f&&timer <= 3)
            {
                for(int r = 0; r < 5; r++)
                {
                    cool += Time.deltaTime;
                    if (cool > 0.1f)
                    {
                        obj[1].GetComponent<Image>().color = Color.white;
                        cool = 0;
                    }
                }
            }
        }
        if (timer > 3)
        {
            obj[0].GetComponent<Image>().color = Color.red;
            obj[1].GetComponent<Image>().color = Color.white;
            if (timer > 5.2 && timer < 6)
            {
                for (int r = 0; r < 5; r++)
                {
                    cool += Time.deltaTime;
                    if (cool > 0.1f)
                    {
                        obj[0].GetComponent<Image>().color = Color.white;
                        cool = 0;
                    }
                }
            }
        }
        if (timer >= 6)
        {
            timer = 0;
        }


        if(obj[1].GetComponent<Image>().color == Color.blue)
        {
            if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))
            {
                ReStart();
            }
        }

        if (obj[0].GetComponent<Image>().color == Color.red)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow))
            {
                ReStart();
            }
        }


        if (p1.transform.position == p1.spawn.position&& p2.transform.position == p2.spawn.position)
        {
            ReStartText.SetActive(true);
        }
        else if (p1.transform.position != p1.spawn.position || p2.transform.position != p2.spawn.position)
        {
            ReStartText.SetActive(false);
        }
    }

    public void ReStart()
    {
        key.GetComponent<CapsuleCollider2D>().enabled = true;
        key.ren.enabled = true;
        key.isKey1 = false;
        key.isKey2 = false;

        p1.gameObject.SetActive(true);
        p2.gameObject.SetActive(true);

        p1.transform.position = p1.spawn.position;
        p2.transform.position = p2.spawn.position;
        ca.transform.position = p2.spawn.position;
        CountBox[0].transform.position = CountBoxSpawn[0].transform.position;
        CountBox[1].transform.position = CountBoxSpawn[1].transform.position;
        CountBox[2].transform.position = CountBoxSpawn[2].transform.position;
    }
}
