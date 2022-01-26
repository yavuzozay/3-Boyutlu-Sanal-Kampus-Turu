using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Cycle
{
    Morning, Night
}
public class LightingManager : MonoSingleton<LightingManager>
{
   
    [SerializeField]private Cycle cycle;
    [SerializeField]private Gradient AmbientColor;
    [SerializeField]private Gradient DirectionalColor;
    [SerializeField]private Gradient FogColor;
    private Light dirLight;
    public void SetCycle(Cycle cycle)
    {
        this.cycle = cycle;
    }
    public Cycle GetCycle()
    {
        return cycle;
    }
    private void Awake()
    {
        cycle = Cycle.Morning;
        base.Awake();
    }
    
 
    public void SetDayCylceRender(float ambientColor,float fogcolor,float sunColor, float fogDensity)
    {
        RenderSettings.ambientLight = AmbientColor.Evaluate(ambientColor);
        RenderSettings.fogColor = FogColor.Evaluate(fogcolor);
        RenderSettings.fogDensity= fogDensity;
        RenderSettings.sun.color = DirectionalColor.Evaluate(sunColor);
    }
    public void DefaultNightMode()
    {
        SetDayCylceRender(1, 1, 1, .1f);
    }
    public void DefaultMorningMode()
    {
        SetDayCylceRender(0,0,0,.01f);

    }

}
