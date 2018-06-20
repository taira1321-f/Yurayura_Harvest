using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDraw : MonoBehaviour
{
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

    void Update()
    {
        if (!CountEndFlg)
        {
            LoopCount += 10;

            if (LoopCount <= Score)
            {
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

                if (LoopCount == Score)
                {
                    CountEndFlg = true;
                }
            }
        }
    }
    void SetImage(GameObject Image, int SubScore){
        Image.GetComponent<Image>().sprite = S_Image[SubScore];
    }
}

