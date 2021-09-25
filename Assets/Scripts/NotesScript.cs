using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesScript : MonoBehaviour
{

    public int laneNum;
    public int highSpeed;
    private GameManager gameManager;
    private bool isInLine = false; // good判定範囲かどうか
    private KeyCode laneKey;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        laneKey = GameUtil.GetKeyCodeByLineNum(laneNum);
    }

    void Update()
    {
        // ノーツを落とす処理
        this.transform.position += Vector3.down * highSpeed * Time.deltaTime;
        if(this.transform.position.y < -7.0f){ // 叩かずに通過した場合の処理
            // Debug.Log("miss"); // for debug
            Destroy(this.gameObject);
        }

        // 判定範囲に入っているとき
        if(isInLine){
            CheckInput(laneKey); // レーン番号確認
        }
    }

    void CheckInput(KeyCode key)
    {
        //　ノーツに対して入力があったとき
        if(Input.GetKeyDown(key)){
            Debug.Log("CheckInput"); // for debug
            gameManager.GoodTimingFunc(laneNum); // 判定関数を呼び出す
            Destroy(this.gameObject); // ノーツを消す
        }
    }

    void OnTriggerEnter2D (Collider2D other) { // 判定範囲内の時
        isInLine = true;
        Debug.Log(isInLine); // for debug
    }

    void OnTriggerExit2D (Collider2D other) { // 判定範囲外の時
        isInLine = false;
        Debug.Log(isInLine); // for debug
    }

}
