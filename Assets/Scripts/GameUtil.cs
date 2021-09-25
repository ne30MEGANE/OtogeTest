using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUtil : MonoBehaviour
{
    public static KeyCode GetKeyCodeByLineNum(int lineNum) // レーン番号のキーボードのキーを返す
    {
        switch(lineNum){
            case 0: 
                // Debug.Log("D"); // for debug
                return KeyCode.D;
            case 1: 
                // Debug.Log("F"); // for debug
                return KeyCode.F;
            case 2: 
                // Debug.Log("J"); // for debug
                return KeyCode.J;
            case 3: 
                // Debug.Log("K"); // for debug
                return KeyCode.K;
            default: 
                return KeyCode.None;
        }
    }
}
