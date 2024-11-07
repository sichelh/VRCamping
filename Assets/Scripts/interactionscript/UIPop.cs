using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPop : MonoBehaviour
{
    public GameObject whatobj; //바라보면 UI 나오게 할 Object
    public GameObject UI; //팝업 나오는 UI
    
    public float timeToSelect = 3.0f; //UI 나올때까지의 시간
    public float timerToDestory = 10.0f; //UI 자동으로 사라지는 시간
    private float countTimer;
    private float countDown;

    // Start is called before the first frame update
    void Start()
    {
        UI.SetActive(false); //UI 처음엔 안보이게
        countDown = timeToSelect;
        countTimer = timerToDestory;
    }

    // Update is called once per frame
    void Update() //ButtonExecute 참고해서 코드 설정
    {
        Transform camera = Camera.main.transform;
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && (hit.collider.gameObject == whatobj))
        {
            if (countDown < 0.0f)
            {
                UI.SetActive(true); //object timeToSelect시간 동안 바라보면 UI 활성화
            }
            else
            {
                countDown -= Time.deltaTime;
                //print(countDown);
                UI.SetActive(false); //바라보고 있는 동안은 시간 줄어들면서 UI는 안켜져 있음
                
            }
        }
        
        //UI 활성화시킨 후에 오브젝트에서 시야가 벗어났을때 UI가 꺼지는 것을 방지
        else if (UI.activeSelf == true) //UI가 켜져있을 때
        {
            UI.SetActive(true); //UI는 켜진 상태로 유지
            countTimer -= Time.deltaTime;
            if (countTimer < 0.0f) //countTimer가 점점 줄어들다가 0이되면 UI 꺼짐
            {
                UI.SetActive(false);
                countTimer = timerToDestory; //타이머 초기화
                countDown = timeToSelect;
            }   
        }

        else //오브젝트 안보고있을 때 UI 꺼져있음
        {
            countDown = timeToSelect;
            UI.SetActive(false);
        }
    }
}
