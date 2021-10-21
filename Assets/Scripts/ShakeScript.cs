using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeScript : MonoBehaviour
{
    public float ShakeDetectionThreshold; // Threshold = しきい値、　シェイク判定される基準になるふり幅
    public float MinShakeInterval; // 次のシェイクを判定するまでのインターバル

    public AudioSource sound;

    private float sqrShakeDetectionthreshold;
    private float timeSinceLastShake;

    // Start is called before the first frame update
    void Start()
    {
        sqrShakeDetectionthreshold = Mathf.Pow(ShakeDetectionThreshold, 2);
        if(UnityEditor.EditorApplication.isRemoteConnected)Debug.Log("iPhone Connected");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.acceleration.sqrMagnitude >= sqrShakeDetectionthreshold
        && Time.unscaledTime >= timeSinceLastShake + MinShakeInterval){
            sound.Play();
            Debug.Log("Shake!");
            timeSinceLastShake = Time.unscaledTime; // 最後にシェイク判定された時間を記録
        }
    }
}
