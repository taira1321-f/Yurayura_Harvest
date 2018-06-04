using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Children : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (this.transform.childCount > 1)
        {
            GameObject Child1 = null;
            bool OneFlg = false;
            foreach (Transform transform in gameObject.transform)
            {
                // Transformからゲームオブジェクト取得・削除
                var TargetChild = transform.gameObject;
                if (!OneFlg)
                {
                    Child1 = TargetChild;
                    OneFlg = true;
                }
                if (Child1 != TargetChild)
                {
                    Destroy(TargetChild);
                    Child1.GetComponent<SizeManager>().SizePoint++;
                }
            }
        }
    }
}
