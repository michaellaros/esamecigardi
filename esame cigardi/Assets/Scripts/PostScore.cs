using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PostScore : MonoBehaviour
{
    public static PostScore Singleton;

    public string DreamloLink = "http://dreamlo.com/lb/fHjfJawM_UmbWvrVgIXTIQ79NktK8u6Uqy0XDglmnphg";
    // http://dreamlo.com/lb/fHjfJawM_UmbWvrVgIXTIQ79NktK8u6Uqy0XDglmnphg "my dreamlo"
    public string PlayerName;
    public int Score;
    public List<ScoreEntry> ScoreBoardEntries = new List<ScoreEntry>();

    public UnityEvent ScoreBoardUpdatedEvent;

    void Awake ()   
       {
        setPlayerScore();
        setPlayerName();
        PostNewScore(PlayerName, Score);

        if (Singleton == null)
        {
            DontDestroyOnLoad(gameObject);
            Singleton = this;
        }
        else if (Singleton != this)
        {
            Destroy (gameObject);
        }
            
      }

    private void OnEnable()
    {
        Singleton = this;
    }

    public void setPlayerName()
    {
        PlayerName = Menager.Instance.PlayerName;
    }

    public void setPlayerScore()
    {
        Score = Menager.Instance.Score;
    }

    public void PostNewScore(string playerName, int score)
    {      
        StartCoroutine(PostScoreEnumerator(playerName, score));
        PlayerName = playerName;
        Score = score;
    }

    IEnumerator PostScoreEnumerator(string playerName, int score)
    {
        string myUrl = DreamloLink + "/add/" + playerName + "/" + score.ToString();
        using (WWW loadedWebsite = new WWW(myUrl))
        {
            yield return loadedWebsite;
            if (loadedWebsite.text.Contains("OK"))
            {
                print("Caricamento Completato");
            }
            StartCoroutine(GetScoreBoardEnumerator());
        }
    }

    IEnumerator GetScoreBoardEnumerator()
    {
        //Creating the URL to get the ScoreBoard
        string myUrl = DreamloLink + "/quote";
        //Cleaning UP old Values in the list (I forgot to do this during the lesson, this is why it was not working)
        ScoreBoardEntries.Clear();

        using (WWW loadedWebsite = new WWW(myUrl))
        {
            yield return loadedWebsite;
            string pageContent = loadedWebsite.text;
            string[] pageContentLines = pageContent.Split('\n');

            for (int i = 0; i < pageContentLines.Length; i++)
            {
                if (!string.IsNullOrEmpty(pageContentLines[i]))
                {
                    string[] lineContent = pageContentLines[i].Split(',');

                    string myPlayerName = QuotedStringCleanup(lineContent[0]);
                    int myScore = int.Parse(QuotedStringCleanup(lineContent[1]));

                    ScoreBoardEntries.Add(new ScoreEntry(myPlayerName, myScore));
                }
            }   
        }
        yield return new WaitForFixedUpdate();
        ScoreBoardUpdatedEvent.Invoke();
    }

    string QuotedStringCleanup(string rawString)
    {
        string tempString = rawString.Substring(1, rawString.Length - 2);
        return tempString;
    }
}

public class ScoreEntry
{
    public string PlayerName;
    public int PlayerScore;

    public ScoreEntry(string playerName,int playerScore)
    {
        PlayerName = playerName;
        PlayerScore = playerScore;
    }
}
