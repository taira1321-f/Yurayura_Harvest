using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEffect : MonoBehaviour {


    public ParticleSystem Waterparticle;

    // Use this for initialization
    void Start () {
        NearWaterEffect();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NearWaterEffect()
    {
        float tmpDistance = 0;           //距離用一時変数
        float nearDistance = 0;          //最も近いオブジェクトの距離

        foreach (GameObject obs in GameObject.FindGameObjectsWithTag("Effect"))
        {
            //自身と取得したオブジェクトの距離を取得
            tmpDistance = Vector3.Distance(obs.transform.position, this.transform.position);

            //オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
            //一時変数に距離を格納
            if (nearDistance == 0 || nearDistance > tmpDistance)
            {
                nearDistance = tmpDistance;
                Waterparticle = obs.GetComponent<ParticleSystem>();
            }
        }
    }

    public void WaterEffectPlay()
    {
        Waterparticle.Play();
    }
}
