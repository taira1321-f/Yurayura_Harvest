using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rush_Enemy : MonoBehaviour {
    enum State { STAY, RUSH, TURN };
    State s_mode;
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
        s_mode = State.STAY;
        // StartPosをオブジェクトに初期位置に設定
        transform.position = StartPos;
        // 1秒当たりの移動量を算出
        deltaPos = (EndPos - StartPos) / time;
        elapsedTime = 0;
        GameObject go = transform.Find("e_p").gameObject;
        go.SetActive(false);
    }

    void Update(){
        switch (s_mode) {
            case State.RUSH:
                Rush();
                break;
            case State.TURN:
                Turn();
                break;
            case State.STAY:
                Stay();
                break;
        }
    }
    void ModeChange() {
        if (s_mode == State.RUSH) s_mode = State.TURN;
        else if (s_mode == State.TURN) s_mode = State.STAY;
        else if (s_mode == State.STAY) s_mode = State.RUSH;
    }
    void Rush() {
        transform.position += deltaPos * Time.deltaTime;
        elapsedTime += Time.deltaTime;
        if (elapsedTime > time){
            if (bStartToEnd){
                deltaPos = (StartPos - EndPos) / time;
                transform.position = EndPos;
            }else{
                deltaPos = (EndPos - StartPos) / time;
                transform.position = StartPos;
            }
            bStartToEnd = !bStartToEnd;
            elapsedTime = 0;
            ModeChange();
        }
    }
    void Turn() {
        goAngle = gameObject.transform.eulerAngles;
        if (bStartToEnd){
            goAngle.z -= angle;
            if (((int)goAngle.z) == ((int)TurnAngle[1]) || ((int)goAngle.z) == ((int)TurnAngle[2])) ModeChange();
        }else{
            goAngle.z += angle;
            if (((int)goAngle.z) == ((int)TurnAngle[0])) ModeChange();
        }
        if (goAngle.z >= 360 || goAngle.z <= -360) goAngle.z = 0;  
        gameObject.transform.eulerAngles = goAngle;
    }
    void Stay() {
        GameObject go = transform.Find("e_p").gameObject;
        go.SetActive(true);
        if (go.GetComponent<Rush_Col_Enemy>().RockOn) {
            go.GetComponent<Rush_Col_Enemy>().RockOn = false;
            go.SetActive(false);
            ModeChange();
        }
    }
}
