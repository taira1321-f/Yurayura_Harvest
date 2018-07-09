using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rush_E_Body : MonoBehaviour {
    public GameObject snd;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.transform.tag == "target")
        {
            col.GetComponent<MandState>().ctype = MandState.CalotteType.RESET;
            snd.GetComponent<SoundsManager>().Boar_V(4);
        }
    }
}
