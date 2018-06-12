using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rush_E_Body : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.transform.tag == "target")
        {
            col.GetComponent<MandState>().ctype = MandState.CalotteType.RESET;
        }
    }
}
