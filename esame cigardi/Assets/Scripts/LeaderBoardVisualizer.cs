using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardVisualizer : MonoBehaviour
{
    public RectTransform ContentBoxTransform;
    public RectTransform ScoreEntryPrefab;

    public List<GameObject> currentlyInstantiatedTexts = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreVisualization();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateScoreVisualization()
    {
        int numberOfPlayerInBoard = PostScore.Singleton.ScoreBoardEntries.Count;

        ContentBoxTransform.sizeDelta = new Vector2(ContentBoxTransform.sizeDelta.x, ScoreEntryPrefab.sizeDelta.y * numberOfPlayerInBoard);

        for (int i = 0; i < currentlyInstantiatedTexts.Count; i++)
        {
            Destroy(currentlyInstantiatedTexts[i]);
        }
        currentlyInstantiatedTexts.Clear();

        for (int i = 0; i < PostScore.Singleton.ScoreBoardEntries.Count; i++)
        {
            RectTransform tempText = Instantiate(ScoreEntryPrefab, ContentBoxTransform);
            tempText.anchoredPosition = new Vector2(0, -(i * ScoreEntryPrefab.sizeDelta.y));
            tempText.GetComponent<Text>().text = PostScore.Singleton.ScoreBoardEntries[i].PlayerName + " / " + PostScore.Singleton.ScoreBoardEntries[i].PlayerScore.ToString();
            currentlyInstantiatedTexts.Add(tempText.gameObject);
        }
    }
}
