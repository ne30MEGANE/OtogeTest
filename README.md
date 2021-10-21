# 音ゲ試作

## 参考
音ゲーシステム部分
- https://qiita.com/Teach/items/12a2e3b2f8c09dbbc5bd
- https://qiita.com/Teach/items/e8343fe0405da7ebd5fc

加速度センサー処理部分
- https://resocoder.com/2018/07/20/shake-detecion-for-mobile-devices-in-unity-android-ios/

## 素材
- フリー効果音素材 くらげ工匠

## メモ(Ver.0～)

### 仕様
譜面CSV解釈→ノーツ生成→落下(判定)

譜面CSVは「type(int), timing(秒), lane(int)」
> *Ver.0.3*
> 
> シェイクノーツ実装に伴いノーツタイプの概念を追加

ノーツ生成位置はハイスピ依存

### 判定

判定エリア内にノーツが入った(OnTriggerEnter2D)とき、判定を有効にする

→対応するレーンに入力があったらgood判定・Destroy・score+1(固定値)

→判定エリア外に出た(OnTriggerExit2D)とき、判定を無効にする

> *Ver.0.1*
> 
> ノーツを動かす処理はFixedUpdate、判定を受け付ける側の処理はUpdateで行うように変更
>
> また、ハイスピ設定や判定ラインの設定位置に応じてノーツ生成位置＆落下速度が調整され、正しくハイスピ変更が機能するように改善

> *Ver.0.3*
> 
> シェイクノーツ・シェイク判定クラスを実装

入力がないままノーツのy座標が指定値より小さく(下に)なったらmiss判定・Destroy

ハイスピはGameManagerでの設定値を参照
