using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject TutoUI;
    public Text TutoText;
    public Text TutoText2;

    private int Phase=0;

    float timer=0;
    int waitingTime;

    void Start()
    {
        timer=0;
        waitingTime=10;
        TutoText.GetComponent<Text>().text= "VR 캠핑 체험에 오신 것을 환영합니다.";
        TutoText2.GetComponent<Text>().text = "하단의 버튼을 응시하여 걸을 수 있습니다.";
        Phase =0;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if(Phase==2)
        {
            TutoUI.GetComponent<Canvas>().enabled=true;
            TutoText.GetComponent<Text>().text= "캠핑장에서는 모닥불을 켜고 의자에 앉거나 해먹에 누울 수 있습니다.";
            TutoText2.GetComponent<Text>().text = "기타를 연주할 수 있고 랜턴을 들어서 불을 킬 수도 있습니다.";
            Phase =3;
            
        }
   
        if(timer > waitingTime)
        {
            //Action
            if(Phase==0)
            {
                TutoText.GetComponent<Text>().text= "멀리 바다가 보이는 정면으로 가면 캠핑장이 나옵니다.";
                TutoText2.GetComponent<Text>().text = "뒤로 돌아서 가면 꽃밭이 있는 동굴로 들어갈 수 있습니다.";
                Phase =1;
            }
            else if(Phase==1)
            {
                TutoUI.GetComponent<Canvas>().enabled=false;
                if(GameObject.Find("Player").transform.position.x<80)
                    Phase=2;
            }
            else if(Phase==3)
            {
                TutoUI.GetComponent<Canvas>().enabled=false;
            }
            timer = 0;
        }
        /*
        if(GameObject.Find("Player").GetComponent<LookMoveTo>.isMove==true)
        {

        }*/


    }
}
