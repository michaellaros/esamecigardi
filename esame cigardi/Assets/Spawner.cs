using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Vector3 positiontospawn = new Vector3(31.9f, 8.4f, 54.84f);
    public float tempodispawn = 0f;
    public float startingTime = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        tempodispawn = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        tempodispawn -= 1 * Time.deltaTime;

        if (tempodispawn<=0)
        {
            Instantiate(objectToSpawn, positiontospawn, Quaternion.identity);
            tempodispawn = 5f;
        }
    }
}
