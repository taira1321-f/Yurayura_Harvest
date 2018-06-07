using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rush_Enemy : MonoBehaviour {
    bool R_flg;     //true:Rush関数,false:Turn関数
    //Rush関数用変数
    public Vector3 StartPos;
    public Vector3 EndPos;
    public float time;
    private Vector3 deltaPos;
    private float elapsedTime;
    private bool bStartToEnd = true;
    //Turn関数用変数
    float[] TurnAngle = { 75.0f, 255.0f, -105.0f, };
    Vector3 goAngle;
    const float angle = 0.5f;

    void Start()
    {
        // StartPosをオブジェクトに初期位置に設定
        transform.position = StartPos;
        // 1秒当たりの移動量を算出
        deltaPos = (EndPos - StartPos) / time;
        elapsedTime = 0;
    }

    void Update(){
        DebugInput();
        if (R_flg) Rush();
        else Turn();
    }
    void DebugInput() {
        if (R_flg && Input.GetKeyDown(KeyCode.Z)) R_flg = false;
        else if (!R_flg && Input.GetKeyDown(KeyCode.Z)) R_flg = true;
    }
    void Rush() {
        Debug.Log("ラッシュ");
        // 1秒当たりの移動量にTime.deltaTimeを掛けると1フレーム当たりの移動量となる
        // Time.deltaTimeは前回Updateが呼ばれてからの経過時間
        transform.position += deltaPos * Time.deltaTime;
        // 往路復路反転用経過時間
        elapsedTime += Time.deltaTime;
        // 移動開始してからの経過時間がtimeを超えると往路復路反転
        if (elapsedTime > time)
        {
            if (bStartToEnd)
            {
                // StartPos→EndPosだったので反転してEndPos→StartPosにする
                // 現在の位置がEndPosなので StartPos - EndPosでEndPos→StartPosの移動量になる
                deltaPos = (StartPos - EndPos) / time;
                // 誤差があるとずれる可能性があるので念のためオブジェクトの位置をEndPosに設定
                transform.position = EndPos;
            }
            else
            {
                // EndPos→StartPosだったので反転してにStartPos→EndPosする
                // 現在の位置がStartPosなので EndPos - StartPosでStartPos→EndPosの移動量になる
                deltaPos = (EndPos - StartPos) / time;
                // 誤差があるとずれる可能性があるので念のためオブジェクトの位置をSrartPosに設定
                transform.position = StartPos;
            }
            // 往路復路のフラグ反転
            bStartToEnd = !bStartToEnd;
            // 往路復路反転用経過時間クリア
            elapsedTime = 0;
            R_flg = !R_flg;
        }
    }
    void Turn() {
        Debug.Log(goAngle);
        goAngle = gameObject.transform.eulerAngles;
        if (bStartToEnd){
            Debug.Log("true");
        }else {
            Debug.Log("false");
            goAngle.z += angle;
        }
        if (goAngle.z >= 360 || goAngle.z <= -360) goAngle.z = 0;  
        gameObject.transform.eulerAngles = goAngle;
        
    }
}
