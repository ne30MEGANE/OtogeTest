using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForDebug : MonoBehaviour
{
    public Text infoText;
    private string info;

    void Start(){
        string highspeed = GameManager.highSpeed.ToString();
        string humen = GameManager.filePass.ToString();
        info = "HighSpeed: " + highspeed + " , 譜面: " + humen;
    }

    void Update()
    {
        infoText.text = info;   
    }
}
