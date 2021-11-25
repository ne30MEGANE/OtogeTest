using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingScript : MonoBehaviour
{
    private Slider slider;
    public Text hs;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        GameManager.highSpeed = slider.value;
        hs.text = GameManager.highSpeed.ToString();
    }

    public void HighSpeedSetting(){
        GameManager.highSpeed = slider.value;
        hs.text = GameManager.highSpeed.ToString();
    }
}
