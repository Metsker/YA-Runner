using System;
using UnityEngine;

[Serializable]
[AttributeUsage (AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
public sealed class RangeExAttribute : PropertyAttribute
{
    public readonly int min;
    public readonly int max;
    public readonly float step;
     
    public RangeExAttribute (int min, int max, float step)
    {
        this.min = min;
        this.max = max;
        this.step = step;
    }
}