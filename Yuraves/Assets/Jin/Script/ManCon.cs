using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManCon : MonoBehaviour {
   

    void Start()
    {

    }
    
    void Update()
    {

    }
    void OnCollisionEnter(Collision collision) {
        //衝突判定
        if (collision.gameObject.tag == "Spring") {
            //相手のタグがSpringならば、自分を消す
            Destroy(this.gameObject);
        }
    }
}
