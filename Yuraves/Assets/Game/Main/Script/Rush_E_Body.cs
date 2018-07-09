using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rush_E_Body : MonoBehaviour {
    public GameObject snd;
<<<<<<< HEAD
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

>>>>>>> 3f050ed7a6488efa38676b220683cf09fc7f5233
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.transform.tag == "target")
        {
<<<<<<< HEAD
=======
            Collisionparticle.Play();
>>>>>>> 3f050ed7a6488efa38676b220683cf09fc7f5233
            col.GetComponent<MandState>().ctype = MandState.CalotteType.RESET;
            snd.GetComponent<SoundsManager>().Boar_V(4);
        }
    }
}
