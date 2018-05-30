using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yogi
{
    public class ChangeObjectMode : MonoBehaviour
    {
        
        public int ObjectMode = 0;
        int ObjectLifeSpan = 0;
        int ObjectReBornSpan = 0;
        static public int DamyFlg = 0;
        int OneceFlg = 0;
        bool Holdflg;
        Mandragora _Mand;
        int ObjectStepUpSpan = 0;
        PolygonCollider2D ColiderObject;
        SpriteRenderer MandoragoraMainSprite;
        Object MousePointor;
        public Sprite MandoragoraSprite01;
        public Sprite MandoragoraSprite02;
        public Sprite MandoragoraSprite03;
        public GameObject Parent;
        public GameObject Relation;
        float ChangeAlpha = 0.0f;
        float Red;
        float Blue;
        float Green;
        float Alpha;
        GameObject MandMane;
        // Use this for initialization
        void Start()
        {
            ObjectMode = 0;
            ObjectLifeSpan = 0;
            ObjectReBornSpan = 0;
            ObjectStepUpSpan = 0;
            ChangeAlpha = 0.0f;
            Red = GetComponent<SpriteRenderer>().color.r;
            Blue = GetComponent<SpriteRenderer>().color.b;
            Green = GetComponent<SpriteRenderer>().color.g;
            Alpha = GetComponent<SpriteRenderer>().color.a;
            MandoragoraMainSprite = gameObject.GetComponent<SpriteRenderer>();
            GetComponent<SpriteRenderer>().color = new Color(Red, Green, Blue, ChangeAlpha);
            GetComponent<BoxCollider2D>().enabled = false;
            _Mand = GetComponent<Mandragora>();
            Relation = transform.root.gameObject;
            MandMane = GameObject.FindGameObjectWithTag("Spawn");
        }

        // Update is called once per frame
        void Update(){
            KeyGet();
            if (Parent != Relation){
                if (this.transform.position.y < -6.0f) {
                    DamyFlg = 0;

                    MandMane = GameObject.FindGameObjectWithTag("Spawn");
                    MandMane.GetComponent<MandGeneretor>().MandGene(gameObject.transform.name);
                    Destroy(gameObject);
                }
                if (OneceFlg == 0){
                    switch (ObjectMode){
                        case 0:
                            ObjectReBornSpan++;
                            if (ObjectReBornSpan == 60){
                                ObjectReBornSpan = 0;
                                if (Random.Range(0, 2) == 1){
                                    MandoragoraMainSprite.sprite = MandoragoraSprite01;
                                    GetComponent<BoxCollider2D>().enabled = true;
                                    GetComponent<SpriteRenderer>().color = new Color(Red, Green, Blue, Alpha);
                                    ObjectMode = 1;
                                    
                                }
                            };
                            break;
                        case 1:
                            if (!Holdflg) ObjectStepUpSpan++;
                            if (ObjectStepUpSpan >= 300){
                                ObjectMode = 2;
                                ObjectStepUpSpan = 0;
                                MandoragoraMainSprite.sprite = MandoragoraSprite02;
                                
                            }
                            break;
                        case 2:
                            if (!Holdflg) ObjectStepUpSpan++;
                            if (ObjectStepUpSpan >= 300) {
                                ObjectMode = 3;
                                MandoragoraMainSprite.sprite = MandoragoraSprite03;
                                ObjectStepUpSpan = 0;
                                
                            }
                            break;
                        case 3:
                            if (!Holdflg) ObjectLifeSpan++;
                            if (ObjectLifeSpan == 300) {
                                GetComponent<BoxCollider2D>().enabled = false;
                                GetComponent<SpriteRenderer>().color = new Color(Red, Green, Blue, ChangeAlpha);
                                ObjectLifeSpan = 0;
                                ObjectMode = 0;
                            }
                            break;
                    }
                }

            }
            Relation = transform.root.gameObject;
        }

        //Holdflgの切り替え
        void KeyGet(){
            if (Input.GetMouseButton(0) && (_Mand.ctype != Mandragora.CalotteType.FLEE)) Holdflg = true;
            else Holdflg = false;
        }
    }
}