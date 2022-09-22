using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RangeFloat
{
    public float min;
    public float max;

    public bool WithinRange(float value)
    {
        return value >= min && value <= max;
    }

    public float Clamp(float value)
    {
        return Mathf.Clamp(value, min, max);
    }
}
