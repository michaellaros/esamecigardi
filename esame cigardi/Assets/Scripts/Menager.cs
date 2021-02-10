using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menager : MonoBehaviour
{
    public static Menager Instance;

    public string PlayerName;

    void Awake ()   
       {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy (gameObject);
        }
      }

    void Start()
    {
        PlayerName = PlayerPrefs.GetString("PlayerName");
    }

    void Update()
    {
        
    }
}
