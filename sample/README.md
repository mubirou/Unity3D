# Unity サンプル

### <b>INDEX</b>

|No.|内容|WebGL|.apk|project|作成日|更新日|
|:--:|:--|:--:|:--:|:--:|:--:|:--:|
|[001](#001)|キャラクター（9ポーズ）制御|―|[●](https://github.com/mubirou/Unity/blob/master/sample/apk/sample001.apk)|[●](https://github.com/mubirou/Unity/blob/master/sample/project/sample001.zip)|2019-02-05|―|
|[002](#002)|―|―|―|―|―|―|


<a name="001"></a>
### 001 キャラクター（9ポーズ）制御

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
作成日：2019年02月XX日

© 2019 夢寐郎