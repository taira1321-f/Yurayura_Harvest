using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManCon : MonoBehaviour 
{
    
    [SerializeField]
    private GameObject HotSpring1;
    private GameObject HotSpring2;
    private GameObject HotSpring3;
    private GameObject HotSpring4;

    private GameObject Mandoragora;

    //enum型を使うにはまずenumクラスを用意する	
	public enum SpringType{
		Hot1,
		Hot2,
		Hot3,
		Hot4
	}

    public SpringType springType;

    void Start()
    {
        HotSpring1 = GameObject.Find("HotSpring1");
        HotSpring2 = GameObject.Find("HotSpring2");
        HotSpring3 = GameObject.Find("HotSpring3");
        HotSpring4 = GameObject.Find("HotSpring4");
        Mandoragora = GameObject.FindGameObjectWithTag("Calotte");
    }
    
    void Update()
    {
    }
    void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.name == "HotSpring1")
        {
            springType = SpringType.Hot1;

        }else if(collision.gameObject.name == "HotSpring2")
        {
            springType = SpringType.Hot2;

        }else if(collision.gameObject.name == "HotSpring3")
        {
            springType = SpringType.Hot3;

        }
        else if(collision.gameObject.name == "HotSpring4")
        {
            springType = SpringType.Hot4;
        }

        switch(springType){

            case SpringType.Hot1:
                Destroy(this.Mandoragora);
                break;
            case SpringType.Hot2:
                Destroy(this.Mandoragora);
                break;
            case SpringType.Hot3:
                Destroy(this.Mandoragora);
                break;
            case SpringType.Hot4:
                Destroy(this.Mandoragora);
                break;

        }

    }
}
