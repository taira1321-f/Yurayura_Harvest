using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDrawYogi : MonoBehaviour
{
    private int Score;
    private int Scorenum;

    GameObject RankingLoadObject;
    RankingLoad RankingLoadScript;

    public GameObject OneImage;
    public GameObject TenImage;
    public GameObject HundredImage;
    public GameObject ThousandImage;
    public int myNumber;
    public Sprite[] S_Image;

    void Start()
    {
        RankingLoadObject = GameObject.Find("RankingLoadObject");
        RankingLoadScript = RankingLoadObject.GetComponent<RankingLoad>();

        
    }

    void Update()
    {
        Score = RankingLoadScript.ReturnScore(myNumber);
        int S;
        Scorenum = Score;
        SetImage(ThousandImage, ((Scorenum / 1000) % 10));
        S = Scorenum / 1000;
        Scorenum -= S * 1000;

        SetImage(HundredImage, ((Scorenum / 100) % 10));
        S = Scorenum / 100;
        Scorenum -= S * 100;

        SetImage(TenImage, ((Scorenum / 10) % 10));
        S = Scorenum / 10;
        Scorenum -= S * 10;

        SetImage(OneImage, (Scorenum % 10));
        S = Scorenum / 1;
        Scorenum -= S * 1;
    }
    void SetImage(GameObject Image, int SubScore){
        Image.GetComponent<Image>().sprite = S_Image[SubScore];
    }
}

