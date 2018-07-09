using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MandoragoraDraw : MonoBehaviour
{
    public int CatchMandoragoraCreate;
    public int MaxMandoragoraCreate;
    public GameObject Mandragora;
<<<<<<< HEAD
    private int[,] DrawCounter;
    private int CounterX, CounterY;
=======
    int CounterX;
    int CounterY;
>>>>>>> 3f050ed7a6488efa38676b220683cf09fc7f5233
    private bool CreateFlg = true;
    private int CreateCouter;
    void Start(){
        CatchMandoragoraCreate = Director.MandCont;
        MaxMandoragoraCreate = 30;
        CounterY = MaxMandoragoraCreate / 5;
        CounterX = MaxMandoragoraCreate / CounterY;
<<<<<<< HEAD
        DrawCounter = new int[CounterX, CounterY];
=======
>>>>>>> 3f050ed7a6488efa38676b220683cf09fc7f5233
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
