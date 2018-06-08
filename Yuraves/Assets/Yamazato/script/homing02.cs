using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homing02 : MonoBehaviour {

    Vector2 A, C, AB, AC; // ベクトル

    public GameObject target; // 追いかける対象
    private int MoveFlg=0;

    private float speed = 0; // 移動スピード
    private float maxRot = 0; // 曲がる最大角度

    private Transform Destination;  //到着地


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        switch(MoveFlg)
        {
            case 0:
                speed = 0f;
                maxRot = 0f;
                break;
            case 1:
                Move(Sita()); // 移動処理
               
                break;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "point":
                if (this.gameObject.GetComponent<CircleCollider2D>().enabled == false)
                {
                    Debug.Log("in2");
                    this.gameObject.GetComponent<CircleCollider2D>().enabled = true;
                }
                break;
            case "Player":
                Debug.Log("in");

                //移動スピードと曲がる最大角度を設定
                speed = Random.Range(1.0f, 1.5f);
                maxRot = Random.Range(2.5f, 3.0f);

                Destination = collision.gameObject.transform;       //到着地をプレイヤーをサーチした位置に設定
                target.transform.position = Destination.position;   //ターゲットを到着地に設定
                MoveFlg = 1;
                this.gameObject.GetComponent<CircleCollider2D>().enabled = false; //プレイヤサーチ用のCircleColliderをfalse
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    //-----------------------------------------------------------------------------------------------
    // なす角θを求める
    //-----------------------------------------------------------------------------------------------
    float Sita()
    {

        A = transform.position; // 自身の座標
        C = target.transform.position; // ターゲットの座標

        AB = transform.up; // 自身の上方向ベクトル
        AC = C - A; // ターゲットの方向ベクトル

        float dot = Vector3.Dot(AB, AC); // 内積
        float rot = Acosf(dot / (Length(AB) * Length(AC))); // アークコサインからθを求める

        // 外積から回転方向を求める
        if (AB.x * AC.y - AB.y * AC.x < 0)

        {
            rot = -rot;
        }

        return rot * 180f / Mathf.PI; // ラジアンからデグリーに変換して角度を返す
    }

    //-----------------------------------------------------------------------------------------------
    // 移動処理
    //-----------------------------------------------------------------------------------------------
    void Move(float rot)
    {
        // 求めた角度が曲がる最大角度より大きかった場合に戻す処理
        if (rot > maxRot)

        {
            rot = maxRot;
        }
        else if (rot < -maxRot)
        {
            rot = -maxRot;
        }

        transform.eulerAngles += new Vector3(0, 0, rot); // 回転
        GetComponent<Rigidbody2D>().velocity = AB * speed; // 上に移動
    }

    /// <summary>
    /// ベクトルの長さを求める
    /// </summary>
    /// <param name="vec">2点間のベクトル</param>
    /// <returns></returns>
    float Length(Vector2 vec)
    {
        return Mathf.Sqrt(vec.x * vec.x + vec.y * vec.y);
    }

    /// <summary>
    /// Acosの引数の値が+-1を越えたとき1に戻すAcos関数
    /// </summary>
    /// <param name="a">内積 / （ベクトルの長さ * ベクトルの長さ）</param>
    /// <returns></returns>
    float Acosf(float a)
    {
        if (a < -1) a = -1;
        if (a > 1) a = 1;

        return (float)Mathf.Acos(a);
    }

}
