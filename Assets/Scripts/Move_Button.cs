﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Move_Button : MonoBehaviour
{
    public bool isWalking = false;
    public float timeToSelect = 0.05f;
    private float countDown;
    private GameObject currentButton;
    private Clicker clicker = new Clicker ();
    // Update is called once per frame
    void Update () {
    Transform camera = Camera.main.transform;
    Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward );
    RaycastHit hit;
    GameObject hitButton = null;
    PointerEventData data = new PointerEventData(EventSystem.current);
    if (Physics.Raycast (ray, out hit)) {
        if (hit.transform.gameObject.tag == "Button") {
        hitButton = hit.transform.parent.gameObject;
        }
    }

    if (currentButton != hitButton) 
    {
        if (currentButton != null) {
        ExecuteEvents.Execute<IPointerExitHandler> (currentButton, data,ExecuteEvents.pointerExitHandler);
        }
        currentButton = hitButton;
        if (currentButton != null) {
        ExecuteEvents.Execute<IPointerEnterHandler> (currentButton,
        data, ExecuteEvents.pointerEnterHandler);
        countDown = timeToSelect;
        }
    }
    if (currentButton != null) 
    {
        countDown -= Time.deltaTime;
        if (clicker.clicked() || countDown < 0.0f) 
        {
            ExecuteEvents.Execute<IPointerClickHandler> (currentButton,
            data, ExecuteEvents.pointerClickHandler);
            countDown = timeToSelect;
        }
    }
    }
}


