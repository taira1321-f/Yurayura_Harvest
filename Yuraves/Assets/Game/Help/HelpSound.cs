using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpSound : MonoBehaviour {
    AudioSource audio;
    public AudioClip bgm;
    public AudioClip se;
    // Use this for initialization
    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
        audio.PlayOneShot(bgm);
    }

    // Update is called once per frame
    void Update(){

    }
    public void Select(){
        audio.PlayOneShot(se);
    }
}
