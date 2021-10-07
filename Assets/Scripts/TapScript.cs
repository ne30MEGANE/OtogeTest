using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapScript : MonoBehaviour
{   
    public bool[] touching; // 各レーンのタッチ状況を保持

    void Start()
    {
        touching = new bool[] {false, false, false, false};
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TapDown(int lane){ // レーンがタップされたとき
        touching[lane] = true;
        // Debug.Log("lane:" + lane + " on"); // for debug
    }

    public void TapUp(int lane){ // レーンから手が離れた時
        if(touching[lane]) {
            touching[lane] = false;
            // Debug.Log("lane:" + lane + " off"); // for debug
        }
    }

    public bool GetLaneBool(int lane){ // レーンへの入力情報を返す
        return touching[lane];
    }
}
