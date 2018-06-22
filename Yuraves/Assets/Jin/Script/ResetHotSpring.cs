using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetHotSpring : MonoBehaviour {
    public GameObject director;
    //温泉
    public GameObject[] Spring;
    public GameObject MandMane;
    bool[] checkFlg = new bool[4];
    int AnimeCnt;
    public Sprite[] Sprite_sp;
    bool BonusFlg;
    void Start(){
        BonusFlg = false;
        AnimeCnt = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (director.GetComponent<Director>().gameMode != Director.MODE.PLAY) return;
        int i = checkFlg.Length - 1;
        for (; i >= 0; i--) {
            if (checkFlg[i]) SpringAnime(i);
        }
        i = checkFlg.Length - 1;
        for (; i >= 0; i--) checkFlg[i] = GetComponent<MandGeneretor>().HotSpringFlag[i];

        if (AllTrue()) {
            BonusFlg = true;
            Invoke("HotSpringReset", 0.25f); 
        }
	}
    void SpringAnime(int i) {
        Spring[i].GetComponent<SpriteRenderer>().sprite = Sprite_sp[AnimeMandSpring()];
    }
    int AnimeMandSpring()
    {
        AnimeCnt++;
        if (AnimeCnt > 60)
        {
            AnimeCnt = 0;
            return 0;
        }
        else if (AnimeCnt > 30)
        {
            return 1;
        }
        else return 0;
    }
    public bool AllTrue() {
        int cnt = 0;//trueカウンター
        for (int i = 0; i <= 3; i++) {
            if (checkFlg[i]) cnt++;
        }
        if (cnt == 4) {
            return true; 
        }
        else return false;
    }

    public void HotSpringReset()
    {
        //すべてのフラグをfalseへ
        int a = MandMane.GetComponent<MandGeneretor>().HotSpringFlag.Length - 1;
        for (; a >= 0; a--) {
            MandMane.GetComponent<MandGeneretor>().HotSpringFlag[a] = false;
        }
        //すべての温泉の画像切り替えと当たり判定の復活
        int i = Spring.Length - 1;
        for (; i >= 0; i--){
            this.Spring[i].GetComponent<ChangeImage>().ChangeStateToStandby();
            this.Spring[i].GetComponent<BoxCollider2D>().enabled = true;
        }
        if (BonusFlg) {
            BonusFlg = !BonusFlg;
            Director.Score += 50; 
        }
    }

}
