using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string ScenesName;

    void Start()
    {
        
    }

    public void changeScene()
    {
        SceneManager.LoadScene(ScenesName);
    }
}
