using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSound : MonoBehaviour {
    AudioSource Audio_S;
    public AudioClip[] se;
	// Use this for initialization
	void Start () {
        Audio_S = gameObject.GetComponent<AudioSource>();
        Application.targetFrameRate = 60;   //ターゲットフレームレート
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Select() {
        Audio_S.PlayOneShot(se[0]);
    }
}
