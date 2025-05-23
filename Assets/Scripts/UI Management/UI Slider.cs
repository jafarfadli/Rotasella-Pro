using UnityEngine;
using TMPro;

public class UISlider : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI sliderText;


    public void sliderChange(float value)
    {
        float localValue = value * 100;
        sliderText.text = localValue.ToString("0") + "%";
    }
}