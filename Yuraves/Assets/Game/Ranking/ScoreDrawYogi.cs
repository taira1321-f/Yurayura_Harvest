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
    public Sprite image0;
    public Sprite image1;
    public Sprite image2;
    public Sprite image3;
    public Sprite image4;
    public Sprite image5;
    public Sprite image6;
    public Sprite image7;
    public Sprite image8;
    public Sprite image9;

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
        SetImage(ThousandImage, Scorenum / 1000);
        S = Scorenum / 1000;
        Scorenum -= S * 1000;

        SetImage(HundredImage, Scorenum / 100);
        S = Scorenum / 100;
        //Debug.Log(S);
        Scorenum -= S * 100;

        SetImage(TenImage, Scorenum / 10);//7
        S = Scorenum / 10;
        Scorenum -= S * 10;

        SetImage(OneImage, Scorenum / 1);
        S = Scorenum / 1;
        Scorenum -= S * 1;
    }
    void SetImage(GameObject Image, int SubScore)
    {
        switch (SubScore)
        {
            case 0:
                Image.GetComponent<Image>().sprite = image0;
                break;
            case 1:
                Image.GetComponent<Image>().sprite = image1;
                break;
            case 2:
                Image.GetComponent<Image>().sprite = image2;
                break;
            case 3:
                Image.GetComponent<Image>().sprite = image3;
                break;
            case 4:
                Image.GetComponent<Image>().sprite = image4;
                break;
            case 5:
                Image.GetComponent<Image>().sprite = image5;
                break;
            case 6:
                Image.GetComponent<Image>().sprite = image6;
                break;
            case 7:
                Image.GetComponent<Image>().sprite = image7;
                break;
            case 8:
                Image.GetComponent<Image>().sprite = image8;
                break;
            case 9:
                Image.GetComponent<Image>().sprite = image9;
                break;
        }
    }
}

