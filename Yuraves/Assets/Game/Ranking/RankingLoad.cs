
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
        Score1 = PlayerPrefs.GetInt("RankingNumber1", 0);
        Score2 = PlayerPrefs.GetInt("RankingNumber2", 0);
        Score3 = PlayerPrefs.GetInt("RankingNumber3", 0);
        Score4 = PlayerPrefs.GetInt("RankingNumber4", 0);
        Score5 = PlayerPrefs.GetInt("RankingNumber5", 0);
        QualitySettings.vSyncCount = 0;     //VSyncをOFFにする
        Application.targetFrameRate = 60;   //ターゲットフレームレート       
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