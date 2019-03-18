# Unity サンプル

### <b>INDEX</b>

|No.|内容|WebGL|.apk|project|作成日|更新日|
|:--:|:--|:--:|:--:|:--:|:--:|:--:|
|[001](#001)|キャラクター（9ポーズ）制御|―|[●](https://github.com/mubirou/Unity/blob/master/sample/apk/sample001.apk)|[●](https://github.com/mubirou/Unity/blob/master/sample/project/sample001.zip)|2019-02-05|―|
|[002](#002)|Avoid missile（複雑な衝突判定）|[●](https://mubirou.github.io/Unity/sample/html/sample002/index.html)|[●](https://github.com/mubirou/Unity/blob/master/sample/apk/sample002.apk)|[●](https://github.com/mubirou/Unity/blob/master/sample/project/sample002.zip)（未リファクタリング）|2019-03-11|―|


<a name="001"></a>
# 001 キャラクター（9ポーズ）制御

![sample001_06](https://mubirou.github.io/Unity/sample/jpg/sample001_06.jpg)  

1. Blenderで[モデリング＆アニメーション](https://github.com/mubirou/Blender/tree/master/sample#001)

1. アニメーターコントローラーの作成（[Project]-[Create]-[AnimatorController]）  
![sample001_01](https://mubirou.github.io/Unity/sample/jpg/sample001_01.jpg)  

1. パラメーターの設定（[AnimatorController]-[open]-[Parameters]）  
![sample001_02](https://mubirou.github.io/Unity/sample/jpg/sample001_02.jpg)  

1. 遷移条件の設定（ポーズ間の[→]-[Inspector]-[Conditions]）👈9ポーズX8x往復+α本分💦  
![sample001_03](https://mubirou.github.io/Unity/sample/jpg/sample001_03.jpg)  

1. ボタンの配置（[Hierarchy]-[Create]-[UI]-[Button]）  
![sample001_04](https://mubirou.github.io/Unity/sample/jpg/sample001_04.jpg)  
※ボタン以外の文字はTextMesh-Pro（[Hierarychy]-[Create]-[UI]-[TextMesh-Pro]）を使用  
※フォントは[1001 FREE FONTS](https://www.1001freefonts.com/)を利用

1. 各ポーズ用のスクリプトを記述（[Assets]-[Create]-[C#Script]）
    ```
    //ActionButton.cs
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI; //for Button

    public class ActionButton : MonoBehaviour {
        private GameObject _mubirou;
        private Animator _mubirouAnim;

        void Start () {
            _mubirou = GameObject.Find("mubirou");
            _mubirouAnim = _mubirou.GetComponent<Animator>();
        }
        
        public void OnClick() {
            _mubirouAnim.SetBool("isIdle", false);
            _mubirouAnim.SetBool("isFly", false);
            _mubirouAnim.SetBool("isJump", false);
            _mubirouAnim.SetBool("isRun", false);
            _mubirouAnim.SetBool("isWalk", false);
            _mubirouAnim.SetBool("isRove", false);
            _mubirouAnim.SetBool("isDeath", false);
            _mubirouAnim.SetBool("isBreak", false);
            _mubirouAnim.SetBool("isAttack", false);

            switch (this.name) {
                case "Button_Idle": _mubirouAnim.SetBool("isIdle", true); break;
                case "Button_Rove": _mubirouAnim.SetBool("isRove", true); break;
                case "Button_Walk": _mubirouAnim.SetBool("isWalk", true); break;
                case "Button_Run": _mubirouAnim.SetBool("isRun", true); break;
                case "Button_Jump": _mubirouAnim.SetBool("isJump", true); break;
                case "Button_Fly": _mubirouAnim.SetBool("isFly", true); break;
                case "Button_Attack": _mubirouAnim.SetBool("isAttack", true); break;
                case "Button_Break": _mubirouAnim.SetBool("isBreak", true); break;
                case "Button_Death": _mubirouAnim.SetBool("isDeath", true); break;
                default: break;
            }

            //ボタンの色の変更
            GameObject _canvas = GameObject.Find("Canvas");
            foreach (Transform _child in _canvas.transform){
                if(_child == this.transform){
                    //選択したボタンを#FFCC00に変更
                    ColorBlock _colors = this.GetComponent<Button>().colors;
                    _colors.highlightedColor = new Color(1.0f, 0.8f, 0.0f, 1.0f);
                    this.GetComponent<Button>().colors = _colors;
                } else {
                    if (_child.name != "Button_Random"){
                        //その他のボタンを#FFFFFFに戻す
                        Button _otherButton = _child.gameObject.GetComponent<Button>();
                        ColorBlock _colors = _otherButton.colors;
                        _colors.normalColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                        _otherButton.colors = _colors;
                    }
                }
            }
        }
    }
    ```

1. RANDOM用のスクリプトを記述（[Assets]-[Create]-[C#Script]）
    ```
    //RandomButton.cs
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI; //for Button

    public class RandomButton : MonoBehaviour {
        private GameObject _mubirou;
        private Animator _mubirouAnim;
        private List<string> _poseList 
        = new List<string>() {"Idle","Fly","Jump","Run","Walk","Rove","Death","Break","Attack"};

        void Start () {
            _mubirou = GameObject.Find("mubirou");
            _mubirouAnim = _mubirou.GetComponent<Animator>();
        }
        
        public void OnClick() {
            _mubirouAnim.SetBool("isIdle", false);
            _mubirouAnim.SetBool("isFly", false);
            _mubirouAnim.SetBool("isJump", false);
            _mubirouAnim.SetBool("isRun", false);
            _mubirouAnim.SetBool("isWalk", false);
            _mubirouAnim.SetBool("isRove", false);
            _mubirouAnim.SetBool("isDeath", false);
            _mubirouAnim.SetBool("isBreak", false);
            _mubirouAnim.SetBool("isAttack", false);
            
            //現在再生中のアニメーションクリップ名（"アーマチュア|Idle"など）
            string _currentClipName = _mubirouAnim.GetCurrentAnimatorClipInfo(0)[0].clip.name;

            //アニメーションクリップ名から余計な文字（"アーマチュア|"）を除く
            string _currentPoseName = _currentClipName.Substring(7);

            //次のポーズをランダムに決める（"Walk"など）
            string _nextPoseName = _poseList[Random.Range(0,_poseList.Count)];

            //現在再生中のポーズと次のポーズが別になるようにする
            while (_currentPoseName == _nextPoseName) {
                _nextPoseName = _poseList[Random.Range(0,_poseList.Count)];
            }

            //ポーズの変更
            _mubirouAnim.SetBool("is" + _nextPoseName, true);

            //ボタンの色の変更
            GameObject _canvas = GameObject.Find("Canvas");
            foreach (Transform _child in _canvas.transform){
                //選択したポーズボタンを#FFCC00に変更
                if(_child.name == "Button_" + _nextPoseName){
                    Button _nextButton = _child.gameObject.GetComponent<Button>();
                    ColorBlock _colors = _nextButton.colors;
                    _colors.normalColor = new Color(1.0f, 0.8f, 0.0f, 1.0f);
                    _nextButton.colors = _colors;
                } else {
                    if (_child.name != "Button_Random"){
                        //その他のボタンを#FFFFFFに戻す
                        Button _otherButton = _child.gameObject.GetComponent<Button>();
                        ColorBlock _colors = _otherButton.colors;
                        _colors.normalColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                        _otherButton.colors = _colors;
                    }
                }
            }
        }
    }
    ```

1. Mainクラスを記述（[Assets]-[Create]-[C#Script]）
    ```
    //Main.cs
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI; //for Button

    public class Main : MonoBehaviour {
        private GameObject _floor;

        void Start () {
            _floor = GameObject.Find("floor");

            //ボタンの色の変更
            GameObject _canvas = GameObject.Find("Canvas");
            foreach (Transform _child in _canvas.transform){
                //IDLEボタンを#FFCC00に変更
                if(_child.name == "Button_Idle"){
                    Button _theButton = _child.gameObject.GetComponent<Button>();
                    ColorBlock _colors = _theButton.colors;
                    _colors.normalColor = new Color(1.0f, 0.8f, 0.0f, 1.0f);
                    _theButton.colors = _colors;
                }
            }
        }
        
        void Update () {
            _floor.transform.Rotate(new Vector3(0,1,0));
        }
    }
    ```
    ※中心となる空のオブジェクト（[GameObject]-[CreateEmpty]）にアタッチ

1. ボタンにスクリプトをアタッチ＆有効化
    1. ボタンの[Inspector]に上記のボタン用のスクリプトをドラッグ
    1. 引き続き[Inspector]-[Button]-[OnClick()]-[+]を選択
    1. [None（Object）]-[⦿]→[Sceneタブ]-[（該当のボタン）]をダブルクリック
    1. [NoFunction]→[WalkButton]-[OnClick]を選択（(該当のボタン).OnClickと表示される）  
    ![sample001_05](https://mubirou.github.io/Unity/sample/jpg/sample001_05.jpg)  

実行環境：Unity 2018.2 Personal、Ubuntu 18.0.4.1 LTS、Blender 2.79、Android 8.0  
作成者：夢寐郎  
作成日：2019年02月06日


<a name="002"></a>
# 002 Avoid missile（複雑な衝突判定）

1. Blenderで[モデリング＆アニメーション](https://github.com/mubirou/Blender/tree/master/sample#001)

1. アニメーターコントローラーの作成（[Project]-[Create]-[AnimatorController]）  
![sample002_01](https://mubirou.github.io/Unity/sample/jpg/sample002_01.jpg)  

1. カメラ（Main Camera）の設定
    * [Inspector]-[Camera]-[FieldofView] を35に変更（35mm換算70mm弱）
    * [Inspector]-[Transform]-[Position]-[Z] を-18に変更

1. ミサイルを横切らせるコードの肝（Missileオブジェクトにアタッチ） 
    ```
    //Missile.cs
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Missile : MonoBehaviour {
        private float _speedX; //ミサイルの速度

        void Start () {
            Init();
        }

        void Update() {
            //常にミサイルを回転させる
            transform.Rotate(new Vector3(0,0,-25));

            //Position（左から右へ移動を繰り返す）
            if (transform.position.x < 10) {
                Vector3 _missilePos = transform.position;
                _missilePos.x += _speedX;
                transform.position = _missilePos;
            } else {
                Init();
            }
        }

        //ミサイルの初期化（どんな状態でも元に戻す）
        void Init () {
            //Visible（何かタイミングで消えている場合…）
            if (! gameObject.activeSelf) { //非表示の場合
                gameObject.SetActive(true); //表示する
            }

            //Position（位置）
            Vector3 _missilePos = transform.position;
            _missilePos.x = -11;
            _missilePos.y = UnityEngine.Random.Range(0.5f, 2.3f);
            _missilePos.z = 0;
            transform.position = _missilePos;

            //Rotation（角度）
            transform.rotation = Quaternion.Euler(0.0f, 90.0f, -90.0f);
            //transform.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            //transform.GetComponent<Rigidbody>().velocity = Vector3.zero;

            //Speed（速度）
            _speedX = UnityEngine.Random.Range(0.35f, 0.5f);
        }
    }
    ```

1. キャラクターとミサイルの複雑な衝突判定
    1. キャラクターとミサイルに **Rigidbody** を追加
        1. キャラクターに [Rigidbody] を追加  
            * [Hierarchy]-[Mubirou]-[Inspector]-[AddComponent]-[Physics]-[Rigidbody] を選択
            * [Inspector]-[Rigidboby] を次通りに設定  
                * Use Gravity：✔
                * Is Kinematic：✔
        1. ミサイルに [Rigidbody] を追加  
            * [Hierarchy]-[Mubirou]-[Inspector]-[AddComponent]-[Physics]-[Rigidbody] を選択
            * [Inspector]-[Rigidboby] を次通りに設定  
                * Use Gravity：なし
                * Is Kinematic：なし

    1. ミサイルにコライダー（**Capsule Collider**）を追加
        1. [Hierarchy]-[Missile]-[Inspector]-[AddComponent]-[Physics]-[CapsuleCollider] を選択
        1. [Inspector]-[CapsuleCollider]-[EditCollider] で調整

    1. キャラクターにコライダー（**SABoneColliderBuilder**）を追加  
        ![sample002_02](https://mubirou.github.io/Unity/sample/jpg/sample002_02.jpg)  
        1. [Window]-[AssetStore] で "SAColliderBuilder" を検索→[Import]
        1. 全て✔した状態で [Import]
        1. [Hierarchy]-[**Mubirou**]-[Inspector] に [Project] 内の [SAColliderBuilder]-[**Script**]-[SABoneColliderBuilder] をドラッグ
        1. [Inspector]-[SABoneColliderBuilder] の設定は次の通り  
            * Reducer
                * Shape Type：Capsule
                * Fit Type：Inner
            * Rigidbody
                * Is Create：なし
                * Is Kinematic：なし
        1. [Process] ボタンをクリック

    1. スクリプトで衝突判定を検知（上記のコード参照）
        ```
        //Missile.cs
        using System.Collections;
        using System.Collections.Generic;
        using UnityEngine;

        public class Missile : MonoBehaviour {
            …省略…
            void OnCollisionEnter(Collision _target) {
                //gameObject.SetActive(false); //ミサイルを消す場合
                Debug.Log("命中");
            }
        }
        ```
        ここまでの[プロジェクト](https://github.com/mubirou/Unity/blob/master/sample/project/sample002_1.zip)（.zipファイル）

1. カウンターの表示
    1. [Hierarchy]-[Create]-[3DObject]-[TextMeshPro-Text] を選択
    1. [TMPImporter] ダイアログで [ImportTMPEssentials] ボタンをクリック
    1. 名前を"CurrentScore"に変更
    1. [Inspector]-[TextMeshPro] を変更
        * FontSize：任意
        * Text："SCORE: 0"
    1. 空をGameObject（MainObject）を作成
        1. [GameObject]-[CreateEmpty] を選択、名前を"Main"に変更
        1. [Assets]-[Create]-[C#Script] を選択、名前を"Main"に変更
        1. [Hierarychy]-[Main]-[Inspector] に上記の"Main"（C#）ドラッグ＆ドロップ
    1. スクリプトを記述  
        ```
        //Main.cs
        using System.Collections;
        using System.Collections.Generic;
        using UnityEngine;
        using TMPro; //TextMeshPro用
        using System; //Int32用

        public class Main : MonoBehaviour {
            private TextMeshPro _currentScore;

            void Start() {
                _currentScore = GameObject.Find("CurrentScore").GetComponent<TextMeshPro>();
            }

            void Update() {
                int _now = Int32.Parse(_currentScore.text.Substring(7));
                int _new = _now - 2; //減点し続ける場合
                _currentScore.text = "SCORE: " + _new;
            }
        }
        ```

1. 全ソースコード（未リファクタリング）
```
//Main.cs（未リファクタリング）
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //for TextMeshPro
using System; //for Math

public class Main : MonoBehaviour {
    private GameObject _missile;
    private Missile _missileScript;
    private TextMeshPro _currentScore;
    private GameObject _mubirou;
    private Mubirou _mubirouScript;
    private bool _isDeath = false;

    void Awake() {
        //framerate
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 24;
    }

    void Start() {
        //highScore
        TextMeshPro _highScore = GameObject.Find("HighScore").GetComponent<TextMeshPro>();
        _highScore.text = "HIGH SCORE: " + HighScore.ToString();
		_missile = GameObject.Find("Missile");
		_missileScript = _missile.GetComponent<Missile>();
        _missileScript.AddPointEvent += PointHandler;

        //currentScore
        _currentScore = GameObject.Find("CurrentScore").GetComponent<TextMeshPro>();
        //Debug.Log(_currentScore.text);

        //mubirouEvent
        _mubirou = GameObject.Find("Mubirou");
        _mubirouScript = _mubirou.GetComponent<Mubirou>();
        _mubirouScript.ComebackEvent += ComebackHandler;
        _mubirouScript.DeathEvent += DeathHandler;
    }

    void Update() {
        if (_isDeath) {
            int _now = Int32.Parse(_currentScore.text.Substring(7));
            int _new = _now - 2; //減点
            _currentScore.text = "SCORE: " + _new;
        }
        
        //highScore
        HighScore = Int32.Parse(_currentScore.text.Substring(7));
        TextMeshPro _highScore = GameObject.Find("HighScore").GetComponent<TextMeshPro>();
        _highScore.text = "HIGH SCORE: " + HighScore.ToString();
    }

	/***************************
	Missile.PointEvent()
	***************************/
	private void PointHandler (object arg) {
        int _now = Int32.Parse(_currentScore.text.Substring(7));
        int _add = (int)GameObject.Find("Mubirou").GetComponent<Mubirou>().Point;
        int _new = _now + _add;
        _currentScore.text = "SCORE: " + _new;
    }

    void OnApplicationQuit() {
        //Debug.Log("fisish");
        HighScore = Int32.Parse(_currentScore.text.Substring(7));
    }

    public int HighScore {
        get { return PlayerPrefs.GetInt("highScore"); }
        set {
            if (PlayerPrefs.GetInt("highScore") < value) {
                PlayerPrefs.SetInt("highScore", value);
            }
        }
    }

	private void ComebackHandler(object arg) {
		_isDeath = false;
	}

    private void DeathHandler(object arg) {
        _isDeath = true;
    }
}
```

```
// Mubirou.cs（未リファクタリング）
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; //for Math

public class Mubirou : MonoBehaviour {
    private Animator _mubirouAnim;
    private string _status = "Run";
    private float _count = 0.0f;
    private float _originX;
    private float _originY;
    private float _originZ;
    //private float _currentX;
    private float _currentY;
    //private float _currentZ;
    public delegate void MyDelegate(object arg); //customEvent
    public event MyDelegate ComebackEvent; //customEvent
    public event MyDelegate DeathEvent; //customEvent
    private int _addPoint;

    void Start () {
        _mubirouAnim = GetComponent<Animator>();
        _originX = transform.position.x;
        _originY = _currentY = transform.position.y;
        _originZ = transform.position.z;
    }

    void Update () {
        if (_status == "Jump") {
            if (_count < Math.PI) { //0-180d
                _count += 0.25f;
                float _nextY = (float)(3 * Math.Abs(Math.Sin(_count)) + _originY);
                float _disY = _nextY - _currentY;
                transform.Translate(0, _disY, 0); //(x,y,z）
                _currentY = transform.position.y;
            } else {
                _status = "Run";
                _count = 0f;
                _mubirouAnim.SetBool("isJump", false);
                _mubirouAnim.SetBool("isRun", true);
                Vector3 _thisPos = transform.position;
                _thisPos.x = _originX;
                _thisPos.y = _originY;
                _thisPos.z = _originZ;
                transform.position = _thisPos;
            }
        }
    }

    public void Run () {
        _status = "Run";
        _mubirouAnim.SetBool("isBreak", false);
        _mubirouAnim.SetBool("isDeath", false);
        _mubirouAnim.SetBool("isJump", false);
        _mubirouAnim.SetBool("isRun", true);
    }

    public void Jump () {
        _status = "Jump";
        _mubirouAnim.SetBool("isBreak", false);
        _mubirouAnim.SetBool("isDeath", false);
        _mubirouAnim.SetBool("isJump", true);
        _mubirouAnim.SetBool("isRun", false);

        //missileDistance
        GameObject _missile = GameObject.Find("Missile");
        float _disZ = -(_missile.transform.position.z - transform.position.z);
        float _missileY = _missile.transform.position.y;
        _addPoint = (int)(Math.Round(_missileY * _disZ * 10));
    }

    public void Death () {
        _status = "Death";
        _mubirouAnim.SetBool("isBreak", false);
        _mubirouAnim.SetBool("isDeath", true);
        _mubirouAnim.SetBool("isJump", false);
        _mubirouAnim.SetBool("isRun", false);
        //Position
        Vector3 _thisPos = transform.position;
        _thisPos.x = _originX;
        _thisPos.y = _originY;
        _thisPos.z = _originZ;
        transform.position = _thisPos;

        Invoke("InvokeComeback", 1f);
        DeathEvent(this);
    }

    private void InvokeComeback () {
        Run();
        ComebackEvent(this); //eventHandler
    }

    public float Point {
        get { return _addPoint; }
        private set {} //readOnly
    }
}
```

```
// Missile.cs（未リファクタリング）
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {
	private BigExplosion _bigExplosion;
	private bool _isBomb = false;
	private bool _isDeath = false;
	private float _speedZ;
	private GameObject _mubirou;
	private Mubirou _mubirouScript;
	private JumpButton _jumpButtonScript;
    public delegate void MyEventHandler(object arg); //customEvent
    public event MyEventHandler AddPointEvent; //customEvent

	//Missile.Start()
	void Start () {
		Init();

		//bigExplosion
		GameObject _theGameObject = GameObject.Find("BigExplosion");
		_bigExplosion = _theGameObject.GetComponent<BigExplosion>();
		_bigExplosion.EndEvent += EndHandler;

		//mubirou
		_mubirou = GameObject.Find("Mubirou");
		_mubirouScript = _mubirou.GetComponent<Mubirou>();

		//jumpButton
		_theGameObject = GameObject.Find("JumpButton");
		_jumpButtonScript = _theGameObject.GetComponent<JumpButton>();
	}

	//Missile.EndHandler()
	private void EndHandler (object arg) {
		_isBomb = false;
		Init();
		_jumpButtonScript.Enabled = true;
	}

	void Update () {
		if (!_isBomb) {
			if (!_isDeath) {
				//Rotation
				transform.Rotate(new Vector3(0,0,-25));
				//Position
				if (transform.position.z < 6.8) {
					Vector3 _missilePos = transform.position;
					_missilePos.z += _speedZ;
					transform.position = _missilePos;
				} else {
					Init();
					AddPointEvent(this); //eventHandler
				}
			}
		}
	}

	void Init () {
		//visible
		if (! gameObject.activeSelf) {
			gameObject.SetActive(true);
		}
		//position
		Vector3 _missilePos = transform.position;
		_missilePos.x = 0;
		_missilePos.y = UnityEngine.Random.Range(0.5f, 2.3f);
		_missilePos.z = -14;
		transform.position = _missilePos;
		//rotation
		transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
		transform.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
		transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
		//speed
		_speedZ = UnityEngine.Random.Range(0.35f, 0.5f);
	}

	void OnCollisionEnter(Collision _target) {
		_isBomb = true;
		gameObject.SetActive(false); //Visible

		Vector3 _thisPos = transform.position;
		_bigExplosion.Begin(_thisPos.x, _thisPos.y, _thisPos.z);

		_mubirouScript.Death();
		_mubirouScript.ComebackEvent += ComebackHandler;
		_isDeath = true;

		_jumpButtonScript.Enabled = false;
	}

	private void ComebackHandler (object arg) {
		_isDeath = false;
	}

	public float Speed {
        get { return _speedZ; }
        private set {} //readOnly
    }
}
```

```
// BigExplosion.cs（未リファクタリング）
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigExplosion : MonoBehaviour {
	private ParticleSystem _particle;
	public delegate void MyDelegate(object arg); //customEvent
	public event MyDelegate EndEvent; //customEvent

	void Start () {
		_particle = GetComponent<ParticleSystem>();
		//_particle.gameObject.SetActive(false);
	}

	public void Begin (float _x, float _y, float _z) {
		_particle.gameObject.SetActive(true);
		if (! _particle.gameObject.activeSelf) {
			_particle.gameObject.SetActive(true);
		}
		Vector3 _thisPos = transform.position;
		_thisPos.x = _x;
		_thisPos.y = _y;
		_thisPos.z = _z;
		transform.position = _thisPos;
		_particle.Play();
		Invoke("InvokeMethod", _particle.main.duration);
	}

	private void InvokeMethod () {
		_particle.Stop();
		_particle.gameObject.SetActive(false);
		if (EndEvent != null) { EndEvent(this); }
		CancelInvoke();
	}

	public bool Visible {
		get { return gameObject.activeSelf; }
		set { gameObject.SetActive(value); }
	}
}
```

```
// JumpButton.cs（未リファクタリング）
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpButton : MonoBehaviour {
    private Mubirou _mubirou;
    //private bool _enabled = true;
    private Button _button;

    void Start () {
        GameObject _theGameObject = GameObject.Find("Mubirou");
        _mubirou = _theGameObject.GetComponent<Mubirou>();
        _button = GetComponent<Button>();
    }

    public void OnClick() {
        _mubirou.Jump();
    }

    public bool Enabled {
        get { return _button.interactable; }
        set { _button.interactable = value; }
    }
}
```

実行環境：Unity 2018.3 Personal、Ubuntu 18.0.4 LTS、Blender 2.79、Android 8.0  
作成者：夢寐郎  
作成日：2019年03月18日

© 2019 夢寐郎