using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainFadeInOut : MonoBehaviour
{
    public Animation FadeAni;
    public bool isFade=false;

    // Start is called before the first frame update
private Image sr;
public GameObject go;
void Start() 
{ sr = go.GetComponent<Image>(); }
public void Fade() 
{
    isFade=true;
    if (isFade)
    {
    FadeAni.Play("Fade");
    isFade=false;
    }

}
}
