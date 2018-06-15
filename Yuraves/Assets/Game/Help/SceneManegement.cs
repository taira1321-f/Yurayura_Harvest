using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManegement : MonoBehaviour {
    GameObject TitleToStartObject;
    GameObject TitleToHelpObject;

    GameObject HelpToTitleObject;
    GameObject HelpToMainObject;
    // Use this for initialization
    void Start () {

        TitleToStartObject = GameObject.Find("TitleToStartObject");
        TitleToHelpObject = GameObject.Find("TitleToHelpObject");

        HelpToMainObject = GameObject.Find("HelpToMainObject");
        HelpToTitleObject = GameObject.Find("HelpToTitleObject");
    }
	
	// Update is called once per frame
	void Update () {
    }
}
