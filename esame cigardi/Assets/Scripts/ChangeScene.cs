using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string ScenesName;

    void Start()
    {
        if(PostScore.Singleton != null)
        {
            PostScore.Singleton.ScoreBoardUpdatedEvent.AddListener(changeScene);
        }
    }

    public void changeScene()
    {
        SceneManager.LoadScene(ScenesName);
    }
}
