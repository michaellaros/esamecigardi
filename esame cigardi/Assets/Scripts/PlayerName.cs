using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    public Text m_PlayerName;
    // Start is called before the first frame update
    void Start()
    {
        setPlayerName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setPlayerName()
    {
        m_PlayerName.text = Menager.Instance.PlayerName;
    }
}
