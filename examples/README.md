# <b>C# with Unity 基本例</b>

この項目は、編集中の項目です。

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
|017|[オブジェクトを消す](#オブジェクトを消す)|XXXXXXXXXXXXXXXXXXXXXX|
|018|[スライダー](#スライダー)|XXXXXXXXXXXXXXXXXXXXXX|
|019|[ボタン](#ボタン)|XXXXXXXXXXXXXXXXXXXXXX|
|020|[トグルボタン](#トグルボタン)|XXXXXXXXXXXXXXXXXXXXXX|
|021|[シーンの移動](#シーンの移動)|XXXXXXXXXXXXXXXXXXXXXX|
|022|[シーン移動時にGameObjectを残す](#シーン移動時にGameObjectを残す)|XXXXXXXXXXXXXXXXXXXXXX|
|023|[他人のメソッドの実行①](#他人のメソッドの実行①)|XXXXXXXXXXXXXXXXXXXXXX|
|024|[他人のメソッドの実行②](#他人のメソッドの実行②)|XXXXXXXXXXXXXXXXXXXXXX|
|025|[データの保存](#データの保存)|XXXXXXXXXXXXXXXXXXXXXX|
|026|[GameObjectの入れ子](#GameObjectの入れ子)|XXXXXXXXXXXXXXXXXXXXXX|
|027|[キョロキョロ](#キョロキョロ)|XXXXXXXXXXXXXXXXXXXXXX|
|028|[クローン作成](#クローン作成)|XXXXXXXXXXXXXXXXXXXXXX|
|029|[数秒後にメソッドを実行](#数秒後にメソッドを実行)|XXXXXXXXXXXXXXXXXXXXXX|
|030|[二点間の距離](#二点間の距離)|XXXXXXXXXXXXXXXXXXXXXX|
|031|[他のCSファイルの参照](#他のCSファイルの参照)|XXXXXXXXXXXXXXXXXXXXXX|
|032|[万年カレンダー](#万年カレンダー)|XXXXXXXXXXXXXXXXXXXXXX|
|033|[シーンを重ねる](#シーンを重ねる)|XXXXXXXXXXXXXXXXXXXXXX|
|034|[シーンの事前読込み①](#シーンの事前読込み①)|XXXXXXXXXXXXXXXXXXXXXX|
|035|[シーンの事前読込み②](#シーンの事前読込み②)|XXXXXXXXXXXXXXXXXXXXXX|
|036|[フワッと動いてスッと止まる](#フワッと動いてスッと止まる)|XXXXXXXXXXXXXXXXXXXXXX|
|037|[ユニティちゃん入門](#ユニティちゃん入門)|XXXXXXXXXXXXXXXXXXXXXX|
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
1. [Hierarchy]-[Text001]-[Inspector]-[Text001Script(Script)] の [Text] の ⦿ をクリックし、[None(Text)] を [Text001] に変更します（分かり難く見落としがちなので注意）。

### 実行
1. [再生] ボタンまたは [Edit]-[Play] を選択。
1. [Game] ウィンドウ上に "2018/04/02 8:56:35" 等と表示されれば成功。  
![001](https://takashinishimura.github.io/Unity/examples/jpg/001.jpg)

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：Takashi Nishimura  
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
![002](https://takashinishimura.github.io/Unity/examples/jpg/002.jpg)

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：Takashi Nishimura  
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
![003](https://takashinishimura.github.io/Unity/examples/jpg/003.jpg)

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
作成者：Takashi Nishimura  
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
![004](https://takashinishimura.github.io/Unity/examples/jpg/004.jpg)

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：Takashi Nishimura  
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
![005](https://takashinishimura.github.io/Unity/examples/jpg/005.jpg)

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：Takashi Nishimura  
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
![006](https://takashinishimura.github.io/Unity/examples/jpg/006.jpg)

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：Takashi Nishimura  
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
![007](https://takashinishimura.github.io/Unity/examples/jpg/007.jpg)

### 色の指定方法
* new Color(赤, 緑, 青 [,不透明度])  
* Color.red（赤）、Color.blue（青）、Color.green（緑）、Color.black（黒）、Color.white（白）、Color.cyan（シアン）、Color.magenta（マゼンタ）、Color.yellow（黄）、Color.gray（グレー）、Color.clear（RGBAが全て0）

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：Takashi Nishimura  
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
作成者：Takashi Nishimura  
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
![009](https://takashinishimura.github.io/Unity/examples/jpg/009.jpg)

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：Takashi Nishimura  
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
1. 2.5秒後に右へ10、5秒後に元の位置へ…をイーズイン･イーズアウトしながら繰り返せば成功。  
![010](https://takashinishimura.github.io/Unity/examples/jpg/010.jpg)

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：Takashi Nishimura  
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
1. [Audio Source] の [AudioClip] の ⦿ をクリックし、[None(Audio Clip)] を [loop01] に変更。
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
![011](https://takashinishimura.github.io/Unity/examples/jpg/011.jpg)

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：Takashi Nishimura  
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
![012](https://takashinishimura.github.io/Unity/examples/jpg/012.jpg)

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：Takashi Nishimura  
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
![013](https://takashinishimura.github.io/Unity/examples/jpg/013.jpg)

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：Takashi Nishimura  
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
![014](https://takashinishimura.github.io/Unity/examples/jpg/014.jpg)

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：Takashi Nishimura  
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
![015](https://takashinishimura.github.io/Unity/examples/jpg/015.jpg)

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：Takashi Nishimura  
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
![016](https://takashinishimura.github.io/Unity/examples/jpg/016.jpg)

実行環境：Unity 2017.2 Personal、Ubuntu 16.04 LTS  
作成者：Takashi Nishimura  
作成日：2018年04月10日