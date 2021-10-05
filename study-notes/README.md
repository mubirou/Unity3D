# study-notes

### <b>index</b>

|No.|内容|No.|内容|No.|内容|
|:--|:--|:--|:--|:--|:--|
|[2110001](#2110001)|〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇|[2110002](#2110002)|〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇|[2110003](#2110003)|〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇|
|[2110004](#2110004)|〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇|[2110005](#2110005)|〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇|[2110006](#2110006)|〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇|
***

<a name="2110001"></a>
# <b>xxxx</b>

### xxxxxx

1. publicの場合 
    ```
    using UnityEngine;

    public class MyClass : MonoBehaviour {
        public string _name = "mubirou";
        
        void Start() {
            Debug.Log(_name);
        }
    }
    ```
    * インスペクタ上で設定したものが優先.
    * 外のクラスからアクセス可能(OOP的にはNG).

1. SerializeFieldの場合
    ```
    using UnityEngine;

    public class MyClass : MonoBehaviour {
        [SerializeField] string _name = "mubirou";

        void Start() {
            Debug.Log(_name);
        }
    }
    ```
    * publicの場合と挙動は同じ.
    * アクセス修飾子の省略時はprivate扱い.

1. 結論
    「同じクラスからのみアクセス可能、かつインスペクタ上で値が変更可能」という、第4のアクセス修飾子として考えてよい.
    ```
    public string _hoge1 = "mubirou";
    protected string _hoge2 = "mubirou";
    [SerializeField] string _hoge3 = "mubirou";
    private string _hoge1 = "mubirou";
    ```
    ※参照:『Unityの教科書2021』(P108)

実行環境：Windows 10、Unity 2021.1  
作成者：夢寐郎  
作成日：2021年10月06日  


<a name="2110001"></a>
# <b>xxxx</b>

### xxxxxx

1. xxxx  
    1. xxxx

実行環境：Windows 10、Unity 2021.1  
作成者：夢寐郎  
作成日：2021年10月XX日  

© 2021 夢寐郎