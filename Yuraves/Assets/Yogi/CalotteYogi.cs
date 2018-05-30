using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalotteYogi : MonoBehaviour
{
    //定数
    private const float ClickMaxTime = 1.0f;
    private const float MouseDistanceY = -1.5f;
    enum CalotteType { FLEE, KEEP };
    //変数
    [SerializeField]
    private GameObject Player;
    public bool KeepFlg;
    CalotteType ctype;
    [SerializeField]
    private float ClickTime;


    //以下の関数はすべてprivateなので省略します。

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        ClickTime = 0.0f;
        KeepFlg = false;
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

            case CalotteType.KEEP:

                if (Input.GetMouseButtonUp(0))
                {
                    NoneParent();
                    ctype = CalotteType.FLEE;
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
    }
}
