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
            
            enabled = false;
            return;
        }
        //nextendPosition = endPosition;
        startTime = Time.timeSinceLevelLoad;
        startPosition = transform.position;
        nextendPosition = startPosition;
    }

    void Update()
    {
        var diff = Time.timeSinceLevelLoad - startTime;
        if (diff > time)
        {
            transform.position = endPosition;
            enabled = false;
        }

        var rate = diff / time;
        //var pos = curve.Evaluate(rate);

        transform.position = Vector2.Lerp(startPosition, endPosition, rate);
        //transform.position = Vector3.Lerp (startPosition, endPosition, pos);
    }

    void OnDrawGizmosSelected()
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
