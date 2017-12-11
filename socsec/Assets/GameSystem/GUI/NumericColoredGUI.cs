using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class NumericColoredGUI : MonoBehaviour
{
    public float Value;
    public Text ValueDisplay;
    public List<ColorValueRange> ColorValueRange = new List<ColorValueRange>();
    private void Start()
    {

    }

    private void Update()
    {
        ValueDisplay.text = Value.ToString();
        foreach (var range in ColorValueRange)
        {
            if (range.InRange(Value))
            {
                for (var i = 0; i < transform.childCount; i++)
                {
                    var graphics = transform.GetChild(i).gameObject.GetComponentsInChildren<Graphic>();
                    foreach (var graphic in graphics)
                    {
                        graphic.color = range.Color;
                    }
                }
            }
        }
    }
}

[Serializable]
public class ColorValueRange : Range
{
    [SerializeField] public Color Color;
}