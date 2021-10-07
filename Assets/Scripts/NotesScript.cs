using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesScript : MonoBehaviour
{

    public int laneNum;
    private float highSpeed;
    private AudioSource tapSound;
    private GameManager gameManager;
    private TapScript tapScript;
    private bool isInLine = false; // good判定範囲かどうか
    private KeyCode laneKey;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        tapScript = GameObject.Find("TapManager").GetComponent<TapScript>();
        highSpeed = gameManager.highSpeed;
        tapSound = gameManager.tapSound;
        laneKey = GameUtil.GetKeyCodeByLineNum(laneNum);
    }

    void FixedUpdate()
    {
        // ノーツを落とす処理
        this.transform.position += Vector3.down * highSpeed * Time.deltaTime;
        if(this.transform.position.y < -7.0f){ // 叩かずに通過した場合の処理
            // Debug.Log("miss"); // for debug
            Destroy(this.gameObject);
        }

    }
    void Update()
    {
        // 判定範囲に入っているとき
        if(isInLine){
            CheckInput(laneKey); // レーン番号確認
        }

    }

    void CheckInput(KeyCode key)
    {
        // ノーツに対して入力があったとき（キー入力）
        if(Input.GetKeyDown(key) || tapScript.GetLaneBool(laneNum)){
            // Debug.Log("CheckInput"); // for debug
            gameManager.GoodTimingFunc(laneNum); // 判定関数を呼び出す
            tapSound.Play();
            Destroy(this.gameObject); // ノーツを消す
        }

        // ノーツに対して入力があったとき（タッチ）
        // if(tapScript.GetLaneBool(laneNum)){
        //     Debug.Log(laneNum + " tap");
        // }
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
