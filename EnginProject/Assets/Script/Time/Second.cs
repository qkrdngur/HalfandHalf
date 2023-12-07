using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Second : MonoBehaviour
{
    Clear cl;
    Coin coin;
    Player1move player1;
    Player2move player2;

    public GameObject Player1;
    public GameObject Player2;

    float saveSeconds;
    public string timer;
    public string m_Timer = @"00.00";
    public float returnSeconds;
    public float m_TotalSeconds; // ī��Ʈ �ٿ� ��ü ��(5�� X 60��), �ν���Ʈ â���� �����ؾ� ��. 
    public Text m_Text;

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Player1").GetComponent<Player1move>();
        player2 = GameObject.Find("Player2").GetComponent<Player2move>();
        cl = GameObject.Find("ClearDoor").GetComponent<Clear>();
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
                m_Text.text = m_Timer;
        }

            if(m_Timer == @"00.00")
        {
            player1.ren.enabled = true;
            Player1.GetComponent<PolygonCollider2D>().enabled = true;
            player2.ren.enabled = true;
            Player2.GetComponent<PolygonCollider2D>().enabled = true;

            player1.transform.position = player1.spawn.position;
            player2.transform.position = player2.spawn.position;
            m_TotalSeconds = returnSeconds;

            player2.isCoin = true;

            if(player2.iscol == true)
            {
                SceneManager.LoadScene("4");
            }

            if (player2.iscolSp == true)
            {
                SceneManager.LoadScene("New Scene");
                player2.iscolSp = false;
            }
        }
        
    }
    

    public string CountdownTimer(bool IsUpdate = true)
    {
        if (IsUpdate)
        {
            saveSeconds = m_TotalSeconds;
            if (cl.isP1 == true || cl.isP2 == true)
            {
            m_TotalSeconds -= Time.deltaTime;

            }
            if (cl.isP1 == false && cl.isP2 == false)
            {
                m_TotalSeconds = saveSeconds;
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

    public void ReStart()
    {
        SceneManager.LoadScene("4");

    }

    public void ReStart2()
    {
        SceneManager.LoadScene("5");
    }
}
