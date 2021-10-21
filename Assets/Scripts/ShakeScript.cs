using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeScript : MonoBehaviour
{
    public float ShakeDetectionThreshold; // Threshold = しきい値、　シェイク判定される基準になるふり幅
    public float MinShakeInterval; // 次のシェイクを判定するまでのインターバル

    private float sqrShakeDetectionthreshold;
    private float timeSinceLastShake;

    private bool shake;

    // Start is called before the first frame update
    void Start()
    {
        sqrShakeDetectionthreshold = Mathf.Pow(ShakeDetectionThreshold, 2);
        shake = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.acceleration.sqrMagnitude >= sqrShakeDetectionthreshold
        && Time.unscaledTime >= timeSinceLastShake + MinShakeInterval && !shake){
            ShakeFlagSwitch();
            timeSinceLastShake = Time.unscaledTime; // 最後にシェイク判定された時間を記録
        }
    }

    public bool GetShakeBool(){
        return shake;
    }

    private void ShakeFlagSwitch(){
        shake = true;
        Invoke(nameof(ShakeFlagDown),0.1f); // 0.1秒後にオフ
    }

    private void ShakeFlagDown(){
        shake = false;
    }
}
