﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MandoragoraDraw : MonoBehaviour
{
    public int CatchMandoragoraCreate;
    public int MaxMandoragoraCreate;
    public GameObject Mandragora;
    int CounterX;
    int CounterY;
    private bool CreateFlg = true;
    private int CreateCouter;
    void Start(){
        CatchMandoragoraCreate = Director.MandCont;
        MaxMandoragoraCreate = 30;
        CounterY = MaxMandoragoraCreate / 5;
        CounterX = MaxMandoragoraCreate / CounterY;
    }

    void Update(){
        CreateMandoragora();
    }

    void CreateMandoragora()
    {
        if (CreateFlg)
        {
            int count = 0;

            for (int y = 0; CounterY > y; y++)
            {
                for (int x = 0; CounterX > x; x++)
                {
                    if (count < CatchMandoragoraCreate)
                    {
                        GameObject TargetObject;
                        TargetObject = Instantiate(Mandragora, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
                        TargetObject.name = "ReleaseMandragora" + count;
                        TargetObject.GetComponent<MandragoraCreate>().SetPosition(x, y, CounterX, CounterY);
                        count++;
                    }
                }
            }
            CreateFlg = false;
        }
    }
}
