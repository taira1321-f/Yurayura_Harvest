using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeImage : MonoBehaviour {
    SpriteRenderer MainSpriteRenderer;
    // publicで宣言し、inspectorで設定可能にする
    public Sprite StandbySprite;
    public Sprite HoldSprite;

	void Start () {
		//このobjectのSpriteRendererを取得
        MainSpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
	}
	void Update () {
	}

    public void ChangeStateToHold()
    {
        //SpriteRenderのspriteを設定済みの他のspriteに変更
        //例）HoldSpriteに変更
        MainSpriteRenderer.sprite = HoldSprite;
    }
    public void ChangeStateToStandby()
    {
        MainSpriteRenderer.sprite = StandbySprite;
    }
}
