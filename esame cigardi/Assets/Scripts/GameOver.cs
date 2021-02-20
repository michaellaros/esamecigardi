using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public UnityEvent ev_GameOver;
    public Text HpTx;
    private int hp = 3;

    // Start is called before the first frame update
    void Start()
    {
        hp = 3;
        HpTx.text = "Life " + hp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Febbre"))
        {
            Destroy(other.gameObject);
            hp = hp - 1;
            if(hp == 1)
            {
                if (ev_GameOver != null)ev_GameOver.Invoke();
            }
            HpTx.text = "Life " + hp;
        }
        else if(other.gameObject.CompareTag("Passante"))
        {
            Destroy(other.gameObject);
        }
    }
}
