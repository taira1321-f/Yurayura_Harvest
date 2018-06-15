using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MandoragoraDraw : MonoBehaviour
{
    public int CatchMandoragoraCreate;
    public int MaxMandoragoraCreate;
    public GameObject Mandragora;
    private int[,] DrawCounter;
    private int CounterX, CounterY;
    private bool CreateFlg = true;
    private int CreateCouter;
    void Start()
    {
        //CatchMandoragoraCreate = Director.MandCont;
        CatchMandoragoraCreate = 25;
        MaxMandoragoraCreate = 30;
        CounterY = MaxMandoragoraCreate / 5;
        CounterX = MaxMandoragoraCreate / CounterY;
        DrawCounter = new int[CounterX, CounterY];
    }

    void Update()
    {
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
                        //TargetObject.GetComponent<MandragoraCreate>().Position = new int[x, y];
                        TargetObject.GetComponent<MandragoraCreate>().SetPosition(x, y, CounterX, CounterY);
                        count++;
                    }
                }
            }
            CreateFlg = false;
        }
    }
}
