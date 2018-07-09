using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

<<<<<<< HEAD
public class InoutScoreDraw1 : MonoBehaviour
{

=======
public class InoutScoreDraw1 : MonoBehaviour{
>>>>>>> 3f050ed7a6488efa38676b220683cf09fc7f5233
    public int Score = 0;
    private int Scorenum;

    public GameObject OneImage;
    public GameObject TenImage;
    public GameObject HundredImage;
    public GameObject ThousandImage;
    public Sprite[] S_Image;
    private int LoopCount = 0;
    private bool CountEndFlg = false;

<<<<<<< HEAD
    void Start()
    {
    }

    void Update()
    {
        if (!CountEndFlg)
        {
            Score = PlayerPrefs.GetInt("RankingNumber1", 0);

            if (LoopCount <= Score)
            {
=======
    void Update(){
        if (!CountEndFlg){
            Score = PlayerPrefs.GetInt("RankingNumber1", 0);
            LoopCount += 30;

            if (LoopCount <= Score){
>>>>>>> 3f050ed7a6488efa38676b220683cf09fc7f5233
                int S;
                Scorenum = LoopCount;
                SetImage(ThousandImage, Scorenum / 1000 % 10);
                S = Scorenum / 1000;
                Scorenum -= S * 1000;

                SetImage(HundredImage, Scorenum / 100 % 10);
                S = Scorenum / 100;
                Scorenum -= S * 100;

                SetImage(TenImage, Scorenum / 10 % 10);
                S = Scorenum / 10;
                Scorenum -= S * 10;

                SetImage(OneImage, Scorenum % 10);
                S = Scorenum / 1;
                Scorenum -= S * 1;

<<<<<<< HEAD
                if (LoopCount == Score)
                {
                    CountEndFlg = true;
                }
            }
            LoopCount += 10;
        }
    }
    void SetImage(GameObject TargetObject, int SubScore)
    {
=======
            }else if (LoopCount >= Score){
                AdjustLoopCount(LoopCount - Score);
            }
        }
    }

    void AdjustLoopCount(int z){
        
        LoopCount -= z;

        int S;
        Scorenum = LoopCount;
        SetImage(ThousandImage, Scorenum / 1000 % 10);
        S = Scorenum / 1000;
        Scorenum -= S * 1000;

        SetImage(HundredImage, Scorenum / 100 % 10);
        S = Scorenum / 100;
        Scorenum -= S * 100;

        SetImage(TenImage, Scorenum / 10 % 10);
        S = Scorenum / 10;
        Scorenum -= S * 10;

        SetImage(OneImage, Scorenum % 10);
        S = Scorenum / 1;
        Scorenum -= S * 1;

        CountEndFlg = true;

    }
    void SetImage(GameObject TargetObject, int SubScore){
>>>>>>> 3f050ed7a6488efa38676b220683cf09fc7f5233
        TargetObject.GetComponent<Image>().sprite = S_Image[SubScore];
    }
}
