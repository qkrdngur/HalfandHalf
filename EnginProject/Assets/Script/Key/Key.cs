using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
     public SpriteRenderer ren;
    public GameObject obj;
    public bool isKey1 = false;
    public bool isKey2 = false;
    public float Count = 37;
    // Start is called before the first frame update
    void Start()
    {
        ren = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Player1�� Ű�� ������ ������
        if(collision.gameObject.CompareTag("Player1"))
        {
            ren.enabled = false;
            GetComponent<CapsuleCollider2D>().enabled = false;
            isKey1 = true;
        }

        //Player2�� Ű�� ������ ������
        if(collision.gameObject.CompareTag("Player2"))
        {
            ren.enabled = false;
            GetComponent<CapsuleCollider2D>().enabled = false;
            isKey2 = true;
        }
        
    }
    
}
