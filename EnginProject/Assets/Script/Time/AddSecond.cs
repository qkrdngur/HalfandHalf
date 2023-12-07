using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class AddSecond : MonoBehaviour
{
    Key key;
    Clear cl;
    CameraMove ca;
    Player1move player1;
    Player2move player2;

    public GameObject Player1;
    public GameObject Player2;

    public float add;
    public string timer;
    public string m_Timer = @"00.00";
    public float returnSeconds;
    public float m_TotalSeconds; // ī��Ʈ �ٿ� ��ü ��(5�� X 60��), �ν���Ʈ â���� �����ؾ� ��. 
    public Text m_Text;

    public GameObject[] life;
    public int Count = 2;
    public bool isboom = false;
    float lifetimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Player1").GetComponent<Player1move>();
        player2 = GameObject.Find("Player2").GetComponent<Player2move>();
        cl = GameObject.Find("ClearDoor").GetComponent<Clear>();
        ca = GameObject.Find("Main Camera").GetComponent<CameraMove>();
        key = GameObject.Find("Key").GetComponent<Key>();
        m_Timer = CountdownTimer(false); // Text�� �ʱⰪ�� �־� �ֱ� ����
    }

    // Update is called once per frame
    void Update()
    {
        m_Timer = CountdownTimer();

        // m_TotalSeconds�� �پ�鶧, ������ 0�� ����� ���� ������  
        if (m_TotalSeconds <= 0)
        {
            SetZero();
            //... ���⿡ ī��Ʈ �ٿ��� ���� �ɶ� [�̺�Ʈ]�� ������ �˴ϴ�. 
        }

        
            if (m_Text)
        {
            if (cl.isP1 == true || cl.isP2 == true)
            {
                m_Text.text = m_Timer;
            }
            
        }

            if(m_Timer == @"00.00"||Count <= 0)
        {
            player1.ren.enabled = true;
            Player1.GetComponent<PolygonCollider2D>().enabled = true;
            player2.ren.enabled = true;
            Player2.GetComponent<PolygonCollider2D>().enabled = true;

            key.ren.enabled = true;
            key.isKey1 = false;
            key.isKey2 = false;

            player1.transform.position = player1.spawn.position;
            player2.transform.position = player2.spawn.position;
            ca.transform.position = player2.spawn.position;
            m_TotalSeconds += returnSeconds;

            lifetimer += Time.deltaTime;

            if (Count <= 0)
            {
                SetZero();
            }
                life[0].SetActive(true);
                life[1].SetActive(true);
            Count = 2;
            
                lifetimer = 0f;
            
        }
        
    }

    public string CountdownTimer(bool IsUpdate = true)
    {
        if (IsUpdate)
        {
            m_TotalSeconds -= Time.deltaTime;

            if (add == 1.5f)
            {

                m_TotalSeconds += add;
                add = 0;
            }
        }

        TimeSpan timespan = TimeSpan.FromSeconds(m_TotalSeconds);
         timer = string.Format("{0:00}:{1:00}:{2:00}",
            timespan.Minutes, timespan.Seconds, timespan.Milliseconds);

        

        return timer;
    }

    private void SetZero()
    {
        m_Timer = @"00.00";
        m_TotalSeconds = 0;
    }

    public void Life()
    {
        life[0].SetActive(false);
    }

    public void ReStart()
    {
        Debug.Log("sdoijhapsocmx");
        player1.ren.enabled = true;
        Player1.GetComponent<PolygonCollider2D>().enabled = true;
        player2.ren.enabled = true;
        Player2.GetComponent<PolygonCollider2D>().enabled = true;

        player1.transform.position = player1.spawn.position;
        player2.transform.position = player2.spawn.position;
        ca.transform.position = player2.spawn.position;
        m_TotalSeconds = returnSeconds;

        key.GetComponent<CapsuleCollider2D>().enabled = true;
        key.ren.enabled = true;
        key.isKey1 = false;
        key.isKey2 = false;

        lifetimer += Time.deltaTime;

        Count = 2;

        lifetimer = 0f;
    }
}
