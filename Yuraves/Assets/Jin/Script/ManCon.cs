using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManCon : MonoBehaviour 
{
	public enum SpringType{
		Hot1,
		Hot2,
		Hot3,
		Hot4,
	}
    public SpringType springType;
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
    void Start() {
    }
    void OnCollisionEnter2D(Collision2D col) 
    {
        GameObject Spring = col.gameObject;
        if(col.gameObject.name == "HotSpring1"){
            springType = SpringType.Hot1;
            Spring.GetComponent<ChangeImage>().ChangeStateToHold();
        }else if (col.gameObject.name == "HotSpring2"){
            springType = SpringType.Hot2;
            Spring.GetComponent<ChangeImage>().ChangeStateToHold();
        }else if (col.gameObject.name == "HotSpring3"){
            springType = SpringType.Hot3;
            Spring.GetComponent<ChangeImage>().ChangeStateToHold();
        }else if (col.gameObject.name == "HotSpring4"){
            springType = SpringType.Hot3;
            Spring.GetComponent<ChangeImage>().ChangeStateToHold();
        }

        switch(springType){
            case SpringType.Hot1:
                MandGeneretor.Flag1 = true;
                Spring.GetComponent<BoxCollider2D>().enabled = false;
                break;
            case SpringType.Hot2:
                MandGeneretor.Flag2 = true;
                Spring.GetComponent<BoxCollider2D>().enabled = false;
                break;
            case SpringType.Hot3:
                MandGeneretor.Flag3 = true;
                Spring.GetComponent<BoxCollider2D>().enabled = false;
                break;
            case SpringType.Hot4:
                MandGeneretor.Flag4 = true;
                Spring.GetComponent<BoxCollider2D>().enabled = false;
                break;
            default:
                return;
        }
    }

    void OnCollisionExit2D(Collision2D col) {
        if (col.gameObject.CompareTag("Spring")){
            Destroy(gameObject);
            MandGene(this.gameObject.transform.name);
        }
    }
    void MandGene(string str)
    {
        //引数の名前は？
        //その名前があればtrue
        switch (str)
        {
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
        if (OnFlg_3)
        {
            GameObject go = Instantiate(MandPrefab);
            go.transform.position = new Vector3(GPos[2].x, GPos[2].y, GPos[2].z);
            go.name = "Mand_3";
            if (GameObject.Find("Mand_3")) OnFlg_3 = false;
        }
        if (OnFlg_4)
        {
            GameObject go = Instantiate(MandPrefab);
            go.transform.position = new Vector3(GPos[3].x, GPos[3].y, GPos[3].z);
            go.name = "Mand_4";
            if (GameObject.Find("Mand_4")) OnFlg_4 = false;
        }
    }
}
