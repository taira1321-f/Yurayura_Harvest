using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mandragora : MonoBehaviour
{
    //定数
    const float ClickMaxTime = 2.0f;
    const float MouseDistanceY = 0.05f;
    public enum CalotteType { FLEE, KEEP, RESET };
    //変数
    public GameObject Player;
    bool KeepFlg;
    public CalotteType ctype;
    float ClickTime;

    void Start()
    {
        Player = GameObject.Find("RotationManager");
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
            case CalotteType.KEEP:  //揺れる

                if (Input.GetMouseButtonUp(0))
                {
                    ctype = CalotteType.RESET;
                }
                break;
            case CalotteType.RESET:  //揺れる
                NoneParent();
                ctype = CalotteType.FLEE;
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
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
}
