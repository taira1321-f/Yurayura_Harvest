using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManCon : MonoBehaviour 
{
    GameObject GM;
    void Start() {
        GM = GameObject.FindGameObjectWithTag("Spawn");
        Debug.Log("当たり前\n" + GM);
    }

    void OnCollisionEnter2D(Collision2D col) 
    {
        GM = GameObject.FindGameObjectWithTag("Spawn");
        Debug.Log("ふざけるな\n" + GM);
        //どの温泉に浸かっているかチェック
        GameObject Spring = col.gameObject;
        //MGeneretor = MandMane.GetComponent<MandGeneretor>();
        if (col.gameObject.name == "HotSpring_1"){
            Changer(Spring, 0);
        }else if (col.gameObject.name == "HotSpring_2"){
            Changer(Spring, 1);
        }else if (col.gameObject.name == "HotSpring_3"){
            Changer(Spring, 2);
        }else if (col.gameObject.name == "HotSpring_4"){
            Changer(Spring, 3);
        }
    }
    void Changer(GameObject sp,int i) {
        GM.GetComponent<MandGeneretor>().MandGene(gameObject.transform.name);
        GM.GetComponent<MandGeneretor>().HotSpringFlag[i] = true;
        sp.GetComponent<ChangeImage>().ChangeStateToHold(); //温泉の画像差し替え
        sp.GetComponent<BoxCollider2D>().enabled = false;   //当たり判定消す        
    }
    void OnCollisionExit2D(Collision2D col) {
        if (col.gameObject.CompareTag("Spring")){
            Destroy(gameObject);
        }
    }
}
