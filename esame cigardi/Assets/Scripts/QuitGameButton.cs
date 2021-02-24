using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitGameButton : MonoBehaviour
{
    private Button quitGameButton;
    // Start is called before the first frame update
    void Start()
    {
        quitGameButton = GetComponent<Button>();
        quitGameButton.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    private void QuitGame()
    {
        Application.Quit();
    }
}
