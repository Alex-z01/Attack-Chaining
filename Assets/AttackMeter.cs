using UnityEngine;
using UnityEngine.UI;

public class AttackMeter : MonoBehaviour
{
    public Slider slider;

    private void Update()
    {
        if(slider.value > slider.minValue) 
        {
            slider.value -= Time.deltaTime;
        }
    }

    public void SetSliderMax(float timer)
    {
        slider.maxValue = timer;
        slider.value = slider.maxValue;
    }
}
