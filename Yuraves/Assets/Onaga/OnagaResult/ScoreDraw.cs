using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

<<<<<<< HEAD
public class ScoreDraw : MonoBehaviour
{
=======
public class ScoreDraw : MonoBehaviour{
>>>>>>> 3f050ed7a6488efa38676b220683cf09fc7f5233
    public int Score;
    private int Scorenum;

    public GameObject OneImage;
    public GameObject TenImage;
    public GameObject HundredImage;
    public GameObject ThousandImage;
    public Sprite[] S_Image;
    private int LoopCount = 0;
    private bool CountEndFlg = false;
    void Start(){
        Score = Director.Score;
    }

<<<<<<< HEAD
    void Update()
    {
        if (!CountEndFlg)
        {
            LoopCount += 10;

            if (LoopCount <= Score)
            {
=======
    void Update(){
        if (!CountEndFlg){
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
<<<<<<< HEAD
                Scorenum -= S * 1;

                if (LoopCount == Score)
                {
                    CountEndFlg = true;
                }
            }
        }
    }
=======
                Scorenum -= S * 1; 
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

>>>>>>> 3f050ed7a6488efa38676b220683cf09fc7f5233
    void SetImage(GameObject Image, int SubScore){
        Image.GetComponent<Image>().sprite = S_Image[SubScore];
    }
}

