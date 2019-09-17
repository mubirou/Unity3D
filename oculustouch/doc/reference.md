# OTouch リファレンスマニュアル
Version Alpha1.201909171011 対応  
© 2019 夢寐郎

## ◆ メソッド一覧
* [AddTargetObjects()](#AddTargetObjects) : 
* [RemoveTargetObjects()](#RemoveTargetObjects) : 


## ◆ プロパティ一覧
* [IsLHandTriggerDown](#IsLHandTriggerDown) : 「左中指トリガーを押している」か否か
* [IsLIndexTriggerDown](#IsLIndexTriggerDown) : 「左人差し指トリガーを押している」か否か
* [IsRHandTriggerDown](#IsRHandTriggerDown) : 「右中指トリガーを押している」か否か
* [IsRIndexTriggerDown](#IsRIndexTriggerDown) : 「右人差し指トリガーを押している」か否か
* [L](#L) : 左手側の Oculus Touch コントローラーの動きに連動する GameObject を指定
* [LHandTrigger](#LHandTrigger) : 「左中指トリガーを押しているトリガー量」（0〜1まで小数点以下15桁で表示）
* [LIndexTrigger](#LIndexTrigger) : 「左人差し指トリガーを押しているトリガー量」（0〜1まで小数点以下15桁で表示）
* [LThumbstickRotate](#LThumbstickRotate) : 
* [R](#R) : 右手側の Oculus Touch コントローラーの動きに連動する GameObject を指定
* [RHandTrigger](#RHandTrigger) : 「右中指トリガーを押しているトリガー量」（0〜1まで小数点以下15桁で表示）
* [RIndexTrigger](#RIndexTrigger) : 「右人差し指トリガーを押しているトリガー量」（0〜1まで小数点以下15桁で表示）
* [RThumbstickRotate](#RThumbstickRotate) : 
* [TargetObjects](#TargetObjects) : 


## ◆ イベント一覧
* [ADown](#ADown) : 「Aボタンを押した時」のイベントハンドラの登録や削除
* [ARawTouch](#ARawTouch) : 「Aボタンに触れた時」のイベントハンドラの登録や削除
* [AUp](#AUp) : 「Aボタンを押した後、離した時」のイベントハンドラの登録や削除
* [BDown](#BDown) : 「Bボタンを押した時」のイベントハンドラの登録や削除
* [BRawTouch](#BRawTouch) : 「Bボタンに触れた時」のイベントハンドラの登録や削除
* [BUp](#BUp) : 「Bボタンを押した後、離した時」のイベントハンドラの登録や削除
* [LHandTriggerDown](#LHandTriggerDown) : 「左中指トリガーを押した時」のイベントハンドラの登録や削除
* [LHandTriggerUp](#LHandTriggerUp) : 「左中指トリガーを押した後、離した時」のイベントハンドラの登録や削除
* [LIndexTriggerDown](#LIndexTriggerDown) : 「左人差し指トリガーを押した時」のイベントハンドラの登録や削除
* [LIndexTriggerRawNearTouch](#LIndexTriggerRawNearTouch) : 
* [LIndexTriggerRawTouch](#LIndexTriggerRawTouch) : 
* [LIndexTriggerUp](#LIndexTriggerUp) : 「左人差し指トリガーを押した後、離した時」のイベントハンドラの登録や削除
* [LLaserDown](#LLaserDown) : 
* [LLaserOut](#LLaserOut) : 
* [LLaserOver](#LLaserOver) : 
* [LLaserUp](#LLaserUp) : 
* [LLsserUpOutside](#LLsserUpOutside) : 
* [LThumbstickDown](#LThumbstickDown) : 「左親指スティックを押した時」のイベントハンドラの登録や削除
* [LThumbstickDownDown](#LThumbstickDownDown) : 
* [LThumbstickDownUp](#LThumbstickDownUp) : 
* [LThumbstickLeftDown](#LThumbstickLeftDown) : 
* [LThumbstickLeftUp](#LThumbstickLeftUp) : 
* [LThumbstickRawTouch](#LThumbstickRawTouch) : 
* [LThumbstickRightDown](#LThumbstickRightDown) : 
* [LThumbstickRightUp](#LThumbstickRightUp) : 
* [LThumbstickUp](#LThumbstickUp) : 「左親指スティックを押した後、離した時」のイベントハンドラの登録や削除
* [LThumbstickUpUp](#LThumbstickUpUp) : 
* [LThumbstickUpDown](#LThumbstickUpDown) : 
* [RHandTriggerDown](#RHandTriggerDown) : 「右中指トリガーを押した時」のイベントハンドラの登録や削除
* [RHandTriggerUp](#RHandTriggerUp) : 「右中指トリガーを押した後、離した時」のイベントハンドラの登録や削除
* [RIndexTriggerDown](#RIndexTriggerDown) : 「右人差し指トリガーを押した時」のイベントハンドラの登録や削除
* [RIndexTriggerRawNearTouch](#RIndexTriggerRawNearTouch) : 
* [RIndexTriggerRawTouch](#RIndexTriggerRawTouch) : 
* [RIndexTriggerUp](#RIndexTriggerUp) : 「右人差し指トリガーを押した後、離した時」のイベントハンドラの登録や削除
* [RLaserDown](#RLaserDown) : 
* [RLaserOut](#RLaserOut) : 
* [RLaserOver](#RLaserOver) : 
* [RLaserUp](#RLaserUp) : 
* [RLsserUpOutside](#RLsserUpOutside) : 
* [RThumbstickDown](#RThumbstickDown) : 「右親指スティックを押した時」のイベントハンドラの登録や削除
* [RThumbstickDownDown](#RThumbstickDownDown) : 
* [RThumbstickDownUp](#RThumbstickDownUp) : 
* [RThumbstickLeftDown](#RThumbstickLeftDown) : 
* [RThumbstickLeftUp](#RThumbstickLeftUp) : 
* [RThumbstickRawTouch](#RThumbstickRawTouch) : 
* [RThumbstickRightDown](#RThumbstickRightDown) : 
* [RThumbstickRightUp](#RThumbstickRightUp) : 
* [RThumbstickUp](#RThumbstickUp) : 「右親指スティックを押した後、離した時」のイベントハンドラの登録や削除
* [RThumbstickUpUp](#RThumbstickUpUp) : 
* [RThumbstickUpDown](#RThumbstickUpDown) : 
* [StartDown](#StartDown) : 「スタートボタン（Xボタンの下）を押した時」のイベントハンドラの登録や削除
* [StartUp](#StartUp) : 「スタートボタン（Xボタンの下）を押した後、離した時」のイベントハンドラの登録や削除
* [XDown](#XDown) : 「Xボタンを押した時」のイベントハンドラの登録や削除
* [XRawTouch](#XRawTouch) : 「Xボタンに触れた時」のイベントハンドラの登録や削除
* [XUp](#XUp) : 「Xボタンを押した後、離した時」のイベントハンドラの登録や削除
* [YDown](#YDown) : 「Yボタンを押した時」のイベントハンドラの登録や削除
* [YRawTouch](#YRawTouch) : 「Yボタンに触れた時」のイベントハンドラの登録や削除
* [YUp](#YUp) : 「Yボタンを押した後、離した時」のイベントハンドラの登録や削除

***

<a name="ADown"></a>

# OTouch.ADown

### ◇ 構文
<em>otouch</em>.ADown += <em>SomeMethodHandler</em>  
<em>otouch</em>.ADown -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「Aボタンを押した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OTouch _otouch = GetComponent<OTouch>();
        _otouch.L = GameObject.Find("OculusTouchL");
        _otouch.R = GameObject.Find("OculusTouchR");
        _otouch.ADown += ADownHandler; // イベントハンドラの登録
        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void ADownHandler() { // イベントハンドラ
        //ここに「Aボタンを押した時」の処理を記述
        _console.Log("Aボタン↓"); //DEBUG用
    }
}
```

### ◇ 参照
[OTouch.AUp](#AUp)  
[OTouch.ARawTouch](#ARawTouch)  

***

<a name="ARawTouch"></a>

# OTouch.ARawTouch

### ◇ 構文
<em>otouch</em>.ARawTouch += <em>SomeMethodHandler</em>  
<em>otouch</em>.ARawTouch -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「Aボタンに触れた時」（触れている間ではなく、最初に触れた瞬間）のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OTouch _otouch = GetComponent<OTouch>();
        _otouch.L = GameObject.Find("OculusTouchL");
        _otouch.R = GameObject.Find("OculusTouchR");
        _otouch.ARawTouch += ARawTouchHandler; // イベントハンドラの登録
        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void ARawTouchHandler() { // イベントハンドラ
        //ここに「Aボタンに触れた時」の処理を記述
        _console.Log("Aボタンにタッチ"); //DEBUG用
    }
}
```

### ◇ 参照
[OTouch.ADown](#ADown)  
[OTouch.AUp](#AUp)  

***

<a name="AUp"></a>

# OTouch.AUp

### ◇ 構文
<em>otouch</em>.AUp += <em>SomeMethodHandler</em>  
<em>otouch</em>.AUp -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「Aボタンを押した後、離した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OTouch _otouch = GetComponent<OTouch>();
        _otouch.L = GameObject.Find("OculusTouchL");
        _otouch.R = GameObject.Find("OculusTouchR");
        _otouch.AUp += AUpHandler; // イベントハンドラの登録
        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void AUpHandler() { // イベントハンドラ
        //ここに「Aボタンを押した後、離した時」の処理を記述
        _console.Log("Aボタン↑"); //DEBUG用
    }
}
```

### ◇ 参照
[OTouch.ADown](#ADown)  
[OTouch.ARawTouch](#ARawTouch)  

***

<a name="BDown"></a>

# OTouch.BDown

### ◇ 構文
<em>otouch</em>.BDown += <em>SomeMethodHandler</em>  
<em>otouch</em>.BDown -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「Bボタンを押した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OTouch _otouch = GetComponent<OTouch>();
        _otouch.L = GameObject.Find("OculusTouchL");
        _otouch.R = GameObject.Find("OculusTouchR");
        _otouch.BDown += BDownHandler; // イベントハンドラの登録
        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void BDownHandler() { // イベントハンドラ
        //ここに「Bボタンを押した時」の処理を記述
        _console.Log("Bボタン↓"); //DEBUG用
    }
}
```

### ◇ 参照
[OTouch.BUp](#BUp)  
[OTouch.BRawTouch](#BRawTouch)  

***

<a name="BRawTouch"></a>

# OTouch.BRawTouch

### ◇ 構文
<em>otouch</em>.BRawTouch += <em>SomeMethodHandler</em>  
<em>otouch</em>.BRawTouch -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「Bボタンに触れた時」（触れている間ではなく、最初に触れた瞬間）のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OTouch _otouch = GetComponent<OTouch>();
        _otouch.L = GameObject.Find("OculusTouchL");
        _otouch.R = GameObject.Find("OculusTouchR");
        _otouch.BRawTouch += BRawTouchHandler; // イベントハンドラの登録
        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void BRawTouchHandler() { // イベントハンドラ
        //ここに「Bボタンに触れた時」の処理を記述
        _console.Log("Bボタンにタッチ"); //DEBUG用
    }
}
```

### ◇ 参照
[OTouch.BDown](#BDown)  
[OTouch.BUp](#BUp)  

***

<a name="BUp"></a>

# OTouch.BUp

### ◇ 構文
<em>otouch</em>.BUp += <em>SomeMethodHandler</em>  
<em>otouch</em>.BUp -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「Bボタンを押した後、離した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OTouch _otouch = GetComponent<OTouch>();
        _otouch.L = GameObject.Find("OculusTouchL");
        _otouch.R = GameObject.Find("OculusTouchR");
        _otouch.BUp += BUpHandler; // イベントハンドラの登録
        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void BUpHandler() { // イベントハンドラ
        //ここに「Bボタンを押した後、離した時」の処理を記述
        _console.Log("Bボタン↑"); //DEBUG用
    }
}
```

### ◇ 参照
[OTouch.BDown](#BDown)  
[OTouch.BRawTouch](#BRawTouch)  

***

<a name="IsLHandTriggerDown"></a>

# OTouch.IsLHandTriggerDown

### ◇ 構文
<em>otouch</em>.IsLHandTriggerDown

### ◇ 説明
プロパティ。  
「左中指トリガーを押している」か否かを示すブール値（読み取り専用）。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private OTouch _otouch;
    private Console _console; //DEBUG用

    void Start() {
        _otouch = GetComponent<OTouch>();
        _otouch.L = GameObject.Find("OculusTouchL");
        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    void Update() {
        if (_otouch.IsLHandTriggerDown ) {
            _console.Log("左中指トリガー↓"); //DEBUG用
        }
    }
}
```

### ◇ 参照
[OTouch.IsRHandTriggerDown](#IsRHandTriggerDown)  
[OTouch.LHandTriggerDown](#LHandTriggerDown)  
[OTouch.LHandTrigger](#LHandTrigger)  

***

<a name="IsLIndexTriggerDown"></a>

# OTouch.IsLIndexTriggerDown

### ◇ 構文
<em>otouch</em>.IsLIndexTriggerDown

### ◇ 説明
プロパティ。  
「左人差し指トリガーを押している」か否かを示すブール値（読み取り専用）。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private OTouch _otouch;
    private Console _console; //DEBUG用

    void Start() {
        _otouch = GetComponent<OTouch>();
        _otouch.L = GameObject.Find("OculusTouchL");
        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    void Update() {
        if (_otouch.IsLIndexTriggerDown) {
            _console.Log("左人差し指トリガー↓"); //DEBUG用
        }
    }
}
```

### ◇ 参照
[OTouch.IsRIndexTriggerDown](#IsRIndexTriggerDown)  
[OTouch.LIndexTriggerDown](#LIndexTriggerDown)  
[OTouch.LIndexTrigger](#LIndexTrigger)  

***

<a name="IsRHandTriggerDown"></a>

# OTouch.IsRHandTriggerDown

### ◇ 構文
<em>otouch</em>.IsRHandTriggerDown

### ◇ 説明
プロパティ。  
「右中指トリガーを押している」か否かを示すブール値（読み取り専用）。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private OTouch _otouch;
    private Console _console; //DEBUG用

    void Start() {
        _otouch = GetComponent<OTouch>();
        _otouch.L = GameObject.Find("OculusTouchL");
        _otouch.R = GameObject.Find("OculusTouchR");
        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    void Update() {
        if (_otouch.IsRHandTriggerDown ) {
            _console.Log("右中指トリガー↓"); //DEBUG用
        }
    }
}
```

### ◇ 参照
[OTouch.IsLHandTriggerDown](#IsLHandTriggerDown)  
[OTouch.RHandTriggerDown](#RHandTriggerDown)  
[OTouch.RHandTrigger](#RHandTrigger)  

***

<a name="IsRIndexTriggerDown"></a>

# OTouch.IsRIndexTriggerDown

### ◇ 構文
<em>otouch</em>.IsRIndexTriggerDown

### ◇ 説明
プロパティ。  
「右人差し指トリガーを押している」か否かを示すブール値（読み取り専用）。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private OTouch _otouch;
    private Console _console; //DEBUG用

    void Start() {
        _otouch = GetComponent<OTouch>();
        _otouch.L = GameObject.Find("OculusTouchL");
        _otouch.R = GameObject.Find("OculusTouchR");
        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    void Update() {
        if (_otouch.IsRIndexTriggerDown) {
            _console.Log("右中指トリガー↓"); //DEBUG用
        }
    }
}
```

### ◇ 参照
[OTouch.IsLIndexTriggerDown](#IsLIndexTriggerDown)  
[OTouch.RIndexTriggerDown](#RIndexTriggerDown)  

***

<a name="L"></a>

# OTouch.L

### ◇ 構文
<em>otouch</em>.L

### ◇ 説明
プロパティ。  
Oculus Touch コントローラー（左手側）の動きに連動する GameObject を指定したり、調べることができます。

### ◇ 例文
```
OTouch _otouch = GetComponent<OTouch>();
_otouch.L = GameObject.Find("OculusTouchL");
```

### ◇ 参照
[OTouch.R](#R)

***

<a name="LHandTrigger"></a>

# OTouch.LHandTrigger

### ◇ 構文
<em>otouch</em>.LHandTrigger

### ◇ 説明
プロパティ。  
「左中指トリガーを押しているトリガー量」（0〜1 まで小数点以下15桁で表示）。読み取り専用。  
0〜100までの整数値を求める場合、Math.Round((<em>otouch</em>.LHandTrigger*100)) とします。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private OTouch _otouch;
    private Console _console; //DEBUG用

    void Start() {
        _otouch = GetComponent<OTouch>();
        _otouch.L = GameObject.Find("OculusTouchL");
        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    void Update() {
        if (_otouch.IsLHandTriggerDown ) {
            _console.Log(_otouch.LHandTrigger.ToString());
        }
    }
}
```

### ◇ 参照
[OTouch.RHandTrigger](#RHandTrigger)  
[OTouch.IsLHandTriggerDown](#IsLHandTriggerDown)  

***

<a name="LHandTriggerDown"></a>

# OTouch.LHandTriggerDown

### ◇ 構文
<em>otouch</em>.LHandTriggerDown += <em>SomeMethodHandler</em>  
<em>otouch</em>.LHandTriggerDown -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「左中指トリガーを押した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OTouch _otouch = GetComponent<OTouch>();
        _otouch.L = GameObject.Find("OculusTouchL");
        _otouch.LHandTriggerDown += LHandTriggerDownHandler; // イベントハンドラの登録
        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void LHandTriggerDownHandler() { // イベントハンドラ
        //ここに「左中指トリガーを押した時」の処理を記述
        _console.Log("左中指トリガー↓"); //DEBUG用
    }
}
```

### ◇ 参照
[OTouch.RHandTriggerDown](#RHandTriggerDown)  
[OTouch.LHandTriggerUp](#LHandTriggerUp)  
[OTouch.IsLHandTriggerDown](#IsLHandTriggerDown)  

***

<a name="LHandTriggerUp"></a>

# OTouch.LHandTriggerUp

### ◇ 構文
<em>otouch</em>.LHandTriggerUp += <em>SomeMethodHandler</em>  
<em>otouch</em>.LHandTriggerUp -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「左中指トリガーを押した後、離した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OTouch _otouch = GetComponent<OTouch>();
        _otouch.L = GameObject.Find("OculusTouchL");
        _otouch.LHandTriggerUp += LHandTriggerUpHandler; // イベントハンドラの登録
        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void LHandTriggerUpHandler() { // イベントハンドラ
        //ここに「左中指トリガーを押した後、離した時」の処理を記述
        _console.Log("左中指トリガー↑"); //DEBUG用
    }
}
```

### ◇ 参照
[OTouch.RHandTriggerUp](#RHandTriggerUp)  
[OTouch.LHandTriggerDown](#LHandTriggerDown)  

***

<a name="LIndexTrigger"></a>

# OTouch.LIndexTrigger

### ◇ 構文
<em>otouch</em>.LIndexTrigger

### ◇ 説明
プロパティ。  
「左人差し指トリガーを押しているトリガー量」（0〜1 まで小数点以下15桁で表示）。読み取り専用。  
0〜100までの整数値を求める場合、Math.Round((<em>otouch</em>.LIndexTrigger*100)) とします。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour{
    private OTouch _otouch;
    private Console _console; //DEBUG用

    void Start() {
        _otouch = GetComponent<OTouch>();
        _otouch.L = GameObject.Find("OculusTouchL");
        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    void Update() {
        if (_otouch.IsLIndexTriggerDown) {
            _console.Log(_otouch.LIndexTrigger.ToString());
        }
    }
}

```

### ◇ 参照
[OTouch.RIndexTrigger](#RIndexTrigger)  
[OTouch.IsLIndexTriggerDown](#IsLIndexTriggerDown)  

***

<a name="LIndexTriggerDown"></a>

# OTouch.LIndexTriggerDown

### ◇ 構文
<em>otouch</em>.LIndexTriggerDown += <em>SomeMethodHandler</em>  
<em>otouch</em>.LIndexTriggerDown -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「左人差し指トリガーを押した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OTouch _otouch = GetComponent<OTouch>();
        _otouch.L = GameObject.Find("OculusTouchL");
        _otouch.LIndexTriggerDown += LIndexTriggerDownHandler; //イベントハンドラの登録
        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void LIndexTriggerDownHandler() { //イベントハンドラ
        //ここに「左人差し指トリガーを押した時」の処理を記述
        _console.Log("左人差し指トリガー↓"); //DEBUG用
    }
}
```

### ◇ 参照
[OTouch.RIndexTriggerDown](#RIndexTriggerDown)  
[OTouch.LIndexTriggerUp](#LIndexTriggerUp)  
[OTouch.IsLIndexTriggerDown](#IsLIndexTriggerDown)  

***

<a name="LIndexTriggerUp"></a>

# OTouch.LIndexTriggerUp

### ◇ 構文
<em>otouch</em>.LIndexTriggerUp += <em>SomeMethodHandler</em>  
<em>otouch</em>.LIndexTriggerUp -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「左人差し指トリガーを押した後、離した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OTouch _otouch = GetComponent<OTouch>();
        _otouch.L = GameObject.Find("OculusTouchL");
        _otouch.LIndexTriggerUp += LIndexTriggerUpHandler; // イベントハンドラの登録
        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void LIndexTriggerUpHandler() { // イベントハンドラ
        //ここに「左人差し指トリガーを押した後、離した時」の処理を記述
        _console.Log("右人差し指トリガー↑"); //DEBUG用
    }
}
```

### ◇ 参照
[OTouch.RIndexTriggerUp](#RIndexTriggerUp)  
[OTouch.LIndexTriggerDown](#LIndexTriggerDown)  

***

<a name="LThumbstickDown"></a>

# OTouch.LThumbstickDown

### ◇ 構文
<em>otouch</em>.LThumbstickDown += <em>SomeMethodHandler</em>  
<em>otouch</em>.LThumbstickDown -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「左親指スティックを押した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OTouch _otouch = GetComponent<OTouch>();
        _otouch.L = GameObject.Find("OculusTouchL");
        _otouch.LThumbstickDown += LThumbstickDownHandler; // イベントハンドラの登録
        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void LThumbstickDownHandler() { // イベントハンドラ
        //ここに「左親指スティックを押した時」の処理を記述
        _console.Log("左親指スティック↓"); //DEBUG用
    }
}
```

### ◇ 参照
[OTouch.RThumbstickDown](#RThumbstickDown)  
[OTouch.LThumbstickUp](#LThumbstickUp)  

***

<a name="LThumbstickUp"></a>

# OTouch.LThumbstickUp

### ◇ 構文
<em>otouch</em>.LThumbstickUp += <em>SomeMethodHandler</em>  
<em>otouch</em>.LThumbstickUp -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「左親指スティックを押した後、離した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OTouch _otouch = GetComponent<OTouch>();
        _otouch.L = GameObject.Find("OculusTouchL");
        _otouch.LThumbstickUp += LThumbstickUpHandler; // イベントハンドラの登録
        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void LThumbstickUpHandler() { // イベントハンドラ
        //ここに「左親指スティックを押した後、離した時」の処理を記述
        _console.Log("左親指スティック↑"); //DEBUG用
    }
}
```

### ◇ 参照
[OTouch.RThumbstickUp](#RThumbstickUp)  
[OTouch.LThumbstickDown](#LThumbstickDown)  

***

<a name="R"></a>

# OTouch.R

### ◇ 構文
<em>otouch</em>.R

### ◇ 説明
プロパティ。  
Oculus Touch コントローラー（右手側）の動きに連動する GameObject を指定したり、調べることができます。

### ◇ 例文
```
OTouch _otouch = GetComponent<OTouch>();
_otouch.R = GameObject.Find("OculusTouchR");
```

### ◇ 参照
[OTouch.L](#L)

***

<a name="RHandTrigger"></a>

# OTouch.RHandTrigger

### ◇ 構文
<em>otouch</em>.RHandTrigger

### ◇ 説明
プロパティ。  
「右中指トリガーを押しているトリガー量」（0〜1 まで小数点以下15桁で表示）。読み取り専用。  
0〜100までの整数値を求める場合、Math.Round((<em>otouch</em>.RHandTrigger*100)) とします。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private OTouch _otouch;
    private Console _console; //DEBUG用

    void Start() {
        _otouch = GetComponent<OTouch>();
        _otouch.L = GameObject.Find("OculusTouchL");
        _otouch.R = GameObject.Find("OculusTouchR");
        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    void Update() {
        if (_otouch.IsRHandTriggerDown ) {
            _console.Log(_otouch.RHandTrigger.ToString());
        }
    }
}
```

### ◇ 参照
[OTouch.LHandTrigger](#LHandTrigger)  
[OTouch.IsRHandTriggerDown](#IsRHandTriggerDown)  

***

<a name="RHandTriggerDown"></a>

# OTouch.RHandTriggerDown

### ◇ 構文
<em>otouch</em>.RHandTriggerDown += <em>SomeMethodHandler</em>  
<em>otouch</em>.RHandTriggerDown -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「右中指トリガーを押した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OTouch _otouch = GetComponent<OTouch>();
        _otouch.L = GameObject.Find("OculusTouchL");
        _otouch.R = GameObject.Find("OculusTouchR");
        _otouch.RHandTriggerDown += RHandTriggerDownHandler; // イベントハンドラの登録
        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void RHandTriggerDownHandler() { // イベントハンドラ
        //ここに「右中指トリガーを押した時」の処理を記述
        _console.Log("右中指トリガー↓"); //DEBUG用
    }
}
```

### ◇ 参照
[OTouch.LHandTriggerDown](#LHandTriggerDown)  
[OTouch.RHandTriggerUp](#RHandTriggerUp)  
[OTouch.IsRHandTriggerDown](#IsRHandTriggerDown)  

***

<a name="RHandTriggerUp"></a>

# OTouch.RHandTriggerUp

### ◇ 構文
<em>otouch</em>.RHandTriggerUp += <em>SomeMethodHandler</em>  
<em>otouch</em>.RHandTriggerUp -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「右中指トリガーを押した後、離した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OTouch _otouch = GetComponent<OTouch>();
        _otouch.L = GameObject.Find("OculusTouchL");
        _otouch.R = GameObject.Find("OculusTouchR");
        _otouch.RHandTriggerUp += RHandTriggerUpHandler; // イベントハンドラの登録
        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void RHandTriggerUpHandler() { // イベントハンドラ
        //ここに「右中指トリガーを押した後、離した時」の処理を記述
        _console.Log("右中指トリガー↑"); //DEBUG用
    }
}
```

### ◇ 参照
[OTouch.LHandTriggerUp](#LHandTriggerUp)  
[OTouch.RHandTriggerDown](#RHandTriggerDown)  

***

<a name="RIndexTrigger"></a>

# OTouch.RIndexTrigger

### ◇ 構文
<em>otouch</em>.RIndexTrigger

### ◇ 説明
プロパティ。  
「右人差し指トリガーを押しているトリガー量」（0〜1 まで小数点以下15桁で表示）。読み取り専用。  
0〜100までの整数値を求める場合、Math.Round((<em>otouch</em>.RIndexTrigger*100)) とします。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour{
    private OTouch _otouch;
    private Console _console; //DEBUG用

    void Start() {
        _otouch = GetComponent<OTouch>();
        _otouch.L = GameObject.Find("OculusTouchL");
        _otouch.R = GameObject.Find("OculusTouchR");
        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    void Update() {
        if (_otouch.IsRIndexTriggerDown) {
            _console.Log(_otouch.RIndexTrigger.ToString());
        }
    }
}
```

### ◇ 参照
[OTouch.LIndexTrigger](#LIndexTrigger)  
[OTouch.IsRIndexTriggerDown](#IsRIndexTriggerDown)  

***

<a name="RIndexTriggerDown"></a>

# OTouch.RIndexTriggerDown

### ◇ 構文
<em>otouch</em>.RIndexTriggerDown += <em>SomeMethodHandler</em>  
<em>otouch</em>.RIndexTriggerDown -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「右人差し指トリガーを押した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OTouch _otouch = GetComponent<OTouch>();
        _otouch.L = GameObject.Find("OculusTouchL");
        _otouch.R = GameObject.Find("OculusTouchR");
        _otouch.RIndexTriggerDown += RIndexTriggerDownHandler; // イベントハンドラの登録
        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void RIndexTriggerDownHandler() { // イベントハンドラ
        //ここに「右人差し指トリガーを押した時」の処理を記述
        _console.Log("右人差し指トリガー↓"); //DEBUG用
    }
}
```

### ◇ 参照
[OTouch.LIndexTriggerDown](#LIndexTriggerDown)  
[OTouch.RIndexTriggerUp](#RIndexTriggerUp)  
[OTouch.IsRIndexTriggerDown](#IsRIndexTriggerDown)  

***

<a name="RIndexTriggerUp"></a>

# OTouch.RIndexTriggerUp

### ◇ 構文
<em>otouch</em>.RIndexTriggerUp += <em>SomeMethodHandler</em>  
<em>otouch</em>.RIndexTriggerUp -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「右人差し指トリガーを押した後、離した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OTouch _otouch = GetComponent<OTouch>();
        _otouch.L = GameObject.Find("OculusTouchL");
        _otouch.R = GameObject.Find("OculusTouchR");
        _otouch.RIndexTriggerUp += RIndexTriggerUpHandler; // イベントハンドラの登録
        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void RIndexTriggerUpHandler() { // イベントハンドラ
        //ここに「右人差し指トリガーを押した後、離した時」の処理を記述
        _console.Log("右人差し指トリガー↑"); //DEBUG用
    }
}
```

### ◇ 参照
[OTouch.LIndexTriggerUp](#LIndexTriggerUp)  
[OTouch.RIndexTriggerDown](#RIndexTriggerDown)  

***

<a name="RThumbstickDown"></a>

# OTouch.RThumbstickDown

### ◇ 構文
<em>otouch</em>.RThumbstickDown += <em>SomeMethodHandler</em>  
<em>otouch</em>.RThumbstickDown -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「右親指スティックを押した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OTouch _otouch = GetComponent<OTouch>();
        _otouch.L = GameObject.Find("OculusTouchL");
        _otouch.R = GameObject.Find("OculusTouchR");
        _otouch.RThumbstickDown += RThumbstickDownHandler; // イベントハンドラの登録
        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void RThumbstickDownHandler() { // イベントハンドラ
        //ここに「右親指スティックを押した時」の処理を記述
        _console.Log("右親指スティック↓"); //DEBUG用
    }
}
```

### ◇ 参照
[OTouch.LThumbstickDown](#LThumbstickDown)  
[OTouch.RThumbstickUp](#RThumbstickUp)  

***

<a name="RThumbstickUp"></a>

# OTouch.RThumbstickUp

### ◇ 構文
<em>otouch</em>.RThumbstickUp += <em>SomeMethodHandler</em>  
<em>otouch</em>.RThumbstickUp -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「右親指スティックを押した後、離した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OTouch _otouch = GetComponent<OTouch>();
        _otouch.L = GameObject.Find("OculusTouchL");
        _otouch.R = GameObject.Find("OculusTouchR");
        _otouch.RThumbstickUp += RThumbstickUpHandler; // イベントハンドラの登録
        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void RThumbstickUpHandler() { // イベントハンドラ
        //ここに「右親指スティックを押した後、離した時」の処理を記述
        _console.Log("右親指スティック↑"); //DEBUG用
    }
}
```

### ◇ 参照
[OTouch.LThumbstickUp](#LThumbstickUp)  
[OTouch.RThumbstickDown](#RThumbstickDown)  

***

<a name="StartDown"></a>

# OTouch.StartDown

### ◇ 構文
<em>otouch</em>.StartDown += <em>SomeMethodHandler</em>  
<em>otouch</em>.StartDown -= <em>SomeMethodHandler</em>

### ◇ 説明
「メニューボタン（Xボタンの下）を押した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OTouch _otouch = GetComponent<OTouch>();
        _otouch.L = GameObject.Find("OculusTouchL");
        _otouch.StartDown += StartDownHandler; // イベントハンドラの登録
        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void StartDownHandler() { // イベントハンドラ
        //ここに「メニューボタンを押した時」の処理を記述
        _console.Log("メニューボタン↓"); //DEBUG用
    }
}
```

### ◇ 参照
[OTouch.StartUp](#StartUp)  

***

<a name="StartUp"></a>

# OTouch.StartUp

### ◇ 構文
<em>otouch</em>.StartUp += <em>SomeMethodHandler</em>  
<em>otouch</em>.StartUp -= <em>SomeMethodHandler</em>

### ◇ 説明
「メニューボタン（Xボタンの下）を押した後、離した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OTouch _otouch = GetComponent<OTouch>();
        _otouch.L = GameObject.Find("OculusTouchL");
        _otouch.StartUp += StartUpHandler; // イベントハンドラの登録
        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void StartUpHandler() { // イベントハンドラ
        //ここに「メニューボタンを押した後、離した時」の処理を記述
        _console.Log("メニューボタン↑"); //DEBUG用
    }
}
```

### ◇ 参照
[OTouch.StartDown](#StartDown)  

***

<a name="XDown"></a>

# OTouch.XDown

### ◇ 構文
<em>otouch</em>.XDown += <em>SomeMethodHandler</em>  
<em>otouch</em>.XDown -= <em>SomeMethodHandler</em>

### ◇ 説明
「Xボタンを押した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OTouch _otouch = GetComponent<OTouch>();
        _otouch.L = GameObject.Find("OculusTouchL");
        _otouch.XDown += XDownHandler; // イベントハンドラの登録
        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void XDownHandler() { // イベントハンドラ
        //ここに「Xボタンを押した時」の処理を記述
        _console.Log("Xボタン↓"); //DEBUG用
    }
}
```

### ◇ 参照
[OTouch.XUp](#XUp)  
[OTouch.XRawTouch](#XRawTouch)  

***

<a name="XRawTouch"></a>

# OTouch.XRawTouch

### ◇ 構文
<em>otouch</em>.XRawTouch += <em>SomeMethodHandler</em>  
<em>otouch</em>.XRawTouch -= <em>SomeMethodHandler</em>

### ◇ 説明
「Xボタンに触れた時」（触れている間ではなく、最初に触れた瞬間）のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OTouch _otouch = GetComponent<OTouch>();
        _otouch.L = GameObject.Find("OculusTouchL");
        _otouch.XRawTouch += XRawTouchHandler; // イベントハンドラの登録
        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void XRawTouchHandler() { // イベントハンドラ
        //ここに「Xボタンに触れた時」の処理を記述
        _console.Log("Xボタンにタッチ"); //DEBUG用
    }
}
```

### ◇ 参照
[OTouch.XDown](#XDown)  
[OTouch.XUp](#XUp)  

***

<a name="XUp"></a>

# OTouch.XUp

### ◇ 構文
<em>otouch</em>.XUp += <em>SomeMethodHandler</em>  
<em>otouch</em>.XUp -= <em>SomeMethodHandler</em>

### ◇ 説明
「Xボタンを押した後、離した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OTouch _otouch = GetComponent<OTouch>();
        _otouch.L = GameObject.Find("OculusTouchL");
        _otouch.XUp += XUpHandler; // イベントハンドラの登録
        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void XUpHandler() { // イベントハンドラ
        //ここに「Xボタンを押した後、離した時」の処理を記述
        _console.Log("Xボタン↑"); //DEBUG用
    }
}
```

### ◇ 参照
[OTouch.XDown](#XDown)  
[OTouch.XRawTouch](#XRawTouch)  

***

<a name="YDown"></a>

# OTouch.YDown

### ◇ 構文
<em>otouch</em>.YDown += <em>SomeMethodHandler</em>  
<em>otouch</em>.YDown -= <em>SomeMethodHandler</em>

### ◇ 説明
「Yボタンを押した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OTouch _otouch = GetComponent<OTouch>();
        _otouch.L = GameObject.Find("OculusTouchL");
        _otouch.YDown += YDownHandler; // イベントハンドラの登録
        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void YDownHandler() { // イベントハンドラ
        //ここに「Yボタンを押した時」の処理を記述
        _console.Log("Yボタン↓"); //DEBUG用
    }
}
```

### ◇ 参照
[OTouch.YUp](#YUp)  
[OTouch.YRawTouch](#YRawTouch)  

***

<a name="YRawTouch"></a>

# OTouch.YRawTouch

### ◇ 構文
<em>otouch</em>.YRawTouch += <em>SomeMethodHandler</em>  
<em>otouch</em>.YRawTouch -= <em>SomeMethodHandler</em>

### ◇ 説明
「Yボタンに触れた時」（触れている間ではなく、最初に触れた瞬間）のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OTouch _otouch = GetComponent<OTouch>();
        _otouch.L = GameObject.Find("OculusTouchL");
        _otouch.YRawTouch += YRawTouchHandler; // イベントハンドラの登録
        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void YRawTouchHandler() { // イベントハンドラ
        //ここに「Yボタンに触れた時」の処理を記述
        _console.Log("Yボタンにタッチ"); //DEBUG用
    }
}
```

### ◇ 参照
[OTouch.YDown](#YDown)  
[OTouch.YUp](#YUp)  

***

<a name="YUp"></a>

# OTouch.YUp

### ◇ 構文
<em>otouch</em>.YUp += <em>SomeMethodHandler</em>  
<em>otouch</em>.YUp -= <em>SomeMethodHandler</em>

### ◇ 説明
「Yボタンを押した後、離した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OTouch _otouch = GetComponent<OTouch>();
        _otouch.L = GameObject.Find("OculusTouchL");
        _otouch.YUp += YUpHandler; // イベントハンドラの登録
        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void YUpHandler() { // イベントハンドラ
        //ここに「Yボタンを押した後、離した時」の処理を記述
        _console.Log("Yボタン↑"); //DEBUG用
    }
}
```

### ◇ 参照
[OTouch.YDown](#YDown)  
[OTouch.YRawTouch](#YRawTouch)  

***

<a name="XXXX"></a>

# XXXX

### ◇ 構文
XXXX

### ◇ 引数
XXXX  

### ◇ 説明
XXXX

### ◇ 例文
```
//GameManager.cs
```

### ◇ 参照
XXXX