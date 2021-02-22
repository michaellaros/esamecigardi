using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menager : MonoBehaviour
{
    public static Menager Instance;

    public string PlayerName;
    public int Score;

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
        PlayerName = PlayerPrefs.GetString("PlayerName");
      }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
