
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RankingLoad : MonoBehaviour
{

    //　読み込んだテキストを出力するUIテキスト
    int Score1;
    int Score2;
    int Score3;
    int Score4;
    int Score5;
    
    //　読む込むテキストが書き込まれている.txtファイル
    [SerializeField]
    private TextAsset textAsset;
    //　テキストファイルから読み込んだデータ
    private string loadText1;
    //　改行で分割して配列に入れる
    private string[] splitText1;

    void Start(){
        loadText1 = textAsset.text;
        splitText1 = loadText1.Split(char.Parse("\n"));
        Score1 = int.Parse(splitText1[0]);
        Score2 = int.Parse(splitText1[1]);
        Score3 = int.Parse(splitText1[2]);
        Score4 = int.Parse(splitText1[3]);
        Score5 = int.Parse(splitText1[4]);
    }

    public int ReturnScore(int myNumber)
    {
        int Score = 0;
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