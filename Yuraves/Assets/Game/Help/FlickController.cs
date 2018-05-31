using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlickController : MonoBehaviour {

    private Vector3 touchStartPosition;
    private Vector3 touchEndPosition;
    private string Direction;
    //画像の移動量
    //private float SlideSpeed = 0f;
    //スライドさせる画像
    private GameObject HelpSlide;
    //左ボタン
    public GameObject LeftButton;
    //右ボタン
    public GameObject RightButton;
    float directionX;
    float directionY;

    void Start () {
        this.HelpSlide = GameObject.Find("Swimsuit_Mirei_SR");
        Animation anim = gameObject.GetComponent<Animation>();
        
	}
    //右へスライドする処理
    public void RightSlide(Animation anim)
    {
        //真ん中から右へ
        if(this.HelpSlide.transform.position.x == 0)
        {
            anim.Play("RightSlide2");
            RightButton.SetActive(false);
            Debug.Log("真ん中から右へ");
        //左から真ん中へ
        }else if(this.HelpSlide.transform.position.x >= 4.8)
        {
            anim.Play("RightSlide1");
            LeftButton.SetActive(true);
            Debug.Log("左から右へ");
        }          
    }
    //左へスライドする処理
    public void LeftSlide(Animation anim)
    {
        //真ん中から左へ
        if(this.HelpSlide.transform.position.x == 0)
        {
            anim.Play("LeftSlide2");
            LeftButton.SetActive(false);
            Debug.Log("真ん中から左へ");
        //右から真ん中へ
        }else if(this.HelpSlide.transform.position.x <= -4.8)
        {
            anim.Play("LeftSlide1");
            RightButton.SetActive(true);
            Debug.Log("右から左へ");
        }
    }

    void GetDirection()
    {
        directionX = touchEndPosition.x - touchStartPosition.x;
        directionY = touchEndPosition.y - touchStartPosition.y;

        if(Mathf.Abs(directionY) < Mathf.Abs(directionX))
        {
            if(30 < directionX)
            {
                //右向きにフリック
                Direction = "right";
            }else if(-30 > directionX)
            {
                //左向きにフリック
                Direction = "left";
            }
        }else if(Mathf.Abs(directionX) < Mathf.Abs(directionY))
        {
            if(30 < directionY)
            {
                //上向きにフリック
                Direction = "up";
            }else if(-30 > directionY)
            {
                //下向きフリック
                Direction = "down";
            }
        }else
        {
            //タッチを検出
            Direction = "touch";
        }
    }

    void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            touchStartPosition = new Vector3(Input.mousePosition.x,
                                             Input.mousePosition.y,
                                             Input.mousePosition.z);
        }

        if (Input.GetMouseButtonUp(0))
        {
            touchEndPosition = new Vector3(Input.mousePosition.x,
                                           Input.mousePosition.y,
                                           Input.mousePosition.z);

            GetDirection();
        }

        switch (Direction)
        {
            case "up":
                
                break;

            case "down":

                break;

            case "right":
                Vector2 position = transform.position;
                position.x += -4.8f;
                this.HelpSlide.transform.position = position;
                break;

            case "left":

                break;

            case "touch":

                break;
        }
	}
}