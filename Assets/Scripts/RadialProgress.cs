using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialProgress : MonoBehaviour
{
    public float timeToSelect = 3.0f; //UI 나올때까지의 시간
    private float countDown = 0;

    public Image LoadingBar;
    float currentValue = 0;

    public GameObject MainCamera;

    private void Start()
    {
        LoadingBar.fillAmount = 0;
        currentValue = 0;
        countDown = timeToSelect;
    }

    private void Update()
    {
        Transform camera = Camera.main.transform;
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit) && (hit.transform.gameObject.tag == "InteractObj" || hit.transform.gameObject.tag == "Button"))
        {
            if (countDown < 0.0f)
            {
                LoadingBar.fillAmount = 0;
                countDown = timeToSelect;
                currentValue = 0;
            }
            else
            {
                if (MainCamera.activeSelf == true)
                {
                    if (currentValue < 2)
                    {
                        currentValue += Time.deltaTime;
                    }
                    LoadingBar.fillAmount = currentValue / 2;
                    countDown -= Time.deltaTime;
                }
                else 
                {
                    if (Physics.Raycast(ray, out hit) && (hit.transform.gameObject.tag == "Button"))
                    {
                        if (currentValue < 2)
                        {
                            
                            currentValue += Time.deltaTime;
                        }
                        LoadingBar.fillAmount = currentValue / 2;
                        countDown -= Time.deltaTime;
                    }
                    else
                    {
                        LoadingBar.fillAmount = 0;
                        currentValue = 0;
                    }
                }
                
            }
        }
        else //오브젝트 안보고있을 때 꺼져있음
        {
            countDown = timeToSelect;
            LoadingBar.fillAmount = 0;
            currentValue = 0;
        }

    }
    

}
