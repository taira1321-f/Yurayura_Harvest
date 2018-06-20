using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpSound : MonoBehaviour {
    AudioSource Audio_S;
    public AudioClip bgm;
    public AudioClip se;
    // Use this for initialization
    void Start()
    {
        Audio_S = gameObject.GetComponent<AudioSource>();
        Audio_S.PlayOneShot(bgm);
    }

    // Update is called once per frame
    void Update(){

    }
    public void Select(){
        Audio_S.PlayOneShot(se);
    }
}
