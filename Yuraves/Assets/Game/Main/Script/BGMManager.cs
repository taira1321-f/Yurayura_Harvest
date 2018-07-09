using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour {
    public GameObject DIR;
    public AudioClip[] BGM;
    public AudioClip[] SE;
    AudioSource audio_source;
	// Use this for initialization
	void Start () {
        audio_source = gameObject.GetComponent<AudioSource>();
        audio_source.PlayOneShot(BGM[0]);
	}
	
	// Update is called once per frame
	void Update () {

	}
    public void StartSE() {
        audio_source.PlayOneShot(SE[0]);
    }
}
