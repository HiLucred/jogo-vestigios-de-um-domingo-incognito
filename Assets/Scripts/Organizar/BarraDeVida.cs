using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void saudeMaxima(int saudeMaxima)
    {
        slider.maxValue = saudeMaxima;
        slider.value = saudeMaxima;
        fill.color = gradient.Evaluate(1f);
    }
    public void setSaude(int saude)
    {
        slider.value = Mathf.Lerp(slider.value, saude, 1f);
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
