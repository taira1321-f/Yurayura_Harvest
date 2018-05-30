using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
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
=======
namespace COy
{
    public class ChangeObjectMode : MonoBehaviour
    {

        int ObjectMode = 0;
        int ObjectLifeSpan = 0;
        GameObject go;
        int ObjectReBornSpan = 0;
        Rigidbody2D ObjectRigit;
        public GameObject MandragoraPrefub;
        static public int DamyFlg = 0;
        int OneceFlg = 0;
        int ObjectStepUpSpan = 0;
        PolygonCollider2D ColiderObject;
        SpriteRenderer MandoragoraMainSprite;
 //       DamyChangeObject DamyStartScript;
        Calotte CalotteScript;
>>>>>>> Yogi_SceneM
        Object MousePointor;
        public Sprite MandoragoraSprite01;
        public Sprite MandoragoraSprite02;
        public Sprite MandoragoraSprite03;
        public GameObject Parent;
        public GameObject Relation;
<<<<<<< HEAD
=======
        GameObject Damy;
>>>>>>> Yogi_SceneM
        float ChangeAlpha = 0.0f;
        float Red;
        float Blue;
        float Green;
        float Alpha;
<<<<<<< HEAD
        GameObject MandMane;
=======
>>>>>>> Yogi_SceneM
        // Use this for initialization
        void Start()
        {
            ObjectMode = 0;
            ObjectLifeSpan = 0;
            ObjectReBornSpan = 0;
            ObjectStepUpSpan = 0;
            ChangeAlpha = 0.0f;
<<<<<<< HEAD
=======
            ObjectRigit = GetComponent<Rigidbody2D>();
>>>>>>> Yogi_SceneM
            Red = GetComponent<SpriteRenderer>().color.r;
            Blue = GetComponent<SpriteRenderer>().color.b;
            Green = GetComponent<SpriteRenderer>().color.g;
            Alpha = GetComponent<SpriteRenderer>().color.a;
            MandoragoraMainSprite = gameObject.GetComponent<SpriteRenderer>();
<<<<<<< HEAD
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
                                    
=======
            //マンドラゴラを消す
            GetComponent<SpriteRenderer>().color = new Color(Red, Green, Blue, ChangeAlpha);
            GetComponent<PolygonCollider2D>().enabled = false;
            Relation = transform.root.gameObject;
            Parent = GameObject.Find("Mousepointer");
            Damy = GameObject.Find("MandragoraDamy");
            //DamyStartScript = Damy.GetComponent<DamyChangeObject>();
            CalotteScript = GetComponent<Calotte>();
        }

        // Update is called once per frame
        void Update()
        {
            //if (Calotte.ctype != Calotte.CalotteType.KEEP)
            //{
            if (Parent != Relation)
            {

                if (this.transform.position.y < -6.0f)
                {
                    //ObjectMode = DamyChangeObject.ObjectMode;
                    //ObjectLifeSpan = DamyChangeObject.ObjectLifeSpan;
                    //ObjectReBornSpan = DamyChangeObject.ObjectReBornSpan;
                    //ObjectStepUpSpan = DamyChangeObject.ObjectStepUpSpan;
                    //ObjectRigit.bodyType = RigidbodyType2D.Kinematic;
                    //transform.position = new Vector3(DamyChangeObject.transform.position.x, DamyChangeObject.transform.position.y, DamyChangeObject.transform.position.z);
                    //this.transform.position = DamyChangeObject.DamyPos;


                    //CalotteScript.KeepFlg = false;
                    //go = Instantiate(MandragoraPrefub) as GameObject;
                    //go.transform.position = Damy.transform.position;
                    //go = Damy;
                    //DamyChangeObject.ObjectMode = 0;
                    //DamyChangeObject.ObjectStepUpSpan = 0;
                    //DamyChangeObject.ObjectLifeSpan = 0;
                    //DamyChangeObject.ObjectReBornSpan = 0;
                    //DamyChangeObject.ChangeAlpha = 0.0f;

                    //DamyStartScript.Start();
                    DamyFlg = 0;
                    Destroy(this.gameObject);



                }
                if (OneceFlg == 0)
                {
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
>>>>>>> Yogi_SceneM
                                }
                            };
                            break;
                        case 1:
<<<<<<< HEAD
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
=======
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
>>>>>>> Yogi_SceneM
                            }
                            break;
                    }
                }
<<<<<<< HEAD

            }
            Relation = transform.root.gameObject;
        }

        //Holdflgの切り替え
        void KeyGet(){
            if (Input.GetMouseButton(0) && (_Mand.ctype != Mandragora.CalotteType.FLEE)) Holdflg = true;
            else Holdflg = false;
=======

            }
            else if (Parent == Relation && OneceFlg == 0)
            {
                //DamyFlg = 1;
                OneceFlg = 1;
                go = Instantiate(MandragoraPrefub) as GameObject;
                go.transform.position = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
                //Damy.transform.position = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
            }


            Relation = transform.root.gameObject;
            //  }


>>>>>>> Yogi_SceneM
        }
    }
}