using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yogi
{
    public class ChangeObjectMode : MonoBehaviour
    {
        
        int ObjectMode = 0;
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
        bool OnFlg_1 = false;
        bool OnFlg_2 = false;
        bool OnFlg_3 = false;
        bool OnFlg_4 = false;
        public GameObject MandPrefab;
        Vector3[] GPos = {
                         new Vector3( -2.0f, -3.5f, 0f),
                         new Vector3(-0.75f, -3.5f, 0f),
                         new Vector3( 0.75f, -3.5f, 0f),
                         new Vector3(  2.0f, -3.5f, 0f),
                     };
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
            Parent = GameObject.Find("Mousepointer");
        }

        // Update is called once per frame
        void Update(){
            KeyGet();
            if (Parent != Relation){
                if (this.transform.position.y < -6.0f) {
                    DamyFlg = 0;
                    Destroy(this.gameObject);
                    MandGene(gameObject.transform.name);
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
                                    Debug.Log("でたー");
                                }
                            };
                            break;
                        case 1:
                            if (!Holdflg) ObjectStepUpSpan++;
                            if (ObjectStepUpSpan >= 300){
                                ObjectMode = 2;
                                ObjectStepUpSpan = 0;
                                MandoragoraMainSprite.sprite = MandoragoraSprite02;
                                Debug.Log("かわったー");
                            }
                            break;
                        case 2:
                            if (!Holdflg) ObjectStepUpSpan++;
                            if (ObjectStepUpSpan >= 300) {
                                ObjectMode = 3;
                                MandoragoraMainSprite.sprite = MandoragoraSprite03;
                                ObjectStepUpSpan = 0;
                                Debug.Log("かわったー");
                            }
                            break;
                        case 3:
                            ObjectLifeSpan++;
                            if (ObjectLifeSpan == 300) {
                                GetComponent<BoxCollider2D>().enabled = false;
                                GetComponent<SpriteRenderer>().color = new Color(Red, Green, Blue, ChangeAlpha);
                                ObjectLifeSpan = 0;
                                ObjectMode = 0;
                                Debug.Log("きえたー");
                            }
                            break;
                    }
                }

            }
            Relation = transform.root.gameObject;
        }

        void KeyGet() {
            if (Input.GetMouseButton(0) &&
                (_Mand.ctype != Mandragora.CalotteType.FLEE)) Holdflg = true;
            else Holdflg = false;
        }
        void MandGene(string str){            
            //引数の名前は？
            //その名前があればtrue
            switch (str){
                case "Mand_1":
                    OnFlg_1 = true;
                    break;
                case "Mand_2":
                    OnFlg_2 = true;
                    break;
                case "Mand_3":
                    OnFlg_3 = true;
                    break;
                case "Mand_4":
                    OnFlg_4 = true;
                    break;
            }
            //trueを生成
            if (OnFlg_1){
                GameObject go = Instantiate(MandPrefab);
                go.transform.position = new Vector3(GPos[0].x, GPos[0].y, GPos[0].z);
                go.name = "Mand_1";
                if (GameObject.Find("Mand_1")) OnFlg_1 = false;
            }
            if (OnFlg_2){
                GameObject go = Instantiate(MandPrefab);
                go.transform.position = new Vector3(GPos[1].x, GPos[1].y, GPos[1].z);
                go.name = "Mand_2";
                if (GameObject.Find("Mand_2")) OnFlg_2 = false;
            }
            if (OnFlg_3){
                GameObject go = Instantiate(MandPrefab);
                go.transform.position = new Vector3(GPos[2].x, GPos[2].y, GPos[2].z);
                go.name = "Mand_3";
                if (GameObject.Find("Mand_3")) OnFlg_3 = false;
            }
            if (OnFlg_4){
                GameObject go = Instantiate(MandPrefab);
                go.transform.position = new Vector3(GPos[3].x, GPos[3].y, GPos[3].z);
                go.name = "Mand_4";
                if (GameObject.Find("Mand_4")) OnFlg_4 = false;
            }
        }
    }
}