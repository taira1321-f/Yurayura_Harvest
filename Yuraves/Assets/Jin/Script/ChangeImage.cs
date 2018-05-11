using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeImage : MonoBehaviour {
    SpriteRenderer MainSpriteRenderer;
    // publicで宣言し、inspectorで設定可能にする
    public Sprite StandbySprite;
    public Sprite HoldSprite;
    public Sprite SlashSprite;

    private GameObject Mandoragora;

	void Start () {
		//このobjectのSpriteRendererを取得
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        Mandoragora = GameObject.FindGameObjectWithTag("Calotte");
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeStateToHold();
        }
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Mandoragora")
        {
            Debug.Log("画像切り替え");
            ChangeStateToHold();
        }
    }

    void ChangeStateToHold()
    {
        //SpriteRenderのspriteを設定済みの他のspriteに変更
        //例）HoldSpriteに変更
        MainSpriteRenderer.sprite = HoldSprite;
    }
}
