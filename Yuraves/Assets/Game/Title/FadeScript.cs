using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class FadeScript : MonoBehaviour {
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
    }
    //FadeInFlgを入れる関数
    public void FadeOutSet(bool a){
        if (a) FadeOut();
    }
    
    void FadeIn(){
        Alfa -= Add;
        FadePanel.color = new Color(Red, Green, Blue, Alfa);
    }

    public void FadeInSet(bool b){
        if (b) FadeIn();
    }

    public void Sound(int i) {
        if (i == 1) sound.GetComponent<SoundsManager>().Select();
        else if (i == 2) sound.GetComponent<HelpSound>().Select();
        else if (i == 3) sound.GetComponent<RankingSound>().Select();
        else if (i == 4) sound.GetComponent<SoundResult>().Select();
        else if (i == 5) sound.GetComponent<InputSound>().Select();
        else sound.GetComponent<TitleSound>().Select();
    }

}
