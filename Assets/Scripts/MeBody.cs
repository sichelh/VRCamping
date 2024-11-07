using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeBody : MonoBehaviour
{
    private Transform head;
    private Transform body;

    void Start()
    {
        head = Camera.main.transform;
        body = transform.Find("MeBody");
    }
    void Update()
    {
        body.transform.rotation = Quaternion.Euler(new Vector3(90.0f,head.transform.eulerAngles.y, 0.0f));
    }
}
