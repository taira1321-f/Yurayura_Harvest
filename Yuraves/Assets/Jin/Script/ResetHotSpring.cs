using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetHotSpring : MonoBehaviour {
    public GameObject director;
    //温泉
    public GameObject[] Spring;
    private TimerController timercontroller;
    public GameObject MandMane;
    bool[] checkFlg = new bool[4];
     void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (director.GetComponent<Director>().gameMode != Director.MODE.PLAY) return;
        int i = checkFlg.Length - 1;
        for (; i >= 0; i--){
            checkFlg[i] = MandMane.GetComponent<MandGeneretor>().HotSpringFlag[i];
        }
        if (AllTrue())
        {
            Invoke("HotSpringReset", 2);
        }
	}

    bool AllTrue() {
        int cnt = 0;//trueカウンター
        for (int i = 0; i <= 3; i++) {
            if (checkFlg[i]) cnt++;
        }
        if (cnt == 4) return true;
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
        for (; i >= 0; i--)
        {
            this.Spring[i].GetComponent<ChangeImage>().ChangeStateToStandby();
            this.Spring[i].GetComponent<BoxCollider2D>().enabled = true;
        }
    }

}
