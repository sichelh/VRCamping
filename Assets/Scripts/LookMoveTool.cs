using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookMoveTool : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Camera;
    public Transform infoBubble;

    void Start () {
    }


    // Update is called once per frame
    void Update()

    
    {
    infoBubble.LookAt (Camera.transform.position);
    //infoBubble.Rotate (0.0f, 180.0f, 0.0f);
    }

}
        
        
