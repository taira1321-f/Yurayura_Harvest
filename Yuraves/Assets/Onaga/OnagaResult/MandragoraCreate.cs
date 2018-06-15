using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MandragoraCreate : ManragoraBase
{
    private const float Side = 1.0f;//x の間隔
    private const float Width = 1.8f;
    private const float LengthY = 3.8f;
    private const float InitX = -7.0f;
    private const float FirstX = -2.0f;
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
                PositionXVector = LengthY - (float)x * Width;
                break;
            case 1:
                PositionXVector = LengthY - (float)x * Width;
                break;
            case 2:
                PositionXVector = LengthY - (float)x * Width;
                break;
            case 3:
                PositionXVector = LengthY - (float)x * Width;
                break;
            case 4:
                PositionXVector = LengthY - (float)x * Width;
                break;
            case 5:
                PositionXVector = LengthY - (float)x * Width;
                break;
        }

        return PositionXVector;
    }
}
