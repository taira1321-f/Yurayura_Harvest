using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour {
    private GameObject Mouse = null;
    private Vector3 Screenmousepos;
    private Vector3 Worldmousepos;

	void Start () {
        Mouse = this.gameObject;
    }
	

	void Update () {
        //マウス座標を取得　&　カメラ基準へ変換
        Screenmousepos = Input.mousePosition;
        Worldmousepos = Camera.main.ScreenToWorldPoint(Screenmousepos);

        //カメラより前に変更し自身オブジェクトへ
        Worldmousepos.z = 0.0f;
        Mouse.transform.position = Worldmousepos;
        
    }
}
