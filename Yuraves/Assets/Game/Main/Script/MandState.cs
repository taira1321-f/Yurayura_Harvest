using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MandState : MonoBehaviour{
    //定数
    const float ClickMaxTime = 0.5f;
    const float MouseDistanceY = 1.5f;
    //変数
    public enum CalotteType { FLEE, KEEP, RESET, FALL };
    [SerializeField]
    GameObject Player;
    GameObject GM;
    GameObject GD;
    SizeManager SM;
    public GameObject Sound;
    public Sprite[] Mand;
    bool KeepFlg;
    public CalotteType ctype;
    float ClickTime;
    //落下用変数
    public enum FallStatus { FALL, OROORO, FLIGHT };
    public FallStatus fallStatus;
    public float MoveSpeed = 0.04f;
    public float FlightSpeed = 0.08f;
    public float LatencyMaxTime = 0.5f;
    public float OroOroTime = 1.0f;
    private float LatencyTime;
    int sndCnt;
    bool enemyflg;
    int AnimeCnt;
    bool AnimeFlg;
    //以下の関数はすべてprivateなので省略します。

    void Start(){
        GM = GameObject.FindGameObjectWithTag("Spawn");
        GD = GameObject.Find("Director");
        Player = GameObject.Find("RotationManager");
        Sound = GameObject.Find("SoundsSE");
        SM = GetComponent<SizeManager>();
        ClickTime = 0.0f;
        KeepFlg = false;
        LatencyTime = 0.0f;
        sndCnt = 0;
        AnimeCnt = 0;
    }

    void Initialize(){
        ClickTime = 0.0f;
        KeepFlg = false;
    }

    void Update(){
        if (GD.GetComponent<Director>().gameMode != Director.MODE.PLAY) return;
        switch (ctype){
            case CalotteType.FLEE:
                if (Input.GetMouseButton(0)){
                    if (KeepFlg){
                        ClickTime += Time.deltaTime;
                        if (sndCnt == 0){
                            Sound.GetComponent<SoundsManager>().Mandragora(0, 0);
                            sndCnt = 1;
                        }
                        if (ClickTime >= ClickMaxTime){
                            SetParent();
                            GetComponent<SpriteRenderer>().sprite = Mand[0];
                            if (sndCnt == 1){
                                Sound.GetComponent<SoundsManager>().Mandragora(2, sndCnt);
                                sndCnt = 2;
                            }else if (sndCnt == 2){
                                Sound.GetComponent<SoundsManager>().Mandragora(2, sndCnt);
                                sndCnt = 2;
                            }
                            this.GetComponent<HarvestEffect>().EffectPlay();
                            ctype = CalotteType.KEEP;
                        }
                    }
                }
                break;
            case CalotteType.KEEP:  //揺れる
                if (Input.GetMouseButtonUp(0)) ctype = CalotteType.RESET;
                break;
            case CalotteType.RESET:  //揺れる
                NoneParent();
                ctype = CalotteType.FALL;
                gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
                break;

            case CalotteType.FALL:
                switch (fallStatus){
                    case FallStatus.FALL:
                        GetComponent<SpriteRenderer>().sprite = Mand[0];
                        if (this.gameObject.transform.position.x >= 0) AnimeFlg = true;
                        else AnimeFlg = false;
                        if (LatencyTime <= LatencyMaxTime){
                            LatencyTime += Time.deltaTime;
                            this.gameObject.transform.position -= new Vector3(0, MoveSpeed, 0);
                        }else{
                            fallStatus = FallStatus.OROORO;
                            LatencyTime = 0.0f;
                        }
                        break;
                    case FallStatus.OROORO:
                        Flight_Anime();
                        if (LatencyTime <= OroOroTime) LatencyTime += Time.deltaTime;
                        else{
                            fallStatus = FallStatus.FLIGHT;
                            LatencyTime = 0.0f;
                        }
                        break;
                    case FallStatus.FLIGHT:
                        Flight_Anime();
                        if (this.gameObject.transform.position.x >= 0) this.gameObject.transform.position += new Vector3(FlightSpeed, 0.0f, 0.0f);
                        else this.gameObject.transform.position -= new Vector3(FlightSpeed, 0.0f, 0.0f);
                        if (gameObject.transform.position.x >= 4.0f || gameObject.transform.position.x <= -4.0f
                            || gameObject.transform.position.y >= 6.0f || gameObject.transform.position.y <= -5.5f){
                            GameObject go = GameObject.FindGameObjectWithTag("Spawn");
                            go.GetComponent<MandGeneretor>().MandGene(gameObject.transform.name);
                            Destroy(gameObject);
                        }
                        break;
                }
                break;
        }
    }
    void Flight_Anime(){
        AnimeCnt++;
        if (AnimeFlg){
            if (AnimeCnt > 24){
                AnimeCnt = 0;
                GetComponent<SpriteRenderer>().sprite = Mand[3];
            }
            else if (AnimeCnt > 12) GetComponent<SpriteRenderer>().sprite = Mand[4];
        }else{
            if (AnimeCnt > 24){
                AnimeCnt = 0;
                GetComponent<SpriteRenderer>().sprite = Mand[5];
            }else if (AnimeCnt > 12) GetComponent<SpriteRenderer>().sprite = Mand[6];
        }
    }
    void OnTriggerStay2D(Collider2D other){
        if (other.tag == "Player") KeepFlg = true;
        //どの温泉に浸かっているかチェック
        GameObject Spring = other.gameObject;
        if (ctype == CalotteType.FALL){
            GM = GameObject.FindGameObjectWithTag("Spawn");
            if (other.gameObject.name == "HotSpring_1") Changer(Spring, 0);
            else if (other.gameObject.name == "HotSpring_2") Changer(Spring, 1);
            else if (other.gameObject.name == "HotSpring_3") Changer(Spring, 2);
            else if (other.gameObject.name == "HotSpring_4") Changer(Spring, 3);
        }
    }
    void Changer(GameObject sp, int i){
        sp.GetComponent<ChangeImage>().ChangeStateToHold(); //温泉の画像差し替え
        sp.GetComponent<BoxCollider2D>().enabled = false;   //当たり判定消す
        AddScore();
        GM.GetComponent<MandGeneretor>().HotSpringFlag[i] = true;
        GM.GetComponent<MandGeneretor>().MandGene(gameObject.transform.name);
    }
    void AddScore(){
        Director.MandCont++;
        int om = gameObject.GetComponent<Yogi.ChangeObjectMode>().ObjectMode;
        int mg = SM.SizePoint;
        int add = 0;
        if (om == 1) add += 50;
        else if (om == 2) add += 30;
        else if (om == 3) add += 10;
        if (mg == 0) add *= (mg + 1);
        else add *= mg;
        Director.Score += add;

    }
    void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.CompareTag("Spring") && ctype == CalotteType.FALL) Destroy(gameObject);
        if (other.tag == "Player") Initialize();
    }
    void SetParent(){
        gameObject.transform.parent = Player.transform;
        gameObject.transform.position = new Vector3(Player.transform.position.x,
            Player.transform.position.y, Player.transform.position.z);
        gameObject.transform.position -= new Vector3(0.0f, MouseDistanceY, 0.0f);

    }
    void NoneParent(){
        gameObject.transform.parent = null;
    }
}
