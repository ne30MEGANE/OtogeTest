using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.UI;

public class ButtonScript : MonoBehaviour
{
    public string sceneName;
    public string humenName;

    public void MusicStart()
    {
        GameManager.filePass = humenName; // 譜面を指定
        SceneManager.LoadScene(sceneName);
    }

    public void ToTitle(){
        SceneManager.LoadScene(sceneName);
    }

}
