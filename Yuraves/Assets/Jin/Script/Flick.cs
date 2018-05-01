using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flick : MonoBehaviour {

    private Vector3 screenPoint;
    private Vector3 offset;

    void OnMouseDown() {
        //このオブジェクトの位置(transform.position)をスクリーン座標に変換
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        //ワールド座標上の、マウスカーソルと、対象の位置の差分
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseUp() {
        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
