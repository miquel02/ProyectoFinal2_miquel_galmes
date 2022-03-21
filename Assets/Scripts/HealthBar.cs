using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //AQUEST SCRIPT S'ENCARREGA DE CREAR LA HEALTH BAR

    //Variables per guardar elements de la barra
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    
    //Funci� per determinar una vida m�xima
    public void SetmaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
    }
    
    //Funci� per fer que l'slider tengui el valor de la vida
    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
