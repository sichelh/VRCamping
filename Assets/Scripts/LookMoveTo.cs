using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class LookMoveTo : MonoBehaviour {
    public float velocity = 3.0f;
    // Update is called once per frame
    private bool isMove=false;

    public CharacterController controller;

    public Image ButtonImg;
    public Sprite RunImg;
    public Sprite StandImg;

    private AudioSource footsteps;

    //public Transform H;

    public void ButtonPut()
{
        if(isMove==false)
        {
            isMove=true;
            ButtonImg.sprite=StandImg;
            footsteps.Play();

        }
        else if(isMove==true)
        {
            isMove=false;
            ButtonImg.sprite=RunImg;
            footsteps.Stop();

        }
    }
    void Start () {
        this.transform.position=new Vector3(controller.transform.position.x,7.0f,controller.transform.position.z);
        footsteps = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(isMove)
        {

        Vector3 moveDirection = Camera.main.transform.forward;
        //Vector3 moveDirection= new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //moveDirection = transform.TransformDirection(moveDirection);
        //Vector3 moveDirection = this.transform.forward;
        moveDirection *= velocity*Time.deltaTime;
        //this.transform.position += moveDirection;
        controller.Move(moveDirection);
        //this.transform.position=new Vector3(controller.transform.position.x,7.0f,controller.transform.position.z);


        }
        this.transform.position=new Vector3(controller.transform.position.x,7.0f,controller.transform.position.z);
        //this.transform.position=new Vector3(Camera.main.transform.position.x,7.0f,Camera.main.transform.position.z);
    }

}