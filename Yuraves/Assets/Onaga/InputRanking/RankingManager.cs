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
    //各順位のscoreを格納する配列
    private int[] Ranking = new int[5];
    //今回のscore
    private int NewScore = 0;
    //ランクインがあった場合の順位
    int Rankin;
    void Start()
    {
        NewScore = Director.Score;
        RankingInput();
        RankingSort(NewScore);
        RankingSet();
        Initialize();
    }

    //Rankingの保存データを取得
    void RankingInput()
    {
        for (int i = 0; i <= 4; i++)
        {

            switch (i)
            {
                case 0:
                    Ranking[i] = PlayerPrefs.GetInt(Ranking1, 0);
                    break;
                case 1:
                    Ranking[i] = PlayerPrefs.GetInt(Ranking2, 0);
                    break;
                case 2:
                    Ranking[i] = PlayerPrefs.GetInt(Ranking3, 0);
                    break;
                case 3:
                    Ranking[i] = PlayerPrefs.GetInt(Ranking4, 0);
                    break;
                case 4:
                    Ranking[i] = PlayerPrefs.GetInt(Ranking5, 0);
                    break;
            }
        }
    }

    //NewScoreをRankingへ入れてソート
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
        for (int i = 0; i <= 4; i++)
        {
            
        }
    }

    //新たなRankinaデータを保存
    void RankingSet()
    {
        for (int i = 0; i <= 4; i++)
        {
            switch (i)
            {
                case 0:
                    PlayerPrefs.SetInt(Ranking1, Ranking[i]);
                    Debug.Log(PlayerPrefs.GetInt(Ranking1, 0));
                    break;
                case 1:
                    PlayerPrefs.SetInt(Ranking2, Ranking[i]);
                    Debug.Log(PlayerPrefs.GetInt(Ranking2, 0));
                    break;
                case 2:
                    PlayerPrefs.SetInt(Ranking3, Ranking[i]);
                    Debug.Log(PlayerPrefs.GetInt(Ranking3, 0));
                    break;
                case 3:
                    PlayerPrefs.SetInt(Ranking4, Ranking[i]);
                    Debug.Log(PlayerPrefs.GetInt(Ranking4, 0));
                    break;
                case 4:
                    PlayerPrefs.SetInt(Ranking5, Ranking[i]);
                    Debug.Log(PlayerPrefs.GetInt(Ranking5, 0));
                    break;
            }
            PlayerPrefs.Save(); 
        }
    }

    void Initialize()
    {
        for (int i = 0; i <= 4; i++)
        {
            Ranking[i] = 0;
        }
        NewScore = 0;
    }
}