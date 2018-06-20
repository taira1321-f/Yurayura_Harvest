using System.Collections;
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
    void Update() { }

    public void FadeOut(){
        A += Add;
        FadePanelSpriteRenderer.color = new Color(R, G, B, A);
    }
    //FadeInFlgを入れる関数
    public void FadeOutSet(bool a){
        if (a) FadeOut();
    }


    public void FadeIn(){
        A -= Add;
        FadePanelSpriteRenderer.color = new Color(R, G, B, A);
    }

    public void FadeInSet(bool b)
    {
        if (b) FadeIn();
    }
    public void Sound(int i) {
        if (i == 1) sound.GetComponent<SoundsManager>().Select();
        else if (i == 2) sound.GetComponent<HelpSound>().Select();
        else if (i == 3) sound.GetComponent<RankingSound>().Select();
        else if (i == 4) sound.GetComponent<SoundResult>().Select();
        else sound.GetComponent<TitleSound>().Select();
    }

}
