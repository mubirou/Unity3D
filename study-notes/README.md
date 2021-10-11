# study-notes

### <b>index</b>

|No.|内容|No.|内容|No.|内容|
|:--|:--|:--|:--|:--|:--|
|[2110001](#2110001)|public vs SerializeField|[2110002](#2110002)|〇秒待機してから実行|[2110003](#2110003)|ScriptableObjectの基本|
|[2110004](#2110004)|〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇|[2110005](#2110005)|〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇|[2110006](#2110006)|〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇|
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
# <b>〇秒待機してから実行</b>

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
（注意）  
* XXXX

実行環境：Windows 10、Unity 2021.1  
作成者：夢寐郎  
作成日：2021年10月11日  


<a name="2110001"></a>
# <b>xxxx</b>

### xxxxxx

1. xxxx  
    1. xxxx

実行環境：Windows 10、Unity 2021.1  
作成者：夢寐郎  
作成日：2021年10月XX日  


© 2021 夢寐郎