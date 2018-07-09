using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing_Enemy : MonoBehaviour {
    public GameObject director;
    Vector2 A, C, AB, AC; // ベクトル
    public GameObject MouseChild;
    public Transform Center;
    Transform target; // 追いかける対象
    private float speed = 0; // 移動スピード
    const float maxRot = 1.0f; // 曲がる最大角度

    private void OnTriggerStay2D(Collider2D collision){
        if (collision.transform.tag == "Enemy") return;
        if (director.GetComponent<Director>().gameMode != Director.MODE.PLAY) {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0,0,0);
            return;
        } 
        int childcnt = MouseChild.transform.childCount;
        if (childcnt == 0) target = Center;
        else{
            Transform tf = MouseChild.transform.GetChild(0);
            target = tf;
        }
        speed = Random.Range(0.5f, 1.0f);
        float rt = Sita();
        Move(rt); // 移動処理
    }
    //-----------------------------------------------------------------------------------------------
    // なす角θを求める
    //-----------------------------------------------------------------------------------------------
    float Sita()
    {

        A = transform.position; // 自身の座標
        C = target.position; // ターゲットの座標

        AB = transform.up; // 自身の上方向ベクトル
        AC = C - A; // ターゲットの方向ベクトル

        float dot = Vector3.Dot(AB, AC); // 内積
        float rot = Acosf(dot / (Length(AB) * Length(AC))); // アークコサインからθを求める

        // 外積から回転方向を求める
        if (AB.x * AC.y - AB.y * AC.x < 0) rot = -rot;
        float a = ((rot * 180f) / Mathf.PI);
        
        return a; // ラジアンからデグリーに変換して角度を返す
    }

    //-----------------------------------------------------------------------------------------------
    // 移動処理
    //-----------------------------------------------------------------------------------------------
    void Move(float rot)
    {
        if (float.IsNaN(rot)) rot = 0;
        Vector3 rtt = transform.eulerAngles;
        // 求めた角度が曲がる最大角度より大きかった場合に戻す処理
        if (rot >= maxRot) rot = maxRot;
        if (rot <= -maxRot) rot = -maxRot;
        
        rtt.z += rot;
<<<<<<< HEAD
        //Debug.Log(rtt);
=======
>>>>>>> 3f050ed7a6488efa38676b220683cf09fc7f5233
        transform.eulerAngles = new Vector3(rtt.x, rtt.y, rtt.z);
        GetComponent<Rigidbody2D>().velocity = AB * speed; // 上に移動
    }

    float Length(Vector2 vec){
        return Mathf.Sqrt(vec.x * vec.x + vec.y * vec.y);
    }

    float Acosf(float a){
        if (a < -1) a = -1;
        if (a > 1) a = 1;

        return (float)Mathf.Acos(a);
    }

}
