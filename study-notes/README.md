# 🖊 Unity Study Notes <a name="TOP"></a>

### <b>index</b>

| [publicとSerializeField](#2110001) | [コールチン](#2110002) | [ScriptableObject](#2110003) | [シーン遷移](#2110004) | [staticクラス](#2110005) | [PlayerPrefs(1)](#2110006) | [PlayerPrefs(2)](#2110007) | [継承](#2110008) | [C#スクリプトのテンプレート](#2110009) | [委譲とInterface](#2110010) | [構造体](#2110011) | [列挙型](#2110012) | [ParticleSystem](#2110013) | [Input System](#2110014) | [ToString()](#2110015) | [Androidビルド](#2110016) | [処理速度計測](#2110017) | [三平方の定理](#2110018) | [VRビルド](#2204001) |
***

<a name="2110001"></a>
# <b>publicとSerializeField</b>

* 解説  
    インスペクタ上で変数の値を設定できる方法の比較（public vs SerializeField）。  

1. publicの場合
    ```c#
    using UnityEngine;

    public class MyClass : MonoBehaviour {
        public string _name = "mubirou";
        
        void Start() {
            Debug.Log(_name);
        }
    }
    ```
    * 通常のC#と異なり**インスペクタ上で値の変更が可能**。
    * インスペクタ上で設定したものが優先。
    * 外部クラスからアクセス可能（OOP的にはNG）。

2. SerializeFieldの場合
    ```c#
    using UnityEngine;

    public class MyClass : MonoBehaviour {
        [SerializeField] string _name = "mubirou";

        void Start() {
            Debug.Log(_name);
        }
    }
    ```
    * 外部クラスからアクセス不可以外はpublicの場合と同じ。
    * 一般的には2行に分けて記述するが、1行でも記述可能。
    * 個人的には「**同じクラスからのみアクセス可能、かつインスペクタ上で値が変更可能**」という「**第4のアクセス修飾子**」として利用したい（privateを明示してもよいが冗長過ぎる）。
    * 外部からアクセスする場合は、getter/setterを利用する。

* 参考
    * 『UnityC#ゲームプログラミング入門』(P258)
    * 『Unityの教科書2021』(P108)

実行環境：Windows 10、Unity 2021.1  
作成者：夢寐郎  
作成日：2021年10月06日  
更新日：2021年10月07日  
[[TOP]](#TOP)


<a name="2110002"></a>
# <b>コールチン</b>

* **コールチン**の基本的な操作とWaitForSecondsの利用法。
* サンプルは「**〇秒待機してから一度だけ実行する**」場合。

（構文）
```c#
using System.Collections; //IEnumeratorに必要

StartCoroutine(Hoge());

IEnumerator Hoge() {
    yield return new WaitForSeconds(〇);
    //〇秒後に実行したい処理
}
```

（SAMPLE）
```c#
using UnityEngine;
using System.Collections; //IEnumeratorに必要

public class MyClass : MonoBehaviour {
    void Start() {
        StartCoroutine(Coroutine1(3.5f));
    }

    IEnumerator Coroutine1(float arg) { //引数はオプション
        yield return new WaitForSeconds(arg);

        //〇秒後に実行したい処理
        Debug.Log(Time.time); //-> 3.500929
    }
}
```

実行環境：Windows 10、Unity 2021.1  
作成者：夢寐郎  
作成日：2021年10月07日  
[[TOP]](#TOP)


<a name="2110003"></a>
# <b>ScriptableObject</b>

サンプルは**ScriptableObject**（SharedObject.cs）を➀GameManager.csと➁Cube1.csの2箇所で共有しています。

```c#
//SharedObject.cs（ScriptableObject＝C#本P137下,148）
using UnityEngine;

[CreateAssetMenu(fileName = "XXX", menuName = "ScriptableObjects/SharedObject")]
public class SharedObject : ScriptableObject {
    //ScriptableObjectに保管したいデータ（Editor上でのみ記憶）
    [SerializeField] int _score; //Inspector上で上書き可能（再生中も可）

    //外部からの保管データへのアクセス用（setter/getter）
    public int Score {
        get { return _score; }
        set { _score = value; }
    }
}
```

```c#
//GameManager.cs（GameManager＝空のGameObjectにアタッチ）
using UnityEngine;

public class GameManager : MonoBehaviour {
    //Inspactor上でScriptableObjectのインスタンスを選択（C#本P148）
    [SerializeField] SharedObject _sharedObject;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            //ScriptableObjectに保管されているデータを変更
            _sharedObject.Score ++;
        }
    }
}
```

```c#
//Cube1.cs（Cube1＝GameObjectにアタッチ）
using UnityEngine;

public class Cube1 : MonoBehaviour {
    //Inspactor上でScriptableObjectのインスタンスを選択（C#本P148）
    [SerializeField] SharedObject _sharedObject;

    void Update() {
        //ScriptableObjectに保管されているデータを取得
        int _score = _sharedObject.Score;

        //取得したScriptableObjectの値を活用例
        transform.position = new Vector3(_score*0.1f, 0, 0);
    }
}
```
（備考）  
* Unity Editor上では保存されるがビルドした場合は保存されない。
* Unity Editor上でもScriptableObjectの値を変更した後（上記の場合「_sharedObject.Score ++;」の直後）で次の処理をしないと、Unity Editor再起動時には値が保存されない。
```c#
#if UNITY_EDITOR
UnityEditor.EditorUtility.SetDirty(_sharedObject);
UnityEditor.AssetDatabase.SaveAssets();
#endif
```
* Unity Editor上で保存されることがデメリットとなることもある。
* [シーン遷移](#2110004)時でもデータを渡すことが可能。

実行環境：Windows 10、Unity 2021.1  
作成者：夢寐郎  
作成日：2021年10月11日  
更新日：2021年10月12日 シーン遷移時の記述を追加  
[[TOP]](#TOP)


<a name="2110004"></a>
# <b>シーン遷移</b>

1. MainScene.unityの作成  
    1. [File]-[Save As]で"MainScene.unity"を保存。
    1. [GameObject]-[UI]-[Button]でボタンを作成。名前は"Button1"に変更。
    1. [GameObject]-[Create Empty]で"空のGameObject"を作成。名前は"GameManager"に変更。
    1. [Assets]-[Create]-[C# Script]で"GameManager.cs"を作成。
    1. "GameManager.cs"を記述。
        ```c#
        using UnityEngine;

        public class GameManager : MonoBehaviour {
            void Start() {}
            void Update() {}
            public void ButtonClick() {
                Debug.Log("GameManager.ButtonClick()");
            }
        }
        ```
    1. "GameManger"（GameObject）に"GameManager.cs"をアタッチ。
    1. "Button1"の[Inspector]-[Button]-[On Click()]-[+]-[None(Object)]に"GameManager"（GameObject）をドラッグ＆ドロップ。
    1. [No Function]-[GameManager]-[ButtonClick()]を選択。
    1. 再生テスト。[Button]をクリックして[Console]に"GameManager.ButtonClick()"と出力されたら成功。

1. EndScene.unityの作成
    1. [File]-[New Scene]-[Basic(Built-in)]-[Create]で新しいシーンを作成。
    1. [File]-[Save As]で"EndScene.unity"を保存。
    1. 終了画面を作成。

1. シーン遷移のコードを記述
    1. "GameManager.cs"を変更。
    ```c#
    using UnityEngine;
    using UnityEngine.SceneManagement; //SceneManagerに必要（スペル注意）

    public class GameManager : MonoBehaviour {
        void Start() {}
        void Update() {}
        public void ButtonClick() {
            SceneManager.LoadScene("EndScene");
        }
    }
    ```
1. 動作確認
    1. [Project]-[MainScene]をダブルクリック。
    1. [再生]して[Button]をクリックして"EndScene"に遷移すれば成功！
    ※ビルド時は [File]-[Build Setting]-[Scenes Build]のエリアに[Project]-[Assets]内の"MainScene"と"EndScene"をドラッグ＆ドロップが必要（順序が重要）。

実行環境：Windows 10、Unity 2021.1  
作成者：夢寐郎  
作成日：2021年10月12日  
[[TOP]](#TOP)


<a name="2110005"></a>
# <b>staticクラス</b>

1. 特徴
    1. 複数のクラスから利用可能な「共有データ」（変更可能）が作れる。
    1. [シーン遷移](#2110004)時でもデータを渡すことが可能。
    1. GameObjectにアタッチ等しなくてよい。
    1. 利用はどこからでも可能。
    1. staticとすることでインスタンスを生成しないことを明示できる。  
    （プロパティやメソッドも全てstaticまたはconstにする必要がある）

1. 記述方法
    ```c#
    //Shared.cs
    public static class Shared {
        public static int Score = 100;
        public static string Hello(string arg) {
            return "Hello," + arg + "!" ;
        }
    }
    ```
    ※Debug.Log等を使う場合は「using UnityEngine;」等が必要。  
    ※定数にする場合は「static」の代わりに「**const**」を使う（この場合、値を変更しようとするとエラーが発生する）。
    ```c#
    public const int Score = 100;
    ```

1. 利用方法（複数シーンを含めどこからでも可能）
    ```c#
    Shared.Score --;
    Debug.Log(Shared.Score); //-> 99
    Debug.Log(Shared.Hello("MUBIROU")); //-> "Hello,MUBIROU!"
    ```

実行環境：Windows 10、Unity 2021.1  
作成者：夢寐郎  
作成日：2021年10月12日  
更新日：2021年10月16日 constを追加  
[[TOP]](#TOP)


<a name="2110006"></a>
# <b>PlayerPrefs(1)</b>

簡単なデータをローカル上に保存する方法。データベース不要。オフラインで利用可能。

* 基本構文
    * 値の読取り
    ```c#
    int _sample1 = PlayerPrefs.GetInt("sample1");
    int _sample2 = PlayerPrefs.GetFloat("sample2");
    int _sample3 = PlayerPrefs.GetString("sample3");
    ```
    未保存の場合は以下の値が返る。  
    PlayerPrefs.GetInt("sample1") -> 0（int型）  
    PlayerPrefs.GetFloat("sample2) -> 0（float型）  
    PlayerPrefs.GetString("sample3) -> ""（string型）  

    * 値の保存
    ```c#
    PlayerPrefs.SetInt("sample1", 100);
    PlayerPrefs.SetFloat("sample1", 100.0f);
    PlayerPrefs.SetString("sample1", "ABC");
    ```

* サンプルコード  
    ```c#
    //GameManager.cs
    using UnityEngine;
    using UnityEngine.UI; //Textに必要

    public class GameManager : MonoBehaviour {
        private Text _text;
        private int _score = 0;

        void Start() {
            _score = PlayerPrefs.GetInt("score"); //読取り
            _text = GameObject.Find("Text1").GetComponent<Text>();
            _text.text = _score.ToString("D3");
        }
        
        public void ButtonClick() {
            _score ++;
            _text.text = _score.ToString("D3");
            PlayerPrefs.SetInt("score", _score); //保存
        }
    }
    ```

* 注意
    * 次のようにOnDestroy()で保存をすると保存できない場合がある（Androidアプリ時）
    ```c#
    void OnDestroy() {
        PlayerPrefs.SetInt("sample", 100);
    }
    ```

実行環境：Windows 10、Unity 2021.1、Android 11  
作成者：夢寐郎  
作成日：2021年10月13日  
[[TOP]](#TOP)


<a name="2110007"></a>
# <b>PlayerPrefs(2)</b>

* 解説  
    [PlayerPrefs(1)](#2110006)のようなint･float･string型といったシンプルな値ではなく複雑なデータを保存する場合、クラスをシリアライズして保存する。ビルド時（Android、PC Standalone）も有効。

* サンプルコード
    ```c#
    //GameManager.cs
    using UnityEngine;

    public class GameManager : MonoBehaviour {
        void Start() {
            string _string = PlayerPrefs.GetString("user8"); //読み取り
            if (_string != "") { //最初はデータなし
                User _user = JsonUtility.FromJson<User>(_string); //JSON->object
                Debug.Log(_user.Name); //-> "mubirou"
                Debug.Log(_user.Age); //-> 54
            } else {
                Debug.Log("NO DATA");
            }
        }
        
        void Update() {
            if (Input.GetMouseButtonDown(0)) {
                User _user = new User();
                string _json = JsonUtility.ToJson(_user); //Object->JSON
                PlayerPrefs.SetString("user8", _json); //保存
            }
        }
    }

    //保存するクラス
    [System.Serializable] //シリアライズ
    public class User {
        [SerializeField] string _name = "mubirou";
        [SerializeField] int _age = 54;

        public string Name {
            get { return _name; }
            set { _name = value; }
        }

        public int Age {
            get { return _age; }
            set { _age = value; }
        }
    }
    ```

実行環境：Windows 10、Unity 2021.1、Android 11  
作成者：夢寐郎  
作成日：2021年10月14日  
[[TOP]](#TOP)


<a name="2110008"></a>
# <b>継承</b>

似たような機能に[委譲](#2110010)がある。  

* スーパークラス（基本クラス･基底クラス･ベースクラス･親クラス）
    ```c#
    //SuperClass.cs（アタッチは不要）
    using UnityEngine; //MonoBehaviourに必要

    //多重継承不可のためここでMonoBehaviourを継承する必要がある
    public class SuperClass : MonoBehaviour { //publicのみ可能
        //派生クラスをアタッチしたGameObjectのインスペクタ上で個別に設定可能
        //個別に設定しない場合はprivateアクセス修飾子を使う
        [SerializeField] string _name; //privateは省略（第4のアクセス修飾子にする為）

        //protected＝同じクラスおよび派生クラス内でのみアクセス可能
        //protectedにするとで継承されることを暗示
        protected void SomethingMethod() { //publicでもよい
            Debug.Log("SuperClass.SomethingMethod()");
        }

        //private変数用のgetter/setter
        protected string Name { //publicでもよい
            get { return _name; }
            set { _name = value; }
        }
    }
    ```
    ＜Unity独自機能＞  
    1. publicまたは[SerializeField]にすることでインスペクタ上でインスタンス毎に異なる値を設定できる。
    1. GameObjectにアタッチするスクリプトは必ずMonoBehaviourクラスを継承する必要がある、かつC#は多重継承ができないためにスーパークラスでMonoBehaviourクラスを継承する必要がある。
    1. MonoBehaviourクラスやDebug.Log()を利用するには「using UnityEngine;」という名前空間を定義する必要がる。

* サブクラス（派生クラス･子クラス）
    ```c#
    //Cube1.cs（GameObject＝Cube1にアタッチ）
    using UnityEngine;

    public class Cube1 : SuperClass {
        void Start() {
            //thisは省略可
            Debug.Log(this.Name); //プロパティの取得
            this.Name = "Hoge"; //プロパティの変更
            this.SomethingMethod(); //メソッドの実行
        }

        void Update() {}
    }
    ```

実行環境：Windows 10、Unity 2021.1  
作成者：夢寐郎  
作成日：2021年10月16日  
[[TOP]](#TOP)


<a name="2110009"></a>
# <b>C#スクリプトのテンプレート</b>

* Windowsの場合  
    C:\Program Files\Unity\Hub\Editor\2021.1.25f1\Editor\Data\Resources\ScriptTemplates\81-C# Script-NewBehaviourScript.cs.txt  
    ```c#
    using UnityEngine;

    #ROOTNAMESPACEBEGIN#
    public class #SCRIPTNAME# : MonoBehaviour {
        void Start() {}

        void Update() {}
    }
    #ROOTNAMESPACEEND#
    ```

実行環境：Windows 10、Unity 2021.1.25f1  
作成者：夢寐郎  
作成日：2021年10月16日  
[[TOP]](#TOP)


<a name="2110010"></a>
# <b>委譲とInterface</b>

[継承](#2110008)の代わりに使用。インタフェースと併用することが多い。  

* 利用したいクラス
    ```c#
    //SomethingClass.cs（アタッチ不要）
    using UnityEngine; //Debug.Log()用

    class SomethingClass {
        private string _name = "mubirou";

        public void SomethingMethod() {
            Debug.Log("SomethingClass.SomethingMethod()");
        }

        public string Name {
            get { return _name; }
            set { _name = value; }
        }
    }
    ```

* 利用したいクラス用のインタフェース
    ```c#
    //ISomethingClass.cs（アタッチ不要）
    public interface ISomethingClass {
        void SomethingMethod();
        string Name { get; set; }
    }
    ```

* 委譲を引受けるクラス
    ```c#
    //Cube1.cs（GameObject＝Cube1にアタッチ）
    using UnityEngine;

    public class Cube1 : MonoBehaviour, ISomethingClass { //インターフェースの実装
        private SomethingClass _class;

        void Awake() {
            _class = new SomethingClass(); //委譲開始！
        }

        void Start() {}

        void Update() {}

        public void SomethingMethod() { //インターフェースにより必須
            _class.SomethingMethod();
        }

        public string Name { //インターフェースにより必須
            get { return _class.Name; }
            set { _class.Name = value; }
        }
    }
    ```

* 外部クラスからの操作
    ```c#
    //GameManager.cs（空のGameObject"GameManager"にアタッチ）
    using UnityEngine;

    public class GameManager : MonoBehaviour {
        private Cube1 _cube1; //GameObject(Cube1)にアタッチしたCube1.cs

        void Awake() {
            _cube1 = GameObject.Find("Cube1").GetComponent<Cube1>();
        }

        void Start() {
            _cube1.SomethingMethod(); //->"SomethingClass.SomethingMethod()"
            Debug.Log(_cube1.Name); //->"mubirou"
        }

        void Update() {}
    }
    ```

実行環境：Windows 10、Unity 2021.1  
作成者：夢寐郎  
作成日：2021年10月17日  
[[TOP]](#TOP)


<a name="2110011"></a>
# <b>構造体</b>

* 解説  
    * クラスに比べ制限が多いが軽量のオブジェクトとして扱うのに適する。
    * 構造体はクラスのような「参照型」ではなく「値型」データ。
    * 構造体を収めた変数は直接、オブジェクト（構造体）の「実体」を表す。
    * オブジェクトを生成する度に構造体のコピー？が生成される。つまり参照ではなく実体ではあるが「静的（static）」なものではない。
    * 構文はクラスとほぼ同じ。但し以下の違いがある。
        * 継承は不可（Interfaceの実装は可能）。
        * プロパティ宣言と同時の初期化は不可。
        * コンストラクタを定義する場合は引数が必須（コンストラクタは必須ではない）。
        * 「static struct」は恐らく不可。  
        ※その他、メソッドの定義、return文、private変数、getter/setter等も可能。
    * 名前空間（using UnityEngine;など）を定義すればDebug.Log()等も利用可能。
    * ちなみに「UnityEngine.Vector3」の内部はクラスではなく構造体。

* 構造体のサンプル
    ```c#
    //Pos3.cs
    struct Pos3 {
        //プロパティ宣言
        public float x;
        public float y;
        public float z;
        
        //コンストラクタ
        public Pos3(float x, float y, float z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
    ```

* 構造体の利用法➀（newを使う場合）
    ```c#
    Pos3 _pos3 = new Pos3(100f,80f,60f);
    
    Debug.Log(_pos3.x); //-> 100
    _pos3.x --;
    Debug.Log(_pos3.x); //-> 99
    ```

* 構造体の利用法➁（newを使わない場合）
    ```c#
    Pos3 _pos3;
    _pos3.x = 100f;
    _pos3.y = 80f;
    _pos3.z = 60f;

    Debug.Log(_pos3.x); //-> 100
    _pos3.x --;
    Debug.Log(_pos3.x); //-> 99
    ```

実行環境：Windows 10、Unity 2021.1  
作成者：夢寐郎  
作成日：2021年10月18日  
[[TOP]](#TOP)


<a name="2110012"></a>
# <b>列挙型</b>

* 解説  
    * 複数の定数をひとつにまとめておくことができる型。
    * コンテンツのステータス（状態）を表すものとして、文字列（重い）や数値（判りにくい）の代わりとして利用すると良い。
    * 列挙型の値に何かを代入するものではなく、逆にこの値を任意の変数に代入して利用。
    * 内部の値は数値である（以下検証）。  
        ```c#
        using UnityEngine;

        public class GameManager : MonoBehaviour {
            private enum Hoge { FUGA, PIYO, FOO }

            void Start() {
                Debug.Log((int)Hoge.FUGA); //-> 0
                Debug.Log((int)Hoge.PIYO); //-> 1
                Debug.Log((int)Hoge.FOO); //-> 2
            }
        }
        ```

* サンプル➀（特定の場所で利用する場合） 
    ```c#
    //GameManager.cs
    using UnityEngine;

    public class GameManager : MonoBehaviour {
        private enum Anim { PLAY, PAUSE, STOP }
        private Anim _status;

        void Start() {
        _status  = Anim.PLAY;
        }

        void Update() {
            if (_status == Anim.PLAY) {
                //状態は再生（PLAY）の時に実行したい処理
            } else if (_status == Anim.PAUSE) {
                //状態は再生（PAUSE）の時に実行したい処理
            } else if (_status == Anim.STOP) {
            //状態は再生（STOP）の時に実行したい処理
            }
        }
    }
    ```

* サンプル➁（いろいろな場所で利用する場合）
    * 定義方法（外部ファイルとして一括定義）
        ```c#
        //Enum.cs（ファイル名は任意）
        enum Anim {
            PLAY,
            PAUSE,
            STOP
        }

        enum Color {
            RED,
            GREEN,
            BLUE
        }
        ```

    * 利用方法（どこからでも利用可能）
        ```c#
        //GameManager.cs
        using UnityEngine;

        public class GameManager : MonoBehaviour {
            void Start() {
                Debug.Log(Anim.PLAY); //PLAY（Anim型）
                Debug.Log(Anim.PAUSE); //PAUSE（Anim型）
                Debug.Log(Anim.STOP); //STOP（Anim型）
                Debug.Log(Color.RED); //RED（Color型）
                Debug.Log(Color.GREEN); //GREEN（Color型）
                Debug.Log(Color.BLUE); //BLUE（Color型）
            }
        }
        ```

実行環境：Windows 10、Unity 2021.1  
作成者：夢寐郎  
作成日：2021年10月19日  
[[TOP]](#TOP)


<a name="2110013"></a>
# <b>ParticleSystem</b>

初期設定では使いにくいParticleSystemの設定を変更して活用できるようにする

* GameObjectにParticle Systemをアタッチ  
    [任意のGameObject]-[Inspector]-[Add Component]-[Effects]-[Particle System]を選択（デフォルトは矩形のマゼンタ色）

* 粒子を白色（ボケ付）にする  
    [Inspector]-[Particle System]-[✓Renderer]（一番下）-[Material]（上から3番目）-[⦿]-[Default-Particle]を選択

* 粒子の色と不透明度  
    [Inspector]-[Particle System]-[Start Color]-[A]を"1"→"0.4"に変更

* 球状に放出する  
    [Inspector]-[Particle System]-[✓Shape]-[Shape]を"Cone"→"Sphere"に変更  
    [Inspector]-[Particle System]-[✓Shape]-[Radius]（上から3番目）を"1"→"0.1
    "に変更（粒子のサイズ／オプション）

* 重力の適用
    [Inspector]-[Particle System]-[Gravity Modifier]を"0"→"0.2"に変更

* 放出量  
    [Inspector]-[Particle System]-[✓Emmision]を次の通りに設定   
    ・[Rate over Time]：0（初期値10）  
    ・[Bursts]-[+]-[Count]：60（初期値30）
    
* 瞬間的に放出  
    [Inspector]-[Particle System]-[Duration]を"5"→"0.3"に変更（余韻）  
    [Inspector]-[Particle System]-[Start Lifetime]を"5"→"0.5"に変更（放出時間）

* フェードアウト  
    [Inspector]-[Particle System]-[Size over Lifetim]を✓  
    [Inspector]最下部にある[Particle System Curves]を下から上に広げる（わかりづらい）  
    減衰カーブを選択（微調整可能）

* ループ再生の中止  
    [Inspector]-[Particle System]-[✓Looping]の✓を外す

* 最初の再生を中止  
    [Inspector]-[Particle System]-[✓Play On Awake]の✓を外す


* コードの記述
    ```c#
    //GameManager.cs（空のGameObject"GameManager"にアタッチ）
    using UnityEngine;

    public class GameManager : MonoBehaviour {
        private GameObject _sphere;

        void Start() {
            _sphere = GameObject.Find("Sphere");
        }

        void Update() {
            if (Input.GetKeyDown(KeyCode.Space)) {
                _sphere.GetComponent<ParticleSystem>().Play();
            }
        }
    }
    ```

実行環境：Windows 10、Unity 2021.1  
作成者：夢寐郎  
作成日：2021年10月20日  
[[TOP]](#TOP)


<a name="2110014"></a>
# <b>Input System</b>

1. Input Systemのインストール  
    **[Window]-[Package Manager]-[Packages:]-[Unity Registry]-[Input System]-[Install]**  
    ※[Warning]ダイアログが表示されたら[Yes]  
    ※旧来のAPIを使いたい場合は **[Edit]-[Project Settings]-[Player]-[Other Settings]-[Active Input Handling]-[Input Manager(Old)]** もしくは **[Both]**（両方使えるようにする）を選択

1. Input System設定ファイルの作成（要調査）  
    **[Edit]-[Project Settings]-[Input System Package]-[Create settings asset]**

* キー入力  
    ```c#
    //GameManager.cs（空のGameObject"GameManager"にアタッチ）
    using UnityEngine;
    using UnityEngine.InputSystem; //Keyboardに必要

    public class GameManager : MonoBehaviour {
        private Keyboard _key; //キーボードの状態

        void Start() {
            _key = Keyboard.current;
        }

        void Update() {
            //[Space]キーを押した時
            if (_key.spaceKey.wasPressedThisFrame) {
                Debug.Log("Space↓");
            }

            //[Space]キーを押し続けている時
            if (_key.spaceKey.isPressed) {
                Debug.Log("Space↓↓");
            }
            
            //[Space]キーを離した時
            if (_key.spaceKey.wasReleasedThisFrame) {
                Debug.Log("SPECE↑");
            }
        }
    }
    ```
    ＜その他のキー入力＞  
    * aKey～zKey（アルファベントキー）
    * upArrowKey～leftArrowKey（矢印キー）ほか  
    * 参考サイト：[Unity InputSystem入門（1）](https://note.com/npaka/n/nde6965c8b5d0#iWQx9)

* マウス入力
    ```c#
    //GameManager.cs（空のGameObject"GameManager"にアタッチ）
    using UnityEngine;
    using UnityEngine.InputSystem; //Mouseに必要

    public class GameManager : MonoBehaviour {
        private Mouse _mouse; //マウスの状態

        void Start() {
            _mouse = Mouse.current;
        }

        void Update() {
            //マウスボタン関連
            if (_mouse.leftButton.wasPressedThisFrame) {
                Debug.Log("MouseL↓"); //マウス左ボタンを押した時の処理
            }
            if (_mouse.leftButton.isPressed) {
                Debug.Log("MouseL↓↓"); //マウス左ボタンを押し続けている時の処理
            }
            if (_mouse.leftButton.wasReleasedThisFrame) {
                Debug.Log("MouseL↑"); //マウス左ボタンを離した時の処理
            }

            //マウスポインタの座標
            Vector2 _mousePos = _mouse.position.ReadValue();
            Debug.Log(_mousePos.x + ":" + _mousePos.y);

            //マウスポインタの前フレームからの移動距離
            Vector2 _mouseDelta = _mouse.delta.ReadValue();
            Debug.Log(_mouseDelta.x + ":" + _mouseDelta.y);
        }
    }
    ```
    ＜その他＞  
    * leftButton（マウスの左ボタン）
    * rightButton（マウスの右ボタン）
    * middleButton（マウスの中央ボタン）他
    * 参考サイト：[Unity InputSystem入門（1）](https://note.com/npaka/n/nde6965c8b5d0#85dSg)


実行環境：Windows 10、Unity 2021.1（Input System 1.0.2）  
作成者：夢寐郎  
作成日：2021年10月21日  
[[TOP]](#TOP)


<a name="2110015"></a>
# <b>ToString()</b>

### Int32.ToString()メソッド  
```c#
//GameManager.cs（空のGameObject"GameManager"にアタッチ）
using UnityEngine;
using System; //DateTimeに必要

public class GameManager : MonoBehaviour {
    void Start() {
        //現在の時刻を"hh:mm:ss"形式で表示
        DateTime _now = DateTime.Now;
        string _h = (_now.Hour < 10) ? "0" + _now.Hour : _now.Hour.ToString();
        string _m = (_now.Minute < 10) ? "0" + _now.Minute : _now.Minute.ToString();
        string _s = (_now.Second < 10) ? "0" + _now.Second : _now.Second.ToString();
        Debug.Log(_h + ":" + _m + ":" + _s); //"07:08:09"
    }
}
```

### Int32.ToString("xx")メソッド  
サンプル➀（整数表示で指定桁数に満たない場合は左側に"0"を挿入）
```c#
//GameManager.cs
using UnityEngine;
using System; //DateTimeに必要

public class GameManager : MonoBehaviour {
    void Start() {
        //現在の時刻を"hh:mm:ss"形式で表示
        DateTime _now = DateTime.Now;
        string _h = _now.Hour.ToString("D2");
        string _m = _now.Minute.ToString("D2");
        string _s = _now.Second.ToString("D2");
        Debug.Log(_h + ":" + _m + ":" + _s); //"07:08:09"
    }
}
```

サンプル➁（小数点以下の桁数の指定）
```c#
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    void Start() {
        Debug.Log((12.3456).ToString("F3")); //-> "12.346"（四捨五入される）
        Debug.Log((12).ToString("F3")); //-> "12.000"
    }
}
```

参考サイト：[docs.microsoft.com](https://docs.microsoft.com/ja-jp/dotnet/api/system.int32.tostring?view=net-5.0#System_Int32_ToString_System_String_)

### DateTime.ToString("xx")メソッド  
サンプル（時刻を"hh:mm:ss"形式で表示）  
```c#
//GameManager.cs
using UnityEngine;
using System; //DateTimeに必要

public class GameManager : MonoBehaviour {
    void Start() {
        //現在の時刻を"hh:mm:ss"形式で表示
        Debug.Log(DateTime.Now.ToString("HH:mm:ss")); //"07:08:09"
    }
}
```
参考サイト：[docs.microsoft.com](https://docs.microsoft.com/ja-jp/dotnet/api/system.datetime.tostring?view=net-5.0#System_DateTime_ToString_System_String_)

実行環境：Windows 10、Unity 2021.1  
作成者：夢寐郎  
作成日：2021年10月22日  
[[TOP]](#TOP)


<a name="2110016"></a>
# <b>Androidビルド</b>

Android実機テストに必要な最低限のビルド設定。

1. Android SDK･NDK･JDKの確認
    1. [Unity Hub](https://unity3d.com/jp/get-unity/download)を起動
    1. インストール済Unityの右肩の縦三点をクリック
    1. [モジュールを加える]-[Platforms]-[✓Android Build Support]-[✓Android SDK & NDK Tools]および[✓OpenJDK]を確認

1. シーンの追加  
    1. [File]-[Build Settings]-[Scenes In Build]エリアを確認
    1. [Project]-[Assets]から必要なシーンをドラッグ＆ドロップ  
    * 複数ある場合は順序が重要（1番上のシーンが最初に再生される）
    
1. プラットフォームをAndroidに変更
    1. [File]-[Build Settings]を開く
    1. [Platform]-[Android]-[Switch Platform]を選択

1. プロジェクトの設定
    1. 事前に[プロジェクト]-[Assets]内にアイコン用ファイル（432x432pxの.png）を用意
    1. [File]-[Build Settings]-[Player Settings]を選択
    1. [Player]の以下を設定  
        (1) Company Name : mubirou（初期値はDefaultCompany）  
        (2) Product Name : Android端末上のアプリ名（初期値はプロジェクト名）  
        (3) Version : 0.1（Android端末上で確認可能）  
        (4) Default Icon : 上記の432x432pxの.pngを選択  
    1. [Player]-[Resolution and Presentation]-[Orientation]-[Default Orientation]を次の中から選択  
        (1) Portrait : 縦  
        (2) Portrait Upside Down : 縦（反対向き）  
        (3) Landscape Right : 横（右回転）  
        (4) Landscape Left : 横（左回転）  
        (5) Auto Rotation : 自動

1. スマホの開発者向け設定
    1. [設定]-[デバイス情報]-[すべての仕様]-[MIMUバージョン]を8回連打 
    1. [設定]-[追加設定]-[開発者向けオプション]-[USBデバッグ]と[USB経由でインストール]をON
    1. [✓私は起こりうるリスクを認識し、その結果として起こりうる結果を自発的に受け入れます]-[OK]

1. スマホとPCを接続
    1. USBケーブルで接続
    1. [ファイル転送/Android Auto]を✓

1. ビルド
    1. [File]-[Build Settings]-[Build And Run]を選択
    1. 任意のファイル名（.apk）を付け保存
    1. Android端末上に[USB経由でこのアプリをインストールしますか？]と表示されたら[インストール]を選択
    1. Android端末上でアプリが起動すれば成功！

実行環境：Windows 10、Unity 2021.1、Xiaomi Redmi Note 9T (Android 11)  
作成者：夢寐郎  
作成日：2021年10月23日  
[[TOP]](#TOP)


<a name="2110017"></a>
# <b>処理速度計測</b>

1. Stopwatchクラスを利用する方法
    ```c#
    //GameManager.cs（空のGameObject"GameManager"にアタッチ）
    using UnityEngine;
    using System.Diagnostics; //Stopwatchに必要
    using Debug = UnityEngine.Debug; //衝突回避

    public class GameManager : MonoBehaviour {
        void Start() {
            Stopwatch _stopWatch = new Stopwatch();
            _stopWatch.Start();
            for (long i=0; i<1000000000; i++) { //10億回繰り返す場合…
                //速度計測したい処理
            }
            _stopWatch.Stop();
            Debug.Log(_stopWatch.Elapsed); //00:00:00.2516972
        }
    }
    ```
    * 「UnityEngine.Debug()」と「System.Diagnostics.Debug()」が衝突するため、上記のように記述するか「new System.Diagnostics.Stopwatch()」とする必要がある  
    * 参考サイト：[docs.microsoft.com](https://docs.microsoft.com/ja-jp/dotnet/api/system.diagnostics.stopwatch?view=net-5.0)  

2. DateTime.Ticksプロパティを利用する方法
    ```c#
    //GameManager.cs
    using UnityEngine;
    using System; //DateTimeに必要

    public class GameManager : MonoBehaviour {
        void Start() {
            long _start = DateTime.Now.Ticks; //100ナノ秒単位（精度は10ミリ秒）
            for (long i=0; i<1000000000; i++) { //10億回繰り返す場合…
                //速度計測したい処理
            }
            Debug.Log((DateTime.Now.Ticks - _start)/10000000f); //0.2513274（秒）
        }
    }
    ```
    参考サイト：[docs.microsoft.com](https://docs.microsoft.com/ja-jp/dotnet/api/system.datetime.ticks?view=net-5.0)

実行環境：Windows 10、Unity 2021.1  
作成者：夢寐郎  
作成日：2021年10月23日  
[[TOP]](#TOP)


<a name="2110018"></a>
# <b>三平方の定理</b>

三辺の長さが1:2:√3の直角三角形を三平方の定理で確認する

1. Math.Sqrt()を利用する方法
    ```c#
    //GameManager.cs
    using UnityEngine;
    using System; //DateTimeに必要

    public class GameManager : MonoBehaviour {
        void Start() {
            long _start = DateTime.Now.Ticks;
            double _result = 0;
            for (long i=0; i<100000000; i++) {
                //↓この３行のみ異なる
                double _a = (double)Math.Sqrt(3); //√3
                double _b = 1; //1
                _result = Math.Sqrt(_a*_a + _b*_b);
            }
            Debug.Log((DateTime.Now.Ticks - _start)/10000000f);
            Debug.Log(_result);
        }
    }
    ```
    * 処理速度結果：約**0.3**秒
    * 結果：2（double型）以下全て同結果

1. Vector2.magnitudeを利用する方法
    ```c#
    float  _a = (float)Math.Sqrt(3);
    float  _b = 1f;
    _result = new Vector2(_a, _b).magnitude;
    ```
    * 処理速度結果：約**2.5**秒
    * 処理速度を求める場合は「Math.Sqrt()」を使うべき

1. UnityEngine.Mathfを利用する方法
    ```c#
    float _a = (float)Mathf.Sqrt(3);
    float _b = 1f;
    _result = Mathf.Sqrt(_a*_a + _b*_b);
    ```
    * 処理速度結果：約**4.2**秒
    * 「UnityEngine.Mathf」は「System.Math」より遅い

1. Math.Pow()を利用する方法
    ```c#
    double _a = (double)Math.Sqrt(3);
    double _b = 1;
    _result = Math.Sqrt(Math.Pow(_a,2) + Math.Pow(_b,2));
    ```
    * 処理速度結果：約**7.0**秒
    * 「Math.Pow()」を使った二乗は非常に遅い

実行環境：Windows 10、Unity 2021.1  
作成者：夢寐郎  
作成日：2021年10月24日  
[[TOP]](#TOP)


<a name="2204001"></a>
# <b>VRビルド</b>

## この項目は書きかけです

* 以下のものを準備します
    * Meta Quest（ここでは初代を使用） 
    * Windows 10 パソコン
    * Unity（Windows版）
    * [Oculus Link対応ケーブル](https://www.amazon.co.jp/gp/product/B01MZIPYPY/ref=ppx_yo_dt_b_search_asin_title?ie=UTF8&psc=1)
    * スマートホン（ここではAndroidを使用）

### Unity のインストール～制作準備

1. Unity のインストール  
    1. [Unity Hub をダウンロード](https://unity3d.com/jp/get-unity/download)を選択し UnityHubSetup.exe をダウンロード
    1. ダウンロードした UnityHubSetup.exe をダブルクリックし指示に従いインストール
    1. Unity Hub を起動
    1. [インストール]-[エディターをインストール]-[プレリリース]-[ベータ]から最新のベータ版を[インストール]
    1. 途中「モジュールを加える」画面で以下のモジュールを追加  
        **✓Android Build Support**  
        └ **✓Android SDK & NDK Tools**  
        └ **✓OpenJDK**  
    ～しばらく時間がかかります☕～

1. プロジェクトの作成
    1. [Unity Hub]を起動
    1. [プルジェクト]-[新しいプロジェクト]を選択
    1. エディターバージョンを上記でインストールしたものにする
    1. [**VR**（コア）]を選択
    1. [プロジェクト名]と[保存場所]を設定して[プロジェクトを作成]ボタンを押す  
    ～しばらく時間がかかります～

1. 最低限のコンテンツ作成（仮のオブジェクトを配置）  
    1. [GameObject]-[3D Object]-[Cube]でテスト用の立方体を作成
    1. [Inspector]-[Transform]-[Position]のX,Y,Zをそれぞれ「1」に変更
    1. [File]-[Build Settings]-[Add Open Scenes]ボタンを押して[Scenes In Build]にシーンを追加

1. プラットフォームを**Android**に変更
    1. 引き続き[File]-[Build Settings]-[Platform]-[**Android**]する
    1. 引き続き[Texture Compression]を[**ASTC**]に変更
    1. [Switch Platform]ボタンを押す  
    ～すこし時間がかかります～

1. テクスチャの圧縮形式が**ASTC**か確認（＆変更）  
    1. 上記の設定でASTCに変更されているか以下で確認（恐らく変更されていないので変更）
    1. [File]-[Build Settings]-[Player Settings]-[Player]-[Android settings]（Androidのアイコン）タブ-[Other Settings]-[Texture compression format]-[**ASTC**]に変更

1. グラフィックAPIを**Vulkan**にする  
    1. 引き続き[File]-[Build Settings]-[Player Settings]-[Player]-[Android settings]（Androidのアイコン）タブ-[Other Settings]-[Auto Graphics API]の✓を外す
    1. 表示された[Graphics APIs]のうち[OpenGLES3]を削除し[**Vulkan**]のみ残す  

1. プラグインプロバイダーを**Oculus**にする  
    1. [File]-[Build Settings]-[Player Settings]-[XR Plug-in Management]-[Windows, Mac, Linux settings]（パソコンのアイコン）タブを選択し[**Oculus**]に✓を入れる
    1. 同様に[Android settings]（Androidのアイコン）タブを選択し[**Oculus**]に✓を入れる

1. **Oculus Integration**をインポートする  
    1. [Window]-[Asset Store]を開く
    1. [Search for assets]に"**Oculus Integration**"と入力し検索
    1. 検索された[**Oculus Integration**]を選択
    1. [Open in Unity]ボタンを押し[Unity Editor を開く]を選択
    1. [Download]→[Import]→[Import]と続けて選択  
    ～しばらく時間がかかります☕～  
    【要調査】途中「OpenXR Backend」ダイアログが表示されたら「Use OpenXR」を選択
    1. [Project]-[Assets]-[Oculus]が追加されたのを確認

### HMD（Meta Quest）+ スマホの準備作業  

1. Questを開発者モードにする  
    1. Quest本体の電源を入れ、AndroidスマホのBluetoothをオン
    1. Androidスマホにインストールした[Oculusアプリ](https://play.google.com/store/apps/details?id=com.oculus.twilight&hl=ja)を起動
    1. [メニュー]-[デバイス]でQuestと接続
    1. 引き続き[開発者モード]をオンにする

1. QuestとWindowsパソコンを接続  
    1. [Oculus Link対応ケーブル](https://www.amazon.co.jp/gp/product/B01MZIPYPY/ref=ppx_yo_dt_b_search_asin_title?ie=UTF8&psc=1)を用意
    1. 上記のケーブルでQuest本体とWindowsパソコンを接続
    1. Quest本体の画面上に「**データへのアクセスを許可**（接続したデバイスが、このヘッドセットのファイルにアクセスできるようになります。」と表示されたら「許可する」を選択
    1. 引き続きQuest本体の画面上に「**Oculus Linkをオンにする**（QuestがPCに接続されている状態でRiftのアプリにアクセスしてください。いつでもクイック設定でオンまたはオフにできます。」と表示された「オンにする」を選択
    * PC上にQuestと接続した時の動作の指示を求められた場合は「何もしない」を選択します

～再びUnity上での作業～ 

1. ビルド
    1. [File]-[Build Settings]-[Build And Run]を押す
    1. ファイル名（〇〇.apk）を付ける（名前は任意）  
    （初回のビルドは非常に時間がかかります）
    1. Quest本体に"MADE WITH Unity"と表示されコンテンツが再生されれば成功

～PC用Oculus Appの準備～

1. [oculus.com/setup](https://www.oculus.com/setup/)から[QUEST2 PCアプリをダウンロード]を選択
1. ダウンロードした OculusSetup.exe をダブルクリックしインストール
1. [Windows]-[Oculus]-[Oculus]でOculus Appを起動
1. [デバイス設定]で[QuestとTouch]が認識されているのを確認

～再びQuest上で設定～

1. Quest上のUIの[デスクトップ]アイコン（右から2番目）をTouchを使って選択し[モニター〇]（Unityが起動しているPCモニター）を選択
1. PC上のマウスカーソルを動かすと、Quest上のPC画面上でも動作するのを確認
1. Unityでコンテンツを再生するとQuest上でもリアルタイムで再生されれば成功


参考：[FRAME SYNTESIS](https://framesynthesis.jp/tech/unity/oculusquest/)  
参考：[developer.oculus.com](https://developer.oculus.com/documentation/unity/unity-conf-settings/#build-settings)  
実行環境：**Windows 10**、i7-9750H、64GB、GeForce RTX2070  
Unity Hub 3.1.1、**Unity 2022.1**.0b16、Oculus Integration 38.0  
作成者：夢寐郎  
作成日：202X年XX月XX日  
[[TOP]](#TOP)


<a name="2110019"></a>
# <b>XXXXX</b>

* XXX

実行環境：Windows 10、Unity 2021.1  
作成者：夢寐郎  
作成日：202X年XX月XX日  
[[TOP]](#TOP)


© 2021-2022 夢寐郎