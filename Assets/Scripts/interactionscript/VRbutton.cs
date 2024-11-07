using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRbutton : MonoBehaviour
{
    /*  게임이 로딩중임을 알리는 스크롤바와 텍스트를 관리하는 스크립트입니다. */

    public Text label;
    public UnityEngine.UI.Scrollbar obj_scrollbar_;

    public void Start()
    {
        label.text = "At start func";
    }

    private void Update()
    {

    }

    //시점이 스크롤바에 닿으면 작동하는 함수입니다
    public void PointEnter()
    {
        label.text = "게임 로딩 중";
        StartCoroutine(TimeToAction());
    }

    //시점이 스크롤바를 벗어나면 작동하는 함수입니다.
    public void PointExit()
    {
        label.text = "다시 시도해주세요";
        obj_scrollbar_.size = 0;
        StopAllCoroutines();
    }

    //애니메이션 발생 효과 함수입니다.
    IEnumerator TimeToAction()
    {
        for (float value = 0.0f; value < 1.0f; value += 0.01f)
        {
            obj_scrollbar_.size = value;
            yield return new WaitForEndOfFrame();
        }
        obj_scrollbar_.size = 1.0f;
        Debug.Log("게임시작!");

    }
}
