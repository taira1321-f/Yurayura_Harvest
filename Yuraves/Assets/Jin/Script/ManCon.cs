using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yogi;

public class ManCon : MonoBehaviour 
{
    GameObject GM;
    void Start() {
        GM = GameObject.FindGameObjectWithTag("Spawn");
    }

    void OnTriggerStay2D(Collider2D col) 
    {
        GM = GameObject.FindGameObjectWithTag("Spawn");
        //どの温泉に浸かっているかチェック
        GameObject Spring = col.gameObject;
        if (col.gameObject.name == "HotSpring_1")
        {
            Changer(Spring, 0);
        }
        else if (col.gameObject.name == "HotSpring_2")
        {
            Changer(Spring, 1);
        }
        else if (col.gameObject.name == "HotSpring_3")
        {
            Changer(Spring, 2);
        }
        else if (col.gameObject.name == "HotSpring_4")
        {
            Changer(Spring, 3);
        }
        
    }
    void Changer(GameObject sp,int i) {
        GM.GetComponent<MandGeneretor>().MandGene(gameObject.transform.name);
        GM.GetComponent<MandGeneretor>().HotSpringFlag[i] = true;
        sp.GetComponent<ChangeImage>().ChangeStateToHold(); //温泉の画像差し替え
        AddScore();
        sp.GetComponent<BoxCollider2D>().enabled = false;   //当たり判定消す        
    }
    void AddScore() {
        int om = gameObject.GetComponent<Yogi.ChangeObjectMode>().ObjectMode;
        if (om == 1) Director.Score += 30;
        else if (om == 2) Director.Score += 20;
        else if (om == 3) Director.Score += 10;
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Spring"))
        {
            Destroy(gameObject);
        }
    }
}
