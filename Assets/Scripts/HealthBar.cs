using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Gradient gradient;

    public Image fill;
    
    public void SetHealth(int value)
    {
        healthSlider.value = value;
        fill.color = gradient.Evaluate(healthSlider.normalizedValue); // Ratio between Max and Current
    }
    
    public void SetMaxHealth(int value)
    {
        healthSlider.maxValue = value;
        healthSlider.value = value;

        fill.color = gradient.Evaluate(1f);
    }
}
