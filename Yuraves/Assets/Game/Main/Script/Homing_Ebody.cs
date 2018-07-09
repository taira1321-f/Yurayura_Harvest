using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing_Ebody : MonoBehaviour {
    public GameObject snd;
<<<<<<< HEAD
    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.transform.tag == "target"){
=======
    public ParticleSystem Collisionparticle;

    void Start()
    {
        CollisionparticleSet();
    }

    void CollisionparticleSet()
    {
        Collisionparticle = GameObject.Find("/MousePosition/CFX_MagicPoof").GetComponent<ParticleSystem>();
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.transform.tag == "target")
        {
            Collisionparticle.Play();
>>>>>>> 3f050ed7a6488efa38676b220683cf09fc7f5233
            col.GetComponent<MandState>().ctype = MandState.CalotteType.RESET;
            snd.GetComponent<SoundsManager>().Monkey(4);
        }
    }
}
