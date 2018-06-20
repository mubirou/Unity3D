# Unity 入門

* 実行環境：Unity 2017.2 Personal 以降 / Ubuntu 16.04.4 LTS 以降

### <b>INDEX</b>

|No.|タイトル|内容|WebGL|参考サイト|
|:--:|:--|:--|:--:|:--:|
|001|[プリミティブ･オブジェクト](#プリミティブ･オブジェクト)|立方体･球･カプセル･円柱･平面の利用|－|－|
|002|[Blenderからの読み込み](#Blenderからの読み込み)|Blenderで加工したモデルをインポート|－|－|
|003|[入門動画](#入門動画)|入門者向けの解説動画|－|－|
|004|[『Unityで神になる本。』](#Unityで神になる本)|参考書の勉強|[●](#Unityで神になる本)|－|
|005|[ユーザー設定](#ユーザー設定)|初期設定では使いにくい設定を変更|－|
|006|[マウス操作](#マウス操作)|個人的に必須のマウス操作|－|
|007|[出力](#出力)|Unityで作成したプロジェクトを出力する方法|－|
***

<a name="プリミティブ･オブジェクト"></a>
# <b>001 プリミティブ･オブジェクト</b>

### 概要
* Unity内で作成できる基本的な形状。
* モデリング（変更）は不可。
* X･Y･Z方向への拡大･縮小は可能。
* 通常はテスト目的でプレースホルダーとして利用。
* [Inspector]-[Mesh Renderer] の [✔] を外して「当たり判定」の領域として使うことも可能。

### 作成方法
1. [GameObject]-[3D Object] を選択。
1. ①Cube ②Sphere ③Capsole ④Cylinder ⑤Plane ⑥Quad の中から選択。

### プリミティブの種類
1. Cube（キューブ）
    * 1x1x1の立方体。
    * 壁、柱、箱、階段などに利用。
1. Sphere（スフィア／球）
    * 直径1（半径0.5）の球。
    * 星ｍ弾丸などに利用。
1. Capsole（カプセル）
    * 円柱（高さ1、直径1）の上下に半球（直径1）を加えたもの。
    * 物理挙動をテストするプロトタイプなどに利用。
1. Cylinder（シリンダー／円柱）
    * 高さ2、直径1の円柱。
    * 柱、棒、タイヤなどに利用。
1. Plane（プレーン／平面）
    * 10x10の平面（200個の三角形で構成）。
    * 床、壁などに利用。
1. Quad（クワッド）
    * 1x1の平面（2個の三角形で構成）。
    * 画像や動画の再生などに利用。  

![001](https://vvestvillage.github.io/Unity/introduction/jpg/001.jpg)

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：vvestvillage  
作成日：2018年04月17日


<a name="Blenderからの読み込み"></a>
# <b>002 Blenderからの読み込み</b>

### 3Dモデル無料素材の用意
* [Free3D](https://free3d.com/)にアクセス。
* 任意のモデル（.obj形式）を選択し [Download]。

### Blenderでインポート〜エクスポート
1. Blenderを起動（立方体は削除）。
1. [ファイル]-[インポート]-[wavefront(.obj)] で上記の "xxx.obj" ファイルをインポート。
1. 任意で修正。
1. [ファイル]-[エクスポート]-[FBX(.fbx)] からエクスポート。

### Unityにインポート
1. Unityを起動。
1. [Project]-[Create]-[Folder] を選び "Model001" フォルダを作成。
1. デスクトップ等にある "xxx.fbx" ファイルを、上記のフォルダにドラッグ＆ドロップ。
    * (Project name)/Assets/ フォルダ内に "xxx.fbx" ファイル等がコピーされます。
1. [Project]-[Model001] 内のモデルを [Hierarchy] にドラッグ＆ドロップ。
1. 必要に応じて色を変更するなど行います。

![002](https://vvestvillage.github.io/Unity/introduction/jpg/002.jpg)

実行環境：Unity 2017.2 Personal、Blender 2.79、Ubuntu 16.04 LTS  
作成者：vvestvillage  
作成日：2018年04月18日


<a name="入門動画"></a>
# <b>003 入門動画</b>

|No.|内容|WebGL|視聴日|
|:--|:--|:--:|:--:|
|001|[板とボール+物理エンジン①](https://www.youtube.com/watch?v=ruAN7e4wRwg)|－|2018-04-20|
|002|[板とボール+物理エンジン②（反射係数）](https://www.youtube.com/watch?v=Km8TpJ850Yo)|－|2018-04-20|
|XXX|[XXX](#XXX)|－|－|

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：vvestvillage  
作成日：2018年04月20日  
更新日：2018年0X月XX日


<a name="Unityで神になる本"></a>
# <b>004 『Unityで神になる本。』</b>

頁数は [『Unityで神になる本。／廣鉄夫著』](https://amzn.to/2s85DAv) のページです。

|No.|内容|頁数|WebGL|参考サイト|作成日|
|:--|:--|:--:|:--:|:--:|:--:|
|001|天地創造。（プログラムレス）|33〜76|[●](https://vvestvillage.github.io/Unity/introduction/html/004_001/index.html)|[●](https://assetstore.unity.com/packages/essentials/asset-packs/standard-assets-32351)|2018-05-23|
|002|XXX|XXX〜XXX|－|－|2018-XX-XX|

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：vvestvillage  
作成日：2018年05月23日  
更新日：2018年XX月XX日


<a name="ユーザー設定"></a>
# <b>005 ユーザー設定</b>

初期設定では使いにくい設定を変更します。

1. [Edit]-[Preferences]-[Colors]
    * [General]-[Playmode tint] をダーク系にする……再生中であることを明確にする為

1. XXX

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：vvestvillage  
作成日：2018年05月24日  
更新日：2018年XX月XX日

<a name="マウス操作"></a>
# <b>006 マウス操作</b>

|マウス操作|内容|DATE|
|:--|:--|:--:|
|[左ボタン]|オブジェクトの選択|2018-05-24|
|[Shift]+[左ボタン]|オブジェクトの選択の追加 / 選択の解除|2018-05-24|
|[ホイール回転]|視点のズームアップ･ズームダウン（画面中央を基準）|2018-05-24|
|[右ボタン]+[ドラッグ]|視点の回転|2018-05-24|
|[Shift]+[中ボタン]+[ドラッグ]|視点の自由移動|2018-05-24|

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：vvestvillage  
作成日：2018年05月24日  
更新日：2018年XX月XX日


<a name="出力"></a>
# <b>007 出力</b>

### プラットフォーム
[File]-[Build Settings] から選択。  
|マウス操作|内容|DATE|
|:--|:--|:--:|

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：vvestvillage  
作成日：2018年06月20日  
更新日：2018年XX月XX日


© 2018 vvestvillage