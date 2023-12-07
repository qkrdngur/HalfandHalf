using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WElevatorText : MonoBehaviour
{

    WidthElevator elevator;
    TextMeshPro Counts;
    public Transform Target;

    // Start is called before the first frame update
    void Start()
    {
        elevator = GameObject.Find("Elevator").GetComponent<WidthElevator>();
        Counts = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Target.position + new Vector3(-0.05f, 0, 0);

        if (elevator.Count == 0)
        {
            Counts.text = 0.ToString();
        }
        if (elevator.Count == 1)
        {
            Counts.text = 1.ToString();
        }
    }
}
