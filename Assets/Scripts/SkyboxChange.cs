using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkyboxChange : MonoBehaviour
{
    // Start is called before the first frame update

public Material MShader;

public Material AShader;


public Material NShader;

public MeshRenderer Ocean;
public MeshRenderer Wave;
public Material Morning;
public Material Afternoon;
public Material Night;

public Light light_;


public void InvokeMorning()
{
    Invoke("MorningChange", 0.5f);
}
public void InvokeAft()
{
    Invoke("AfternoonChange", 0.5f);
}
public void InvokeNight()
{
    Invoke("NightChange", 0.5f);
}

private void MorningChange()

{
    GameObject.Find("GameController").GetComponent<MainFadeInOut>().isFade = true;
    RenderSettings.skybox=Morning;
    Ocean.material=MShader;
    Wave.material=MShader;
    light_.intensity=1f;
}

private void AfternoonChange()
{
    RenderSettings.skybox=Afternoon;
    Wave.material=AShader;
    Ocean.material=AShader;
    light_.intensity=0.8f;
}

private void NightChange()
{
    RenderSettings.skybox=Night;
    Wave.material=NShader;
    Ocean.material=NShader;
    light_.intensity=0f;}
    
}
