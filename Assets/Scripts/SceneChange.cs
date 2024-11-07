using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public Image Fade;
    private bool isT=false;
    int SceneNum=0;
    public GameObject Cave;
    public GameObject SeaSide;
    //public GameObject Cave_Camera;
    public GameObject SeaSide_Camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(isFade)
        {
            FadeOut();
            if(Fade.color.a>=1)
            { */  
            if(isT)
            {
                if (SceneNum==0)//SceneNum == 0)
                {
                    
                    SeaSide_Camera.GetComponent<MainFadeInOut>().Fade();
                    Invoke("InCave", 0.5f);
                }
                else if(SceneNum==1)
                {
                    
                    this.GetComponent<MainFadeInOut>().Fade();
                     Invoke("OutCave", 0.5f);
             
                }
            }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.collider.CompareTag("Teleporte"))
        {
            isT=true;
        }
    }

    void InCave()
    {
         SeaSide_Camera.transform.position=new Vector3(311.8f,7f,-3f);
          SeaSide.SetActive(false);
           Cave.SetActive(true);
            SceneNum=1;
            isT=false;

    }

        void OutCave()
    {
        SeaSide_Camera.transform.position=new Vector3(340f,7f,27f);
        Cave.SetActive(false);
        SeaSide.SetActive(true);
                  SceneNum=0;
                  isT=false;

    }
}
