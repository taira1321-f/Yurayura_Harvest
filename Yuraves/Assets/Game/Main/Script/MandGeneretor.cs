using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MandGeneretor : MonoBehaviour {

    public bool[] HotSpringFlag = { false, false, false, false };
    bool[] InstantiateFlg = { false, false, false, false };
    string[] MandName = { "Mand_1", "Mand_2", "Mand_3", "Mand_4" };
    public GameObject MandPrefab;//生成するやつー
    Vector3[] GPos = {
                         new Vector3( -2.0f, -4.0f, 0f),
                         new Vector3(-0.75f, -4.0f, 0f),
                         new Vector3( 0.75f, -4.0f, 0f),
                         new Vector3(  2.0f, -4.0f, 0f),
                     };
	// Use this for initialization
	void Start () {
        //フラグの初期化
        int i = (HotSpringFlag.Length - 1);
        for (; i >= 0; i--) {
            HotSpringFlag[i] = false;
        }
	}
	
	// Update is called once per frame
	void Update () {

	}

    //Destroy時 or 温泉に浸かった時に生成
    public void MandGene(string str)
    {
        //引数の名前は？
        //その名前がなければ生成
        switch (str)
        {
            case "Mand_1":
                InstantiateInit(0, str);
                break;
            case "Mand_2":
                InstantiateInit(1, str);
                break;
            case "Mand_3":
                InstantiateInit(2, str);
                break;
            case "Mand_4":
                InstantiateInit(3, str);
                break;
        }
        if (GameObject.Find("Mand_1") == null) InstantiateFlg[0] = true;
        if (GameObject.Find("Mand_2") == null) InstantiateFlg[1] = true;
        if (GameObject.Find("Mand_3") == null) InstantiateFlg[2] = true;
        if (GameObject.Find("Mand_4") == null) InstantiateFlg[3] = true;
        int i = InstantiateFlg.Length - 1;
        for (; i >= 0; i--) {
            if (InstantiateFlg[i]) InstantiateInit(i, MandName[i]);
        }
        if (GameObject.Find(str))
        {
            GameObject mand = GameObject.Find(str);
            Destroy(mand);
            return;
        }
    }
    //生成処理時の初期設定
    void InstantiateInit(int i, string str)
    {
        GameObject MP;
        MP = Instantiate(MandPrefab);
        MP.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        MP.transform.position = new Vector3(GPos[i].x, GPos[i].y, GPos[i].z);
        MP.transform.Rotate(new Vector3(0, 0, 0));
        MP.name = MandName[i];

    }
    
}
