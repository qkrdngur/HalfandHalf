using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ElCountText : MonoBehaviour
{
    Elevator elevator;
    TextMeshPro Counts;
    public Transform Target;
    // Start is called before the first frame update
    void Start()
    {
        elevator = GameObject.Find("Elevator").GetComponent<Elevator>();
        Counts = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Target.position + new Vector3(-0.05f, 0, 0);


        //text에 숫자 표시
        if (elevator.Count == 0)
        {
            Counts.text = 0.ToString();
        }
        if (elevator.Count == 1)
        {
            Counts.text = 1.ToString();
        }
        if (elevator.Count == 2)
        {
            Counts.text = 2.ToString();
        }
        if(elevator.istext == true)
        {
            Counts.text = 0.ToString();
        }

    }
}
