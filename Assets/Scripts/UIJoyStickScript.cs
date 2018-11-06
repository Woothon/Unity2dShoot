using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIJoyStickScript : MonoBehaviour {

	// 
	public Vector3 initPosition;

	public float r;

	public Transform border;

	// Use this for initialization
	void Start () {
        border = GameObject.Find("Border").transform;
        initPosition = GetComponentInParent<RectTransform>().position;
        r = Vector3.Distance(transform.position, border.position);
	}

    public void OnDragIng()
    {
        if(Vector3.Distance(Input.mousePosition, initPosition) < r)
        {
            //虚拟键跟随鼠标
            transform.position = Input.mousePosition;
        }
        else
        {
            Vector3 dir = Input.mousePosition - initPosition;
            transform.position = initPosition + dir.normalized * r;
        }
    }

    public void OnDragEnd()
    {
        //松开鼠标虚拟摇杆回到原点
        transform.position = initPosition;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
