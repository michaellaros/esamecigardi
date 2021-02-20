using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public UnityEvent ev_GameOver;
    public int hp = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Febbre"))
        {
            Destroy(other);
            hp = hp - 1;
            if(hp == 1)
            {
                if (ev_GameOver != null)ev_GameOver.Invoke();
            }
        }
        else if(other.gameObject.CompareTag("Passante"))
        {
            Destroy(other);
        }
    }
}
