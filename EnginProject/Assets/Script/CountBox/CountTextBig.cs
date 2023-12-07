using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountTextBig : MonoBehaviour
{
    public int BigCount;
    CountBox countBox;
    TextMeshPro Counts;
    public Transform Target;
    // Start is called before the first frame update
    void Start()
    {
        countBox = GameObject.Find("BigCountBox").GetComponent<CountBox>();
        Counts = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.position = Target.position;

        //text에 숫자 표시
        if(countBox.Count == 0)
        {
            Counts.text = 0.ToString();
        }
        if (countBox.Count == 1)
        {
            Counts.text = 1.ToString();
        }
        if (countBox.Count == 2)
        {
            Counts.text = 2.ToString();
        }
    }
}
