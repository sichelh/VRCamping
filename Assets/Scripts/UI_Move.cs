using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Move : MonoBehaviour
{
    // Start is called before the first frame updat
    public GameObject UIview;
    // Update is called once per frame
    void Update()
    {
         this.transform.position=new Vector3(UIview.transform.position.x,5.0f,UIview.transform.position.z);
    }

}