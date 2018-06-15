using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingManager : MonoBehaviour
{
    //PlayerPlefsの各キー
    private const string Ranking1 = "RankingNumber1";//１位
    private const string Ranking2 = "RankingNumber2";// |
    private const string Ranking3 = "RankingNumber3";// |
    private const string Ranking4 = "RankingNumber4";// |
    private const string Ranking5 = "RankingNumber5";//５位
    //表示するUIのオブジェクト変数
    public GameObject DrawRanking1;
    public GameObject DrawRanking2;
    public GameObject DrawRanking3;
    public GameObject DrawRanking4;
    public GameObject DrawRanking5;
    //各順位のscoreを格納する配列
    private int[] Ranking;
    //今回のscore
    private int NewScore;
    private int RankingScore;
    //ランクインがあった場合の順位
    int Rankin;
    void Start()
    {
        NewScore = 3;
        //ここ外すとこ
        //NewScore = Director.Score;
        Ranking = new int[5];
        RankingInput();
        RankingSort(NewScore);
        for (int k = 0; k <= 4; k++)
        {
            //Debug.Log(Ranking[k]);
        }
        RankingSet();
    }

    void RankingInput()
    {
        for (int i = 0; i <= 4; i++)
        {
            switch (i)
            {
                case 0:
                    Ranking[i] = PlayerPrefs.GetInt(Ranking1, 0005);
                    break;
                case 1:
                    Ranking[i] = PlayerPrefs.GetInt(Ranking2, 0004);
                    break;
                case 2:
                    Ranking[i] = PlayerPrefs.GetInt(Ranking3, 0003);
                    break;
                case 3:
                    Ranking[i] = PlayerPrefs.GetInt(Ranking4, 0002);
                    break;
                case 4:
                    Ranking[i] = PlayerPrefs.GetInt(Ranking5, 0001);
                    break;
            }
        }
    }

    void RankingSort(int newscore)
    {
        int[] sort = new int[5];
        for (int i = 0; i <= 4; i++)
        {
            if (Ranking[i] < newscore)
            {
                sort[i] = newscore;
                for (int k = i; k <= 4; k++)
                {
                    if (k + 1 <= 4)
                    {
                        sort[k + 1] = Ranking[k];
                    }
                    i = 5;
                }
            }
            else
            {
                sort[i] = Ranking[i];
            }
        }
        for (int n = 0; n <= 4; n++)
        {
            Ranking[n] = sort[n];
        }
    }

    void RankingSet()
    {
        for (int i = 0; i <= 4; i++)
        {
            switch (i)
            {
                case 0:
                    PlayerPrefs.SetInt(Ranking1, Ranking[i]);
                    DrawRanking1.GetComponent<ScoreDraw>().Score = Ranking[i];
                    break;
                case 1:
                    PlayerPrefs.SetInt(Ranking2, Ranking[i]);
                    DrawRanking2.GetComponent<ScoreDraw>().Score = Ranking[i];
                    break;
                case 2:
                    PlayerPrefs.SetInt(Ranking3, Ranking[i]);
                    DrawRanking3.GetComponent<ScoreDraw>().Score = Ranking[i];
                    break;
                case 3:
                    PlayerPrefs.SetInt(Ranking4, Ranking[i]);
                    DrawRanking4.GetComponent<ScoreDraw>().Score = Ranking[i];
                    break;
                case 4:
                    PlayerPrefs.SetInt(Ranking5, Ranking[i]);
                    DrawRanking5.GetComponent<ScoreDraw>().Score = Ranking[i];
                    break;
            }
        }
    }

    void Update()
    {
    }
}
