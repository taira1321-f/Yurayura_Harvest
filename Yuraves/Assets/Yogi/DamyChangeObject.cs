using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamyChangeObject : MonoBehaviour
{

    public static int ObjectMode = 0;
    public int InitFlg = 0;
    public static int ObjectLifeSpan = 0;
    public static int ObjectReBornSpan = 0;
    public static int ObjectStepUpSpan = 0;
    PolygonCollider2D ColiderObject;
    SpriteRenderer MandoragoraMainSprite;
    Object MousePointor;
    public Sprite MandoragoraSprite01;
    public Sprite MandoragoraSprite02;
    public Sprite MandoragoraSprite03;
    public GameObject Parent;
    public GameObject Relation;
    public static Vector3 DamyPos;
    public float ChangeAlpha = 0.0f;
    float Red;
    float Blue;
    float Green;
    float Alpha;
    // Use this for initialization
    public void Start()
    {
        ObjectMode = 0;
        ObjectLifeSpan = 0;
        ObjectReBornSpan = 0;
        ObjectStepUpSpan = 0;
        ChangeAlpha = 0.0f;
        
        DamyPos = transform.position;
        transform.position = DamyPos;
        Red = GetComponent<SpriteRenderer>().color.r;
        Blue = GetComponent<SpriteRenderer>().color.b;
        Green = GetComponent<SpriteRenderer>().color.g;
        Alpha = GetComponent<SpriteRenderer>().color.a;
        MandoragoraMainSprite = gameObject.GetComponent<SpriteRenderer>();
        //マンドラゴラを消す
        GetComponent<SpriteRenderer>().color = new Color(Red, Green, Blue, ChangeAlpha);
        GetComponent<PolygonCollider2D>().enabled = false;
        Relation = transform.root.gameObject;
        Parent = GameObject.Find("Mousepointer");
    }

    // Update is called once per frame
    void Update()
    {
        //if (Calotte.ctype != Calotte.CalotteType.KEEP)
        //{
        if (ChangeObjectMode.DamyFlg==1)
        {
            Debug.Log("だみー");
            switch (ObjectMode)
            {
                case 0:
                    ObjectReBornSpan++;
                    if (ObjectReBornSpan == 60)
                    {
                        ObjectReBornSpan = 0;
                        if (Random.Range(0, 2) == 1)
                        {
                            MandoragoraMainSprite.sprite = MandoragoraSprite01;
                            GetComponent<PolygonCollider2D>().enabled = true;
                            GetComponent<SpriteRenderer>().color = new Color(Red, Green, Blue, Alpha);
                            ObjectMode = 1;
                            Debug.Log("でたー");
                        }
                    };
                    break;
                case 1:
                    ObjectStepUpSpan++;
                    if (ObjectStepUpSpan == 300)
                    {
                        //GetComponent<PolygonCollider2D>().enabled = false;
                        //GetComponent<SpriteRenderer>().color = new Color(Red, Green, Blue, ChangeAlpha);
                        ObjectMode = 2;
                        ObjectStepUpSpan = 0;
                        MandoragoraMainSprite.sprite = MandoragoraSprite02;
                        Debug.Log("かわったー");
                    }
                    break;

                case 2:
                    ObjectStepUpSpan++;
                    if (ObjectStepUpSpan == 300)
                    {
                        //GetComponent<PolygonCollider2D>().enabled = false;
                        //GetComponent<SpriteRenderer>().color = new Color(Red, Green, Blue, ChangeAlpha);
                        ObjectMode = 3;
                        MandoragoraMainSprite.sprite = MandoragoraSprite03;
                        ObjectStepUpSpan = 0;
                        Debug.Log("かわったー");
                    }
                    break;

                case 3:
                    ObjectLifeSpan++;
                    if (ObjectLifeSpan == 300)
                    {
                        GetComponent<PolygonCollider2D>().enabled = false;
                        GetComponent<SpriteRenderer>().color = new Color(Red, Green, Blue, ChangeAlpha);
                        ObjectLifeSpan = 0;
                        ObjectMode = 0;
                        Debug.Log("きえたー");
                    }
                    break;
            }
        }
        Relation = transform.root.gameObject;
        //  }


    }

}
