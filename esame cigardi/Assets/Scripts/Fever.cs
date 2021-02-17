using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fever : MonoBehaviour
{
    public float temperature;

    private void Awake() 
    {
        temperature = Random.Range(35.5f , 38.5f);
    }
    // Start is called before the first frame update
    void Start()
    {
        if(temperature >= 37.1f)
        {
            transform.gameObject.tag = "Febbre";
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
