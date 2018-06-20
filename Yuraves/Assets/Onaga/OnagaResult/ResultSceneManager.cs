using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultSceneManager : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void SceneChenge()
    {
        int NewScore = Director.Score;
        int RankInScore = PlayerPrefs.GetInt("RankingNumber5", 0);
        if (NewScore < RankInScore){
            SceneManager.LoadScene("TitleScene");
        }else{
            SceneManager.LoadScene("InputRanking");
        }

    }
}
