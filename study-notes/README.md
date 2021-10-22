# Study Notes 2021 <a name="TOP"></a>

### <b>index</b>

| [publicとSerializeField](#2110001) | [コールチン](#2110002) | [ScriptableObject](#2110003) | [シーン遷移](#2110004) | [staticクラス](#2110005) | [PlayerPrefs(1)](#2110006) | [PlayerPrefs(2)](#2110007) | [継承](#2110008) | [C#スクリプトのテンプレート](#2110009) | [委譲とInterface](#2110010) | [構造体](#2110011) | [列挙型](#2110012) | [ParticleSystem](#2110013) | [Input System](#2110014) | [ToString()](#2110015) | [Androidビルド](#2110016) |
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
# <b>Androidビルド（この項目は書きかけです）</b>

1. Android SDK･NDK･JDKの確認
    1. [Unity Hub](https://unity3d.com/jp/get-unity/download)を起動
    1. インストール済Unityの右肩の三点をクリック
    1. [モジュールを加える]-[Platforms]-[✓Android Build Support]-[**✓Android SDK & NDK Tools**]および[**✓OpenJDK**]を確認
    ※無効にする場合  
    [Unity]-[Edit]-[Preferences]-[External Tools]-[Android]の以下の✓を外す  
        1. ✓**JDK** Installed with Unity (recommended)
        2. ✓**Android JDK** Installed with Unity (recommended)
        3. ✓**Android NDK** Installed with Unity (recommended)

実行環境：Windows 10、Unity 2021.1、Xiaomi Redmi Note 9T (Android 11)  
作成者：夢寐郎  
作成日：2021年10月XX日  
[[TOP]](#TOP)


<a name="2110017"></a>
# <b>XXXXX</b>

* XXX

実行環境：Windows 10、Unity 2021.1  
作成者：夢寐郎  
作成日：202X年XX月XX日  
[[TOP]](#TOP)

© 2021 夢寐郎