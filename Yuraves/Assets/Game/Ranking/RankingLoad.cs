
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RankingLoad : MonoBehaviour
{


    [SerializeField]
    public int Score1;
    public int Score2;
    public int Score3;
    public int Score4;
    public int Score5;
    public int Score;

    void Start()
    {
        Score1 = PlayerPrefs.GetInt("RankingNumber1", 1234);
        Score2 = PlayerPrefs.GetInt("RankingNumber2", 1234);
        Score3 = PlayerPrefs.GetInt("RankingNumber3", 1234);
        Score4 = PlayerPrefs.GetInt("RankingNumber4", 1234);
        Score5 = PlayerPrefs.GetInt("RankingNumber5", 1234);

        Debug.Log("Score1="+Score1);
       
    }

    void Update()
    {
    }

    public int ReturnScore(int myNumber)
    {
        switch (myNumber)
        {
            case 1:
                Score = Score1;
                break;
            case 2:
                Score = Score2;
                break;
            case 3:
                Score = Score3;
                break;
            case 4:
                Score = Score4;
                break;
            case 5:
                Score = Score5;
                break;
        }
        return Score;
    }
}