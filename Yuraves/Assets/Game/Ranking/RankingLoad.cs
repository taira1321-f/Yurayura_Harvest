
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RankingLoad : MonoBehaviour
{

    //　読み込んだテキストを出力するUIテキスト
    [SerializeField]
    public int Score1;
    public int Score2;
    public int Score3;
    public int Score4;
    public int Score5;
    public int Score;

    
    //　読む込むテキストが書き込まれている.txtファイル
    [SerializeField]
    private TextAsset textAsset;
    //　テキストファイルから読み込んだデータ
    private string loadText1;
    //　Resourcesフォルダから直接テキストを読み込む
    private string loadText2;
    //　改行で分割して配列に入れる
    private string[] splitText1;
    //　改行で分割して配列に入れる
    private string[] splitText2;


    void Start()
    {
        loadText1 = textAsset.text;
        splitText1 = loadText1.Split(char.Parse("\n"));

        Score1 = int.Parse(splitText1[0]);
        Score2 = int.Parse(splitText1[1]);
        Score3 = int.Parse(splitText1[2]);
        Score4 = int.Parse(splitText1[3]);
        Score5 = int.Parse(splitText1[4]);
        //Score1 = 1234;
        //Score2 = 4568;
        //Score3 = 1245;
        //Score4 = 8764;
        //Score5 = 9875;
        //dataText.text = "マウスの左クリックで通常のテキストファイルの読み込み、右クリックでResourcesフォルダ内のテキストファイル読み込みしたテキストが表示されます。";
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