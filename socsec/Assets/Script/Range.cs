using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[Serializable]
public class Range
{
    [SerializeField]
    public float from;
    [SerializeField]
    public float to;

    public float From { get { return from; } set { from = value; } }
    public float To { get { return to; } set { to = value; } }
    public float Length { get { return to - from; } }

    public Range()
    {
        from = to = 0;
    }
    public Range(float from, float to)
    {
        this.from = from;
        this.to = to;
    }

    public bool InRange(float value)
    {
        if (from <= value && value <= to)
            return true;
        return false;
    }
}