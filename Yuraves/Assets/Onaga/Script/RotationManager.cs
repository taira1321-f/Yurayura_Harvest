using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Onaga;

public class RotationManager : MonoBehaviour
{
    private const float MaxVector = 2.5f;   //移動スピード上限
    private const float MoveSpeed = 2.88f;  //傾きのスピード
    private const float MaxRotation = 120.0f;   //傾きの上限
    private const float MinRotation = 240.0f;   //傾きの下限
    private const float StopperRotation = 180.0f;   //傾きの判定用の数値

    private const float ZeroSet = 5.0f;     //動いていないときの戻る間隔
    private const float MinSpeed = 0.0f;
    private const float MaxSpeed = 10.0f;

    public enum ChildCount { none, child };         //子供がいるかいないか
    private enum PositionInit { right, left, zero };//移動方向が右か左か動いていないか
    public static ChildCount childmode;
    private PositionInit positionInit;
    private float InitVactor;   //動いていないときの戻る数値
    private float VectorCounter;
    private float saveVector;
    private float InitSpeed = 0.0f; //動かしていないときの戻る速さ
    private float SpeedAddition;    //揺れるスピード加算を入れる変数
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
        //子供がいるかいないか
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
                switch (Onaga.MousePosition.XDMode)
                {
                    //右に移動中
                    case Onaga.MousePosition.XDStatus.right:
                        if (MinRotation < transform.eulerAngles.z || MaxRotation >= (int)transform.eulerAngles.z)
                        {
                            transform.eulerAngles -= new Vector3(0, 0, Onaga.MousePosition.TolVector * MoveSpeed);
                            if (MinRotation >= transform.eulerAngles.z && StopperRotation <= transform.eulerAngles.z)
                            {
                                transform.eulerAngles = new Vector3(0, 0, MinRotation);
                            }
                        }
                        SlopeVector(transform.eulerAngles.z);
                        ReleaseChild();
                        break;
                    //左に移動中
                    case Onaga.MousePosition.XDStatus.left:
                        if (MaxRotation > transform.eulerAngles.z || StopperRotation <= (int)transform.eulerAngles.z)
                        {
                            transform.eulerAngles += new Vector3(0, 0, Onaga.MousePosition.TolVector * MoveSpeed);
                            if (MaxRotation <= transform.eulerAngles.z && StopperRotation >= transform.eulerAngles.z)
                            {
                                transform.eulerAngles = new Vector3(0, 0, MaxRotation);
                            }
                        }
                        SlopeVector(transform.eulerAngles.z);
                        ReleaseChild();
                        break;

                    //移動していない
                    case Onaga.MousePosition.XDStatus.initial:
                        int roopcount = 1;

                        if (VectorCounter > 0.0f)
                        {
                            switch (positionInit)
                            {
                                case PositionInit.left:
                                    if (VectorCounter > roopcount * (int)ZeroSet)
                                    {
                                        transform.eulerAngles += new Vector3(0, 0, SpeedManager());
                                        VectorCounter -= SpeedManager();
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
                                        transform.eulerAngles -= new Vector3(0, 0, SpeedManager());
                                        VectorCounter -= SpeedManager();
                                    }
                                    else
                                    {
                                        roopcount++;
                                        saveVector -= ZeroSet;
                                        VectorCounter = saveVector;
                                        positionInit = PositionInit.left;
                                    }
                                    break;

                                case PositionInit.zero:
                                    transform.eulerAngles = new Vector3(0, 0, 0);
                                    break;
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
        if (MaxVector < Onaga.MousePosition.TolVector)
        {
            foreach (Transform child in transform)
            {
                child.GetComponent<Mandragora>().ctype = Mandragora.CalotteType.RESET;
            }
        }
    }

    //euler角をangle角に変換
    void SlopeVector(float Vector)
    {

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
        SpeedAddition = MaxSpeed / VectorCounter;
    }
    //戻る速度を計算
    float SpeedManager()
    {
        float HalfAddition = saveVector / 2;

        if (VectorCounter == saveVector)
        {
            InitSpeed = MinSpeed;
        }
        if (VectorCounter > HalfAddition)
        {
            InitSpeed += SpeedAddition;
        }
        if (VectorCounter < HalfAddition)
        {
            InitSpeed -= SpeedAddition;
        }
        return InitSpeed;
    }
}
