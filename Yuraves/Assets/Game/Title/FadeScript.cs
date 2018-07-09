using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class FadeScript : MonoBehaviour {
<<<<<<< HEAD
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
=======
    public SpriteRenderer FadePanel;
    public float Alfa;
    public float Red;
    public float Green;
    public float Blue;
    public bool FadeOutFlg = false;
    public bool FadeInFlg;
    public GameObject sound;
    const float Add = 0.05f;
    float time;
    // Use this for initialization
    void Start () {
        FadePanel = GetComponent<SpriteRenderer>();
        Alfa = FadePanel.color.a;
        Red = FadePanel.color.r;
        Green = FadePanel.color.g;
        Blue = FadePanel.color.b;
    }
    void Update() {
        if (time >= 5.0f){
            Alfa = 0;
        } 
        else time += Time.deltaTime;
    }
    void FadeOut(){
        Alfa += Add;
        FadePanel.color = new Color(Red, Green, Blue, Alfa);
>>>>>>> 3f050ed7a6488efa38676b220683cf09fc7f5233
    }
    //FadeInFlgを入れる関数
    public void FadeOutSet(bool a){
        if (a) FadeOut();
<<<<<<< HEAD
    }


    public void FadeIn(){
        A -= Add;
        FadePanelSpriteRenderer.color = new Color(R, G, B, A);
    }

    public void FadeInSet(bool b)
    {
        if (b) FadeIn();
    }
=======
    }
    
    void FadeIn(){
        Alfa -= Add;
        FadePanel.color = new Color(Red, Green, Blue, Alfa);
    }

    public void FadeInSet(bool b){
        if (b) FadeIn();
    }

>>>>>>> 3f050ed7a6488efa38676b220683cf09fc7f5233
    public void Sound(int i) {
        if (i == 1) sound.GetComponent<SoundsManager>().Select();
        else if (i == 2) sound.GetComponent<HelpSound>().Select();
        else if (i == 3) sound.GetComponent<RankingSound>().Select();
        else if (i == 4) sound.GetComponent<SoundResult>().Select();
        else if (i == 5) sound.GetComponent<InputSound>().Select();
        else sound.GetComponent<TitleSound>().Select();
    }

}
