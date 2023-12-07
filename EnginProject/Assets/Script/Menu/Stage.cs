using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stage : MonoBehaviour
{
    Intro intro;
    public Color cr;

    public GameObject[] Stages;
    public GameObject[] images;

    public GameObject Menu;
    public GameObject stage1;
    public GameObject stage2;
    public GameObject stage3;

    public int levelRequirement;
    public GameObject sprite;
    public string nextSceneName;

    public bool isEle = false;
    // Start is called before the first frame update


    private void Awake()
    {
        intro = GameObject.FindObjectOfType<Intro>();
        
    }

    void Start()
    {
        PlayerPrefs.SetInt("ButtonManager", 8);
        Debug.Log("osdxozp");
        for (int stageindex = 0; stageindex < 9; ++stageindex)
        {
            if (PlayerPrefs.GetInt("ButtonManager") == stageindex)
            {
                Debug.Log(stageindex);
                Stages[stageindex].gameObject.GetComponent<Button>().interactable = true;
                for(int i = 0; i < stageindex; i++)
                        {
                            Stages[i].gameObject.GetComponent<Button>().interactable = true;
                        }

                for (int a = 0; a <= stageindex; a++)
                {

                    if (a == 0)
                    {
                        images[0].gameObject.GetComponent<Image>().color = cr;
                    }
                    if (a == 1)
                    {
                        images[1].gameObject.GetComponent<Image>().color = cr;
                    }
                    if (a == 3)
                    {
                        images[2].gameObject.GetComponent<Image>().color = cr;
                    }
                    if (a == 4)
                    {
                        images[3].gameObject.GetComponent<Image>().color = cr;
                    }
                    if (a == 5)
                    {
                        images[4].gameObject.GetComponent<Image>().color = cr;
                    }
                    if (a == 6)
                    {
                        images[5].gameObject.GetComponent<Image>().color = cr;
                    }
                }
            }
           
        }
    }
    void Update()
    {
        Debug.Log(PlayerPrefs.GetInt("ButtonManager"));
        //PlayerPrefs.SetInt("ButtonManager", 0);
    }

    public void Stage1()
    {
        Menu.SetActive(false);
        stage1.SetActive(true);
    }
    public void Stage2()
    {
        Menu.SetActive(false);
        stage2.SetActive(true);
    }
    public void Stage3()
    {
        Menu.SetActive(false);
        stage3.SetActive(true);
    }

    public void Back()
    {
        Menu.SetActive(true);

        stage1.SetActive(false);
        stage2.SetActive(false);
        stage3.SetActive(false);
    }

    //public void LoadButton()
    //{
    //    StartCoroutine(Play1());
    //}

    //IEnumerator Play1()
    //{
    //    AsyncOperation async = SceneManager.LoadSceneAsync(nextSceneName);
    //    while (!async.isDone)
    //    {
    //        Count=9;
    //        isEle = true;
    //    yield return null;
    //    }
    //}

    public void Play1(string scene)
    {
        SceneManager.LoadSceneAsync(scene);
    }


}
