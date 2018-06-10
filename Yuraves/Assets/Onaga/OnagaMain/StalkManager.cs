using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkManager : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;//自身のスプライトレンダーを入れるスプライト変数
    [SerializeField]
    private GameObject RotationManager;//ローテーションマネージャーをいれるやつ
    private GameObject TargetObject;//ローテーションマネージャーの子供を検索していれるやつ

    //スプライト入れる変数-----------
    public Sprite YoungMandragora;
    public Sprite MiddleMandragora;
    public Sprite Oldimage2;
    //-------------------------------
    [SerializeField]
    private int MandragoraState;//TargetObjectのObjectMode取得用の変数
    // Use this for initialization
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        TargetObject = null;
    } 

    // Update is called once per frame
    void Update()
    {
        //TargetObject = RotationManager.transform.FindChild("Child").gameObject;
        if (RotationManager.transform.childCount == 0)
        {
            TargetObject = null;
        }
        foreach (Transform transform in RotationManager.transform)
        {
            // Transformからゲームオブジェクト取得・削除
            if (transform.gameObject != null)
            {
                TargetObject = transform.gameObject;
            }
        }

        if (TargetObject != null)
        {
            MandragoraState = TargetObject.GetComponent<Yogi.ChangeObjectMode>().ObjectMode;

            switch (MandragoraState)
            {
                case 1:
                    spriteRenderer.sprite = YoungMandragora;
                    break;

                case 2:
                    spriteRenderer.sprite = MiddleMandragora;
                    break;

            }
        }
        else
        {
            spriteRenderer.sprite = null;
        }
    }
}
