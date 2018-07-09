using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rush_Enemy : MonoBehaviour {
    public GameObject director;
    enum State { STAY, RUSH, TURN };
    State s_mode;
    //RUSHMODE用変数
    public Vector3 StartPos;
    public Vector3 EndPos;
    public float time;
    Vector3 deltaPos;
    float elapsedTime;
    bool bStartToEnd = true;
    //TURNMODE用変数
    float[] EyesAngle = { 60.0f, 240.0f, -120.0f };
    float[] BodyAngle = { 0.0f, 180.0f, -180.0f };
    const float angle = 0.5f;
    //ANIME用変数
    public GameObject BODY;
    public Sprite[] Run;
    void Start(){
        s_mode = State.TURN;
        transform.position = StartPos;
        deltaPos = (EndPos - StartPos) / time;
        elapsedTime = 0;
    }
    void Update(){
        if (director.GetComponent<Director>().gameMode != Director.MODE.PLAY) return;
        switch (s_mode) {
            case State.RUSH:
                Rush();
                break;
            case State.TURN:
                EyesTurn();
                BodyTurn();
                break;
            case State.STAY:
                Stay();
                break;
        }
    }
    void ModeChange() {
        if (s_mode == State.RUSH){
            s_mode = State.TURN;
            BODY.GetComponent<SpriteRenderer>().sprite = Run[0];
        }else if (s_mode == State.TURN){
            s_mode = State.STAY;
        }else if (s_mode == State.STAY) {
            s_mode = State.RUSH;
            BODY.GetComponent<SpriteRenderer>().sprite = Run[1];
        } 
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
    void EyesTurn() {
        GameObject ep = transform.Find("e_p").gameObject;
        Vector3 epAngle = ep.transform.eulerAngles;
        if (bStartToEnd){
            epAngle.z -= angle;
            if (((int)epAngle.z) == ((int)EyesAngle[1]) || ((int)epAngle.z) == ((int)EyesAngle[2])) ModeChange();
        }else{
            epAngle.z += angle;
            if (((int)epAngle.z) == ((int)EyesAngle[0])) ModeChange();
        }
        if (epAngle.z >= 360 || epAngle.z <= -360) epAngle.z = 0;  
        ep.transform.eulerAngles = epAngle;
    }
    void BodyTurn() {
        GameObject go = transform.Find("body").gameObject;
        Vector3 body_R = go.transform.eulerAngles;
        if (bStartToEnd){
            body_R.y -= angle;
            if (((int)body_R.y) == ((int)BodyAngle[1]) || ((int)body_R.y) == ((int)BodyAngle[2])) return;
        }else {
            body_R.y -= angle;
            if (((int)body_R.y) == ((int)BodyAngle[0])) return;            
        }
        if (body_R.y >= 360 || body_R.y <= -360) body_R.y = 0;
        go.transform.eulerAngles = body_R;
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
