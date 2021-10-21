using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public GameObject[] notes; // 0~3:通常ノーツ 4:シェイクノーツ
    private int[] type;
    private float[] timing;
    private int[] lane;

    public string filePass;
    private int notesCount = 0;

    private AudioSource audioSource;
    public AudioSource tapSound;
    private float startTime = 0;
    public float timeOffset = -1;
    public GameObject judgeLine;
    private float lineY;

    private bool isPlaying = false;

    public Text scoreText;
    private int score = 0;

    public float highSpeed;

    void Start()
    {
        audioSource = GameObject.Find("GameMusic").GetComponent<AudioSource>();
        type = new int[1024];
        timing = new float[1024];
        lane = new int[1024];
        LoadCSV();
        lineY = judgeLine.gameObject.transform.position.y;
        // Debug.Log(lineY); // for debug
        Invoke(nameof(StartGame), 1f); // 1秒後にスタート
    }

    void Update()
    {
        if(isPlaying) { // 曲が流れている間
            CheckNextNotes();
            scoreText.text = score.ToString();
        }
    }

    public void StartGame()
    {
        startTime = Time.time; // 曲開始時の時刻
        audioSource.Play();
        isPlaying = true;
    }

    void LoadCSV() // 譜面ファイル解釈
    {
        TextAsset csv = Resources.Load(filePass) as TextAsset;
        // Debug.Log(csv.text); // for debug
        StringReader reader = new StringReader(csv.text);

        int i = 0;
        while(reader.Peek() > -1){
            string line = reader.ReadLine();
            string[] values = line.Split(',');
            for (int j = 0; j < values.Length; j++){
                type[i] = int.Parse(values[0]);
                timing[i] = float.Parse(values[1]);
                lane[i] = int.Parse(values[2]);
            }
            i++;
        }
    }

    void CheckNextNotes()
    {
        while(timing[notesCount] + timeOffset < GetMusicTime() && timing[notesCount] != 0){
            SpawnNotes(type[notesCount], lane[notesCount]);
            notesCount++;
        }
    }

    void SpawnNotes(int type, int num)  // numレーンにノーツを生成
    {
        switch(type){
            case 0: // 通常ノーツ
                Instantiate(notes[num], new Vector3(-6.0f + (4.0f*num), highSpeed + lineY, 0), Quaternion.identity);
                // 0:-6  1:-2  2:2  3: 6
                break;
            case 1: // シェイクノーツ
                Instantiate(notes[4], new Vector3(0, highSpeed + lineY, 0), Quaternion.identity);
                break;
            default:
                break;
        }
        
    }

    float GetMusicTime(){
        return Time.time - startTime; // 現在時刻から曲開始時刻の差分＝曲が流れ始めてからの経過時間
    }

    public void GoodTimingFunc(){ // ノーツが叩かれた時に呼ばれる処理
        // Debug.Log("Lane:" + num + " good"); // for debug
        // Debug.Log(GetMusicTime()); // for debug
        score++;
    }
}
