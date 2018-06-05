using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class ManragoraBase : MonoBehaviour{

    [SerializeField]
    public int[,] Position;
    public int PositionX,PositionY;
    private int MaxPositionX, MaxPositionY;

    public void SetPosition(int x, int y, int MaxX, int MaxY)
    {
        MaxPositionX = MaxX;
        MaxPositionY = MaxY;
        Position = new int[MaxPositionX, MaxPositionY];
        Position[x, y] = 1;
    }
    public void GetPosition()
    {
        for(int y = 0; y < MaxPositionY; y++)
        {
            for(int x = 0; x < MaxPositionX; x++)
            {
                if(Position[x, y] == 1)
                {
                    PositionX = x;
                    PositionY = y;
                }
            }
        }
    }
}
