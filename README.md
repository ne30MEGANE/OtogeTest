# 音ゲ試作

## 参考
- https://qiita.com/Teach/items/12a2e3b2f8c09dbbc5bd
- https://qiita.com/Teach/items/e8343fe0405da7ebd5fc

## 素材
- フリー効果音素材 くらげ工匠

## メモ(Ver.0)

### 仕様
譜面CSV解釈→ノーツ生成→落下(判定)

譜面CSVは「timing(秒), lane(int)」

ノーツ生成位置はハイスピ依存

### 判定

判定エリア内にノーツが入った(OnTriggerEnter2D)とき、判定を有効にする

→対応するレーンに入力があったらgood判定・Destroy・score+1(固定値)

→判定エリア外に出た(OnTriggerExit2D)とき、判定を無効にする


入力がないままノーツのy座標が指定値より小さく(下に)なったらmiss判定・Destroy

ハイスピは固定値(GameManagerの設定値を参照)
