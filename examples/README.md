# <b>C# with Unity GameObject</b>

### <b>INDEX</b>

|No.|タイトル|内容|
|:--:|:--|:--|
|001| [テキスト表示](#テキスト表示)|UIのTextを使った時間表示|
|002|[ボールのバウンド](#ボールのバウンド)|バウンドし続けるボール|
|003|[キーで動かす](#キーで動かす)|キーボードのキーでボールを操作|
|004|[マウスボタンで回転](#マウスボタンで回転)|マウスのボタンで立方体を回転|
|005|[追跡するカメラ](#追跡するカメラ)|キーボードのキーで動くボールをカメラが追跡|
|006|[物理エンジンで動かす](#物理エンジンで動かす)|斜めの床をボールが転がり落ちる|
|007|[マテリアルの設定](#マテリアルの設定)|オブジェクトに色を付ける|
|008|[マウスに追従](#マウスに追従)|マウスを押している間ボールが追従する|
|009|[ボールをクリック](#ボールをクリック)|どのオブジェクトを選択したか調べる|
|010|[アニメーションクリップ](#アニメーションクリップ)|イーズイン･イーズアウトを繰り返すアニメーション|
|011|[サウンド再生](#サウンド再生)|ループサウンドや効果音を鳴らす|
|012|[当たり判定（反発）](#当たり判定（反発）)|ボールを移動させ別のボールとの当たり判定を調べる（反発）|
|013|[当たり判定（通過）](#当たり判定（通過）)|ボールを落下させ別のボールとの当たり判定を調べる（通過）|
|014|[パーティクル](#パーティクル)|任意の操作でパーティクルを発生させる|
|015|[ハロー](#ハロー)|任意の操作でハローを表示させる|
|016|[オブジェクトの生成](#オブジェクトの生成)|たくさんの立方体を生成|
|017|[オブジェクトを消す](#オブジェクトを消す)|任意の操作でオブジェクトを半透明や非表示にする|
|018|[スライダー](#スライダー)|UIのスライダーを使ってオブジェクとの色を変更|
|019|[ボタン](#ボタン)|UIのボタンを使う|
|020|[トグルボタン](#トグルボタン)|UIのトグルボタンを使う|
|021|[シーンの移動](#シーンの移動)|任意の操作でシーンを移動させる|
|022|[シーン移動時にオブジェクトを残す](#シーン移動時にオブジェクトを残す)|シーン移動時にオブジェクトを残す|
|023|[他人のメソッドの実行①](#他人のメソッドの実行①)|他のオブジェクトのメソッドを実行する（引数1個まで）|
|024|[他人のメソッドの実行②](#他人のメソッドの実行②)|他のオブジェクトのメソッドを実行する（引数2個以上）|
|025|[データの保存](#データの保存)|任意の操作でデータ（整数値･浮動小数点数･文字列）を保存|
|026|[GameObjectの入れ子](#GameObjectの入れ子)|オブジェクトの入れ子（ネスト）|
|027|[キョロキョロ](#キョロキョロ)|オブジェクトを任意の方向に向かせる|
|028|[クローン作成](#クローン作成)|ミサイルのように同じオブジェクトが次々と登場|
|029|[数秒後にメソッドを実行](#数秒後にメソッドを実行)|数秒後にメソッドを実行|
|030|[二点間の距離](#二点間の距離)|三次元空間にある2つのオブジェクト間の距離を調べる|
|031|[他のC#ファイルの参照](#他のC#ファイルの参照)|同一オブジェクトにアタッチしたC#ファイルを利用する|
|032|[シーンを重ねる](#シーンを重ねる)|シーンを重ねる|
|033|[シーンの事前読込み①](#シーンの事前読込み①)|ロードに時間がかかるシーンを事前に読込む①|
|034|[シーンの事前読込み②](#シーンの事前読込み②)|ロードに時間がかかるシーンを事前に読込む②|
|035|[フワッと動いてスッと止まる](#フワッと動いてスッと止まる)|矢印キーでフワッと動いてスッと止まる|
|036|[ユニティちゃん入門](#ユニティちゃん入門)|ユニティちゃんを動かしてみる|
|037|[外部クラスの利用](#外部クラスの利用)|外部クラス（C#ファイル）の利用|
***

<a name="テキスト表示"></a>
# <b>001 テキスト表示</b>

### Textオブジェクトの作成
1. [GameObject]-[UI]-[Text] を選択。
1. [Hierarchy] ウィンドウに追加された [Canvas] 階層化の [Text] をダブルクリックして確認。
    * [Canvas] は、[Text] 等のGUIの土台となるオブジェクトです。
1. [Scene] ウィンドウ上に "New Text" という文字が表示されているのが確認できるはずです。
1. [Inspector] ウィンドウで、名前を "Text" から "Text001" に変更。
* 時どき [File]-[Save Scene] でシーンを保存しておきましょう。

### C#ファイルの作成
1. [Assets]-[Create]-[C# Script] を選択。
1. 名前を "NewBehaviourScript" から "Text001Script" に変更。
    * 同時に (プロジェクト名)/Assets/Text001Script.cs が生成されます。

### C#の記述
1. VSCode等のエディタで "Text001Script.cs" を開きます。
1. 次のように書き換えて保存。
```
//Text001Script.cs
using UnityEngine;
using UnityEngine.UI; //Textに必要（追加）
using System; //DateTimeに必要（追加）

public class Text001Script : MonoBehaviour {
	public Text _text; //このC#ファイルを紐付けたTextを参照（追加）←特殊な考え方

	void Update () {
		_text.text = DateTime.Now.ToString(); //追加
	}
}
```

### オブジェクトとC#の紐付け
1. [Hierarchy] ウィンドウの [Text001] を選択した状態で、[Inspector] ウィンドウを確認。
1. 上記で作成した [Text001Script] を [Add Component] エリアにドラッグ＆ドロップ。
    * 今回は、Text 自身にスクリプトを組み込み（紐付け）ました。
1. [Hierarchy]-[Text001]-[Inspector]-[Text001Script(Script)] の [Text] の [⦿] をクリックし、[None(Text)] を [Text001] に変更します（分かり難く見落としがちなので注意）。

### 実行
1. [再生] ボタンまたは [Edit]-[Play] を選択。
1. [Game] ウィンドウ上に "2018/04/02 8:56:35" 等と表示されれば成功。  
![001](https://mubirou.github.io/Unity/examples/jpg/001.jpg)

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：夢寐郎  
作成日：2018年03月29日  
更新日：2018年04月02日


<a name="ボールのバウンド"></a>
# <b>002 ボールのバウンド</b>

### 床の作成
1. [GameObject]-[3D Object]-[Cube] を選択。
1. [Inspector] ウィンドウで、名前を "Cube" から "Floor001" に変更。
1. [Transform] を次のように変更。
    * Position X:0 Y:-2.5 Z:0
    * Scale X:80 Y:5 Z:80 ←大きさ80x80m、厚さ5mの床

### ボールの作成
1. [GameObject]-[3D Object]-[Sphere] を選択。
1. [Inspector] ウィンドウで、名前を "Sphere" から "Ball001" に変更。
1. [Transform] を次のように変更。
    * Position X:0 Y:10 Z:0 ←床の上に置いてあるように配置（半径分移動）
    * Scale X:20 Y:20 Z:20 ←直径20mの玉

### 空のゲームオブジェクトを作成
1. [GameObject]-[Create Empty] を選択。
1. [Inspector] ウィンドウで、名前を "GameObject" から "God" に変更。

### C#ファイルの作成
1. [Assets]-[Create]-[C# Script] を選択。
1. 名前を "NewBehaviourScript" から "Main" に変更。
    * 同時に (プロジェクト名)/Assets/Main.cs が生成されます。
1. 上記で作成した "God" の [Inspector]-[Add Component] エリアに上記のC#（Main）をドラッグ＆ドロップ。
* MonoBehaviourを継承したスクリプトを動作させるためには、いずれかのGameObjectにアタッチ（紐付け）する必要があります。

### C#の記述
1. VSCode等のエディタで "Main.cs" を開きます。
1. 次のように書き換えて保存。
```
//Main.cs
using UnityEngine;
using System; //Mathに必要

public class Main : MonoBehaviour {
	private GameObject _ball; //ターゲットのGameObjectの参照
	private float _originY;
	private float _currentY;
	private float _count = 0f;

	void Start () {
		_ball = GameObject.Find("Ball001"); //シーンの中から任意のGameObjectを探します
		_originY = _currentY = _ball.transform.position.y; //GameObjectのY座標位置
	}
	
	void Update () {
		_count += 0.05f;
		float _nextY = (float)(50 * Math.Abs(Math.Cos(_count)) + _originY);
		float _disY = _nextY - _currentY;
		_ball.transform.Translate(0, _disY, 0); //移動させたい値（x,y,z）を指定
		_currentY = _ball.transform.position.y;
	}
}
```

### カメラの調整
[Main Camera]-[Transform] を次のように変更。
* Position X:0 Y:30 Z:-100
* Rotation: X:5 Y:0 Z:0

### 実行
1. [再生] ボタンまたは [Edit]-[Play] を選択。
1. ボールが床にバウンドし続ければ成功。  
![002](https://mubirou.github.io/Unity/examples/jpg/002.jpg)

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：夢寐郎  
作成日：2018年04月02日


<a name="キーで動かす"></a>
# <b>003 キーで動かす</b>

### C#の記述
1. ここでは「[002 ボールのバウンド](#ボールのバウンド)」のMain.csを書き換えてみます。
1. 次のように書き換えて保存。
```
//Main.cs
using UnityEngine;

public class Main : MonoBehaviour {
	private GameObject _ball; //ターゲットのGameObjectの参照

	void Start () {
		_ball = GameObject.Find("Ball001"); //シーンの中から任意のGameObjectを探す
	}

	void Update () {
		if (Input.GetKey(KeyCode.UpArrow)) { //↑キーを押している間...
			_ball.transform.Translate(transform.forward); //○.Translate(0,0,1)と同じ
		} else if (Input.GetKey(KeyCode.DownArrow)) { //↓キーを押している間...
			_ball.transform.Translate(-transform.forward); //○.Translate(0,0,-1)と同じ
		} else if (Input.GetKey(KeyCode.RightArrow)) { //→キーを押している間...
			_ball.transform.Translate(transform.right); //○.Translate(1,0,0)と同じ
		} else if (Input.GetKey(KeyCode.LeftArrow)) { //←キーを押している間...
			_ball.transform.Translate(-transform.right); //○.Translate(-1,0,0)と同じ
		} else if (Input.GetKey(KeyCode.Space)) { //Spaceキーを押している間...
			_ball.transform.Translate(transform.up); //○.Translate(0,1,0)と同じ（上昇）
		}
	}
}
```
![003](https://mubirou.github.io/Unity/examples/jpg/003.jpg)

### GetKey と GetKeyDown / GetKeyUp の違い
```
void Update () {
	//if (Input.GetKey(KeyCode.RightArrow)) { //→キーを押している間...
	if (Input.GetKeyDown(KeyCode.RightArrow)) { //→キーを押す度に...
	//if (Input.GetKeyDown("a")) { //←...KeyCodeを使わない方法もあります
		_ball.transform.Translate(transform.right);
	}
}
```

### 主な KeyCode
KeyCode.A（Aキー）、KeyCode.UpArrow（↑キー）、KeyCode.RightArrow（→キー）
KeyCode.Space（スペースキー）、KeyCode.Return（Enterキー） など

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：夢寐郎  
作成日：2018年04月03日


<a name="マウスボタンで回転"></a>
# <b>004 マウスボタンで回転</b>

### 立方体の作成
1. [GameObject]-[3D Object]-[Cube]を選択。
1. 名前を "Cube" から "Cube001" に変更。
1. Scaleは適当に調整。

### 空のゲームオブジェクトを作成
1. [GameObject]-[Create Empty] を選択。
1. [Inspector] ウィンドウで、名前を "GameObject" から "God" に変更。

### C#ファイルの作成
1. [Assets]-[Create]-[C# Script] を選択。
1. すかさず名前を "NewBehaviourScript" から "Main" に変更。
    * 同時に (プロジェクト名)/Assets/Main.cs が生成されます。
1. 上記で作成した "God" の [Inspector]-[Add Component] エリアに上記のC#（Main）をドラッグ＆ドロップ。

### C#の記述
1. VSCode等のエディタで "Main.cs" を開きます。
1. 次のように書き換えて保存。
```
//Main.cs
using UnityEngine;

public class Main : MonoBehaviour {
	private GameObject _cube1; //ターゲットのGameObjectの参照

	void Start () {
		_cube1 = GameObject.Find("Cube001"); //シーンの中から任意のGameObjectを探す
	}
	
	void Update () {
		if (Input.GetMouseButton(0)) { //左ボタンを押している場合...
			_cube1.transform.Rotate(new Vector3(0,1,0)); //上から見て時計回り
		} else if (Input.GetMouseButton(1)) { //右ボタンを押している場合...
			_cube1.transform.Rotate(new Vector3(0,-1,0)); //上から見て反時計回り
		} else if (Input.GetMouseButton(2)) { //中央ボタンを押している場合...
			_cube1.transform.Rotate(new Vector3(1,0,0)); //奥へ進むように回転
		}
	}
}
```

### 実行
1. [再生] ボタンまたは [Edit]-[Play] を選択。
1. （画面のどこにカーソルがあっても）マウスカーソルのボタンを押して立方体が回転すれば成功。  
![004](https://mubirou.github.io/Unity/examples/jpg/004.jpg)

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：夢寐郎  
更新日：2018年04月03日


<a name="追跡するカメラ"></a>
# <b>005 追跡するカメラ</b>

### ポイント
1. Cameraも（Lightも）実はGameObject。シーンに登場する部品は全てGameObjectです。
1. ①カメラが追跡するGameObjectの位置情報を取得 ②位置調整 ③カメラの位置を設定、の順で処理。

### C#の記述
1. ここでは「[キーで動かす](#キーで動かす)」のMain.csを書き換えてみます。
1. 次のように書き換えて保存。
```
using UnityEngine;

public class Main : MonoBehaviour {
	private GameObject _ball; //カメラが追跡するGameObject
	private GameObject _camera; //カメラの参照
	
	void Start () {
		_ball = GameObject.Find("Ball001");
		_camera = GameObject.Find("Main Camera"); //シーンの中からMain Cameraを探
	}

	void Update () {
		//キーボードのキーを使って球体を動かします
		if (Input.GetKey(KeyCode.UpArrow)) { //↑キーを押している間...
			_ball.transform.Translate(transform.forward / 2);
		} else if (Input.GetKey(KeyCode.DownArrow)) { //↓キーを押している間...
			_ball.transform.Translate(-transform.forward / 2);
		} else if (Input.GetKey(KeyCode.RightArrow)) { //→キーを押している間...
			_ball.transform.Translate(transform.right / 2);
		} else if (Input.GetKey(KeyCode.LeftArrow)) { //←キーを押している間...
			_ball.transform.Translate(-transform.right / 2);
		}

		//①カメラが追跡するGameObjectの位置情報を取得
		Vector3 _cameraPos = _ball.transform.position;

		//②位置調整
		_cameraPos.y += 25; //上方に移動
		_cameraPos.z -= 50; //手前に移動

		//③カメラの位置を設定
		_camera.transform.position = _cameraPos;
	}
}
```
![005](https://mubirou.github.io/Unity/examples/jpg/005.jpg)

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：夢寐郎  
作成日：2018年04月03日


<a name="物理エンジンで動かす"></a>
# <b>006 物理エンジンで動かす</b>

### 床の作成
1. [GameObject]-[3D Object]-[Plane]を選択。
1. [Inspector] ウィンドウで、名前を "Plane" から "Floor001" に変更。
1. [Transform] を次のように変更。
	* Rotation X:-20（=340）Y:0 Z:0 ←手前に20°傾斜

### ボールの作成
1. [GameObject]-[3D Object]-[Sphere] を選択。
1. [Inspector] ウィンドウで、名前を "Sphere" から "Ball001" に変更。
1. [Transform] を次のように変更。
    * Position X:0 Y:5 Z:0 ←空中に浮かす
1. [Hierarchy] で "Ball001" を選択した状態で [Component]-[Physics]-[Rigidbody] を選択。
	* これで "Ball001" に物理的な動きを追加できました。

### 空のゲームオブジェクトを作成
1. [GameObject]-[Create Empty] を選択。
1. [Inspector] ウィンドウで、名前を "GameObject" から "God" に変更。

### C#ファイルの作成
1. [Assets]-[Create]-[C# Script] を選択。
1. 名前を "NewBehaviourScript" から "Main" に変更。
    * 同時に (プロジェクト名)/Assets/Main.cs が生成されます。
1. 上記で作成した "God" の [Inspector]-[Add Component] エリアに上記のC#（Main）をドラッグ＆ドロップ。

### C#の記述
1. VSCode等のエディタで "Main.cs" を開きます。
1. 次のように書き換えて保存。
```
//Main.cs
using UnityEngine;

public class Main : MonoBehaviour {
	private GameObject _ball;
	
	void Start () {
		_ball = GameObject.Find("Ball001");
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) { //スペースキーを押したら...
			_ball.transform.GetComponent<Rigidbody>().AddForce(0,0,500); //奥へ押す
		}
	}
}
```

### 実行
1. [再生] ボタンまたは [Edit]-[Play] を選択。
1. 玉が転がって落ち、スペースキーを押すと登らせることが出来れば成功。  
![006](https://mubirou.github.io/Unity/examples/jpg/006.jpg)

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：夢寐郎  
作成日：2018年04月04日


<a name="マテリアルの設定"></a>
# <b>007 マテリアルの設定</b>

### 方法① 手作業によるマテリアルの設定
1. [Assets]-[Create Empty] を選択。
1. [Inspector] ウィンドウで、[Albedo] や [Emission] などを変更。
1. [Hierarchy] から適用したい GameObject を選択し、[Inspector] の [Add Component] エリアに、上記で作成した [Assets] 内のマテリアルをドラッグ＆ドロップ。

### 方法② スクリプティングによる設定

1. [GameObject]-[Create Empty] を選択。
1. [Inspector] ウィンドウで、名前を "GameObject" から "God" に変更。
1. [Assets]-[Create]-[C# Script] を選択。
1. 名前を "NewBehaviourScript" から "Main" に変更。
    * 同時に (プロジェクト名)/Assets/Main.cs が生成されます。
1. 上記で作成した "God" の [Inspector]-[Add Component] エリアに上記のC#（Main）をドラッグ＆ドロップ。
1. VSCode等のエディタで "Main.cs" を開きます。
1. 次のように書き換えて保存（適用したい GameObject が "Ball001" の場合）。
```
//Main.cs
using UnityEngine;

public class Main : MonoBehaviour {
	private GameObject _ball; //マテリアルを適用したいGameObject
	
	void Start() { // Use this for initialization
		_ball = GameObject.Find("Ball001"); //←マテリアルを適用したいGameObjectを探す

		Debug.Log(_ball.GetComponent<Renderer>().material.color); 
		//RGBA(1.000, 1.000, 1.000, 1.000)

		//R:255 G:204 B:0 の色を適用する（値は0.0f〜1.0f）
		_ball.GetComponent<Renderer>().material.color = new Color(1.0f, 0.8f, 0.0f, 1.0f);

		Debug.Log(_ball.GetComponent<Renderer>().material.color); 
		//RGBA(1.000, 0.800, 0.000, 1.000)
	}
}
```
![007](https://mubirou.github.io/Unity/examples/jpg/007.jpg)

### 色の指定方法
* new Color(赤, 緑, 青 [,不透明度])  
* Color.red（赤）、Color.blue（青）、Color.green（緑）、Color.black（黒）、Color.white（白）、Color.cyan（シアン）、Color.magenta（マゼンタ）、Color.yellow（黄）、Color.gray（グレー）、Color.clear（RGBAが全て0）

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：夢寐郎  
作成日：2018年04月05日


<a name="マウスに追従"></a>
# <b>008 マウスに追従</b>

### ボールの作成
1. [GameObject]-[3D Object]-[Sphere] を選択。
1. [Inspector] ウィンドウで、名前を "Sphere" から "Ball001" に変更。

### 空のゲームオブジェクトを作成
1. [GameObject]-[Create Empty] を選択。
1. [Inspector] ウィンドウで、名前を "GameObject" から "God" に変更。

### C#ファイルの作成
1. [Assets]-[Create]-[C# Script] を選択。
1. 名前を "NewBehaviourScript" から "Main" に変更。
    * 同時に (プロジェクト名)/Assets/Main.cs が生成されます。
1. 上記で作成した "God" の [Inspector]-[Add Component] エリアに上記のC#（Main）をドラッグ＆ドロップ。

### C#の記述
1. VSCode等のエディタで "Main.cs" を開きます。
1. 次のように書き換えて保存。
```
//Main.cs
using UnityEngine;

public class Main : MonoBehaviour {
	private GameObject _ball;
	private float _cameraPosZ; 

	void Start () {
		_ball = GameObject.Find("Ball001");
		_cameraPosZ = Camera.main.transform.position.z; //初期値は-10
	}
	
	void Update () {
		if (Input.GetMouseButton(0)) { //左ボタンを押し続けている間...
		//if (Input.GetMouseButtonDown(0)) { //左ボタンを押したら...

			Vector3 _mousePos = Input.mousePosition; //マウスの位置を取得
			//Debug.Log(_mousePos); //(15.0, 19.0, 0.0) ←画面左下が（0,0,0）

			_mousePos.z = - _cameraPosZ; //画面上のマウスの位置を奥側に移動（-10）

			//↓カメラから見た位置をシーンの絶対座標（グローバル座標）に変換
			Vector3 _newPos = Camera.main.ScreenToWorldPoint(_mousePos);
			_ball.transform.position = _newPos;
		}
	}
}
```

### 実行
1. [再生] ボタンまたは [Edit]-[Play] を選択。
1. マウスの左ボタンを押し続けているとボールが追従したら成功。

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：夢寐郎  
作成日：2018年04月05日


<a name="ボールをクリック"></a>
# <b>009 ボールをクリック</b>

### ２個のボールを作成
1. [GameObject]-[3D Object]-[Sphere] を選択。
1. [Inspector] ウィンドウで、名前を "Sphere" から "RedBall" に変更。
1. [Transform] を次のように変更。
    * Scale X:3 Y:3 Z:3
4. 同様にもう1つ、"WhiteBall" を作成し、[Transform] を次のように変更。
	* Position X:3 Y:0 Z:0
	* Scale X:3 Y:3 Z:3

### 空のゲームオブジェクトを作成
1. [GameObject]-[Create Empty] を選択。
1. [Inspector] ウィンドウで、名前を "GameObject" から "God" に変更。

### C#ファイルの作成
1. [Assets]-[Create]-[C# Script] を選択。
1. 名前を "NewBehaviourScript" から "Main" に変更。
    * 同時に (プロジェクト名)/Assets/Main.cs が生成されます。
1. 上記で作成した "God" の [Inspector]-[Add Component] エリアに上記のC#（Main）をドラッグ＆ドロップ。

### C#の記述
1. VSCode等のエディタで "Main.cs" を開きます。
1. 次のように書き換えて保存。
```
//Main.cs
using UnityEngine;

public class Main : MonoBehaviour {
	void Start () {
		GameObject.Find("RedBall").GetComponent<Renderer>().material.color = Color.red;
		GameObject.Find("WhiteBall").GetComponent<Renderer>().material.color = Color.white;
	}

	void Update () {
		if (Input.GetMouseButtonDown(0)) { //①左ボタンを押したら...
			//②選択した画面の位置をRay（光線）に変換
			Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			//Debug.Log(Input.mousePosition); //(370.0, 164.0, 0.0) など
			//Debug.Log(_ray); //Origin: (0.0, 1.0, -9.7), Dir: (0.0, -0.1, 1.0)
			
			//③Rayが命中したGameObjectの情報を格納
			RaycastHit _hit = new RaycastHit(); //RaycastHitは構造体
			
			//④GameObjectにRay（光線）が命中（選択）したら...
			if (Physics.Raycast(_ray, out _hit, 100f)) {
				Debug.Log(_hit.collider.gameObject.name + "を選択");
			}
		}
	}
}
```

### 実行
1. [再生] ボタンまたは [Edit]-[Play] を選択。
1. ボールを選択すると、"RedBallを選択" または "WhiteBall" を選択と表示されたら成功。  
![009](https://mubirou.github.io/Unity/examples/jpg/009.jpg)

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：夢寐郎  
作成日：2018年04月06日


<a name="アニメーションクリップ"></a>
# <b>010 アニメーションクリップ</b>

### ボールを作成とAnimationコンポーネントの追加
1. [GameObject]-[3D Object]-[Sphere] を選択。
1. [Inspector] ウィンドウで、名前を "Sphere" から "Ball001" に変更。
1. "Ball001"を選んだ状態で[Component]-[Miscellaneous]-[Animation]を選択し追加。
	* 追加しないと以下のコードを書いてもアニメーションしない。

### 空のゲームオブジェクトを作成
1. [GameObject]-[Create Empty] を選択。
1. [Inspector] ウィンドウで、名前を "GameObject" から "God" に変更。

### C#ファイルの作成
1. [Assets]-[Create]-[C# Script] を選択。
1. 名前を "NewBehaviourScript" から "Main" に変更。
    * 同時に (プロジェクト名)/Assets/Main.cs が生成されます。
1. 上記で作成した "God" の [Inspector]-[Add Component] エリアに上記のC#（Main）をドラッグ＆ドロップ。

### C#の記述
1. VSCode等のエディタで "Main.cs" を開きます。
1. 次のように書き換えて保存。
```
//Main.cs
using UnityEngine;

public class Main : MonoBehaviour {
	private GameObject _ball001;

	void Start () { // Use this for initialization
		_ball001 = GameObject.Find("Ball001");

		//①AnimationClipの作成
		AnimationClip _animClip = new AnimationClip();

		//②旧式な方法を可能にする
		_animClip.legacy = true;
		
		//③AnimationCurveの作成（開始時間,開始値,終了時間,終了値）
		AnimationCurve _animCurve = AnimationCurve.EaseInOut(0f, 0f, 5f, 0f);

		//④キーフレームの作成と追加（時間,値）
		Keyframe _keyframe = new Keyframe(2.5f, 10f); //2.5秒後に右へ10の地点
		_animCurve.AddKey(_keyframe); //複数追加可能

		//⑤AnimationClipへAnimationCurveを設定
		_animClip.SetCurve("", typeof(Transform), "localPosition.x", _animCurve);

		//⑥ラップモードの設定（Once/Loop/PingPong（行ったり来たり）等あり）
		_animClip.wrapMode = WrapMode.Loop;

		//⑦Cube01のanimationプロパティにAnimationClipを組み込む
		_ball001.GetComponent<Animation>().AddClip(_animClip, "animClip01");

		//⑨アニメーションの開始
		_ball001.GetComponent<Animation>().Play("animClip01");
		//_ball001.GetComponent<Animation>().Stop("animClip01"); //停止させる場合
	}

	void Update () { //必要なし！
	}
}
```

### 実行
1. [再生] ボタンまたは [Edit]-[Play] を選択。
1. 2.5秒後に右へ10、5秒後に元の位置へ...をイーズイン･イーズアウトしながら繰り返せば成功。  
![010](https://mubirou.github.io/Unity/examples/jpg/010.jpg)

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：夢寐郎  
作成日：2018年04月07日


<a name="サウンド再生"></a>
# <b>011 サウンド再生</b>

### サウンドの用意
1. (Project name)/Assets/ フォルダにBGM用とSE用ファイルを保存。
	* ファイル形式は、MP3、WAV、AIFF、Ogg の何れか。
	* 今回は "loop01.wav" "se01.mp3" "se02.mp3" の3つを用意。
1. [Assets]-[Import New Asset...]から上記のサウンドファイルをインポート。

### 空のゲームオブジェクトを作成
1. [GameObject]-[Create Empty] を選択。
1. [Inspector] ウィンドウで、名前を "GameObject" から "God" に変更。

### ”God" に各サウンドを紐付ける
1. "God" の [Add Component] ボタンをクリック→[Audio]-[Audio Source] を選択。
1. [Audio Source] の [AudioClip] の [⦿] をクリックし、[None(Audio Clip)] を [loop01] に変更。
1. その他、次の通りに設定（確認）する。
* [Play On Awake] を✔（SE用は✔を外す）
* [Loop] に✔（SEの場合は✔をしない）
1. 引き続き、サウンドファイル分繰り返します。

### C#ファイルの作成
1. [Assets]-[Create]-[C# Script] を選択。
1. 名前を "NewBehaviourScript" から "Main" に変更。
    * 同時に (プロジェクト名)/Assets/Main.cs が生成されます。
1. 上記で作成した "God" の [Inspector]-[Add Component] エリアに上記のC#（Main）をドラッグ＆ドロップ。

### C#の記述
1. VSCode等のエディタで "Main.cs" を開きます。
1. 次のように書き換えて保存。
```
//Main.cs
using UnityEngine;

public class Main : MonoBehaviour {
	private AudioSource _loop01, _se01, _se02;

	void Start () {
		AudioSource[] _audioArray = GetComponents<AudioSource>();
		_loop01 = _audioArray[0];
		_se01 = _audioArray[1];
		_se02 = _audioArray[2];
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			//if (! _se01.isPlaying) { //再生中でなければ..を指定する場合
				_se01.Play(); //再生
			//}
		} else if (Input.GetKeyDown(KeyCode.Return)) {
			_loop01.Stop(); //停止
			_se02.Play(); //再生
		}
	}
}
```

### 実行
1. [再生] ボタンまたは [Edit]-[Play] を選択。
1. 最初からBGM（"loop01.mp3"）がループ再生され、スペースキーを押すと効果音（"se01.mp3"）が1回再生（BGMは再生されたまま）。リターンキーを押すとBGMが止まり、効果音（"se02.mp3"）が鳴れば成功。  
![011](https://mubirou.github.io/Unity/examples/jpg/011.jpg)

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：夢寐郎  
作成日：2018年04月07日


<a name="当たり判定（反発）"></a>
# <b>012 当たり判定（反発）</b>

### 1つめのボール作成
1. [GameObject]-[3D Object]-[Sphere] を選択。
1. [Inspector] ウィンドウで、名前を "Sphere" から "Ball001" に変更。
1. [Transform] を次のように変更。
    * Position X:0 Y:0.5 Z:0

### 2つめのボール作成
1. 同様にもう1つ、"Ball002" を作成。
1. [Transform] を次のように変更。
	* Position X:2 Y:1 Z:0
1. "Ball002" を選択した状態で [Component]-[Physics]-[Rigidbody] を選択。

### 床を作成
1. [GameObject]-[3D Object]-[Plane] を選択し「Position X:5.5 Y:0.5 Z:0」に変更。
1. "Main Camera"の設定を「Position X:0 Y:1 Z:-5」に変更。

### C#ファイルの作成
1. [Assets]-[Create]-[C# Script] を選択。
1. 名前を "NewBehaviourScript" から "Ball002" に変更。
    * 同時に (プロジェクト名)/Assets/Ball002.cs が生成されます。
1. 上記で作成した "Ball002" の [Inspector]-[Add Component] エリアに上記のC#（Ball002）をドラッグ＆ドロップ。

### C#の記述
1. VSCode等のエディタで "Ball002.cs" を開きます。
1. 次のように書き換えて保存。
```
//Ball002.cs
using UnityEngine;

public class Ball002 : MonoBehaviour { //以下thisは省略可
	void Start () {} // 不要
	
	void Update () {
		if (Input.GetKey(KeyCode.RightArrow)) { //「→」キーを押している間...
			this.transform.GetComponent<Rigidbody>().AddForce(10,0,0); //右へ押す
		} else if (Input.GetKey(KeyCode.LeftArrow)) { //「←」キーを押している間...
			this.transform.GetComponent<Rigidbody>().AddForce(-10,0,0); //左へ押す
		}
	}

	void OnCollisionEnter(Collision arg) { //衝突判定（当たり判定）イベント
		if (arg.gameObject.name == "Ball001") { //Ball001と接触した瞬間...
			Debug.Log("Ball001に接触");
		}
	}

	void OnCollisionStay(Collision arg) { //衝突判定（当たり判定）イベント
		if (arg.gameObject.name == "Ball001") { //接触し続けている場合...
			Debug.Log("Ball001に接触し続けている");
		}
	}

	void OnCollisionExit(Collision arg) { //衝突判定イベント
		if (arg.gameObject.name == "Ball001") { //離れる瞬間...
			Debug.Log("Ball001と離れた");
		}
	}
}
```

### 実行
1. [再生] ボタンまたは [Edit]-[Play] を選択。
1. 左右の矢印キーで右側のボール（"Ball002"）が移動。"Ball001" に接触したか判定できれば成功。  
![012](https://mubirou.github.io/Unity/examples/jpg/012.jpg)

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：夢寐郎  
作成日：2018年04月07日


<a name="当たり判定（通過）"></a>
# <b>013 当たり判定（通過）</b>

### 1つめのボール作成
1. [GameObject]-[3D Object]-[Sphere] を選択。
1. [Inspector] ウィンドウで、名前を "Sphere" から "Sphere001" に変更。

### 2つめのボール作成
1. 同様にもう1つ、"Sphere002" を作成。
1. [Transform] を次のように変更。
	* Position X:0 Y:2 Z:0
1. "Sphere002" を選択した状態で [Component]-[Physics]-[Rigidbody] を選択。
	* [Sphere Collider]-[Is Trigger]:✔ ←チェックすると重力はあるものの物と物が衝突しても通過


### C#ファイルの作成
1. [Assets]-[Create]-[C# Script] を選択。
1. 名前を "NewBehaviourScript" から "Sphere002" に変更。
    * 同時に (プロジェクト名)/Assets/Sphere002.cs が生成されます。
1. 上記で作成した "Sphere002" の [Inspector]-[Add Component] エリアに上記のC#（Sphere002）をドラッグ＆ドロップ。

### C#の記述
1. VSCode等のエディタで "Sphere002.cs" を開きます。
1. 次のように書き換えて保存。
```
//Sphere002.cs
using UnityEngine;

public class Sphere002 : MonoBehaviour { //以下thisは省略可
	void Start () { //不要
	}

	void Update () { //不要
	}

	void OnTriggerEnter(Collider arg) { //衝突判定（当たり判定）イベント
		if (arg.gameObject.name == "Sphere001") { //Sphere001と接触した瞬間...
			Debug.Log("Sphere001に接触");
		}
	}

	void OnTriggerStay(Collider arg) { //衝突判定（当たり判定）イベント
		if (arg.gameObject.name == "Sphere001") { //接触（通過）し続けている場合...
			Debug.Log("Sphere001を通過中");
		}
	}

	void OnTriggerExit(Collider arg) { //衝突判定（当たり判定）イベント
		if (arg.gameObject.name == "Sphere001") { //離れる瞬間...
			Debug.Log("Sphere001と離れた");
		}
	}
}
```

### 実行
1. [再生] ボタンまたは [Edit]-[Play] を選択。
1. ボール（"Sphere002"）が落下し、"Sphere001" を通過。その際、Consoleに "Sphere001に接触" → "Sphere001を通過中" → "Sphere001と離れた" と表示されたら成功。  
	* この方法（OnTriggerXXX）を使うと物と物が衝突してもそのまま通過します（重力あり）。  
![013](https://mubirou.github.io/Unity/examples/jpg/013.jpg)

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：夢寐郎  
作成日：2018年04月08日


<a name="パーティクル"></a>
# <b>014 パーティクル</b>

* 他にも実用的な Simple Particle Pack（FREE）などAsset Storeを利用する方法もあります。

### ボール作成
1. [GameObject]-[3D Object]-[Sphere] を選択。
1. [Inspector] ウィンドウで、名前を "Sphere" から "Sphere001" に変更。

### ボールにパーティクルを追加
1. [Hierarchy] の "Sphere001" を選んだ状態で、[Component]-[Effects]-[Particle System] を選択。
1. [Inspector]-[Particle System] の値を次のように変更。
	* Looping: OFF（繰返し）
	* Gravity Modifier: 0.1（重力）
	* Play On Awake: OFF（自動実行）
	* Size over Lifetime: ✔（最初は小さく）
	* Rotation over Lifetime: ✔（角度を付ける）

### C#ファイルの作成
1. [Assets]-[Create]-[C# Script] を選択。
1. 名前を "NewBehaviourScript" から "Sphere001" に変更。
    * 同時に (プロジェクト名)/Assets/Sphere001.cs が生成されます。
1. 上記で作成した "Sphere001" の [Inspector]-[Add Component] エリアに上記のC#（Sphere001）をドラッグ＆ドロップ。

### C#の記述
1. VSCode等のエディタで "Sphere001.cs" を開きます。
1. 次のように書き換えて保存。
```
//Sphere001.cs
using UnityEngine;

public class Sphere001 : MonoBehaviour {
	private ParticleSystem _particle;

	void Start () { //不要
	}
	
	void Update () { //thisは省略可
		if (Input.GetKey(KeyCode.Space)) { //スペースキーを押すと...
			_particle = GetComponent<ParticleSystem>();
			_particle.Play();

			//パーティクル終了後、GameObjectを消す
			Destroy(this.gameObject, _particle.duration);
		}
	}
}
```

### 実行
1. [再生] ボタンまたは [Edit]-[Play] を選択。
1. スペースキーを押すとパーティクルが発生し、数秒でボールも含め消えれば成功。  
![014](https://mubirou.github.io/Unity/examples/jpg/014.jpg)

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：夢寐郎  
作成日：2018年04月10日


<a name="ハロー"></a>
# <b>015 ハロー</b>

### ボール作成
1. [GameObject]-[3D Object]-[Sphere] を選択。
1. [Inspector] ウィンドウで、名前を "Sphere" から "Sphere001" に変更。
1. [Transform] を次のように変更。
    * Scale X:2 Y:2 Z:2

### ボールにハローを追加
1. [Hierarchy] の "Sphere001" を選んだ状態で、[Component]-[Effects]-[Halo]を選択。
1. [Inspector]-[Particle System] の値を次のように設定。
	* Halo: OFF（初期状態）
	* Color: 赤
	* Size: 2

### C#ファイルの作成
1. [Assets]-[Create]-[C# Script] を選択。
1. 名前を "NewBehaviourScript" から "Sphere001" に変更。
    * 同時に (プロジェクト名)/Assets/Sphere001.cs が生成されます。
1. 上記で作成した "Sphere001" の [Inspector]-[Add Component] エリアに上記のC#（Sphere001）をドラッグ＆ドロップ。

### C#の記述
1. VSCode等のエディタで "Sphere001.cs" を開きます。
1. 次のように書き換えて保存。
```
//Sphere01.cs
using UnityEngine;

public class Sphere001 : MonoBehaviour { //thisは省略可
	private Behaviour _halo;

	void Start() { //不要
	}

	void Update() {
		if (Input.GetMouseButtonDown(0)) { //① 左ボタンを押したら...
			//② クリックした画面の位置をRay（光線）に変換
			Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			//③ Rayが命中したGameObjectの情報を格納
			RaycastHit _hit = new RaycastHit(); //RaycastHitは構造体

			//④ GameObjectにRay（光線）が命中（クリック）したら...
			if (Physics.Raycast(_ray, out _hit, 100f)) {
				if (_hit.collider.gameObject.name == "Sphere001") {
					//Sphere01をクリックしたら...
					//ハローはenabledのON/OFFしかできません。色サイズも変更不可。
					_halo = (Behaviour)this.GetComponent("Halo"); //Behaviourに変換
					_halo.enabled = true;
				}
			}

		} else if (Input.GetMouseButtonUp(0)) { //左ボタンをリリースしたら...
			_halo.enabled = false;
		}
	}
}
```

### 実行
1. [再生] ボタンまたは [Edit]-[Play] を選択。
1. ボールを選択（プレス）するとハローが表示し、話す（リリース）するとハローが消えれば成功。  
![015](https://mubirou.github.io/Unity/examples/jpg/015.jpg)

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：夢寐郎  
作成日：2018年04月10日


<a name="オブジェクトの生成"></a>
# <b>016 オブジェクトの生成</b>

### 空のゲームオブジェクトを作成
1. [GameObject]-[Create Empty] を選択。
1. [Inspector] ウィンドウで、名前を "GameObject" から "God" に変更。

### C#ファイルの作成
1. [Assets]-[Create]-[C# Script] を選択。
1. 名前を "NewBehaviourScript" から "Main" に変更。
    * 同時に (プロジェクト名)/Assets/Main.cs が生成されます。
1. 上記で作成した "God" の [Inspector]-[Add Component] エリアに上記のC#（Main）をドラッグ＆ドロップ。

### C#の記述
1. VSCode等のエディタで "Main.cs" を開きます。
1. 次のように書き換えて保存。
* 今回は次の21個のGameObjectを生成。座標は次の通りにします。  
[-3,0,50] [0,0,50] [3,0,50]  
[-3,0,40] [0,0,40] [3,0,40]  
[-3,0,30] [0,0,30] [3,0,30]  
[-3,0,20] [0,0,20] [3,0,20]  
[-3,0,10] [0,0,10] [3,0,10]  
[-3,0,0] [0,0,0] [3,0,0]  
[-3,0,-10] [0,0,-10] [3,0,-10]

```
//Main.cs
using UnityEngine;
using System.Collections.Generic; //Listに必要

public class Main : MonoBehaviour { //Update()は省略
	private List<GameObject> _list = new List<GameObject>();

	void Start () { // Use this for initialization
		GameObject _theObject;
		for (int i=0; i<7; i++) { //縦に7列
			for (int j=0; j<3; j++) { //横に3列
				//①Sphere ②Capsule ③Cylinder ④Cube ⑤Planeの5種類あり
				_theObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
				//削除する場合はGameObject.Destroy(_theObject [,秒])

				_list.Add(_theObject);

				int _x = -3 + j*3; //-3,0,3
				int _z = 50 - i*10; //50,40,30,20,10,0,-10

				Vector3 _vector = new Vector3(_x, 0, _z);
				_theObject.transform.position = _vector; //位置を設定
			}
		}
	}
}
```

### 実行
1. [再生] ボタンまたは [Edit]-[Play] を選択。
1. 縦7列、横3列の立方体が生成されたら成功。  
![016](https://mubirou.github.io/Unity/examples/jpg/016.jpg)

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：夢寐郎  
作成日：2018年04月10日


<a name="オブジェクトを消す"></a>
# <b>017 オブジェクトを消す</b>

### 1つめのボール作成
1. [GameObject]-[3D Object]-[Sphere] を選択。
1. [Inspector] ウィンドウで、名前を "Sphere" から "Sphere001" に変更。
1. [Transform] を次のように変更。
    * Scale X:3 Y:3 Z:3

### 1つめのボールにマテリアルを追加
1. [Assets]-[Create]-[Material] を選択（名前は "Material001" に変更）。[Albedo] を赤に変更。
1. [Hierarchy] の "Sphere001" を選択。
1. [Add Component]エリアに、上記で作成したAssets内のマテリアル（"Material001"）をドラッグ＆ドロップ。
1. [Inspector]-[Material001] の値を次の通りに変更
* Rendering Mode: Transparent（初期値は "Opaque"）

### 2つめのボール作成
1. 同様にもう1つ、"Sphere002" を作成。
1. [Transform] を次のように変更。
	* Position Position X:2 Y:0 Z:3
	* Scale X:3 Y:3 Z:3

### C#ファイルの作成
1. [Assets]-[Create]-[C# Script] を選択。
1. 名前を "NewBehaviourScript" から "Sphere001" に変更。
    * 同時に (プロジェクト名)/Assets/Sphere001.cs が生成されます。
1. 上記で作成した "Sphere001" の [Inspector]-[Add Component] エリアに上記のC#（Sphere001）をドラッグ＆ドロップ。

### C#の記述
1. VSCode等のエディタで "Sphere001.cs" を開きます。
1. 次のように書き換えて保存。
```
//Sphere01.cs
using UnityEngine;

public class Sphere001 : MonoBehaviour { //thisは省略可
	void Start() {
		Debug.Log(this.gameObject.activeSelf); //True（表示状態）
	}

	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit _hit = new RaycastHit();

			if (Physics.Raycast(_ray, out _hit, 100f)) {
				//Sphere001をクリックしたら...
				if (_hit.collider.gameObject.name == "Sphere001") {
					// 非表示にする場合
					//this.gameObject.SetActive(false); //非表示にする
					//Debug.Log(this.gameObject.activeSelf); //False（非表示状態）

					// 半透明にする場合 
					this.gameObject.GetComponent<Renderer>().material.color
					= new Color(1, 0, 0, 0); //0.0fにしても完全には消えません
				}
			}
		}
	}
}
```

### 実行
1. [再生] ボタンまたは [Edit]-[Play] を選択。
1. 赤いボールを選択して半透明（または非表示）になったら成功。  
![017](https://mubirou.github.io/Unity/examples/jpg/017.jpg)

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：夢寐郎  
作成日：2018年04月10日


<a name="スライダー"></a>
# <b>018 スライダー</b>

### 3つのスライダーの作成
1. [GameObject]-[UI]-[Slider] を選択（名前を "SliderR" に変更）。
1. [Inspector] ウィンドウで、設定を次の通りにします。
1. [Transform] を次のように変更。
	* Pos X: 0、PosY: -100、PosZ: 0
	* Width: 200、Height: 20
1. [Hierarchy] の "SliderR" を [右クリック]→[Copy]→[Paste]。
1. 名前を "SliderG" に変更。同じように次のように設定します。
	* Pos X: 0、PosY: -130、PosZ: 0
	* Width: 200、Height: 20
5. 同様に "SliderB" を作成。設定は次の通り。
	* Pos X: 0、PosY: -160、PosZ: 0
	* Width: 200、Height: 20

### ボール作成
1. [GameObject]-[3D Object]-[Sphere] を選択。
1. [Inspector] ウィンドウで、名前を "Sphere" から "Sphere001" に変更。
1. [Transform] を次のように変更。
    * Position X:0 Y:0.5 Z:0

### ボールにマテリアルを追加
1. [Assets]-[Create]-[Material] を選択（名前は "Material001" に変更）。[Albedo] を黒に変更。
1. [Hierarchy] の "Sphere001" を選択。
1. [Add Component] エリアに、上記で作成したAssets内のマテリアル（"Material001"）をドラッグ＆ドロップ。

### 空のゲームオブジェクトを作成
1. [GameObject]-[Create Empty] を選択。
1. [Inspector] ウィンドウで、名前を "GameObject" から "God" に変更。

### C#ファイルの作成
1. [Assets]-[Create]-[C# Script] を選択。
1. 名前を "NewBehaviourScript" から "Main" に変更。
    * 同時に (プロジェクト名)/Assets/Main.cs が生成されます。
1. 上記で作成した "God" の [Inspector]-[Add Component] エリアに上記のC#（Main）をドラッグ＆ドロップ。

### C#の追加
1. VSCode等のエディタで "Main.cs" を開きます。
1. 次のように書き換えて保存。
```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnSliderChanged() {} //←この1行だけ追加
}
```

### スライダーと "OnSliderChanged()" メソッドのリンク
* 少し理解しにくい操作です。
1. [Hierarchy] の "SliderR" を選択。
1. [Inspector] の [On Value Changed] にある [+] をクリック。
1. [None(Object)] の [⦿] をクリック。
1. [Scene]から、上記で作成した "God"（GameObject）を選択。
1. [No Function] をクリック→ [Main]-[OnSliderChanged()] を選択。
	* [No Function] が [Main.OnSliderChanged] になっていればOKです。
1. 上記の作業を、"SliderG" と "SliderB" に対しても行ないます。

### C#の記述
1. VSCode等のエディタで再度 "Main.cs" を開きます。
1. 次のように書き換えて保存。
```
//Main.cs
using UnityEngine;
using UnityEngine.UI; //Sliderに必要

public class Main : MonoBehaviour {
	private Slider _sliderR, _sliderG, _sliderB;
	private GameObject _sphere01;

	void Start () {
		_sphere01 = GameObject.Find("Sphere001");
		_sliderR = GameObject.Find("SliderR").GetComponent<Slider>();
		_sliderG = GameObject.Find("SliderG").GetComponent<Slider>();
		_sliderB = GameObject.Find("SliderB").GetComponent<Slider>();
	}

	void Update () { //不要
	}

	// 何れかのスライダーを動かした時...
	public void OnSliderChanged() {
		float _R = _sliderR.value;
		float _G = _sliderG.value;
		float _B = _sliderB.value;
		_sphere01.GetComponent<Renderer>().material.color = new Color(_R, _G, _B);
	}
}
```

### 実行
1. [再生] ボタンまたは [Edit]-[Play] を選択。
1. スライダーを動かすとボールの色が変化すれば成功。  
![018](https://mubirou.github.io/Unity/examples/jpg/018.jpg)

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：夢寐郎  
作成日：2018年04月10日


<a name="ボタン"></a>
# <b>019 ボタン</b>

### ボタンの作成
1. [GameObject]-[UI]-[Button] を選択（名前を "Button001" に変更）。
1. [Hierarchy] の [Canvas]-[Button001]-[Text] を選択し、[Inspector] の [Text] の値を変更（任意）。
	* ダブルバイト文字は不可。

### C#ファイルの作成
1. [Assets]-[Create]-[C# Script] を選択。
1. 名前を "NewBehaviourScript" から "Button001" に変更。
    * 同時に (プロジェクト名)/Assets/Button001.cs が生成されます。
1. 上記で作成した "God" の [Inspector]-[Add Component] エリアに上記のC#（Button001）をドラッグ＆ドロップ。

### C#の追加
1. VSCode等のエディタで "Button001.cs" を開きます。
1. 次のように書き換えて保存。
```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button001 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClick() {} //←この1行を追加
}
```

### ボタンと "OnClick()" メソッドのリンク
* 少し理解しにくい操作です。
1. [Hierarchy] の "Button001" を選択。
1. [Inspector] の [On Click()] にある [+] をクリック。
1. [None(Object)] の [⦿] をクリック。
1. [**Scene**]から、上記で作成した "Button01"（**GameObject**）を選択。
1. [No Function] をクリック→ [Button01]-[OnClick()] を選択。
	* [No Function] が [Button01.OnClick] になっていればOKです。

### C#の記述
1. VSCode等のエディタで再度 "Button001.cs" を開きます。
1. 次のように書き換えて保存。
```
//Button001.cs
using UnityEngine;

public class Button01 : MonoBehaviour {
	void Start () { //不要
	}

	void Update () { //不要
	}

	public void OnClick() {
		Debug.Log("HOGEをクリックしました");
	}
}
```

### 実行
1. [再生] ボタンまたは [Edit]-[Play] を選択。
1. ボタンをクリックするとConsoleに "HOGEをクリックしました" と出力されたら成功。  
![019](https://mubirou.github.io/Unity/examples/jpg/019.jpg)

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：夢寐郎  
作成日：2018年04月10日


<a name="トグルボタン"></a>
# <b>020 トグルボタン</b>

### トグルボタンの作成
1. [GameObject]-[UI]-[Toggle] を選択（名前を "Toggle001" に変更）。
1. [Hierarchy] の [Canvas]-[Toggle001]-[Label] を選択し、[Inspector] の [Text] の値を変更（任意）。
	* ダブルバイト文字は不可。

### C#ファイルの作成
1. [Assets]-[Create]-[C# Script] を選択。
1. 名前を "NewBehaviourScript" から "Toggle001" に変更。
    * 同時に (プロジェクト名)/Assets/Toggle001.cs が生成されます。
1. 上記で作成した "God" の [Inspector]-[Add Component] エリアに上記のC#（Toggle001）をドラッグ＆ドロップ。

### C#の追加
1. VSCode等のエディタで "Toggle001.cs" を開きます。
1. 次のように書き換えて保存。
```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle001 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnToggleChanged() {} //←この1行だけ追加
}
```

### トグルボタンと "OnToggleChanged()" メソッドのリンク
* 少し理解しにくい操作です。
1. [Hierarchy] の "Toggle001" を選択。
1. [Inspector] の [On Value Changed] にある [+] をクリック。
1. [None(Object)] の [⦿] をクリック。
1. [Scene]から、上記で作成した "Toggle001"（GameObject）を選択。
1. [No Function] をクリック→ [Toggle001]-[OnToggleChanged()] を選択。
	* [No Function] が [Toggle001.OnToggleChanged] になっていればOKです。

### C#の記述
1. VSCode等のエディタで再度 "Toggle001.cs" を開きます。
1. 次のように書き換えて保存。
```
//Toggle001.cs
using UnityEngine;
using UnityEngine.UI; //Toggleに必要

public class Toggle001 : MonoBehaviour {
	void Start () { //不要
	}

	void Update () { //不要
	}

	public void OnToggleChanged() { //thisは省略可
		if (this.GetComponent<Toggle>().isOn) {
			Debug.Log("HOGEが✔されました");
		} else {
			Debug.Log("HOGEの✔が外されました");
		}
	}
}
```

### 実行
1. [再生] ボタンまたは [Edit]-[Play] を選択。
1. トグルボタンをON/OFFするとConsoleに "HOGEが✔されました" または "HOGEの✔が外されました" と出力されたら成功。  
![020](https://mubirou.github.io/Unity/examples/jpg/020.jpg)

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：夢寐郎  
作成日：2018年04月10日


<a name="シーンの移動"></a>
# <b>021 シーンの移動</b>

### シーン１の作成
1. [File]-[Save Scene] を選択。名前は "Scene001"。
	* 同時に(Project name)/Assets/内に "Scene001.unity" ファイルが生成されます。

### シーン１に床を配置
1. [GameObject]-[3D Object]-[Plane] を選択。
1. [Assets]-[Create]-[Material] を選択（名前は"Red"）。
1. [Inspector]-[Albedo] を赤に変更。
1. [Hierarchy] の Plane を選択。
1. [Add Component] エリアに、上記で作成したAssets内のマテリアル（"Red"）をドラッグ＆ドロップ。

### シーン１のメインクラスを作成
1. [GameObject]-[Create Empty] を選択（名前は "God" に変更）。
1. [Assets]-[Create]-[C# Script] を選択。すかさず名前を "Scene001" に変更。
	* "Scene001.cs" ファイルが "Scene001" のメインクラスとなります。
1. "God"（GameObject）の [Inspector]-[Add Component] エリアに上記の "Scene001"（C#）をドラッグ＆ドロップ。  ![021_1](https://mubirou.github.io/Unity/examples/jpg/021_1.jpg)

### シーン２の作成
1. [File]-[New Scene] を選択。
1. [File]-[Save Scene] を選択。名前は "Scene002"。
	* 同時に(Project name)/Assets/内に "Scene002.unity" ファイルが生成されます。

### シーン２に床を配置
1. [GameObject]-[3D Object]-[Plane] を選択。
1. [Assets]-[Create]-[Material] を選択（名前は"Blue"）。
1. [Inspector]-[Albedo] を青に変更。
1. [Hierarchy] の Plane を選択。
1. [Add Component] エリアに、上記で作成したAssets内のマテリアル（"Blue"）をドラッグ＆ドロップ。

### シーン２のメインクラスを作成
1. [GameObject]-[Create Empty] を選択（名前は "God" に変更）。
1. [Assets]-[Create]-[C# Script] を選択。すかさず名前を "Scene002" に変更。
	* "Scene002.cs" ファイルが "Scene002" のメインクラスとなります。
1. "God"（GameObject）の [Inspector]-[Add Component] エリアに上記の "Scene002"（C#）をドラッグ＆ドロップ。  ![021_2](https://mubirou.github.io/Unity/examples/jpg/021_2.jpg)

### 各シーンの登録
1. [File]-[Build Settings...] を選択。
1. [Assets]-[Scene001] を選択。
1. [Build Settings] 画面で [Add Open Scenes] をクリック。
1. [Assets]-[Scene002] を選択。
1. [Build Settings] 画面で [Add Open Scenes] をクリック。
1. ①Scene01.unityと②Scene02.unityを追加します。
	* 順番が重要（ドラックで順序を変更できます）。
1. ウィンドウを閉じます。  
 ![021_3](https://mubirou.github.io/Unity/examples/jpg/021_3.jpg)

### C#の記述（シーン１のメインクラス）
1. VSCode等のエディタで "Scene001.cs" を開きます。
1. 次のように書き換えて保存。
```
//Scene001.cs
using UnityEngine;

public class Scene001 : MonoBehaviour {
	void Start () { //不要
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			Debug.Log(Application.loadedLevelName); //Scene001
			Application.LoadLevel("Scene002");
			//Application.LoadLevel(1); //1番目のシーンに移動（上記と同じ動作）
		}
	}
}
```

### C#の記述（シーン２のメインクラス）
1. VSCode等のエディタで "Scene002.cs" を開きます。
1. 次のように書き換えて保存。
```
//Scene002.cs
using UnityEngine;

public class Scene002 : MonoBehaviour {
	void Start () { //不要
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			Debug.Log(Application.loadedLevelName); //Scene002
			Application.LoadLevel("Scene001");
			//Application.LoadLevel(0); //0番目のシーンに移動（上記と同じ動作）
		}
	}
}
```

### 実行
1. [再生] ボタンまたは [Edit]-[Play] を選択。
1. スペースキーを押すと "Scene001" と "Scene002" が入れ替われば成功。

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：夢寐郎  
作成日：2018年04月11日


<a name="シーン移動時にオブジェクトを残す"></a>
# <b>022 シーン移動時にオブジェクトを残す</b>

* 「[022 シーンの移動](#シーンの移動)」を継承します。

### シーン移動後に残るオブジェクトの作成
1. [Assets] の "Scene001" をダブルクリック。
1. [GameObject]-[3D Object]-[Cube] を選択（名前を "Cube001" に変更）。
1. [Inspector] の設定を変更。
	* Position X:3 Y:1 Z:0

### 上記のオブジェクトに動きと色を追加
1. [Assets]-[Create]-[C# Script]を選択。すかさず名前を "Cube001" に変更。
1. [Hierarchy]-[Cube001] の [Inspector]-[Add Component] エリアに [Assets]-[Cube001]（C#）をドラッグ＆ドロップ。
1. VSCodeを起動し "(Project name)/Assets/Cube001.cs" を開き、以下のようにコーディング。
	* 動きと色を付けることで検証しやすくします。
```
//Cube001.cs
using UnityEngine;

public class Cube001 : MonoBehaviour { //thisは省略可
	private int _speedX, _speedY, _speedZ;

	void Start () { // Use this for initialization
		_speedX = Random.Range(-3,3);
		_speedY = Random.Range(-3,3);
		_speedZ = Random.Range(-3,3);
		this.GetComponent<Renderer>().material.color 
		= new Color(Random.value, Random.value, Random.value); //ランダムに着色
	}
	
	void Update () { // Update is called once per frame
		this.transform.Rotate(new Vector3(_speedX,_speedY,_speedZ)); //ランダムに回転
	}
}
```

### C#の記述（シーン１のメインクラス）
1. VSCode等のエディタで "Scene001.cs" を開きます。
1. 次のように書き換えて保存。
```
//Scene001.cs
using UnityEngine;

public class Scene001 : MonoBehaviour {
	private GameObject _cube001;

	void Start () {
		_cube001 = GameObject.Find("Cube001");
		DontDestroyOnLoad(_cube001); //シーンを移動しても"Cube01"を残す
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			Application.LoadLevel("Scene002"); //シーン"Scene02"へ移動
		}
	}
	
	void OnDestroy () {
		//Destroy(_cube001); //"Cube001"を残さず消す場合...
	}
}
```

### C#の記述（シーン２のメインクラス）
1. VSCode等のエディタで "Scene002.cs" を開きます。
1. 次のように書き換えて保存。
```
//Scene002.cs
using UnityEngine;

public class Scene002 : MonoBehaviour {

	void Start () {
		//前シーンから残った"Cube001"を消す（ここでも消すことが可能）
		//Destroy(GameObject.Find("Cube001"));
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			Application.LoadLevel("Scene001"); //シーン"Scene01"へ移動（戻る）
		}
	}
}
```

### 実行
1. [再生] ボタンまたは [Edit]-[Play] を選択。
1. スペースキーでシーンを移動後も立方体が残れば成功（再度シーン１に戻ると立方体が2つ重なる）。  
 ![022](https://mubirou.github.io/Unity/examples/jpg/022.jpg)

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：夢寐郎  
作成日：2018年04月11日


<a name="他人のメソッドの実行①"></a>
# <b>023 他人のメソッドの実行①</b>

* 呼び出すメソッドの引数は「1つ」まで。
* 引数が「2つ以上」の場合、「[024 他人のメソッドの実行②](#他人のメソッドの実行②)」の方法を使います。

### オブジェクト（立方体）の作成
1. [GameObject]-[3D Object]-[Cube] を選択。名前は "Cube001" に変更。
1. [Assets]-[Create]-[C# Script]を選択。すかさず名前を "Cube001" に変更。
	* 同時に(Project name)/Assets/内に "Cube001.cs" ファイルが生成されます。
1. [Hierarchy]-[Cube001] の [Inspector] の [Add Component] エリアへ、[Assets]-[Cube001]（C#）をドラッグ＆ドロップ。

### オブジェクト（God）の作成
1. [GameObject]-[Create Empty] を選択（名前は "God" に変更）。
1. [Assets]-[Create]-[C# Script] を選択。すかさず名前を "Main" に変更。
	* 同時に(Project name)/Assets/内に "Main.cs" ファイルが生成されます。
1. [Hierarchy]-[God] の [Inspector] の [Add Component] エリアへ、[Assets]-[Main]（C#）をドラッグ＆ドロップ。

### C#の記述（Cube001.cs）
1. VSCode等のエディタで再度 "Cube001.cs" を開きます。
1. 次のように書き換えて保存。
```
//Cube001.cs
using UnityEngine;

public class Cube001 : MonoBehaviour {
	void Start () {
		//①Cube01からMainのメソッド（Request()）を実行（引数は1つまで）
		GameObject.Find("God").SendMessage("Request", this.gameObject);
	}

	public void Message(string arg) { 
		Debug.Log(arg); //"Hello,Cube001"
	}
}
```

### C#の記述（Main.cs）
1. VSCode等のエディタで再度 "Main.cs" を開きます。
1. 次のように書き換えて保存。
```
//Main.cs
using UnityEngine;

public class Main : MonoBehaviour {
	void Start () { //不要
	}

	public void Request(GameObject arg) {
		//②GodからCube001のメソッドを実行（引数は2つまで）
		arg.SendMessage("Message", "Hello," + arg.name);
	}
}
```

### 実行
1. [再生] ボタンまたは [Edit]-[Play] を選択。
1. オブジェクト（Cube001）とオブジェクト（God）間でメソッドを呼び出すことで、Consoleに "Hello,Cube001" と表示されたら成功。

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：夢寐郎  
作成日：2018年04月11日


<a name="他人のメソッドの実行②"></a>
# <b>024 他人のメソッドの実行②</b>

* 呼び出すメソッドの引数が「1つ」までの場合、「[023 他人のメソッドの実行①](#他人のメソッドの実行①)」の方が簡単です。
* 「[023 他人のメソッドの実行①](#他人のメソッドの実行①)」の「C#の記述」の部分のみ変更します。

### C#の記述（Cube001.cs）
1. VSCode等のエディタで再度 "Cube001.cs" を開きます。
1. 次のように書き換えて保存。
```
//Cube001.cs
using UnityEngine;
using UnityEngine.EventSystems; //ExecuteEvents.Executeに必要

public class Cube001 : MonoBehaviour {
	void Start () {
		//Cube001からMainのメソッド（Request）を実行（引数は2つ以上も可）
		ExecuteEvents.Execute<IHoge>(
				target: GameObject.Find("God"), //対象のGameObject
				eventData: null, //決め打ち
				functor: (target, eventData) //決め打ち（引数名は任意）
				=> target.Request(this.gameObject, "TAKASHI", 50)
		);
	}
}
```

### C#の記述（Main.cs）
1. VSCode等のエディタで再度 "Main.cs" を開きます。
1. 次のように書き換えて保存。
```
//Main.cs
using UnityEngine;
using UnityEngine.EventSystems; //ExecuteEvents.Executeに必要

public interface IHoge : IEventSystemHandler { //インターフェースの宣言
	void Request(GameObject arg1, string arg2, int arg3); //暗黙的にpublicになる
}

public class Main : MonoBehaviour, IHoge { //インターフェースの実装
	public void Request(GameObject arg1, string arg2, int arg3) {
		Debug.Log(arg1); //Cube001 (UnityEngine.GameObject)
		Debug.Log(arg2 + ":" + arg3); //"TAKASHI:50"
	}
}
```

### 実行
1. [再生] ボタンまたは [Edit]-[Play] を選択。
1. オブジェクト（Cube001）からオブジェクト（God）のメソッド（Request）を呼び出すことで、Consoleに "Cube001"、"TAKASHI:50" と表示されたら成功。

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：夢寐郎  
作成日：2018年04月12日


<a name="データの保存"></a>
# <b>025 データの保存</b>

### 空のゲームオブジェクトを作成
1. [GameObject]-[Create Empty] を選択。
1. [Inspector] ウィンドウで、名前を "GameObject" から "God" に変更。

### C#ファイルの作成
1. [Assets]-[Create]-[C# Script] を選択。
1. 名前を "NewBehaviourScript" から "Main" に変更。
    * 同時に (プロジェクト名)/Assets/Main.cs が生成されます。
1. 上記で作成した "God" の [Inspector]-[Add Component] エリアに上記のC#（Main）をドラッグ＆ドロップ。

### C#の記述
1. VSCode等のエディタで "Main.cs" を開きます。
1. 次のように書き換えて保存。
```
//Main.cs
using UnityEngine;

public class Main : MonoBehaviour {
	private int _highscore;
	private int _count = 0;

	void Start () { 
		// 起動時にデータを読込む
		_highscore = PlayerPrefs.GetInt("highscore"); //①整数型の場合
		//②文字型の場合→ PlayerPrefs.GetString("name");
		//③浮動小数点型の場合→ PlayerPrefs.GetFloat("version");
		
		Debug.Log("これまでの最高記録:" + _highscore);
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			_count ++;
			Debug.Log("途中経過:" + _count);
		}
	}

	void OnDestroy () { //終了時にデータを保存
		if (_count > _highscore) {
			_highscore = _count;
			Debug.Log("最高記録更新です！:" + _highscore);
		} else {
			Debug.Log("今回の記録:" + _count);
		}
	
		PlayerPrefs.SetInt("highscore", _highscore); //①整数型の場合
		
		//②文字型の場合→ PlayerPrefs.SetString("name", "nishimura");
		//③浮動小数点型の場合→ PlayerPrefs.SetFloat("version", 5.1f);
	}
}
```

### 実行
1. [再生] ボタンまたは [Edit]-[Play] を選択。
1. 再生するとConsoleに "これまでの最高記録:XX" と表示され、スペースキーを押す毎に "途中経過:XX" と1ずつ更新。止めると "今回の記録:XX" または "最高記録更新です！:XXX" と表示されます。再度、再生すると最高記録が更新されて表示されるはずです。最高記録は、Unityを終了させるとリセットされます。

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：夢寐郎  
作成日：2018年04月12日


<a name="GameObjectの入れ子"></a>
# <b>026 GameObjectの入れ子</b>

### 床の作成
1. [GameObject]-[3D Object]-[Plane] を選択。名前は "Plane001" に変更。
1. [Inspector]-[Transform] を次のように変更。
	* Scale X: 0.5 Y: 0.5 Z: 0.5

### 赤い立方体を作成
1. [GameObject]-[3D Object]-[Cube] を選択。名前は "Cube001" に変更。
1. [Inspector]-[Transform] を次のように変更。
	* Position X: -2 Y: 0.6 Z: 2
1. [Assets]-[Create]-[Material] を選択。名前を "Red" に変更。
1. [Inspector]-[Albedo] を赤に変更。
1. [Hierarchy] の "Cube001" を選択。
1. [Add Component]エリアに、上記で作成したAssets内のマテリアル（"Red"）をドラッグ＆ドロップ。

### ３つの白い立方体を作成
1. 同様に "Cube002"、"Cube003"、"Cube004" を作成（色はそのまま）。
1. [Inspector]-[Transform] の値をそれぞれ次のように変更。
	* Position X: 2 Y: 0.6 Z: 2（"Cube002"）
	* Position X: 2 Y: 0.6 Z: -2（"Cube003"）
	* Position X: -2 Y: 0.6 Z: -2（"Cube004"）

### 入れ子（ネスト）化
1. [Hierarchy]-[Plane001] の階層下に "Cube001" 〜 "Cube004" をドラッグ＆ドロップで移動します。
	* 上記の4つの立方体を、床（"Plane001"）の入れ子とします。  
![026_1](https://mubirou.github.io/Unity/examples/jpg/026_1.jpg)

### 空のゲームオブジェクトを作成
1. [GameObject]-[Create Empty] を選択。
1. [Inspector] ウィンドウで、名前を "GameObject" から "God" に変更。

### C#ファイルの作成
1. [Assets]-[Create]-[C# Script] を選択。
1. 名前を "NewBehaviourScript" から "Main" に変更。
    * 同時に (プロジェクト名)/Assets/Main.cs が生成されます。
1. 上記で作成した "God" の [Inspector]-[Add Component] エリアに上記のC#（Main）をドラッグ＆ドロップ。

### C#の記述
1. VSCode等のエディタで "Main.cs" を開きます。
1. 次のように書き換えて保存。
```
//Main.cs
using UnityEngine;

public class Main : MonoBehaviour {
	private GameObject _cubes; //Plane001とCube001〜04の上位階層の空のGameObject
	private GameObject _cube001; //赤のCube001

	void Start () {
		_cubes = GameObject.Find("Plane001"); //床
		_cube001 = _cubes.transform.Find("Cube001").gameObject; //入れ子の赤い立方体を検索
	}

	void Update () { //全体が回転しても赤のCube001だけ正面を向かせる
		_cubes.transform.Rotate(new Vector3(0, 0.5f, 0));
		_cube001.transform.Rotate(new Vector3(0, -0.5f, 0));
	}
}
```

### 実行
1. [再生] ボタンまたは [Edit]-[Play] を選択。
1. 全体が回転しますが、赤い立方体だけが常に正面を向いていたら成功。  
![026_2](https://mubirou.github.io/Unity/examples/jpg/026_2.jpg)

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：夢寐郎  
作成日：2018年04月12日


<a name="キョロキョロ"></a>
# <b>027 キョロキョロ</b>

### 立方体１を作成
1. [GameObject]-[3D Object]-[Cube] を選択。名前は "Cube001" に変更。
1. [Assets]-[Create]-[C# Script] を選択。すかさず名前を "Cube01" に変更。
1. [Hierarchy]-[Cube001]-[Cube001] の [Inspector]-[Add Component] エリアに、[Assets]-[Cube001]（C#）をドラッグ＆ドロップ。

### 立方体２を作成
1. [GameObject]-[3D Object]-[Cube] を選択。名前は "Cube002" に変更。
1. [Inspector]-[Transform] を次のように変更。
	* Position X:1.5 Y:0 Z:0
1. [Assets]-[Create]-[C# Script] を選択。すかさず名前を "Cube02" に変更。
1. [Hierarchy]-[Cube001]-[Cube002] の [Inspector]-[Add Component] エリアに、[Assets]-[Cube002]（C#）をドラッグ＆ドロップ。

### C#の記述（Cube001.cs）
1. VSCode等のエディタで "Cube001.cs" を開きます。
1. 次のように書き換えて保存。
```
//Cube001.cs
using UnityEngine;
using System; //Mathに必要

public class Cube001 : MonoBehaviour { //thisは省略可
	private float _originY, _currentY, _count = 0f;

	void Start () {
		_originY = _currentY = this.transform.position.y; //GameObjectのY座標位置
	}
	void Update () {
		//上下に行ったり来たり...
		_count += 0.03f;
		float _nextY = (float)(3 * Math.Cos(_count) + _originY);
		float _disY = _nextY - _currentY;
		this.transform.Translate(0,_disY,0); //移動させたい値（x,y,z）を指定
		_currentY = this.transform.position.y;
	}
}
```

### C#の記述（Cube002.cs）
1. VSCode等のエディタで "Cube001.cs" を開きます。
1. 次のように書き換えて保存。
```
//Cube002.cs
using UnityEngine;

public class Cube002 : MonoBehaviour { //thisは省略可
	private GameObject _target; //ターゲットとなるCube001

	void Start () { // Use this for initialization
		_target = GameObject.Find("Cube001");
	}
	void Update () {
		this.transform.LookAt(_target.transform); //Cube001の方向を向かせる
	}
}
```

### 実行
1. [再生] ボタンまたは [Edit]-[Play] を選択。
1. 上下に動く立方体（Cube001）の方向に、もう一つの立方体（Cube002）が向けば成功。  
![027](https://mubirou.github.io/Unity/examples/jpg/027.jpg)

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：夢寐郎  
作成日：2018年04月12日


<a name="クローン作成"></a>
# <b>028 クローン作成</b>

### 立方体を作成
1. [GameObject]-[3D Object]-[Cube] を選択。名前は "Cube001" に変更。
1. [Hierarchy]-[Cube001] を選択した状態で [Component]-[Physics]-[Rigidbody] を選択し物理的物体にする。

### GameObjectをPrefabと入れ替える
1. [Assets]-[Create]-[Prefab]（プレハブ）を選択。名前は "CubePrefab" に変更。
	* Prefab（プレハブ）とは、オブジェクトを複製する機能です。
1. 上記で作成した [Hierarchy]-[Cube001] を、[Assets]-[CubePrefab] にドラッグ＆ドロップ。
	* "CubePrefab"が濃いグレーの矩形で囲まれます。
1. [Hierarchy]-[Cube001] を削除（今後必要としないため）。
1. その代わりに [Assets]-[CubePrefab] を [Hierarchy] 内にドラッグ＆ドロップ。

### 床を作成（落下防止用）
1. [GameObject]-[3D Object]-[Plane] を選択。
1. [Inspector]-[Transform] を次のように変更。
	* Position X:0 Y:-0.5 Z:0
	* Scale X:0.2 Y:1 Z:0.2

### 空のゲームオブジェクトを作成
1. [GameObject]-[Create Empty] を選択。
1. [Inspector] ウィンドウで、名前を "GameObject" から "God" に変更。

### C#ファイルの作成
1. [Assets]-[Create]-[C# Script] を選択。
1. 名前を "NewBehaviourScript" から "Main" に変更。
    * 同時に (プロジェクト名)/Assets/Main.cs が生成されます。
1. 上記で作成した "God" の [Inspector]-[Add Component] エリアに上記のC#（Main）をドラッグ＆ドロップ。

### C#の記述
1. VSCode等のエディタで "Main.cs" を開きます。
1. 次のように書き換えて保存。
```
//Main.cs
using UnityEngine;

public class Main : MonoBehaviour {
	private GameObject _cubePrefab;

	void Start () {
		_cubePrefab = GameObject.Find("CubePrefab");
		_cubePrefab.gameObject.SetActive(false); //非表示にする
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			//Instantiate(○, ○.transform.position, ○.transform.rotation)で同位置から...
			GameObject _cloneCube = Instantiate(_cubePrefab, new Vector3(0,0,0), Quaternion.Euler(0,0,0)) 
			as GameObject;
			_cloneCube.gameObject.SetActive(true); //非表示→表示する
			_cloneCube.transform.GetComponent<Rigidbody>().AddForce(0,500,1000);
		}
	}
}
```

### カメラの調整
[Main Camera]-[Transform] を次のように変更。
* Position X:4 Y:1 Z:-10

### 実行
1. [再生] ボタンまたは [Edit]-[Play] を選択。
1. スペースキーを押すとミサイルのように次々と登場すれば成功。  
![028](https://mubirou.github.io/Unity/examples/jpg/028.jpg)

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：夢寐郎  
作成日：2018年04月12日


<a name="数秒後にメソッドを実行"></a>
# <b>029 数秒後にメソッドを実行</b>

※他に [new Timer()](https://github.com/mubirou/HelloWorld/blob/master/languages/C%23Unity/C%23Unity_reference.md#%E3%82%BF%E3%82%A4%E3%83%9E%E3%83%BC) を使う方法もあり  
※繰返し実行可能な MonoBehaviour.[InvokeRepeating()](https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.InvokeRepeating.html) もあり

### 空のゲームオブジェクトを作成
1. [GameObject]-[Create Empty] を選択。
1. [Inspector] ウィンドウで、名前を "GameObject" から "God" に変更。

### C#ファイルの作成
1. [Assets]-[Create]-[C# Script] を選択。
1. 名前を "NewBehaviourScript" から "Main" に変更。
    * 同時に (プロジェクト名)/Assets/Main.cs が生成されます。
1. 上記で作成した "God" の [Inspector]-[Add Component] エリアに上記のC#（Main）をドラッグ＆ドロップ。

### C#の記述
1. VSCode等のエディタで "Main.cs" を開きます。
1. 次のように書き換えて保存。
```
//Main.cs
using UnityEngine;

public class Main : MonoBehaviour {
	void Start () { 
		Invoke("MyMethod", 2.5f); //2.5秒後（1秒未満も可）に "MyMethod()" を実行
	}

	void Update () { //不要
	}
	
	void MyMethod() {
		Debug.Log("MyMethod!");
	}
}
```

### 実行
1. [再生] ボタンまたは [Edit]-[Play] を選択。
1. 2.5秒後、Consoleに "MyMethod!" と表示されたら成功。

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：夢寐郎  
作成日：2018年04月12日  
更新日：2018年07月11日


<a name="二点間の距離"></a>
# <b>030 二点間の距離</b>

### 球体１を作成
1. [GameObject]-[3D Object]-[Sphere] を選択。名前は "Sphere001" に変更。
1. [Inspector]-[Transform] を次のように変更。
	* Scale X:2 Y:3 Z:4

### 球体２を作成
1. [GameObject]-[3D Object]-[Sphere] を選択。名前は "Sphere002" に変更。
1. [Inspector]-[Transform] を次のように変更。
	* Scale X:0 Y:0 Z:0

### 空のゲームオブジェクトを作成
1. [GameObject]-[Create Empty] を選択。
1. [Inspector] ウィンドウで、名前を "GameObject" から "God" に変更。

### C#ファイルの作成
1. [Assets]-[Create]-[C# Script] を選択。
1. 名前を "NewBehaviourScript" から "Main" に変更。
    * 同時に (プロジェクト名)/Assets/Main.cs が生成されます。
1. 上記で作成した "God" の [Inspector]-[Add Component] エリアに上記のC#（Main）をドラッグ＆ドロップ。

### C#の記述
1. VSCode等のエディタで "Main.cs" を開きます。
1. 次のように書き換えて保存。
```
//Main.cs
using UnityEngine;
using System; //Mathに必要

public class Main : MonoBehaviour {
	void Start () {
		GameObject _sphere01 = GameObject.Find("Sphere001");
		GameObject _sphere02 = GameObject.Find("Sphere002");

		// 方法① ...... Vector3.Distance() による測定
		// 2D用にVector2.Distance(Vector2 ○, Vector2 ○) も用意されています
		float _result = Vector3.Distance(_sphere01.transform.position, _sphere02.transform.position);
		Debug.Log(_result); //5.385165
		
		// 方法② ...... 三平方の定理（ピタゴラスの定理）による測定
		float _disX = _sphere01.transform.position.x - _sphere02.transform.position.x;
		float _disY = _sphere01.transform.position.y - _sphere02.transform.position.y;
		float _disZ = _sphere01.transform.position.z - _sphere02.transform.position.z;
		float _disXZ = (float)Math.Sqrt(_disX*_disX + _disZ*_disZ);
		_result = (float)Math.Sqrt(_disXZ*_disXZ + _disY*_disY);
		Debug.Log(_result); //5.385165
	}
}
```

### 実行
1. [再生] ボタンまたは [Edit]-[Play] を選択。
1. 2つの球体の三次元空間の距離、5.385165がConsoleに出力されたら成功。  
![030](https://mubirou.github.io/Unity/examples/jpg/030.jpg)

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：夢寐郎  
作成日：2018年04月13日


<a name="他のC#ファイルの参照"></a>
# <b>031 他のC#ファイルの参照</b>

### 空のゲームオブジェクトを作成
1. [GameObject]-[Create Empty] を選択。
1. [Inspector] ウィンドウで、名前を "GameObject" から "God" に変更。

### １つ目のC#ファイルの作成
1. [Assets]-[Create]-[C# Script] を選択。
1. 名前を "NewBehaviourScript" から "Main" に変更。
    * 同時に (プロジェクト名)/Assets/Main.cs が生成されます。
1. 上記で作成した "God" の [Inspector]-[Add Component] エリアに上記のC#（Main）をドラッグ＆ドロップ。

### ２つ目のC#ファイルの作成
1. [Assets]-[Create]-[C# Script] を選択。
1. 名前を "NewBehaviourScript" から "MyClass" に変更。
    * 同時に (プロジェクト名)/Assets/MyClass.cs が生成されます。
1. 上記で作成した "God" の [Inspector]-[Add Component] エリアに上記のC#（MyClass）をドラッグ＆ドロップ。  
![031](https://mubirou.github.io/Unity/examples/jpg/031.jpg)

### C#（Main.cs）の記述
1. VSCode等のエディタで "Main.cs" を開きます。
1. 次のように書き換えて保存。
```
//Main.cs
using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour { //thisは省略可
	void Start () {
		// インスタンスの生成（≒ new MyClass()）
		MyClass _myClass = this.GetComponent<MyClass>();
		Debug.Log(_myClass._prop); //"MyClassのプロパティ"
		_myClass.MyMethod(); //"MyClassのメソッド"
	}

	void Update () { //不要
	}
}
```

### C#（MyClass.cs）の記述
1. VSCode等のエディタで "MyClass.cs" を開きます。
1. 次のように書き換えて保存。
```
//MyClass.cs
using UnityEngine; //必須
using System.Collections; //今回は省略可

public class MyClass : MonoBehaviour { //継承は必須
	public string _prop = "MyClassのプロパティ"; //通常はpublicにしませんが...

	public MyClass() { //コンストラクタは省略可
	}

	public void MyMethod() {
		Debug.Log("MyClassのメソッド");
	}
}
```

### 実行
1. [再生] ボタンまたは [Edit]-[Play] を選択。
1. Consoleに"MyClassのプロパティ" と "MyClassのメソッド" が出力されたら成功。  

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：夢寐郎  
作成日：2018年04月13日


<a name="シーンを重ねる"></a>
# <b>032 シーンを重ねる</b>

### シーン１の作成
1. [File]-[Save Scene] を選択。名前は "Scene001"。
	* 同時に(Project name)/Assets/内に "Scene001.unity" ファイルが生成されます。

### シーン１に床を配置
1. [GameObject]-[3D Object]-[Plane] を選択。
1. [Assets]-[Create]-[Material] を選択（名前は "Red"）。
1. [Inspector]-[Albedo] を赤に変更。
1. [Hierarchy]-[Plane] を選択。
1. [Add Component] エリアに、上記で作成したAssets内のマテリアル（"Red"）をドラッグ＆ドロップ。

### シーン１のメインクラスを作成
1. [GameObject]-[Create Empty] を選択（名前は "God" に変更）。
1. [Assets]-[Create]-[C# Script] を選択。すかさず名前を "Main" に変更。
1. "God"（GameObject）の [Inspector]-[Add Component] エリアに上記の "Main"（C#）をドラッグ＆ドロップ。
* 注意："Main.cs" は "Scene002" を重ねた後も動作します。逆に "Scene002" ではそのメインクラスなる "Main2.cs" のようなものは作らない方が混乱を避けることができると思います。

### シーン２の作成
1. [File]-[New Scene] を選択。
1. [File]-[Save Scene] を選択。名前は "Scene002"。
	* 同時に(Project name)/Assets/内に "Scene002.unity" ファイルが生成されます。

### シーン２に床を配置
1. [Assets]-[Scene002] をダブルクリックして選択。
1. [GameObject]-[3D Object]-[Plane] を選択。
1. [Inspector]-[Transform] を次のように変更。
	* Position X:0 Y:0 Z:10（"Scene001" の "Plane" と連続するように配置）
1. [Assets]-[Create]-[Material] を選択（名前は "Blue"）。
1. [Inspector]-[Albedo] を青に変更。
1. [Hierarchy]-[Plane] を選択。
1. [Add Component] エリアに、上記で作成したAssets内のマテリアル（"Blue"）をドラッグ＆ドロップ。

### シーン２の不要なものを削除
1. [Hierarchy]-[Main Camera] を [Delete]。
1. [Hierarchy]-[Directional Light] も [Delete]。
* "Main Camera" が2つになってしまう為、削除しないと「There are 2 audio listeners in the scene....」とエラー発生。同様に "Directional Light" も重なってしまうため削除。

### 各シーンの登録
1. [File]-[Build Settings...] を選択。
1. [Assets]-[Scene001] を選択。
1. [Build Settings] 画面で [Add Open Scenes] をクリック。
1. [Assets]-[Scene002] を選択。
1. [Build Settings] 画面で [Add Open Scenes] をクリック。
1. "Scene001" と "Scene002" を追加します。
	* 順番が重要（ドラックで順序を変更できます）。
1. ウィンドウを閉じます。

### C#の記述
1. VSCode等のエディタで "Main.cs" を開きます。
1. 次のように書き換えて保存。
```
//Main.cs
using UnityEngine;

public class Main : MonoBehaviour {
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			Application.LoadLevelAdditive("Scene002"); //注意：複数回繰り返さないように
			
			//注意：シーンは"Scene001"のままです。繰返すと何度でも追加できてしまいます。
			//Application.LoadLevelAdditive(1);  //上記と同じ動作（0からスタート）
		}
	}
}
```

### 実行
1. [再生] ボタンまたは [Edit]-[Play] を選択。
1. スペースキーを押すと "Scene001" に "Scene002" が重なれば成功。
	* 今回の場合、赤い床の先に青い床が追加されます。  
![032](https://mubirou.github.io/Unity/examples/jpg/032.jpg)

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：夢寐郎  
作成日：2018年04月14日


<a name="シーンの事前読込み①"></a>
# <b>033 シーンの事前読込み①</b>

### シーン１の作成
1. [File]-[Save Scene] を選択。名前は "Scene001"。
	* 同時に(Project name)/Assets/内に "Scene001.unity" ファイルが生成されます。

### シーン１に床を配置
1. [GameObject]-[3D Object]-[Plane] を選択。
1. [Assets]-[Create]-[Material] を選択（名前は "Red"）。
1. [Inspector]-[Albedo] を赤に変更。
1. [Hierarchy]-[Plane] を選択。
1. [Add Component] エリアに、上記で作成したAssets内のマテリアル（"Red"）をドラッグ＆ドロップ。

### シーン１のメインクラスを作成
1. [GameObject]-[Create Empty] を選択（名前は "God" に変更）。
1. [Assets]-[Create]-[C# Script] を選択。すかさず名前を "Main" に変更。
1. "God"（GameObject）の [Inspector]-[Add Component] エリアに上記の "Main"（C#）をドラッグ＆ドロップ。

### シーン２の作成
1. [File]-[New Scene] を選択。
1. [File]-[Save Scene] を選択。名前は "Scene002"。
	* 同時に(Project name)/Assets/内に "Scene002.unity" ファイルが生成されます。

### シーン２を作り込む
1. [Assets]-[Scene002] をダブルクリックして選択。
1. [Window]-[Asset Store] を選択。
1. 任意の3Dモデル等を選択し [ダウンロード] → [Import]。
1. [Project]-[Assets] から該当のオブジェクトを [Hierarchy] にドラッグ＆ドロップ。
* 上記を繰り返して3Dモデルを配置（シーンを非常に重い状態にします）。

### 各シーンの登録
1. [File]-[Build Settings...] を選択。
1. [Assets]-[Scene001] を選択。
1. [Build Settings] 画面で [Add Open Scenes] をクリック。
1. [Assets]-[Scene002] を選択。
1. [Build Settings] 画面で [Add Open Scenes] をクリック。
1. "Scene001" と "Scene002" を追加します。
	* 順番が重要（ドラックで順序を変更できます）。
1. ウィンドウを閉じます。

### C#の記述
1. VSCode等のエディタで "Main.cs" を開きます。
1. 次のように書き換えて保存。
```
//Main.cs
using UnityEngine;

public class Main : MonoBehaviour {
	private AsyncOperation _async;
	private bool _isLoadStart = false;

	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			_async = Application.LoadLevelAsync("Scene002"); //事前読込開始
			//Application.LoadLevelAdditiveAsync("X")でも可能
			_isLoadStart = true;
		}

		if (_isLoadStart) { //事前読込（非同期読込）を開始している場合...
			if (! _async.isDone) { //ロードが完了していない場合...
				Debug.Log(_async.progress * 100 + "%");  //読込完了の%を表示
			}
		}
	}
}
```

### 実行
1. [Assets]-[Scene001] をダブルクリックし、[再生] ボタンまたは [Edit]-[Play] を選択。
1. スペースキーを押すとConsoleに "Scene002" の読み込み状況（%）が表示され、ロード完了後、"Scene002" が表示されたら成功。

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：夢寐郎  
作成日：2018年04月15日


<a name="シーンの事前読込み②"></a>
# <b>034 シーンの事前読込み②</b>

* 「[034 シーンの事前読込み①](#シーンの事前読込み①)」の "Main.cs" の記述のみ変更します。
* 「[034 シーンの事前読込み①](#シーンの事前読込み①)」では、"Application.LoadLevelAsync()" で読込みを開始後、"Update()" でロードが完了したか否かを自分で確認しました。ここではコールーチン（co-routine）を使って、ロード完了を待つということもメソッド内で行います。
* コード自体は直感的に分かり難いかもしれません。

### C#の記述
1. VSCode等のエディタで "Main.cs" を開きます。
1. 次のように書き換えて保存。
```
//Main.cs
using UnityEngine;
using System.Collections; //必須

public class Main : MonoBehaviour {
	void Start () { //不要
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			StartCoroutine("LoadScene002"); //事前読込開始の合図
		}
	}
	
	IEnumerator LoadScene002() {
		AsyncOperation _async = Application.LoadLevelAsync("Scene002"); //実際に読込開始
		//Application.LoadLevelAdditiveAsync("X") でも可能
		
		while (! _async.isDone) { //ロードが完了していない間（本当はwhile文は避けたい）
			Debug.Log(_async.progress * 100 + "%");  //読込完了の%を表示
			yield return new WaitForSeconds(0.01f); //0.01秒間隔でチェック
		}

		yield return null;
	}
}
```

### 実行
1. [Assets]-[Scene001] をダブルクリックし、[再生] ボタンまたは [Edit]-[Play] を選択。
1. スペースキーを押すとConsoleに "Scene002" の読み込み状況（%）が表示され、ロード完了後、"Scene002" が表示されたら成功。

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：夢寐郎  
作成日：2018年04月16日


<a name="フワッと動いてスッと止まる"></a>
# <b>035 フワッと動いてスッと止まる</b>

### 立方体を作成
1. [GameObject]-[3D Object]-[Cube] を選択。
1. 名前は "Cube001" に変更。

### 空のゲームオブジェクトを作成
1. [GameObject]-[Create Empty] を選択。
1. [Inspector] ウィンドウで、名前を "GameObject" から "God" に変更。

### C#ファイルの作成
1. [Assets]-[Create]-[C# Script] を選択。
1. 名前を "NewBehaviourScript" から "Main" に変更。
    * 同時に (プロジェクト名)/Assets/Main.cs が生成されます。
1. 上記で作成した "God" の [Inspector]-[Add Component] エリアに上記のC#（Main）をドラッグ＆ドロップ。

### C#の記述
1. VSCode等のエディタで "Main.cs" を開きます。
1. 次のように書き換えて保存。
```
//Main.cs
using UnityEngine;

public class Main : MonoBehaviour {
	private GameObject _cube001;

	void Start () {
		_cube001 = GameObject.Find("Cube001");
	}

	void Update () {
		float _speed = Input.GetAxis("Horizontal"); //-1〜1（浮動小数点数）
		_cube001.transform.Translate(new Vector3(_speed,0,0));
	}
}
```

### 実行
1. [再生] ボタンまたは [Edit]-[Play] を選択。
1. 矢印キー（←→）で左右にフワッと動いてスッと止まる感じになります。
* 参照：[Edit]-[Project Settings]-[input]-[Axes]-[Horizontal] の設定

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：夢寐郎  
作成日：2018年04月16日


<a name="ユニティちゃん入門"></a>
# <b>036 ユニティちゃん入門</b>

### ユニティちゃんのインストール
1. [Window]-[Asset Store] を開く。
1. [3D モデル]-[キャラクター]-[トゥーン] から「"Unity-chan!" Model」（無料）を探し「ダウンロード」-[Import]。

### とりあえず動かしてみる
1. [Project]-[Assets]-[UnityChan]-[Scenes]-[Locomotion] をダブルクリック。
1. [▶] ボタンで再生。
1. 操作は次の通り。
	* [Ctrl]（マウスの左ボタン）で正面。
	* [←][→] で方向。
	* [↑][↓] で前進･後退。
	* [Space] で伸び。
	* [↑] + [Space] でジャンプ。
	* [Alt]（マウスの右ボタン）で煽り。

### ユニティちゃんの構造を確認
1. [Project]-[Assets]-[UnityChan]-[Models]-[unitychan] を選択。
1. [Inspector]-[Rig]-[Configure...] をクリック。
	* 戻る場合は [Done] をクリック。
1. [Inspector]-[Mapping] の各 [⦿] をクリックして関節部分を確認。  
	![036_1](https://mubirou.github.io/Unity/examples/jpg/036_1.jpg)
1. [Muscles & Settings] のスライダーを動かして可動範囲を確認。  
	![036_2](https://mubirou.github.io/Unity/examples/jpg/036_2.jpg)

### シーンを新規作成
1. [File]-[New Scene] を選択。
1. [File]-[Save Scene] で "Scene001" として保存。

### シーンに床を配置
1. [GameObject]-[3D Object]-[Plane] を選択。
1. [Inspector]-[Transform] を次のように設定。
	* Position X:0 Y:-0.5 Z:0
	* Scale X:10 Y:1 Z:10

### シーンにユニティちゃんを配置
1. [Project]-[Assets]-[UnityChan]-[Models]-[unitychan] を [Hierarchy] にドラッグ＆ドロップ。
1. [Hierarchy]-[unitychan]-[Inspector]-[Transform] を次のように設定。
	* Position X:0 Y:0 Z:-8

### コントローラーの設定
1. [Hierarchy]-[unitychan] を選択。
1. [Inspector]-[Animator]-[Controller] の [⦿] をクリック。
1. 一覧の中から "UnityChanLocomotions" を選択。

### アバダーの確認
1. [Hierarchy]-[unitychan] を選択。
1. [Inspector]-[Animator]-[Avatar]の [⦿] をクリック。
1. 一覧の中から "unitychanAvatar" を選択（デフォルト）。

### スクリプトの設定
1. [Hierarchy]-[unitychan] を選択。
1. [Component]-[Script]-[Unity Chan Control Script With Rigid Body] を選択。
1. [▶] ボタンで再生。
1. 操作は次の通り（カメラは固定されたままです）。
	* [←][→] で方向。
	* [↑][↓] で前進･後退。
	* [Space] で伸び。

### 余計な表示を消す①
1. [Hierarchy]-[Main Camera] を選択。
1. [Component]-[Scripts]-[Camera Controller]-[Camera Controller] を選択（追加されます）。
1. [Inspector]-[Camera Controller(Script)]-[Show Inst Window] の [✔] を外す。
	* 右下の"Inst Window"が消えます。

### 余計な表示を消す②
1. [Project]-[Assets]-[UnityChan]-[Scripts]-[UnityChanControlScriptWithRgidBody] を編集します。
1. VSCodeを起動し (Project name)/Assets/UnityChan/Scripts/UnityChanControlScriptWithRgidBody.cs を開き、以下の部分（189行目等）を変更。
```
/* コメントアウトします
void OnGUI()
	{
	GUI.Box(new Rect(Screen.width -260, 10 ,250 ,150), "Interaction");
	GUI.Label(new Rect(Screen.width -245,30,250,30),"Up/Down Arrow : Go Forwald/Go Back");
	GUI.Label(new Rect(Screen.width -245,50,250,30),"Left/Right Arrow : Turn Left/Turn Right");
	GUI.Label(new Rect(Screen.width -245,70,250,30),"Hit Space key while Running : Jump");
	GUI.Label(new Rect(Screen.width -245,90,250,30),"Hit Spase key while Stopping : Rest");
	GUI.Label(new Rect(Screen.width -245,110,250,30),"Left Control : Front Camera");
	GUI.Label(new Rect(Screen.width -245,130,250,30),"Alt : LookAt Camera");
}
*/
```
* 右上の"OnGUI"が消えます。  
![036_3](https://mubirou.github.io/Unity/examples/jpg/036_3.jpg)

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：夢寐郎  
作成日：2018年04月16日  


<a name="外部クラスの利用"></a>
# <b>037 外部クラスの利用</b>

### ◆ポイント
* GameObject には複数の C#（.csファイル）をアタッチできる
* 最後にアタッチした C# から順に実行される（MoveUpしても変化なし）
* オブジェクトにアタッチ＆実行すると自動的に C#（クラス）の「インスタンスが生成」される
* アタッチ済みの C#（クラス）の「インスタンスを参照」する方法  
	```
	MyClass _myClass = GetComponent<MyClass>();
	```
* 未アタッチの C#（クラス）の「インスタンスを生成」する方法  
	```
	MyClass _myClass = gameObject.AddComponent<MyClass>() as MyClass;
	```
* 「静的変数（クラス変数）」の参照方法
	```
	Debug.Log(MyClass.NAME);
	```

### ◆アタッチ済みの外部クラス（C#ファイル）の利用
1. 外部クラスの用意  
	1. [Assets]-[Create]-[C#Script] を選択
	1. C#ファイル名をMyClass（クラス名）とする
	1. スクリプトを記述する  
	```
	//MyClass.cs
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class MyClass : MonoBehaviour {
		public static string NAME = "MUBIROU";
		private int _age = 51; //privateは省略

		void Start() {}

		public int Age {
			get { return _age; } //thisは省略
			set { _age = value; } //thisは省略 ←valueは予め定義された変数（決め打ち）
		}

		public void Message(string arg) {
			Debug.Log("MyClass.Message: " + arg);
		}
	}
	```

1. メインクラスの用意  
	1. [GameObject]-[CreateEmpty] を選択し名前を Main に変更
	1. [Assets]-[Create]-[C#Script] を選択し名前を Main（.cs）に変更
	1. GameObject（Main）に C# スクリプト（Main.cs）をアタッチ
	1. スクリプトを記述する  
	```
	//Main.cs
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class Main : MonoBehaviour {
		void Start() {
			//インスタンスの「参照」←アタッチ＆実行した段階でインスタンスが「生成」
			MyClass _myClass = GetComponent<MyClass>(); //ポイント!!
			_myClass.Age = 52;
			Debug.Log(_myClass.Age); //-> 52

			// クラス変数（静的変数）のアクセス
			Debug.Log(MyClass.NAME); //-> "MUBIROU"

			// メソッドの実行
			_myClass.Message("Hello!"); //-> "MyClass.Message: Hello!"
		}
	}
	```

### ◆未アタッチの外部クラス（C#ファイル）の利用
1. 上記と異なり GameObject（Main）に以下のスクリプトをアタッチしません
1. Main.cs のサンプルは次の通り  
	```
	//Main.cs
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class Main : MonoBehaviour {
		void Start() {
			//インスタンスの「生成」（new MyClass() は不可）
			MyClass _myClass = gameObject.AddComponent<MyClass>() as MyClass; //ポイント!!
			_myClass.Age = 52;
			Debug.Log(_myClass.Age); //-> 52

			// クラス変数（静的変数）のアクセス
			Debug.Log(MyClass.NAME); //-> "MUBIROU"

			// メソッドの実行
			_myClass.Message("Hello!"); //-> "MyClass.Message: Hello!"
		}
	}
	```

実行環境：Unity 2019.1 Personal、Ubuntu 18.04 LTS  
作成者：夢寐郎  
作成日：2019年07月19日  


© 2018-2019 夢寐郎