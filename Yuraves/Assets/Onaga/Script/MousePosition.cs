using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    private GameObject Mouse = null;
    private Vector3 Screenmousepos;
    private Vector3 Worldmousepos;

    public float TimeCounter;
    public const float TimeSpan = 0.1f;
    [SerializeField]
    public static float TolVector = 0.0f;
    public enum XDStatus{ initial = -1, right = 0, left};
    public static XDStatus XDMode;

    private bool Status = false;//false 停止, true 動いてる
    private float OldX, OldY;

    void Start()
    {
        Mouse = this.gameObject;
        OldX = OldY = 0.0f;
    }
    void Initialize()
    {
        TimeCounter = 0.0f;
    }

    void Update()
    {
        //マウス座標を取得　&　カメラ基準へ変換
        Screenmousepos = Input.mousePosition;
        Worldmousepos = Camera.main.ScreenToWorldPoint(Screenmousepos);

        //カメラより前に変更し自身オブジェクトへ
        Worldmousepos.z = 0.0f;
        Mouse.transform.position = Worldmousepos;
        //Debug.Log(Worldmousepos);

        TimeCounter += Time.deltaTime;
        
        if (TimeCounter >= TimeSpan)
        {
            if (OldX == Mouse.transform.position.x && OldY == Mouse.transform.position.y)
            {
                Status = false;
            }
            else
            {
                Status = true;
            }
            VectorCalculation();
        }
        if (XDMode != XDStatus.initial)
        {
            if (Status == false)
            {
                XDMode = XDStatus.initial;
            }
        }
    }

    void VectorCalculation()
    {
        float x;
        float y;
        x = OldX - Mouse.transform.position.x;
        y = OldY - Mouse.transform.position.y;
        if (x < 0.0f)
        {
            x = x * -1;
            XDMode = XDStatus.right;
        }
        else if(x > 0.0f)
        {
            XDMode = XDStatus.left;
        }
        if (y < 0.0f)
        {
            y = y * -1;
        }
        TolVector = x + y;
        OldX = Mouse.transform.position.x;
        OldY = Mouse.transform.position.y;
        Initialize();
    }
}
