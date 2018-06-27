using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingInitialize : MonoBehaviour {

	// Use this for initialization
	void Start () {

    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void RankingInit(){
      //  PlayerPrefs.DeleteAll();
    }
}
