using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetHotSpring : MonoBehaviour {
    //カウントダウン
    public Text timerText;
    public float totalTime = 20;
	int seconds;

    //フラグ
    public static bool Flag1 = false;
    public static bool Flag2 = false;
    public static bool Flag3 = false;
    public static bool Flag4 = false;

    //温泉
    private GameObject Spring1;
    private GameObject Spring2;
    private GameObject Spring3;
    private GameObject Spring4;

    //スライド時のスピード
    private float speed=13f;

    //リセット用のポジション宣言
    Vector2 HotSpringposition;

     void Start () {
        //温泉
        Spring1 = GameObject.Find("HotSpring1");
        Spring2 = GameObject.Find("HotSpring2");
        Spring3 = GameObject.Find("HotSpring3");
        Spring4 = GameObject.Find("HotSpring4");
        //リセット用のポジション
        HotSpringposition = Spring1.transform.position;
	}
	
	void Update () {
        //カウントダウン
        totalTime -= Time.deltaTime;
		seconds = (int)totalTime;
		timerText.text= seconds.ToString();

        //４つ埋まった時
		if (Flag1 == true && Flag2 == true && Flag3 == true && Flag4 == true)
        {
            Debug.Log("４つ埋まった");
            Reset();                      
        }
        //時間切れ
        if(seconds == 0)
        {
            Debug.Log("時間が0になった");
            Reset();
        }
	}

    void Reset()
    {
        
        //埋まったら温泉をスライド
        Spring1.transform.Translate(this.speed*Time.deltaTime,0,0);
        //一定の位置に来たらポジションをリセット
        if(Spring1.transform.position.x > 5.6f)
            HotSpringPositionReset();       
        
        //画像と当たり判定の切替
        Invoke("HotSpringReset",0.5f);
        //すべてのフラグをfalseへ
        Invoke("HotSpringFlagReset",0.6f);
    }

    //ポジションをリセット
    void HotSpringPositionReset()
    {
        this.speed = 0;
        HotSpringposition.x = -1.1f;
        Spring1.transform.position = HotSpringposition;
    }   
    void HotSpringReset()
    {

        //すべての温泉の画像切り替え
        this.Spring1.GetComponent<ChangeImage>().ChangeStateToStandby();
        this.Spring2.GetComponent<ChangeImage>().ChangeStateToStandby();
        this.Spring3.GetComponent<ChangeImage>().ChangeStateToStandby();
        this.Spring4.GetComponent<ChangeImage>().ChangeStateToStandby();

        //当たり判定の復活
        this.Spring1.GetComponent<BoxCollider2D>().enabled = true;
        this.Spring2.GetComponent<BoxCollider2D>().enabled = true;
        this.Spring3.GetComponent<BoxCollider2D>().enabled = true;
        this.Spring4.GetComponent<BoxCollider2D>().enabled = true;

    }
    public void HotSpringFlagReset()
    {
        //すべてのフラグをfalseへ
        Flag1 = false;
        Flag2 = false;
        Flag3 = false;
        Flag4 = false;
        //元のスピードに戻す
        this.speed = 13f;
        //時間をリセット
        totalTime = 20;
    }

}
