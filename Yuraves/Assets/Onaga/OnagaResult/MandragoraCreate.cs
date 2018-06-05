using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MandragoraCreate : ManragoraBase
{
    private const float Side = 1.2f;
    private const float Length = 3.0f;
    private const float InitX = -7.0f;
    private const float FirstX = -5.5f;
    private const float MoveSpeed = 0.1f;

    private bool MoveFlg = true;

    void Start()
    {
        GetPosition();
        this.gameObject.transform.position = new Vector3(InitX, SetY(PositionY), 0.0f);
    }

    void Update()
    {
        if (MoveFlg)
        {
            this.gameObject.transform.position += new Vector3(MoveSpeed, 0.0f, 0.0f);
            if (this.gameObject.transform.position.x > FirstX + (float)PositionX * Side)
            {
                this.gameObject.transform.position = new Vector3(FirstX + (float)PositionX * Side, SetY(PositionY), 0.0f);
                MoveFlg = false;
            }
        }
    }

    float SetY(int x)
    {
        float PositionXVector = 0.0f;
        switch (x)
        {
            case 0:
                PositionXVector = Length;
                break;

            case 1:
                PositionXVector = 0.0f;
                break;

            case 2:
                PositionXVector = -Length;
                break;
        }

        return PositionXVector;
    }
}
