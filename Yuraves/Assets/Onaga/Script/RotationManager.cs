using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationManager : MonoBehaviour
{
    private const float MaxVector = 2.5f;
    private const float MoveSpeed = 2.88f;
    private const float VectorOne = 0.25f;
    private const float MaxRotation = 120.0f;
    private const float MinRotation = 240.0f;
    private const float StopperRotation = 180.0f;

    public enum ChildCount { none, child };
    public static ChildCount childmode;

    void Start()
    {

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
            case ChildCount.none:
                transform.eulerAngles += new Vector3(0, 0, 0);
                break;
            case ChildCount.child:
                float SwayCount = MousePosition.TolVector / VectorOne;
                float SwayLimit = SwayCount * MoveSpeed;
                switch (MousePosition.XDMode)
                {
                    case MousePosition.XDStatus.right:
                        Debug.Log("MinRotation" + MinRotation);
                        Debug.Log("MaxRotation" + MaxRotation);
                        Debug.Log("transform.eulerAngles.z" + transform.eulerAngles.z);
                        if (MinRotation<transform.eulerAngles.z || MaxRotation >= (int)transform.eulerAngles.z)
                        {
                            transform.eulerAngles -= new Vector3(0, 0, MousePosition.TolVector * MoveSpeed);
                            if(MinRotation >= transform.eulerAngles.z && StopperRotation <= transform.eulerAngles.z)
                            {
                                transform.eulerAngles = new Vector3(0, 0, MinRotation);
                            }
                        }
                        ReleaseChild();
                        break;

                    case MousePosition.XDStatus.left:
                        Debug.Log("transform.eulerAngles.z" + transform.eulerAngles.z);
                        if (MaxRotation > transform.eulerAngles.z || StopperRotation <= (int)transform.eulerAngles.z)
                        {
                            transform.eulerAngles += new Vector3(0, 0, MousePosition.TolVector * MoveSpeed);
                            if (MaxRotation <= transform.eulerAngles.z && StopperRotation >= transform.eulerAngles.z)
                            {
                                transform.eulerAngles = new Vector3(0, 0, MaxRotation);
                            }
                        }
                        ReleaseChild();
                        break;
                }
                break;
        }
    }
    //子供を解除
    void ReleaseChild()
    {
        if (MaxVector < MousePosition.TolVector)
        {
            foreach (Transform child in transform)
            {
                child.GetComponent<Mandragora>().ctype = Mandragora.CalotteType.RESET;
            }
        }
    }
}
