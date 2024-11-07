using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class ButtonLantern : MonoBehaviour
{
    public float timeToSelectUI = 2.0f;   //버튼 클릭하는 시간
    private float countDownUI;
    private GameObject currentButton;
    private Clicker clicker = new Clicker();


    // Update is called once per frame

    void Update()
    {
        //강의노트4에 있는 ButtonExecute 스크립트(버튼 응시하면 하이라이트 해주는거)
        Transform camera = Camera.main.transform;
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;
        GameObject hitButton = null;
        PointerEventData data = new PointerEventData(EventSystem.current);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.tag == "Button")
            {
                hitButton = hit.transform.parent.gameObject;
            }
        }
        if (currentButton != hitButton)
        {
            if (currentButton != null)
            {
                ExecuteEvents.Execute<IPointerExitHandler>(currentButton, data, ExecuteEvents.pointerExitHandler);
            }
            currentButton = hitButton;
            if (currentButton != null)
            {
                ExecuteEvents.Execute<IPointerEnterHandler>(currentButton, data, ExecuteEvents.pointerEnterHandler);

                countDownUI = timeToSelectUI;
            }
        }
        if (currentButton != null)
        {
            countDownUI -= Time.deltaTime;
            if (clicker.clicked() || countDownUI < 0.0f)
            {
            ExecuteEvents.Execute<IPointerClickHandler>(currentButton, data, ExecuteEvents.pointerClickHandler);
            countDownUI = timeToSelectUI;
            }
        }
    }
}
