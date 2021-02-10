using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class GetScore : MonoBehaviour
{
    public UnityEvent action;
    private string TriggerTag;
    private int ScoreP;
    private int Point;
    public Text ScoreTx;
    private int PointTosse = 10;
    private int PointManiSporche = 15;
    private int PointFebbre = 0;


    // Start is called before the first frame update
    void Start()
    {
        ScoreP = 0;
        ScoreTx.text = "-" + ScoreP + "-";
        Point = PointTosse;
        TriggerTag = "Tosse";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(TriggerTag))
        {
            if (action != null)action.Invoke();  
            GetScorePoint(); 
        }
        
    }

    public void ChangeWeapon(string Enemy)
    {
        TriggerTag = Enemy;
        if (Enemy == "Tosse")
        {
            Point = PointTosse;
        }
        else if (Enemy == "ManiSporche")
        {
            Point = PointManiSporche;
        }
        else if (Enemy == "Febbre")
        {
            Point = PointFebbre;
        }
    }

    private void GetScorePoint()
    {
        ScoreP = ScoreP + Point;
        ScoreTx.text = "-" + ScoreP + "-";
    }
}
