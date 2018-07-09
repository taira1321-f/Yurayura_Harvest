using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingInitialize : MonoBehaviour {

	// Use this for initialization
	void Start () {

<<<<<<< HEAD
        Debug.Log(PlayerPrefs.GetInt("RankingNumber1", 0000));
        Debug.Log(PlayerPrefs.GetInt("RankingNumber2", 0000));
        Debug.Log(PlayerPrefs.GetInt("RankingNumber3", 0000));
        Debug.Log(PlayerPrefs.GetInt("RankingNumber4", 0000));
        Debug.Log(PlayerPrefs.GetInt("RankingNumber5", 0000));
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void RankingInit()
    {
        PlayerPrefs.DeleteAll();
=======
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void RankingInit(){
      //  PlayerPrefs.DeleteAll();
>>>>>>> 3f050ed7a6488efa38676b220683cf09fc7f5233
    }
}
