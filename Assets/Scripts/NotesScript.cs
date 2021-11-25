using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesScript : MonoBehaviour
{
    public int type;
    public int optNum; // option（通常：レーン番号、左右シェイク：方向）
    private float highSpeed;

    private AudioSource tapSound;
    private GameManager gameManager;
    private TapScript tapScript;
    private ShakeScript shakeScript;

    private bool isInLine = false; // good判定範囲かどうか

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        tapScript = GameObject.Find("TapManager").GetComponent<TapScript>();
        shakeScript = GameObject.Find("ShakeManager").GetComponent<ShakeScript>();
        highSpeed = GameManager.highSpeed;
        tapSound = gameManager.tapSound;
    }

    void Update()
    {
        // ノーツを落とす処理
        this.transform.position += Vector3.down * highSpeed * Time.deltaTime;
        if(this.transform.position.y < -7.0f){ // 叩かずに通過した場合の処理
            Destroy(this.gameObject);
        }

        // 判定範囲に入っているとき
        if(isInLine){
            CheckInput(); // ノーツ毎の判定処理
        }

    }

    void CheckInput()
    {
        switch(type){ // ノーツタイプはプレハブ毎に設定
            case 0: // 通常ノーツの判定
                if(tapScript.GetLaneBool(optNum)){
                    gameManager.GoodTimingFunc(); // 判定成功関数を呼び出す
                    tapSound.Play();
                    Destroy(this.gameObject);
                }
                break;
            case 1: // シェイクノーツの判定
                if(shakeScript.GetShakeBool()){
                    gameManager.GoodTimingFunc();
                    tapSound.Play();
                    Destroy(this.gameObject);
                }
                break;
            case 2: // 方向指定シェイクの判定
                if(shakeScript.GetShakeBool(optNum)){ // GetShakeBoolは引数ありで方向を判定
                    gameManager.GoodTimingFunc();
                    tapSound.Play();
                    Destroy(this.gameObject);
                }
                break;
            default:
                break;
        }
    }

    void OnTriggerEnter2D (Collider2D cl) { // 判定範囲内の時
        if(cl.gameObject.tag == "Area"){
            isInLine = true;
            // Debug.Log(isInLine); // for debug
        }
    }

    void OnTriggerExit2D (Collider2D cl) { // 判定範囲外の時
        if(cl.gameObject.tag == "Area"){
            isInLine = false;
            // Debug.Log(isInLine); // for debug
        }
    }

}
