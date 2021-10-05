# study-notes

### <b>index</b>

|No.|内容|No.|内容|No.|内容|
|:--|:--|:--|:--|:--|:--|
|[2110001](#2110001)|public vs SerializeField|[2110002](#2110002)|〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇|[2110003](#2110003)|〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇|
|[2110004](#2110004)|〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇|[2110005](#2110005)|〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇|[2110006](#2110006)|〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇|
***

<a name="2110001"></a>
<span style="font-size: 200%; color: red;">赤くて大きい文字</span>
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
    * 「**同じクラスからのみアクセス可能、かつインスペクタ上で値が変更可能**」という「第4のアクセス修飾子」として考えてよい（privateを明示してもよいが冗長すぎるか…）。

* 参考
    * 『UnityC#ゲームプログラミング入門』(P258)
    * 『Unityの教科書2021』(P108)

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