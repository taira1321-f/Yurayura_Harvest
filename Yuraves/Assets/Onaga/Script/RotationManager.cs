﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MPO;

public class RotationManager : MonoBehaviour
{
    private const float MaxVector = 2.5f; //移動スピード上限
    private const float MoveSpeed = 2.88f;//傾きのスピード
    //private const float VectorOne = 0.25f;
    private const float MaxRotation = 120.0f;//傾きの上限
    private const float MinRotation = 240.0f;//傾きの下限
    private const float StopperRotation = 180.0f;//傾きの判定用の数値

    private const float ZeroSet = 10.0f;//動いていないときの戻る間隔
    private const float InitSpeed = 5.0f;//動かしていないときの戻る速さ

    public enum ChildCount { none, child };//子供がいるかいないか
    private enum PositionInit { right, left, zero };//移動方向が右か左か動いていないか
    public static ChildCount childmode;
    private PositionInit positionInit;
    private float InitVactor;//動いていないときの戻る数値
    private float VectorCounter;
    private float saveVector;

    void Start()
    {
        InitVactor = 0.0f;
    }

    void Initialize()
    {
        InitVactor = 0.0f;
    }
    void Update()
    {
        if (this.transform.childCount == 0)
        {
            childmode = ChildCount.none;
        }
        else
        {
            childmode = ChildCount.child;
        }
        SwayMove();
    }
    //caseに応じて揺れるor戻る
    void SwayMove()
    {
        switch (childmode)
        {
            //子供がいない
            case ChildCount.none:
                transform.eulerAngles += new Vector3(0, 0, 0);
                break;
            //子供がいる
            case ChildCount.child:
                //float SwayCount = MousePosition.TolVector / VectorOne;
                //float SwayLimit = SwayCount * MoveSpeed;
                switch (MPO.MousePosition.XDMode)
                {
                    //右に移動中
                    case MPO.MousePosition.XDStatus.right:
                        if (MinRotation < transform.eulerAngles.z || MaxRotation >= (int)transform.eulerAngles.z)
                        {
                            transform.eulerAngles -= new Vector3(0, 0, MPO.MousePosition.TolVector * MoveSpeed);
                            if (MinRotation >= transform.eulerAngles.z && StopperRotation <= transform.eulerAngles.z)
                            {
                                transform.eulerAngles = new Vector3(0, 0, MinRotation);
                            }
                        }
                        SlopeVector(transform.eulerAngles.z);
                        ReleaseChild();
                        break;
                    //左に移動中
                    case MPO.MousePosition.XDStatus.left:
                        if (MaxRotation > transform.eulerAngles.z || StopperRotation <= (int)transform.eulerAngles.z)
                        {
                            transform.eulerAngles += new Vector3(0, 0, MPO.MousePosition.TolVector * MoveSpeed);
                            if (MaxRotation <= transform.eulerAngles.z && StopperRotation >= transform.eulerAngles.z)
                            {
                                transform.eulerAngles = new Vector3(0, 0, MaxRotation);
                            }
                        }
                        SlopeVector(transform.eulerAngles.z);
                        ReleaseChild();
                        break;

                    //移動していない
                    case MPO.MousePosition.XDStatus.initial:
                        int roopcount = 1;
                        if (VectorCounter > 0.0f)
                        {
                            switch (positionInit)
                            {
                                case PositionInit.left:
                                    //Debug.Log(roopcount * ZeroSet);
                                    if (VectorCounter > roopcount * (int)ZeroSet)
                                    {
                                        transform.eulerAngles += new Vector3(0, 0, InitSpeed);
                                        VectorCounter -= InitSpeed;
                                    }
                                    else
                                    {
                                        roopcount++;
                                        saveVector -= ZeroSet;
                                        VectorCounter = saveVector;
                                        positionInit = PositionInit.right;
                                    }
                                    break;

                                case PositionInit.right:
                                    if (VectorCounter > roopcount * (int)ZeroSet)
                                    {
                                        transform.eulerAngles -= new Vector3(0, 0, InitSpeed);
                                        VectorCounter -= InitSpeed;
                                    }
                                    else
                                    {
                                        roopcount++;
                                        saveVector -= ZeroSet;
                                        VectorCounter = saveVector;
                                        positionInit = PositionInit.left;
                                    }
                                    break;
                            }

                            if (VectorCounter - roopcount * ZeroSet < ZeroSet)
                            {

                                Debug.Log("通った");
                                roopcount = 0;
                                InitVactor = 0.0f;
                                transform.eulerAngles -= new Vector3(0, 0, 0);
                            }
                        }
                        break;
                }
                break;
        }
    }
    //子供を解除
    void ReleaseChild()
    {
        if (MaxVector < MPO.MousePosition.TolVector)
        {
            foreach (Transform child in transform)
            {
                child.GetComponent<Mandragora>().ctype = Mandragora.CalotteType.RESET;
            }
        }
    }

    void SlopeVector(float Vector)
    {
        Debug.Log("通ってる");
        if (Vector >= MinRotation)
        {
            positionInit = PositionInit.left;
        }
        else if (Vector <= MaxRotation)
        {
            positionInit = PositionInit.right;
        }
        else if (Vector == 0.0f)
        {
            positionInit = PositionInit.zero;
        }

        switch (positionInit)
        {
            case PositionInit.left:
                InitVactor = 360.0f - transform.eulerAngles.z;
                break;
            case PositionInit.right:
                InitVactor = transform.eulerAngles.z;
                break;
            case PositionInit.zero:
                InitVactor = 0.0f;
                break;
        }
        VectorCounter = saveVector = InitVactor * 2;
    }
}
