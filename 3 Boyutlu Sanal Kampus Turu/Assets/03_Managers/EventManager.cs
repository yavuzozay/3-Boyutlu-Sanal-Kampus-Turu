using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class EventManager 
{
    public static event Action<Vector3> onWeatherEffectPosChanged;
    public static void Fire_onWeatherEffectPosChanged(Vector3 pos) { onWeatherEffectPosChanged?.Invoke(pos); }
}
