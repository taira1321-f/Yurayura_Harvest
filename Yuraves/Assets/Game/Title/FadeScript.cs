﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class FadeScript : MonoBehaviour {
    public SpriteRenderer FadePanelSpriteRenderer;
    public float A;
    public float R;
    public float G;
    public float B;
    public bool FadeOutFlg = false;
    public bool FadeInFlg;
    public GameObject sound;
    float Add=0.05f;
    // Use this for initialization
    void Start () {
        FadePanelSpriteRenderer = GetComponent<SpriteRenderer>();
        A = GetComponent<SpriteRenderer>().color.a;
        R = GetComponent<SpriteRenderer>().color.r;
        G = GetComponent<SpriteRenderer>().color.g;
        B = GetComponent<SpriteRenderer>().color.b;


    }
	
	// Update is called once per frame
	void Update () {
       
    }

    public void FadeOut()
    {
        
        //this.delta += Time.deltaTime;
        //if (this.delta >= 0.5f)
        //{
            //Debug.Log("フェードアウト");
            A += Add;
            FadePanelSpriteRenderer.color = new Color(R, G, B, A);
            //this.delta = 0.0f;
        //}
    }

    public void FadeOutSet(bool a)//FadeInFlgを入れる関数
    {
        if (a)
        {
            FadeOut();
        }
    }


    public void FadeIn()
    {
        //this.delta += Time.deltaTime;
        //if (this.delta >= 0.5f)
        //{
            A -= Add;
            FadePanelSpriteRenderer.color = new Color(R, G, B, A);
            //delta = 0.0f;
        //}
    }

    public void FadeInSet(bool b)
    {
        if (b)
        {
            FadeIn();
        }
    }
    public void Sound(int i) {
        if (i == 1) sound.GetComponent<SoundsManager>().Select();
        else if (i == 2) sound.GetComponent<HelpSound>().Select();
        else sound.GetComponent<TitleSound>().Select();
    }

}
