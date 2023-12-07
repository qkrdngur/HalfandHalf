using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    public GameObject[] pan; 
    public Transform[] tr;
    private bool isHelp = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isHelp == true)
        {
            pan[0].transform.position = Vector3.MoveTowards(pan[0].transform.position, tr[1].position, 15);
        }
        else if(isHelp == false)
        {
            pan[0].transform.position = Vector3.MoveTowards(pan[0].transform.position, tr[0].position, 15);
        }
    }

    public void InStart()
    {
        SceneManager.LoadSceneAsync("Menu");
    }

    public void Help()
    {
          isHelp = true;
    }

    public void X()
    {
        isHelp = false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ResetY()
    {
        PlayerPrefs.SetInt("ButtonManager", 0);
        isHelp = false;
    }
}
