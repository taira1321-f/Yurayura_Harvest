using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlickController : MonoBehaviour {

    private Vector2 touchStartPosition;
    private Vector2 touchEndPosition;
    private Vector2 touchStayPosition;
    //スライドさせる画像
    private GameObject HelpSlide;
    //左ボタン
    public Button LeftButton;
    //右ボタン
    public Button RightButton;
    //フリック判定用の時間
    private float FlickTimer = 0.30f;
    private float Timer;

    Vector2 LeftLimit = new Vector2(4.8f,0);
    Vector2 RightLimit = new Vector2(-4.8f,0);

    void Start () {
        this.HelpSlide = GameObject.Find("Swimsuit_Mirei_SR");        
	}
    //右へスライドするアニメーション処理
    public void RightSlide(Animation anim)
    {
        //真ん中から右へ
        if(this.HelpSlide.transform.position.x == 0)
        {
            anim.Play("RightSlide2");
            RightButton.gameObject.SetActive(false);
        //左から真ん中へ
        }else if(this.HelpSlide.transform.position.x >= 4.8)
        {
            anim.Play("RightSlide1");
            LeftButton.gameObject.SetActive(true);
        }          
    }
    //左へスライドするアニメーション処理
    public void LeftSlide(Animation anim)
    {
        //真ん中から左へ
        if(this.HelpSlide.transform.position.x == 0)
        {
            anim.Play("LeftSlide2");
            LeftButton.gameObject.SetActive(false);
        //右から真ん中へ
        }else if(this.HelpSlide.transform.position.x <= -4.8)
        {
            anim.Play("LeftSlide1");
            RightButton.gameObject.SetActive(true);
        }
    }

    void GetDirection()
    {
        //タップしてる間の位置　‐　タップ開始時の位置
        float directionX = touchStayPosition.x - touchStartPosition.x;

        //左にフリックかつタップしてた時間が0.30f以下の場合
        if(30 < directionX　&& Timer < FlickTimer)
        {
            //右にスライド
            Animation anim = gameObject.GetComponent<Animation>();
            LeftSlide(anim);
        //右にフリックかつタップしてた時間が0.30f以下の場合
        }else if(-30 > directionX && Timer < FlickTimer)
        {
            //左にスライド
            Animation anim = gameObject.GetComponent<Animation>();
            RightSlide(anim);
        }else
        {
            //タッチを検出
        }
    }

    void Update () {
        //タップ開始
        if (Input.GetMouseButtonDown(0))
        {
            touchStartPosition = new Vector2(Input.mousePosition.x,
                                             Input.mousePosition.y);           
        }
        //タップしている間
        if(Input.GetMouseButton(0))
        {
            touchStayPosition = new Vector2(Input.mousePosition.x,
                                            Input.mousePosition.y);
            GetDirection();
            Timer += Time.deltaTime;
        }
        //タップ終了
        if (Input.GetMouseButtonUp(0))
        {
            //touchEndPosition = new Vector2(Input.mousePosition.x,Input.mousePosition.y);

            GetDirection();
            Timer = 0;
        }

        //左壁に当たる
        if (this.HelpSlide.transform.position.x > 4.8f)
            this.HelpSlide.transform.position = LeftLimit;
        //右壁に当たる
        if(this.HelpSlide.transform.position.x < -4.8)
            this.HelpSlide.transform.position = RightLimit;

  	}
}