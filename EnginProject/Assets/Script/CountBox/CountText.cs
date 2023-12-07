using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountText : MonoBehaviour
{
    CountBox countBox;
    CountBox countBox2;
    CountBox countBox3;
    CountBox BigcountBox;
    TextMeshPro Counts1;
    TextMeshPro Counts2;
    TextMeshPro Counts3;
    TextMeshPro Counts4;
    public Transform Target;
    // Start is called before the first frame update
    void Start()
    {
        countBox = GameObject.Find("CountBox").GetComponent<CountBox>();
        countBox2 = GameObject.Find("CountBox (1)").GetComponent<CountBox>();
        countBox3 = GameObject.Find("CountBox (2)").GetComponent<CountBox>();
        BigcountBox = GameObject.Find("BigCountBox").GetComponent<CountBox>();
        Counts1 = GameObject.Find("Count1").GetComponent<TextMeshPro>();
        Counts2 = GameObject.Find("Count2").GetComponent<TextMeshPro>();
        Counts3 = GameObject.Find("Count3").GetComponent<TextMeshPro>();
        Counts4 = GameObject.Find("BigCount").GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.position = Target.position;


        if (BigcountBox.Count == 0)
        {
            Counts4.text = 0.ToString();
        }
        if (BigcountBox.Count == 1)
        {
            Counts4.text = 1.ToString();
        }
        if (BigcountBox.Count == 2)
        {
            Counts4.text = 2.ToString();
        }

        //text에 숫자 표시
        if (countBox.Count == 0)
        {
            Counts1.text = 0.ToString();
        }
        if (countBox.Count == 1)
        {
            Counts1.text = 1.ToString();
        }
        if (countBox.Count == 2)
        {
            Counts1.text = 2.ToString();
        }



        if (countBox2.Count == 0)
        {
            Counts2.text = 0.ToString();
        }
        if (countBox2.Count == 1)
        {
            Counts2.text = 1.ToString();
        }
        if (countBox2.Count == 2)
        {
            Counts2.text = 2.ToString();
        }

        if (countBox3.Count == 0)
        {
            Counts3.text = 0.ToString();
        }
        if (countBox3.Count == 1)
        {
            Counts3.text = 1.ToString();
        }
        if (countBox3.Count == 2)
        {
            Counts3.text = 2.ToString();
        }
    }
}
