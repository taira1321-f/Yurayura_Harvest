using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundResult : MonoBehaviour {
    AudioSource Audio_S;
    public AudioClip[] SE;
    // Use this for initialization
    void Start()
    {
        Audio_S = GetComponent<AudioSource>();
        Application.targetFrameRate = 60;   //ターゲットフレームレート
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Select()
    {
        Audio_S.PlayOneShot(SE[0]);
    }
}
