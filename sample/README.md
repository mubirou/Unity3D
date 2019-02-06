# Unity サンプル

### <b>INDEX</b>

|No.|内容|WebGL|.apk|project|作成日|更新日|
|:--:|:--|:--:|:--:|:--:|:--:|:--:|
|[001](#001)|キャラクター（9ポーズ）制御|―|[●](https://github.com/mubirou/Unity/blob/master/sample/apk/sample001.apk)|[●](https://github.com/mubirou/Unity/blob/master/sample/project/sample001.zip)|2019-02-05|―|
|[002](#002)|―|―|―|―|―|―|


<a name="001"></a>
### 001 キャラクター（9ポーズ）制御

1. アニメーターコントローラーの作成（[Project]-[Create]-[AnimatorController]）  
![sample001_01](https://mubirou.github.io/Unity/sample/jpg/sample001_01.jpg)  

1. パラメーターの設定（[AnimatorController]-[open]-[Parameters]）  
![sample001_02](https://mubirou.github.io/Unity/sample/jpg/sample001_02.jpg)  

1. 遷移条件の設定（ポーズ間の[→]-[Inspector]-[Conditions]）  
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

実行環境：Unity 2018.2 Personal、Ubuntu 18.0.4.1 LTS、Blender 2.79、Android 8.0  
作成者：夢寐郎  
作成日：2019年02月XX日

© 2019 夢寐郎