using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationManager : MonoBehaviour
{
    private const float MaxVector = 2.5f;
    private const float MoveSpeed = 2.88f;
    private const float VectorOne = 0.25f;
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
                        transform.eulerAngles -= new Vector3(0, 0, MousePosition.TolVector * MoveSpeed);
                        ReleaseChild();
                        break;

                    case MousePosition.XDStatus.left:
                        transform.eulerAngles += new Vector3(0, 0, MousePosition.TolVector * MoveSpeed);
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
