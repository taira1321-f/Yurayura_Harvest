using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManeger : MonoBehaviour {
    //BGM配列
    public AudioSource[] BGM;
    //SE配列
    public AudioSource[] SE;


	// Use this for initialization
	void Start () {
        BGM = gameObject.GetComponents<AudioSource>();
        SE = gameObject.GetComponents<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
