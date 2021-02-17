using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterime : MonoBehaviour
{
    public float timeDuration = 0.1f;
    private float timer;
    private bool Enable;
    void OnEnable()
    {
        Enable = true;
        timer = timeDuration;
    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Enable)
        {
            timer = timer - Time.deltaTime;
            if(timer <= 0)
            {
                Enable = false;
                gameObject.SetActive(false);
            }

        }
    }
}
