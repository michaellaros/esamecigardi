using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class saveName : MonoBehaviour
{
    public GameObject inputField;
    public Text OutputTx;
    // Start is called before the first frame update
    void Start()
    {
        OutputTx.text = "Please insert your name";
        if(PlayerPrefs.GetInt("Named") == 1)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SavePlayerName()
    {
        if (inputField.GetComponent<Text>().text.ToString() != null)
        {
            PlayerPrefs.SetString("PlayerName", inputField.GetComponent<Text>().text);
            PlayerPrefs.SetInt("Named", 1);
            OutputTx.text = "Name saved";
        }
        else
        {
            OutputTx.text = "Please insert your name";
        }
        
    }
}
