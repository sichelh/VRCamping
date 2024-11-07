using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class ButtonCampfire : MonoBehaviour
{
    public GameObject whatobj; //바라보면 UI 나오게 할 Object
    public float ObjtimeToSelect = 3.0f; //UI 나올때까지의 시간
    private float ObjcountDown;

    public GameObject CampfireUI; //모닥불 UI
    public float timeToSelect = 2.0f;   //버튼 클릭하는 시간
    private float countDown;
    private GameObject currentButton;
    private Clicker clicker = new Clicker();


    // Update is called once per frame

    void Start()
    {
        ObjcountDown = ObjtimeToSelect;
        countDown = timeToSelect;
    }

    void Update()
    {
        //강의노트4에 있는 ButtonExecute 스크립트(버튼 응시하면 하이라이트 해주는거)
        Transform camera = Camera.main.transform;
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;
        GameObject hitButton = null;
        PointerEventData data = new PointerEventData (EventSystem.current);

        //UI 활성화
        if (Physics.Raycast(ray, out hit) && (hit.collider.gameObject == whatobj))
        {
            if (ObjcountDown < 0.0f)
            {
                CampfireUI.SetActive(true); //object timeToSelect시간 동안 바라보면 UI 활성화
            }
            else
            {
                ObjcountDown -= Time.deltaTime;
                print(countDown);
                CampfireUI.SetActive(false); //바라보고 있는 동안은 시간 줄어들면서 UI는 안켜져 있음
            }
        }
        //UI 활성화시킨 후에 오브젝트에서 시야가 벗어났을때 UI가 꺼지는 것을 방지
        else if (CampfireUI.activeSelf == true) //UI가 켜져있을 때
        {
            CampfireUI.SetActive(true); //UI는 켜진 상태로 유지
        }
        else //오브젝트 안보고있을 때 UI 꺼져있음
        {
            ObjcountDown = ObjtimeToSelect;
            CampfireUI.SetActive(false);
        }

        //Button
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
                countDown = timeToSelect;
            }
        }
        if (currentButton != null)
        {
            countDown -= Time.deltaTime;
            if (clicker.clicked() || countDown < 0.0f) //timeToSelect가 0이하면 클릭(버튼 클릭)
            {
                ExecuteEvents.Execute<IPointerClickHandler>(currentButton, data, ExecuteEvents.pointerClickHandler);
                countDown = timeToSelect;
            }
        }
    }
}
