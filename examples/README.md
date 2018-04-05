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
|008|[マウスに追従](#マウスに追従)|XXXXXXXXXXXXXXXXXXXXXX|
|009|[ボールをクリック](#ボールをクリック)|XXXXXXXXXXXXXXXXXXXXXX|
|010|[アニメーションクリップ](#アニメーションクリップ)|XXXXXXXXXXXXXXXXXXXXXX|
|011|[サウンド再生](#サウンド再生)|XXXXXXXXXXXXXXXXXXXXXX|
|012|[当たり判定（反発）](#当たり判定（反発）)|XXXXXXXXXXXXXXXXXXXXXX|
|013|[当たり判定（通過）](#当たり判定（通過）)|XXXXXXXXXXXXXXXXXXXXXX|
|014|[パーティクル](#パーティクル)|XXXXXXXXXXXXXXXXXXXXXX|
|015|[ハロー](#ハロー)|XXXXXXXXXXXXXXXXXXXXXX|
|016|[オブジェクトの生成](#オブジェクトの生成)|XXXXXXXXXXXXXXXXXXXXXX|
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
		if (Input.GetKey(KeyCode.UpArrow)) { //↑キーを押している間…
			_ball.transform.Translate(transform.forward); //○.Translate(0,0,1)と同じ
		} else if (Input.GetKey(KeyCode.DownArrow)) { //↓キーを押している間…
			_ball.transform.Translate(-transform.forward); //○.Translate(0,0,-1)と同じ
		} else if (Input.GetKey(KeyCode.RightArrow)) { //→キーを押している間…
			_ball.transform.Translate(transform.right); //○.Translate(1,0,0)と同じ
		} else if (Input.GetKey(KeyCode.LeftArrow)) { //←キーを押している間…
			_ball.transform.Translate(-transform.right); //○.Translate(-1,0,0)と同じ
		} else if (Input.GetKey(KeyCode.Space)) { //Spaceキーを押している間…
			_ball.transform.Translate(transform.up); //○.Translate(0,1,0)と同じ（上昇）
		}
	}
}
```
![003](https://takashinishimura.github.io/Unity/examples/jpg/003.jpg)

### GetKey と GetKeyDown / GetKeyUp の違い
```
void Update () {
	//if (Input.GetKey(KeyCode.RightArrow)) { //→キーを押している間…
	if (Input.GetKeyDown(KeyCode.RightArrow)) { //→キーを押す度に…
	//if (Input.GetKeyDown("a")) { //←…KeyCodeを使わない方法もあります
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
		if (Input.GetMouseButton(0)) { //左ボタンを押している場合…
			_cube1.transform.Rotate(new Vector3(0,1,0)); //上から見て時計回り
		} else if (Input.GetMouseButton(1)) { //右ボタンを押している場合…
			_cube1.transform.Rotate(new Vector3(0,-1,0)); //上から見て反時計回り
		} else if (Input.GetMouseButton(2)) { //中央ボタンを押している場合…
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
		if (Input.GetKey(KeyCode.UpArrow)) { //↑キーを押している間…
			_ball.transform.Translate(transform.forward / 2);
		} else if (Input.GetKey(KeyCode.DownArrow)) { //↓キーを押している間…
			_ball.transform.Translate(-transform.forward / 2);
		} else if (Input.GetKey(KeyCode.RightArrow)) { //→キーを押している間…
			_ball.transform.Translate(transform.right / 2);
		} else if (Input.GetKey(KeyCode.LeftArrow)) { //←キーを押している間…
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
1. 次のように書き換えて保存。
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