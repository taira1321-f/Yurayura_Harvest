using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManCon : MonoBehaviour 
{
    
    [SerializeField]
    private GameObject HotSpring;

    //enum型を使うにはまずenumクラスを用意する	
	public enum SpringType{
		HotSpring1,
		HotSpring2,
		HotSpring3,
		HotSpring4
	}

    public SpringType springType;

    void Start()
    {
        HotSpring = GameObject.FindGameObjectWithTag("Spring");
    }
    
    void Update()
    {
    }
    void OnCollisionEnter2D(Collision2D collision) 
    {
        switch(springType)

           // case Spring

        //衝突判定
        //if (HotSpring.name == "Spring") 
        //{
            //相手のタグがSpringならば、自分を消す
            //Destroy(HotSpring);
        //}
    }
}
