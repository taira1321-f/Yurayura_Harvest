using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour {
    AudioSource audio_source;
    public AudioClip[] SE;  //メインSE配列 ==>> 中身は下のコメント文
    /********************************************
      0:レディー
      1:ゴー
      2:決定音
      3:軋む音
      4:敵が走る音(猪)
      5:猪の怒る声
      6:猪の鳴き声
      7:敵が走る音(猿)
      8:猿の鳴き声
      9:成長音
     10:引き抜く音(デカイ)
     11:引き抜く音(小さい)
     12:切れる音
     13:敵にあたった音
     14:ジャポン(温泉に入る音)
     15:チャポン(温泉に入る音)
     16:そこまでー
     *******************************************/
    
    void Start(){
        audio_source = gameObject.GetComponent<AudioSource>();
    }
    public void StartSE(int i){
        audio_source.PlayOneShot(SE[i]);
    }
    public void FinishSE() {
        audio_source.PlayOneShot(SE[16]);
    }
    public void Select() {
        audio_source.PlayOneShot(SE[2]);
    }
    public void Boar_V(int i) {
        if (i == 1) audio_source.PlayOneShot(SE[4]);
        else if (i == 2) audio_source.PlayOneShot(SE[5]);
        else if (i == 3) audio_source.PlayOneShot(SE[6]);
        else if (i == 4) audio_source.PlayOneShot(SE[13]);
        else return;
    }
    public void Monkey(int i) {
        if (i == 1) audio_source.PlayOneShot(SE[7]);
        else if (i == 2) audio_source.PlayOneShot(SE[8]);
        else if (i == 4) audio_source.PlayOneShot(SE[13]);
        else return;
    }
    public void Mandragora(int i,int size) {
        if (i == 0) audio_source.PlayOneShot(SE[3]);
        else if (i == 1) audio_source.PlayOneShot(SE[9]);
        else if (i == 2 && size == 2) audio_source.PlayOneShot(SE[10]);
        else if (i == 2 && size == 1) audio_source.PlayOneShot(SE[11]);
        else if (i == 3) audio_source.PlayOneShot(SE[12]);
        else if (i == 4 && size == 2) audio_source.PlayOneShot(SE[14]);
        else if (i == 4 && size == 1) audio_source.PlayOneShot(SE[15]);
        else return;
    }
}
