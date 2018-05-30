using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mandragora : MonoBehaviour
{
    //定数
    const float ClickMaxTime = 2.0f;
    const float MouseDistanceY = 1.5f;
    //変数
    public enum CalotteType { FLEE, KEEP, RESET, FALL };
    [SerializeField]
    GameObject Player;
    bool KeepFlg;
    public CalotteType ctype;
    [SerializeField]
    float ClickTime;

    //落下用変数
    public enum FallStatus { FALL, OROORO, FLIGHT };
    public FallStatus fallStatus;
    public float MoveSpeed = 0.04f;
    public float FlightSpeed = 0.08f;
    public float LatencyMaxTime = 0.5f;
    public float OroOroTime = 1.0f;
    private float LatencyTime;
    private float PositionX, PositionY, PositionZ;
    //以下の関数はすべてprivateなので省略します。

    void Start()
    {
        Player = GameObject.Find("RotationManager");
        ClickTime = 0.0f;
        KeepFlg = false;
        LatencyTime = 0.0f;
    }

    void Initialize()
    {
        ClickTime = 0.0f;
        KeepFlg = false;
    }

    void Update()
    {
        switch (ctype)
        {
            case CalotteType.FLEE:
                if (Input.GetMouseButton(0))
                {
                    if (KeepFlg)
                    {
                        ClickTime += Time.deltaTime;
                        if (ClickTime >= ClickMaxTime)
                        {
                            SetParent();
                            ctype = CalotteType.KEEP;
                        }
                    }
                }
                break;

            case CalotteType.KEEP:  //揺れる

                if (Input.GetMouseButtonUp(0))
                {
                    ctype = CalotteType.RESET;
                }
                break;

            case CalotteType.RESET:  //揺れる
                NoneParent();
                PositionX = this.gameObject.transform.position.x;
                PositionY = this.gameObject.transform.position.y;
                PositionZ = this.gameObject.transform.position.z;
                ctype = CalotteType.FALL;
                break;

            case CalotteType.FALL:
                switch (fallStatus)
                {
                    case FallStatus.FALL:
                        if (LatencyTime <= LatencyMaxTime)
                        {
                            LatencyTime += Time.deltaTime;
                            this.gameObject.transform.position -= new Vector3(0, MoveSpeed, 0);
                        }
                        else
                        {
                            fallStatus = FallStatus.OROORO;
                            LatencyTime = 0.0f;
                        }
                        break;

                    case FallStatus.OROORO:
                        if (LatencyTime <= OroOroTime)
                        {
                            LatencyTime += Time.deltaTime;
                        }
                        else
                        {
                            fallStatus = FallStatus.FLIGHT;
                            LatencyTime = 0.0f;
                        }
                        break;

                    case FallStatus.FLIGHT:
                        if (this.gameObject.transform.position.x >= 0)
                        {
                            this.gameObject.transform.position += new Vector3(FlightSpeed, 0.0f, 0.0f);
                        }
                        else
                        {
                            this.gameObject.transform.position -= new Vector3(FlightSpeed, 0.0f, 0.0f);
                        }
                        if (!GetComponent<SpriteRenderer>().isVisible)
                        {
                            Destroy(this.gameObject);
                        }
                        break;
                }

                break;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            KeepFlg = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Initialize();
        }
    }

    void SetParent()
    {
        gameObject.transform.parent = Player.transform;
        gameObject.transform.position += new Vector3(0.0f, MouseDistanceY, 0.0f);
    }
    void NoneParent()
    {
        gameObject.transform.parent = null;
        //gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
}
