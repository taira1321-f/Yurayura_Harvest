using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeManager : MonoBehaviour {
    private const float Scale = 0.3f;
    public int SizePoint;
    float InitSizeX, InitSizeY;
    GameObject snd;
	// Use this for initialization
	void Start () {
        SizePoint = 0;
        InitSizeX = this.transform.localScale.x;
        InitSizeY = this.transform.localScale.y;
        snd = GetComponent<MandState>().Sound;
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.localScale = new Vector3(InitSizeX + SizePoint * Scale,
            InitSizeY + SizePoint * Scale, 1);
        
    }
}
