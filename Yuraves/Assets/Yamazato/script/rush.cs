using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rush : MonoBehaviour {

    [SerializeField, Range(0, 10)]
    float time = 1;

    private float startTime;
    private Vector2 startPosition;  //開始位置
    public Vector2 endPosition;     //終わり位置
    private Vector2 nextendPosition;//次の終わり位置
    private int rotetime=0;
    private int R;

    private void Awake()
    {
        nextendPosition = endPosition;
        enabled = false;
    }

    void OnEnable()
    {
        if (time <= 0)
        {
            transform.position = endPosition;
            transform.Rotate(new Vector3(0, 0, 180));
            enabled = false;
            return;
        }
        //nextendPosition = endPosition;
        R = 1;
        startTime = Time.timeSinceLevelLoad;
        startPosition = transform.position;
        nextendPosition = startPosition;
    }

    void Update()
    {
        switch (R)
        {
            case 1:
                var diff = Time.timeSinceLevelLoad - startTime;
                if (diff > time)
                {
                    transform.position = endPosition;
                    R = 2;
                }
                var rate = diff / time;
                //var pos = curve.Evaluate(rate);

                transform.position = Vector2.Lerp(startPosition, endPosition, rate);
                //transform.position = Vector3.Lerp (startPosition, endPosition, pos);
                break;
            case 2:
                rotetime += 1;
                transform.Rotate(new Vector3(0, 0, 1));
                if(rotetime >= 180)
                {
                    rotetime = 0;
                    R = 3;
                }
                break;
            case 3:
                enabled = false;
                break;
            default:
                break;
        }
        
    }

    void OnDrawGizmos()
    {
#if UNITY_EDITOR
        if (enabled == false)
        {
            
            startPosition = transform.position;
            endPosition = nextendPosition;
        }

        UnityEditor.Handles.Label(endPosition, endPosition.ToString());
        UnityEditor.Handles.Label(startPosition, startPosition.ToString());
#endif
        Gizmos.DrawSphere(endPosition, 0.1f);
        Gizmos.DrawSphere(startPosition, 0.1f);

        Gizmos.DrawLine(startPosition, endPosition);
    }

}
