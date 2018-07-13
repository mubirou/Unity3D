# Unity 入門

* 実行環境：Unity 2017.2 Personal 以降 / Ubuntu 16.04.4 LTS 以降

### <b>INDEX</b>

|No.|タイトル|内容|WebGL|参考資料|
|:--:|:--|:--|:--:|:--:|
|000|[インストール](https://github.com/mubirou/HelloWorld/blob/master/languages/C%23Unity/C%23Unity_linux.md)|開発環境（Linux版）の構築|－|－|
|001|[プリミティブ･オブジェクト](#プリミティブ･オブジェクト)|立方体･球･カプセル･円柱･平面の利用|－|－|
|002|[Blenderからの読み込み](#Blenderからの読み込み)|Blenderで加工したモデルをインポート|－|－|
|003|[入門動画](#入門動画)|入門者向けの解説動画|－|－|
|004|[『Unityで神になる本。』](#Unityで神になる本)|参考書の勉強|[●](#Unityで神になる本)|[●](https://amzn.to/2s85DAv)|
|005|[ユーザー設定](#ユーザー設定)|初期設定では使いにくい設定を変更|－|－|
|006|[マウス操作](#マウス操作)|個人的に必須のマウス操作|－|－|
|007|[出力](#出力)|Unityで作成したプロジェクトを出力する方法|－|[●](https://amzn.to/2s85DAv)|
|008|[VideoPlayerコンポーネント](#VideoPlayerコンポーネント)|VideoPlayerコンポーネントによる動画ファイル再生|－|－|
|009|[『Unity 2018 逆引き大全 300の極意』](#逆引き大全)|参考書の勉強|－|[●](https://amzn.to/2KuNW69)|
***

<a name="プリミティブ･オブジェクト"></a>
# <b>001 プリミティブ･オブジェクト</b>

### 概要
* Unity内で作成できる基本的な形状。
* モデリング（変更）は不可。
* X･Y･Z方向への拡大･縮小は可能。
* 通常はテスト目的でプレースホルダーとして利用。
* [Inspector]-[Mesh Renderer] の ✔ を外して「当たり判定」の領域として使うことも可能。

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

![001](https://mubirou.github.io/Unity/introduction/jpg/001.jpg)

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：夢寐郎  
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

![002](https://mubirou.github.io/Unity/introduction/jpg/002.jpg)

実行環境：Unity 2017.2 Personal、Blender 2.79、Ubuntu 16.04 LTS  
作成者：夢寐郎  
作成日：2018年04月18日


<a name="入門動画"></a>
# <b>003 入門動画</b>

|No.|内容|WebGL|視聴日|
|:--|:--|:--:|:--:|
|001|[板とボール+物理エンジン①](https://www.youtube.com/watch?v=ruAN7e4wRwg)|－|2018-04-20|
|002|[板とボール+物理エンジン②（反射係数）](https://www.youtube.com/watch?v=Km8TpJ850Yo)|－|2018-04-20|
|XXX|[XXX](#XXX)|－|－|

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：夢寐郎  
作成日：2018年04月20日  
更新日：2018年0X月XX日


<a name="Unityで神になる本"></a>
# <b>004 『Unityで神になる本。』</b>

頁数は [『Unityで神になる本。／廣鉄夫著』](https://amzn.to/2s85DAv) のページです。

|No.|内容|頁数|WebGL|.apk|参考サイト|作成日|
|:--|:--|:--:|:--:|:--:|:--:|:--:|
|01|天地創造。（プログラムレス）|33〜76|[●](https://mubirou.github.io/Unity/introduction/html/004_01/index.html)|－|[●](https://assetstore.unity.com/packages/essentials/asset-packs/standard-assets-32351)|2018-05-23|
|02|[考え方と構造。](#考え方と構造。)|77〜112|－|－|－|2018-07-08|
|03|[世界を構成するもの。](#世界を構成するもの。)|113〜164|－|－|－|2018-07-10|
|04|[スクリプト基礎知識。](#スクリプト基礎知識。)|165〜258|－|－|－|2018-0X-XX|

<a name="考え方と構造。"></a>
### 02 考え方と構造。</b>

* [シーン](https://docs.unity3d.com/ja/current/Manual/CreatingScenes.html) : 1つのプロジェクトに作った複数のシーン間をスクリプトで移動可能（シーンは[ビルド](https://docs.unity3d.com/jp/current/Manual/PublishingBuilds.html)に含まなくても良い）
* [GameObject](https://docs.unity3d.com/ja/current/Manual/GameObjects.html) : 世界に配置されているモノの基本単位（[コンポーネント](https://docs.unity3d.com/ja/current/Manual/UsingComponents.html)の入れ物）･[Transform](https://docs.unity3d.com/ja/current/ScriptReference/Transform.html)コンポーネントがミニマム
* [Collider（コライダー）](https://docs.unity3d.com/ja/current/Manual/CollidersOverview.html) : 衝突判定の領域（①Box ②Sphere ③Capsuleの3つあり）
* [Rigidbody](https://docs.unity3d.com/ja/current/Manual/class-Rigidbody.html) : 物体としての属性を持たせる（[Add Component]-[Physics]-[Rigidbody]）
* [跳ね返り効果](https://docs.unity3d.com/ja/current/Manual/class-PhysicMaterial.html)（摩擦係数と反発係数）: [Project]-[Create]-[Physics Material]-[Inspector]-[Bounciness] の値を上げる → オブジェクト（Rigidbody済）の [Inspector]-[XXX Colider] の [Material] にドラッグ
* [Prefab（プレハブ）](https://docs.unity3d.com/jp/current/Manual/Prefabs.html) ≒ Flash MovieClip  
    * [Select] : 親を開く
    * [Revert] : 元のPrefab状態に戻す
    * [Apply] : 元のPrefabを自分と同じ状態に変更
* [スクリプト](https://docs.unity3d.com/ja/current/Manual/CreatingAndUsingScripts.html)とは?（Prefabを100個登場させる例文）
    ```
    //DropBox.cs
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class DropBox : MonoBehaviour {
        public GameObject MyCube;
        private int _count = 0;

        void Start () {
            InvokeRepeating("HogeMethod", 0.0f, 0.1f); //0秒後から0.1秒毎に呼出す
        }

        void HogeMethod() {
            _count ++;
            Instantiate(
                MyCube,
                new Vector3(Random.Range(-2.0f, 2.0f), 10.0f, Random.Range(-2.0f, 2.0f)), 
                Quaternion.identity
                );
            if (_count == 100) {
                CancelInvoke();
            }
        }
    }
    ```
* [タブのロック](https://docs.unity3d.com/ja/current/Manual/InspectorOptions.html) : [Add Tab] で複数のGameObjectの情報を同時表示可能
* [属性のコピー](https://docs.unity3d.com/ja/current/Manual/UsingComponents.html) : [Inspector] 内の任意のComponentの ⚙ から [Copy Component] → [Past ...] でコピー

<a name="世界を構成するもの。"></a>
### 03 世界を構成するもの。</b>

* 音を作成する？（ありものを使う）  
    [freesound.org](https://freesound.org/) : 無料でダウンロード可能  
    [Asset Store](https://assetstore.unity.com/categories/audio) : Unityアセットストア  
* 2次元画像製作。  
    Unityでは実行時に再圧縮をかけるため予め[ダウンサイジングしておく必要はない](https://docs.unity3d.com/jp/current/Manual/class-TextureImporter.html)  
    Unity 2018.1 以降であれば [SVG](https://ja.wikipedia.org/wiki/Scalable_Vector_Graphics) ファイルを[読み込む方法](http://tsubakit1.hateblo.jp/entry/2018/05/22/233000)もあるとのこと  
* 3Dモデリングデータの読み込み方法  
    ①汎用モデルデータ（[.fbx](https://ja.wikipedia.org/wiki/FBX)）  
    ②ネイティブデータ（Unity環境に該当3Dツールがインストールされている必要がある）  
* おすすめ3Dツール  
    ①[Blender](https://blender.jp/) : 無料（Linux/macOS/Win）  
    ②[SketchUp Make](https://www.sketchup.com/ja) : 非商用は無料（macOS/Win）  
    ③[Shade 3D for Unity](https://shade3d.jp/product/shade-3d-for-unity/index.html) : 無料（macOS/Win）  
    ④[Cheetah3D](https://www.cheetah3d.com/) : $99（macOS専用)  
    ⑤[Metasequoia](http://www.metaseq.net/jp/) : 5400円〜（アニメーションには非対応/Win専用）  
    その他、[ZBrush](https://oakcorp.net/pixologic/)、[Maya LT](https://www.autodesk.co.jp/products/maya-lt/overview)、[CINEMA 4D Prime](https://oakcorp.net/maxon/)、[LightWave](http://www.dstorm.co.jp/lw2018/)、[MODO](http://modogroup.jp/modo) 等の高額なツールもある  
    ※Unityで使うのはモデリング等の一部の機能です
* Unity用モデリングの注意  
    * 有効なのは「マテリアル名」と「色情報」のみ（細かな質感とは無視される）  
    * [UVマップ](http://www.blender3d.biz/texturing_uvunwrapmappingtypes.html)は有効  
    * [サブディビジョンサーフェス](http://www.blender3d.biz/simple3dcg_modeling_smoothing.html)は有効
    * リギング（IK）やアニメーションデータは「.fbx」や「.blend」の利用で有効  
    ※[Adobe mixamo](https://www.mixamo.com/#/) : 自動リギング＆アニメーションサービスあり（有料）

<a name="スクリプト基礎知識。"></a>
### 04 スクリプト基礎知識。</b>

* スクリプトはシーン内のGameObjectのコンポーネントとして動作する  
    （どのGameObjectに追加しても良いが、通常わかりやすいところに記述する）
* デフォルトのコード（C#）
    ```
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class HelloWorld : MonoBehaviour {

        // Use this for initialization
        void Start () {
            
        }
        
        // Update is called once per frame
        void Update () {
            
        }
    }
    ```
* 主なイベント  

|イベント名|内容|
|:--|:--|
|[Awake](https://docs.unity3d.com/jp/current/ScriptReference/MonoBehaviour.Awake.html)|最初に実行される|
|[Start](https://docs.unity3d.com/jp/current/ScriptReference/MonoBehaviour.Start.html)|シーンのスタート時に一度だけ実行|
|[Update](https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.Update.html)|再生中画面がアップデートされる度に実行|
|[LastUpdate](https://docs.unity3d.com/ScriptReference/MonoBehaviour.LateUpdate.html)|1フレーム中の描画される直前に実行|
|[OnGUI](https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnGUI.html)|GUIが更新される度に実行|
|[OnCollisionEnter](https://docs.unity3d.com/ja/current/ScriptReference/Collider.OnCollisionEnter.html)|コライダの領域に衝突する度に実行|
|[OnTriggerEnter](https://docs.unity3d.com/ja/current/ScriptReference/Collider.OnTriggerEnter.html)|OnCollisionEnterに似ている（iSTriggerがアクティブな時）|
|[OnDestroy](https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnDestroy.html)|GameObjectが消える時に実行|

* マテリアルを変更する＝信号機を作る（188〜189頁）
    ```
    //Signal.cs
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    //using UnityEditor; //AssetDatabase.LoadAssetAtPath()に必要

    public class Signal : MonoBehaviour {
        //publicの場合Inspector内で手作業で割当てる
        public GameObject _redCube;
        public GameObject _blueCube;
        public Material _blueMaterial;
        public Material _dakBlueMaterial;
        public Material _redMaterial;
        public Material _darkRedMaterial;

        //publicにしておくとInspectorで初期値の変更が可能（プレハブ化時に便利）
        private bool _onOff = false;

        void Start () {
            /* //変数をprivateにすると以下の処理が必要
            _redCube = GameObject.Find("RedCube"); //Hierarchy内で「GameObject」を探す
            _blueCube = GameObject.Find("BlueCube");
            _blueMaterial = AssetDatabase.LoadAssetAtPath("Assets/BlueMaterial.mat", typeof(Material)) as Material; //Assets内で「マテリアル」を探す
            _dakBlueMaterial = AssetDatabase.LoadAssetAtPath("Assets/DarkBlueMaterial.mat", typeof(Material)) as Material;
            _redMaterial = AssetDatabase.LoadAssetAtPath("Assets/RedMaterial.mat", typeof(Material)) as Material;
            _darkRedMaterial = AssetDatabase.LoadAssetAtPath("Assets/DarkRedMaterial.mat", typeof(Material)) as Material;
            */

            //最初の状態を作っておく
            _redCube.GetComponent<Renderer>().material = _darkRedMaterial;
            _blueCube.GetComponent<Renderer>().material = _blueMaterial;

            //3秒後から5秒間隔でSignalLoop()を繰返し実行
            InvokeRepeating("SignalLoop", 3.0f, 5.0f);
        }

        //InvokeRepeating()によって繰返し実行される処理
        void SignalLoop() {
            if (_onOff) {
                _redCube.GetComponent<Renderer>().material = _redMaterial;
                _blueCube.GetComponent<Renderer>().material = _dakBlueMaterial;
            } else {
                _redCube.GetComponent<Renderer>().material = _darkRedMaterial;
                _blueCube.GetComponent<Renderer>().material = _blueMaterial;
            }
            _onOff = !_onOff;
        }
    }
    ```

* [Transform](https://docs.unity3d.com/ja/current/ScriptReference/Transform.html)情報（全てのGameObjectに存在）

    |プロパティ名|記述方法|データ型|内容|
    |:--|:--|:--|:--|
    |[parent](https://docs.unity3d.com/jp/current/ScriptReference/Transform-parent.html)|GameObject.transform.parent|UnityEngine.Transform|親のGameObject（無い場合はNull）|
    |[root](https://docs.unity3d.com/jp/current/ScriptReference/Transform-root.html)|GameObject.transform.root|UnityEngine.Transform|最上位の親＝GameObject|
    |[childCount](https://docs.unity3d.com/jp/current/ScriptReference/Transform-childCount.html)|GameObject.transform.childCount|System.Int32|自分より下層のGameObjectの数（無い場合は0）|
    |[eulerAngles](https://docs.unity3d.com/ja/current/ScriptReference/Transform-eulerAngles.html)|GameObject.transform.eulerAngles|UnityEngine.Vector3|InspectorのRotation値 / (x,y,z) で出力|
    |[right](https://docs.unity3d.com/ja/current/ScriptReference/Transform-right.html)|GameObject.transform.right|UnityEngine.Vector3|赤軸 / (x,y,z) で出力|
    |[up](https://docs.unity3d.com/ja/current/ScriptReference/Transform-up.html)|GameObject.transform.up|UnityEngine.Vector3|緑軸 / (x,y,z) で出力|
    |[forward](https://docs.unity3d.com/jp/current/ScriptReference/Transform-forward.html)|GameObject.transform.forward|UnityEngine.Vector3|青軸 / (x,y,z) で出力|
    |[rotation](https://docs.unity3d.com/ja/current/ScriptReference/Transform-rotation.html)|GameObject.transform.rotation|UnityEngine.Quaternion|(x,x,x,x) で出力|
    |[localEulerAngles](https://docs.unity3d.com/ja/current/ScriptReference/Transform-localEulerAngles.html)|GameObject.transform.localEulerAngles|UnityEngine.Vector3|―|
    |[localPosition](https://docs.unity3d.com/ScriptReference/Transform-localPosition.html)|GameObject.transform.localPosition|UnityEngine.Vector3|―|
    |[localRotation](https://docs.unity3d.com/jp/460/ScriptReference/Transform-localRotation.html)|GameObject.transform.localRotation|UnityEngine.Quaternion|―|
    |[localScale](https://docs.unity3d.com/ja/current/ScriptReference/Transform-localScale.html)|GameObject.transform.localScale|UnityEngine.Vector3|―|
    |[lossyScale](https://docs.unity3d.com/jp/current/ScriptReference/Transform-lossyScale.html)|GameObject.transform.lossyScale|UnityEngine.Vector3|―|
    |[position](https://docs.unity3d.com/ja/current/ScriptReference/Transform-position.html)|GameObject.transform.position|UnityEngine.Vector3|―|
    |[localToWorldMatrix](https://docs.unity3d.com/jp/460/ScriptReference/Transform-localToWorldMatrix.html)|GameObject.transform.localToWorldMatrix|UnityEngine.Matrix4x4|―|
    |[worldToLocalMatrix](https://docs.unity3d.com/jp/current/ScriptReference/Transform-worldToLocalMatrix.html)|GameObject.transform.worldToLocalMatrix|UnityEngine.Matrix4x4|―|
    |[hasChanged](https://docs.unity3d.com/jp/current/ScriptReference/Transform-hasChanged.html)|GameObject.transform.hasChanged|System.Boolean|―|

* 継承される機能（全てのGameObjectに存在）

    |プロパティ名|記述方法|データ型|内容|
    |:--|:--|:--|:--|
    |[Animation](https://docs.unity3d.com/ja/current/ScriptReference/Animation.html)|GameObject.GetComponent&lt;Animation>()|UnityEngine.Animation|アタッチされているAnimation情報（無ければnull）|
    |[AudioSource](https://docs.unity3d.com/ja/current/ScriptReference/AudioSource.html)|GameObject.GetComponent&lt;AudioSource>()|UnityEngine.AudioSource|アタッチされているAudioSource情報（無ければnull）|
    |[Camera](https://docs.unity3d.com/ja/current/ScriptReference/GameObject-camera.html)|GameObject.GetComponent&lt;Camera>()|UnityEngine.Camera|アタッチされているCamera情報（無ければnull）|
    |[Collider](https://docs.unity3d.com/ja/current/ScriptReference/Collider.html)|GameObject.GetComponent&lt;Collider>()|UnityEngine.BoxCollider等|アタッチされているCollider情報|
    |[Collider2D](https://docs.unity3d.com/ja/current/ScriptReference/Collider2D.html)|GameObject.GetComponent&lt;Collider2D>()|UnityEngine.Collider2D|アタッチされているCollider2D情報|
    |[ConstantForce](https://docs.unity3d.com/ja/current/Manual/class-ConstantForce.html)|GameObject.GetComponent&lt;ConstantForce>()|UnityEngine.ConstantForce|アタッチされているConstantForce情報|
    |[GameObject](https://docs.unity3d.com/ja/current/ScriptReference/GameObject.html)|GameObject.gameObject|UnityEngine.GameObject|GameObject情報|
    |[GUIText](https://docs.unity3d.com/jp/current/Manual/class-GUIText.html)|GameObject.GetComponent&lt;GUIText>()|UnityEngine.GUIText|アタッチされているGUIText情報（旧UI）|
    |[GUITexture](https://docs.unity3d.com/jp/current/Manual/class-GUITexture.html)|GameObject.GetComponent&lt;GUITexture>()|UnityEngine.GUITexture|アタッチされているGUITexture情報（旧UI）|
    |[HingeJoint](https://docs.unity3d.com/ja/current/ScriptReference/HingeJoint.html)|GameObject.GetComponent&lt;HingeJoint>()|UnityEngine.HingeJoint|アタッチされているHingeJoint情報|
    |[Light](https://docs.unity3d.com/ja/current/Manual/class-Light.html)|GameObject.GetComponent&lt;Light>()|UnityEngine.Light|アタッチされているLight情報|
    |[NetworkView](https://docs.unity3d.com/ja/current/Manual/class-NetworkView.html)|GameObject.GetComponent&lt;NetworkView>()|UnityEngine.NetworkView|アタッチされているNetworkView情報|
    |[ParticleEmitter](https://docs.unity3d.com/ScriptReference/ParticleEmitter.html)|GameObject.GetComponent&lt;ParticleEmitter>()|UnityEngine.ParticleEmitter|アタッチされているParticleEmitter情報|
    |[ParticleSystem](https://docs.unity3d.com/ja/current/ScriptReference/ParticleSystem.html)|GameObject.GetComponent&lt;ParticleSystem>()|UnityEngine.ParticleSystem|アタッチされているParticleSystem情報|
    |[Renderer](https://docs.unity3d.com/jp/current/ScriptReference/GameObject-renderer.html)|GameObject.GetComponent&lt;Renderer>()|UnityEngine.MeshRenderer|アタッチされているRenderer情報|
    |[Rigidbody](https://docs.unity3d.com/ja/current/ScriptReference/Rigidbody.html)|GameObject.GetComponent&lt;Rigidbody>()|UnityEngine.Rigidbody|アタッチされているRigidbody情報|
    |[Rigidbody2D](https://docs.unity3d.com/ja/current/ScriptReference/Rigidbody2D.html)|GameObject.GetComponent&lt;Rigidbody2D>()|UnityEngine.Rigidbody2D|アタッチされているRigidbody2D情報|
    |[tag](https://docs.unity3d.com/jp/current/ScriptReference/GameObject-tag.html)|GameObject.tag|UnityEngine.String|GameObjectのタグ情報|
    |[Transform](https://docs.unity3d.com/ja/current/ScriptReference/Transform.html)|GameObject.transform|UnityEngine.Transform|GameObjectのタグ情報|
    |[HideFlags](https://docs.unity3d.com/ja/current/ScriptReference/HideFlags.html)|GameObject.hideFlags|UnityEngine.HideFlags|―|

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：夢寐郎  
作成日：2018年05月23日  
更新日：2018年07月13日


<a name="ユーザー設定"></a>
# <b>005 ユーザー設定</b>

初期設定では使いにくい設定を変更します。

1. [Edit]-[Preferences]-[Colors]
    * [General]-[Playmode tint] をダーク系（#666666FF等）にする……再生中であることを明確にする為

1. XXX

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：夢寐郎  
作成日：2018年05月24日  
更新日：2018年06月30日

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
作成者：夢寐郎  
作成日：2018年05月24日  
更新日：2018年XX月XX日


<a name="出力"></a>
# <b>007 出力</b>

### プラットフォーム
[File]-[Build Settings] から選択  

|Platform|内容|
|:--|:--|
|PC, Mac & Linux Standalone|Windowsｍ･macOS･Linux用|
|iOS|iPhone･iPad用|
|Android|Android用|
|Tizen|スマホ等で使われるTizen OS用|
|WebGL|WebGL対応ブラウザ向け|
|Samsung TV|スマートテレビ用|
|Facebook|（Facebookアプリ用）|
|tvOS|Apple TV向け|
|Xbox One|Microsoft XBox One向け|
|PS Vista|SONY PlayStation Vita向け|
|PS4|SONY PlayStation 4向け|

### Linux Standaloneの場合（必要最低限の設定）  
1. プラットフォームの変更  
    ① [File]-[Build Settings]-[PC,Mac & Linux Standalone] を選択し [Switch Platform] を選択  
    ② [Add Open Scenes] を押して任意のシーンを選択  

1. カーソルの変更（タッチパネル用にカーソルをほとんど見えなくする場合）  
    ① [File]-[Build Settings]-[Play Settings] ボタンを押す  
    ② [Default Cursor] を1x1のPNGファイル（Inkscape等で作成）にする  

1. 起動時のダイアログ設定  
    ① [File]-[Build Settings]-[Play Settings] ボタンを押す  
    ② [Resolution and Presentation]-[Standalone Player Options]-[Display Resolution Dialog] を [Enabled] にする（初期値）  
    ※起動時に解像度設定のダイアログを表示したくない場合は「Disabled」  

1. Debug.Log()を出力させなくする  
    上記に引き続き [Use Player Log] の ✔ を外す

1. ビルド  
    ① [File]-[Build Settings]-[Build] を選択  
    ② 任意の場所に xxx..x86_64 ファイルを保存  
    ③ 任意の場所に生成されたアプリを選択し、再生されたら成功!!  

### Androidの場合（必要最低限の設定）
1. Android SDK（[Android Studio](https://ja.wikipedia.org/wiki/Android_Studio)）のインストール（[参考サイト](http://blog.tabolog.net/entry/2017/08/11/092821)）  
    ① [Edit]-[Preferences]-[External Tools] を選択  
    ② Android「SDK」の [Download] を選択  
    ③ [developer.android.com](https://developer.android.com/studio/#Other) の [DOWNLOAD ANDROID STUDIO] を選択  
    ④ ダウンロードされた android-studio-ide-XXX-linux.zip を任意の場所に展開  
    ⑤ 端末で次の通りに実行（デスクトップに展開した場合）  
    ```
    $ デスクトップ/android-studio/bin/studio.sh
    ```
    ⑥ [Android Studio Setup Wizard] の指示に従いインストール  
    ⑦ /home/（ユーザ名）/Android/Sdk が作成されたのを確認  
    ⑧ Unityを起動し、[Edit]-[Preferences]-[External Tools] を選択  
    ⑨ Android「SDK」の [Browse] を選択し、上記のパス /home/（ユーザ名）/Android/Sdk を指定する  

1. [JDK](https://ja.wikipedia.org/wiki/Java_Development_Kit)のインストール  
    Android「JDK」のパスは /usr/lib/jvm/java-1.8.0-openjdk-amd64
    ※既にインストール済みの場合

1. [Android NDK](https://developer.android.com/ndk/guides/?hl=ja)のインストール  
    ① [Edit]-[Preferences]-[External Tools] を選択  
    ② Android「NDK」の [Download] を選択  
    ③ ダウンロードされた android-ndk-r13b-linux-x86_64.zip を任意の場所に展開  
    ④ Unityを起動し、[Edit]-[Preferences]-[External Tools] を選択  
    ⑤ Android「NDK」の [Browse] を選択し、展開したフォルダ android-ndk-r13b を指定  

1. プラットフォームの変更  
    ① [File]-[Build Settings]-[Android] を選択し [Switch Platform] を選択  
    ② [Add Open Scenes] を押して任意のシーンを選択  

1. アプリ名の設定  
    ① [File]-[Build Settings]-[Player Settings] ボタンを押す  
    ② [Product Name]（アプリ名）を設定（初期値はUnityのプロジェクト名）  
    ※この名前がAndroid端末上のアプリ名となる（数字から始まる名前でもOK）  
    ※下記の「アプリケーションID」の最後のドット以降と同じでなくてよい

1. Keystore（証明）ファイルの作成  
    ① [File]-[Build Settings]-[Player Setting]-[Publishing Settings] ボタンを押す  
    ② [Create a new keystore] を ✔  
    ③ [Keystore password] と [Confirm Keystore password] を入力（6文字以上）  
    ④ [Browse Keystore] ボタンを押す  
    ⑤ 任意の場所に xxx.keystore ファイルを保存  

1. アプリケーションIDの登録  
    ① [File]-[Build Settings]-[Player Settings] ボタンを押す  
    ② [Other Settings]-[Identification] の [Package Name] を com.mubirou.app001 等（ユニーク値）にする  
    ※この値が違うと別のアプリとしてAndroid端末にインストールされる  
    ※数値から始まる名前は不可（要注意）

1. Android端末との接続  
    ① Android端末をPCに接続し [端末データへのアクセスの許可]  
    ② Android端末上に [USBデバッグを許可] ダイアログが表示されたら、「このパソコンからのUSBデバッグを常に許可する」を [OK]  

1. ビルド  
    ① [File]-[Build Settings]-[Build And Run] を選択  
    ② 任意の場所に xxx.apk ファイルを保存（アプリ名とは関係ない）  
    ③ Unityの左下に [Build Completed with a result of 'Succeeded'] と表示されたら成功  
    ④ 上記で指定した場所に xxx.apk が生成されたのを確認  
    ⑤ Android端末上に生成されたアプリを選択し、再生されたら成功!!  
    ※ xxx.apk の[ダウンロード](https://mubirou.github.io/Unity/introduction/apk/007.apk)（Android端末へのインストール用）  

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS、Android 8.0  
作成者：夢寐郎  
作成日：2018年06月20日  
更新日：2018年06月30日


<a name="VideoPlayerコンポーネント"></a>
# <b>008 VideoPlayerコンポーネント（検証中）</b>

### 概要
* Unity 5.6（2017年3月リリース）より [VideoPlayerコンポーネント](https://docs.unity3d.com/ja/current/Manual/class-VideoPlayer.html) による動画ファイルの再生が可能
* Linuxの場合 [.webm](https://ja.wikipedia.org/wiki/WebM) または [.ogv](https://ja.wikipedia.org/wiki/Ogg) である必要がある（[.mp4](https://ja.wikipedia.org/wiki/MP4) は不可）（要検証）

### H264 / VP8 / VP9 について  
* 2010年、H.264ライセンス利用料の無料化を発表（それだけでは不十分との意見あり）
* 2011年、Google ChromeはH.264対応をやめWebM推進を発表
* 2011年、GoogleはHTML5ビデオでサポートするフォーマットとしてOgg TheoraとWebM（VP8）を選択
* AppleはVP8ではなくH.264を支持（品質的な理由）
* Ogg Theora（オッグ･シオラ）とはOn2VP3をベースに開発したビデオコーデック（音声コーデックにはOgg Vorbisを利用）
* VP8はGoogleに買収されたOn2テクノロジー社が開発したビデオコーデック
* VP9はVP8の後継（VP8の半分のビットレートで同等の画質を実現、H.265よりも効率的が目標）
* VP9はVP8より20％程度、CPUの使用率が高い
* VP9は動きにとても強い（対VP8、H.264比）
* UnityではVP8に対応（VP9は要調査）

### WebMへの変換
1. [Ubuntuソフトウェア] を起動し [Shotcut](https://www.shotcut.org/) をインストール＆起動  
    ※最新版（18.06.02）が必要な場合は[ここ](https://www.shotcut.org/download/)からダウンロード
1. [ファイルを開く] で任意の動画ファイルを開く
1. [ファイル]-[ビデオExport] を選択
1. [ストック] の中から [WebM] を選択（「WebM VP9」ではない）
1. [ビデオ] タブを選択し次の項目を確認
    * 解像度
    * アスペクトレイシオ
    * フレーム/秒（要調査：なぜか1000fpsになってしまう）
1. [コーデック] タブを選択し次の項目を確認
    * コーデック：libvpx ←VP8コーデックライブラリー
    * レートコントロール
    * ビットレート
1. [オーディオ] タブを選択し次の項目を確認
    * サンプルレート
    * コーデック：vorbis
    * レートコントロール
    * 品質
1. [ファイルをExport] ボタンを選んで xxx.webm の保存場所を指定して [保存]

### Unityで再生
1. Unityを起動しプロジェクトを作成
1. [File]-[Save Scene] でシーンを保存（名前は任意）
1. 上記で作成した xxx.webm をプロジェクトフォルダ内の [Assets] 内にコピー
1. [GameObject]-[3D Object]-[Quad] を選択
1. [Hierarchy] から [Quad] を選択し [Inspector] を確認
1. [Inspector]-[Transform] の [Scale] の値を適当に調整（映像の画角に合わせる）
    * X:8、Y:4.5、Z:1 など
1. 引き続き [Add Component] ボタンを押し [Video]-[Video Player] を選択
1. [Video Player] の [Video Clip] の [⦿] を選び、上記で作成した映像 xxx を選択
1. [▶] ボタンを押して [Quad] 上に映像ファイルが再生されたら成功
    * Linux Standalone では動作確認済み（タッチパネル等では利用可能）

### ビルド（Android）※現在調査中（下記の方法では動画ファイルが再生されず）
1. [出力](#出力)（Androidの場合）の処理を行う（まだビルドは行わない）
1. [File]-[Build Settings]-[Player Settings] ボタンを押す  
1. [Other Settings]-[Rendering] の [Multithreaded Rendering] の ✔ を外す
    ※再生時のコマ落ち防止用
1. [Build And Run] でビルド  
※上記に加えスクリプトの記述が必要の可能性あり

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS、Shotcut 18.03.06  
作成者：夢寐郎  
作成日：2018年06月26日  
更新日：2018年06月28日


<a name="逆引き大全"></a>
# <b>009 『Unity 2018 逆引き大全 300の極意』</b>

* 頁数は [『現場ですぐに使える! Unity 2018 逆引き大全 300の極意／薬師寺国安著』](https://amzn.to/2KuNW69) のページです。  
* .apk はAndroid端末へのインストール用です。  

|No.|内容|Tips番号|WebGL|.apk|参考サイト|作成日|
|:--|:--|:--:|:--:|:--:|:--:|:--:|
|001|[Unityのエディション](#Unityのエディション)|004|－|－|[●](https://store.unity.com/ja)|2018-06-29|
|002|[Asset Store保存場所](#AssetStore保存場所)|007|－|－|－|2018-06-29|
|003|[Editorの設定](#Editorの設定)|008|－|－|－|2018-06-29|
|004|[マテリアルに画像を指定](#マテリアルに画像を指定)|022･023|－|[●](https://mubirou.github.io/Unity/introduction/apk/009_004.apk)|－|2018-06-29|
|005|[空の背景の変更](#空の背景の変更)|028|－|－|－|2018-07-01|
|006|[床を鏡のようにする](#床を鏡のようにする)|031|－|[●](https://mubirou.github.io/Unity/introduction/apk/009_006.apk)|[●](http://corevale.com/unity/923)|2018-07-02|
|007|[Planeに動画を表示](#Planeに動画を表示)|032|－|－|－|2018-07-02|
|008|[ボールに重力を持たせる](#ボールに重力を持たせる)|030･033|－|－|－|2018-07-02|
|009|[オブジェクトの透明化](#オブジェクトの透明化)|033|－|－|－|2018-07-02|
|010|[クリックした位置にPrefabを表示](#クリックした位置にPrefabを表示)|034|－|[●](https://mubirou.github.io/Unity/introduction/apk/009_010.apk)|－|2018-07-03|
|011|[MouseOverで色を変える](#MouseOverで色を変える)|035|－|[●](https://mubirou.github.io/Unity/introduction/apk/009_011.apk)|－|2018-07-04|
|012|[オブジェクトをクリックで落下](#オブジェクトをクリックで落下)|036|－|[●](https://mubirou.github.io/Unity/introduction/apk/009_012.apk)|－|2018-07-04|

<a name="Unityのエディション"></a>
### 001 Unityのエディション

1. Personal（無料）……起動時の「Made with unity」ロゴを非表示できない
1. Plus（4,200円/月）……Apple Store製品20％割引（クリエイター向き）
1. Pro（15,000円/月）……Apple Store製品20％割引（プロ志向）

<a name="AssetStore保存場所"></a>
### 002 Asset Store保存場所（Ubuntuの場合）
```
ホーム/.local/share/unity3d/Asset Store-5.x
```
一度ダウンロードしてインポートしたものは上記の場所に保存され、次回からは「インポート」と表示される

<a name="Editorの設定"></a>
### 003 Editorの設定（Visual Studio Codeの場合）
[Edit]-[Preferences]-[External Tools]-[External Script Editor] で [Browse] を選び以下のパスを指定する
```
/usr/share/code/code
```
従来付属していた「MonoDevelop」はサポートされなくなる

<a name="マテリアルに画像を指定"></a>
### 004 マテリアルに画像を指定

1. デスクトップ等にある画像ファイル（.png .jpg）を [Project]-[Assets] にドラッグ＆ドロップ
1. [Scene] 上のマテリアルを適用したいオブジェクトに上記の画像をドラッグ＆ドロップ

<a name="空の背景の変更"></a>
### 005 空の背景の変更

1. [Window]-[Asset Store] から「Wispy SkyBox」をダウンロード＆インポート
1. [Hierarchy]-[Main Camera] を選択し [Inspector]-[Add Component]-[Rendering]-[Skybox] を追加
1. [Inspector]-[Skybox]-[Custom Skybox] の ⦿ を選び、任意の空の背景を選択

<a name="床を鏡のようにする"></a>
### 006 床を鏡のようにする

1. [Assets]-[Materials] で右クリック → [Create]-[Material] を選択（名前は任意）
1. [Inspector] で次の通りに設定  
    * Metallic : 1
    * Smoothness : 1
1. 床（Plane）に上記のマテリアルをドラッグ
1. [GameObject]-[Create Empty] で空のGameObjectを作成（名前は任意）
1. [Inscpector]-[Add Component] から「Reflection Prob」を検索して追加
1. [Inspector]-[Reflection Probe] で次の通りに設定
    * Type : Realtime
    * Refresh Mode : Every frame
    * Time Slicing : All faces at one（初期値）
    * Box Projection : ✔
    * Resolution : 512
    * Clear Flags : Solid Color
1. [Hierarchy]-[Main Camera] と床の [Inspector]-[Transform]-[Position] の値を確認
1. [Reflection Probe] を追加した空のGameObjectの [Inspector]-[Transform]-[Position] の値を次の通りにする（[Main Camera] の [Potision] の値が「X:0」「Y:2.5」「Z:-10」、床が「X:0」「Y:0」「Z:0」の場合）
    * x : 0
    * Y : -2.5（この値だけ負の値にする）
    * Z : -10
※Androidアプリでは鏡内のアニメーションが動作せず（要検証）

<a name="Planeに動画を表示"></a>
### 007 Planeに動画を表示

1. [Hierarchy]-[Create]-[3D Object]-[Plane] を選択
1. [Inscpector]-[Transform]-[Rotation] を次の通りに設定
    * X : 90
    * Y : 0
    * Z : -180 
1. [Shotcut](https://www.shotcut.org/) 等で作成した [.webm](https://ja.wikipedia.org/wiki/WebM) ファイルを、プロジェクトの [Assets] フォルダに保存
1. 上記で作成した [Plane] の [Inspector]-[Add Component]-[Video Player] を選択
1. [Inspector]-[Video Player]-[Video Clip] の ⦿ を選び、上記の映像を選択

<a name="ボールに重力を持たせる"></a>
### 008 ボールに重力を持たせる
1. [GameObject]-[3D Object]-[Sphere] でボールを作成
1. 同様に [Cube] を使って障害物を作成
1. [Sphere]-[Inspector]-[Add Component]-[Physics]-[Rigidbody] を選択
1. 再生ボタンを押すとボールが落下（障害物にぶつかると変化する）

<a name="オブジェクトの透明化"></a>
### 009 オブジェクトの透明化

1. [Project]-[Assets] を選択し右クリック
1. [Create]-[Folder] でフォルダを作成（名前は「Materials」とする）
1. 作成した [Materials] フォルダを選び右クリック
1. [Create]-[Material] でマテリアルを作成（名前は任意）
1. 作成したマテリアルの [Inspector] の値を次の通りにする
    * Rendering Mode : Fade
    * Albedo : A（Apha値）を0にする

※透明化されただけで存在はしている（衝突判定は有効）

<a name="クリックした位置にPrefabを表示"></a>
### 010 クリックした位置にPrefabを表示

* 「Prefab（プレハブ）」とは、オブジェクトを複製する場合に役立つ機能で、オブジェクトとそのコンポーネントやプロパティを一つに格納するものです
1. オブジェクト（Sphere）の作成  
    [GameObject]-[3D Object]-[Sphere] を選択  
1. オブジェクトのPrefab化  
    [Hierarchy] に表示される上記のオブジェクトを [Project]-[Assets] フォルダ内にドラッグ＆ドロップ  
    ※[Hierarchy] 内の上記のオブジェクトの文字色が青系に変わります  
    ※[Hierarchy] 内の上記のオブジェクトはここでは消します  
1. 空のゲームオブジェクトを作成  
    ① [GameObject]-[Create Empty] を選択  
    ② [Inspector] ウィンドウで、名前を "GameObject" から "God" に変更  
1. C#ファイルの作成  
    ① 上記の空のGameObject（God）を選択  
    ② [Inspector]-[Add Component]-[Net Script] を選択  
    ③ 名前を "NewBehaviourScript" から "CreateSphereScript" に変更  
1. C#の記述  
    ① [Project]-[Assets] 内の [CreateSphereScript]（C#）をダブルクリック  
    ※[Editorの設定](#Editorの設定)を設定していれば外部エディタが起動します  
    ② 次のように書き換えて保存  
    ```
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CreateSphereScript : MonoBehaviour {
        public GameObject _prefab;
        private Vector3 _mousePosition;

        void Update () {
            if (Input.GetMouseButton(0)) {
                _mousePosition = Input.mousePosition;
                _mousePosition.z = 5f;
                Instantiate(
                    _prefab,
                    Camera.main.ScreenToWorldPoint(_mousePosition),
                    _prefab.transform.rotation
                );
            }
        }
    }
    ```
1. public変数（_prefab）とPrefabをリンク  
    ① [Hierarycy]-[God] を選択  
    ② [Inspector]-[CreateSphereScript（Script）] に [Prefab] プロパティが追加されているのを確認  
    ③ ⦿を選び上記でPrefab化したオブジェクト（Sphere）を選択  
1. 実行  
    再生ボタンで実行し、クリックしたところにSphereが次々作成されたら成功

<a name="MouseOverで色を変える"></a>
### 011 MouseOverで色を変える

1. [GameObject]-[3D Object]-[Sphere] で球体を作成（名前は "Sphere01" に変更）
1. [Hierarchy]-[Sphere]-[Inspector]-[Add Component]-[Net Script] で名前は "ChangeColorScript" のC#ファイルを作成
1. [Project]-[Assets]-[ChangeColorScript]（C#）をダブルクリック
1. Visual Studio Codeなどのエディタで次の通りに書き換える
    ```
    //ChangeColorScript.cs
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class ChangeColorScript : MonoBehaviour {
        private GameObject _sphere;

        void Start() {
            _sphere = GameObject.Find("Sphere01");
        }
        
        void OnMouseOver() {
            Debug.Log(_sphere);
            _sphere.GetComponent<Renderer>().material.color = Color.red;
        }

        void OnMouseExit() {
            _sphere.GetComponent<Renderer>().material.color = Color.blue;
        }
    }
    ```
1. 実行すると球体の上にマウスカーソルを乗せると赤に変わり、外すと青になれば成功  
    ※Androidアプリでも有効

<a name="オブジェクトをクリックで落下"></a>
### 012 オブジェクトをクリックで落下

1. 球体（Sphere）の [Inspector]-[Add Component]-[Physics]-[Rigidbody] を追加
1. [Inspector]-[Rigidbody]-[Use Gravity] の ✔ を外す
1. [Hierarchy]-[Sphere]-[Inspector]-[Add Componet]-[New Script] でC#ファイルを作成（名前は "DropSphereScript"）
1. 次の通りにコードを変更
    ```
    //DropSphereScript.cs
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class DropSphereScript : MonoBehaviour {
        void Update () {
            if (Input.GetMouseButtonUp(0)) {
                GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }
    ```

※上記の例の場合、オブジェクト以外をクリックしても落下する

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS、Android 8.0  
作成者：夢寐郎  
作成日：2018年06月28日  
更新日：2018年07月04日


© 2018 夢寐郎