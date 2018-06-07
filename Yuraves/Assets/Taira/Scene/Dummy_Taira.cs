using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dummy_Taira : MonoBehaviour {

    public GameObject ScoreT;
    public GameObject CountT;
    string Itumono = "Score:";
    string Reinoare = "Count:";
	// Use this for initialization
	void Start () {
        ScoreT.GetComponent<Text>().text = Itumono;
        CountT.GetComponent<Text>().text = Reinoare;
	}
	
	// Update is called once per frame
	void Update () {
        ScoreT.GetComponent<Text>().text = Itumono + Director.Score;
        CountT.GetComponent<Text>().text = Reinoare + Director.MandCont;
	}
}
