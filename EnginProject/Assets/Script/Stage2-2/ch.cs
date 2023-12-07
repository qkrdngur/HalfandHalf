using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ch : MonoBehaviour
{
    private void Start()
    {
        SceneManager.LoadScene("5");
    }
    public void ReStart()
    {
        SceneManager.LoadScene("4");
    }
}
