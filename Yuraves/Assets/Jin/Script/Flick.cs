using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flick : MonoBehaviour {
    //定数
    private const float MouseDistanceY = -1.5f;
        //変数
    [SerializeField]
    private GameObject Player;

    private Vector3 screenPoint;
    private Vector3 offset;

     void Start () {
		 Player = GameObject.FindGameObjectWithTag("Player");

	}


    void OnMouseDown() {
        //このオブジェクトの位置(transform.position)をスクリーン座標に変換
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        //ワールド座標上の、マウスカーソルと、対象の位置の差分
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }
    void OnMouseDrag() {
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + this.offset;
        transform.position = currentPosition;
    }
    void SetParent()
    {
        gameObject.transform.parent = Player.transform;
        gameObject.transform.position += new Vector3(0.0f, MouseDistanceY, 0.0f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
