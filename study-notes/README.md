# study-notes

### <b>index</b>

|No.|内容|No.|内容|No.|内容|
|:--|:--|:--|:--|:--|:--|
|[2110001](#2110001)|public vs SerializeField|[2110002](#2110002)|コールチン|[2110003](#2110003)|ScriptableObjectの基本|
|[2110004](#2110004)|シーン遷移|[2110005](#2110005)|staticクラス|[2110006](#2110006)|PlayerPrefsの基本|
***

<a name="2110001"></a>
# <b>public vs SerializeField</b>

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


<a name="2110002"></a>
# <b>コールチン</b>

* **コールチン**の基本的な操作とWaitForSecondsを利用。
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


<a name="2110003"></a>
# <b>ScriptableObjectの基本</b>

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


<a name="2110005"></a>
# <b>staticクラス</b>

1. 特徴
    1. 複数のクラスから利用可能な「共有データ」（変更可能）が作れる。
    1. [シーン遷移](#2110004)時でもデータを渡すことが可能。
    1. GameObjectにアタッチ等しなくてよい。
    1. 利用はどこからでも可能。
    1. staticとすることでインスタンスを生成しないことを明示できる。  
    （プロパティやメソッドも全てstaticにする必要がある）

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

1. 利用方法（複数シーンを含めどこからでも可能）
    ```c#
    Shared.Score --;
    Debug.Log(Shared.Score); //-> 99
    Debug.Log(Shared.Hello("MUBIROU")); //-> "Hello,MUBIROU!"
    ```

実行環境：Windows 10、Unity 2021.1  
作成者：夢寐郎  
作成日：2021年10月12日  


<a name="2110006"></a>
# <b>PlayerPrefsの基本</b>

* 基本構文
    * 値の読み取り
    ```c#
    int _sample1 = PlayerPrefs.GetInt("sample1");
    int _sample2 = PlayerPrefs.GetFloat("sample2");
    int _sample3 = PlayerPrefs.GetString("sample3");
    ```
    未保存の場合は以下の値が返る。  
    PlayerPrefs.GetInt("xxx")：0（int型）  
    PlayerPrefs.GetFloat("xxx)：0（float型）  
    PlayerPrefs.GetString("xxx)：""（string型）  

    * 値の保存
    ```c#
    PlayerPrefs.SetInt("sample1", 100);
    PlayerPrefs.SetFloat("sample1", 100f);
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
            _score = PlayerPrefs.GetInt("score");
            _text = GameObject.Find("Text1").GetComponent<Text>();
            _text.text = _score.ToString("D3");
        }
        
        public void ButtonClick() {
            _score ++;
            _text.text = _score.ToString("D3");
            PlayerPrefs.SetInt("score", _score);
        }
    }
    ```



<a name="2110001"></a>
# <b>xxxx</b>

### xxxxxx

1. xxxx  
    1. xxxx

実行環境：Windows 10、Unity 2021.1  
作成者：夢寐郎  
作成日：2021年10月XX日  


© 2021 夢寐郎