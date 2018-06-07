﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing_Enemy : MonoBehaviour {

    Vector2 A, C, AB, AC; // ベクトル
    public GameObject MouseChild;
    public Transform Center;
    Transform target; // 追いかける対象
    private float speed = 0; // 移動スピード
    private float maxRot = 0; // 曲がる最大角度

    // Use this for initialization
    void Start() { }

    // Update is called once per frame
    void Update() { }

    private void OnTriggerStay2D(Collider2D collision)
    {
        int childcnt = MouseChild.transform.childCount;
        if (childcnt == 0) target = Center;
        else{
            Transform tf = MouseChild.transform.GetChild(0);
            target = tf;
        }
        speed = Random.Range(0.5f, 1.0f);
        maxRot = Random.Range(1.0f, 1.5f);
        Move(Sita()); // 移動処理
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