using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    float timer  = 0;
    public float limit = 1.2f;

    public GameObject[] prefabs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > limit)
        {
            int i = Random.Range(0, prefabs.Length);

            Instantiate(prefabs[i], transform.position, Quaternion.identity);
            timer = 0;
        }
    }
}
