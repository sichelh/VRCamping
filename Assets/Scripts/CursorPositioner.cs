using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorPositioner : MonoBehaviour
{
    private float defaultPosZ;

    // Start is called before the first frame update
    void Start()
    {
        defaultPosZ = transform.localPosition.z;    //recticle cursor의 z값을 변수로 받아옴.
    }

    // Update is called once per frame
    void Update()
    {
        Transform camera = Camera.main.transform;
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))  //Pyhisics.Raycast라는 함수를 가져와서, 이 함수의 내부에서 외부의 값을 가져옴. pointer 변수를 받아와서 값을 넣어줌.
        {
            if (hit.distance <= defaultPosZ)    //Z 포지션이 1보다 작거나 같을 때
            {
                transform.localPosition = new Vector3(0, 0, hit.distance);
            }
            else
            {
                transform.localPosition = new Vector3(0, 0, defaultPosZ);
            }
        }
    }
}
