# OQtouch サンプル

### <b>INDEX</b>

|No.|内容|参考動画|
|:--:|:--|:--:|
|[001](#001)|追跡|[●](https://www.instagram.com/p/B36_s1OnLfc/)|
|[002](#002)|ドローン|―|


<a name="001"></a>

# 001 追跡

### ◇ 解説
右人差し指トリガーを押している間、指定した個数（100個）の任意のオブジェクト（"piece"）を、Oculus Touch コントローラー（右手側）の動きに追跡させます（[参考動画](https://www.instagram.com/p/B36_s1OnLfc/)）。

### ◇ スクリプト（参考）
```
//GameManager.cs
using UnityEngine;
using System.Collections.Generic; //Listに必要

public class GameManager : MonoBehaviour {
    private OQtouch _oqt;
    private GameObject _piece0;
    private List<GameObject> _pieceList;
    private uint _pieceNum = 100; //追従させるオブジェクトの個数

    void Start() {
        _oqt = GetComponent<OQtouch>();
        _oqt.R = GameObject.Find("OculusTouchR");

        _piece0 = GameObject.Find("piece");
        _pieceList = new List<GameObject>();
        _pieceList.Add(_piece0);
        for (int i=1; i<=_pieceNum; i++) { //2つ目以降のpieceを動的配列に格納
            GameObject _thePiece = Instantiate(
                _piece0,
                _piece0.transform.position,
                _piece0.transform.rotation
            );
            _pieceList.Add(_thePiece);
        }
        _piece0.SetActive (false); //先頭を見えなくする
    }

    void Update () {
        if (_oqt.IsRIndexTriggerDown) {
            Vector3 _RPos = _oqt.R.transform.position;
            _piece0.transform.position = _RPos;

            for (int i=1; i<=_pieceNum; i++) {
                GameObject _thePiece = _pieceList[i];
                GameObject _frontPiece = _pieceList[i-1];
                
                float _disX = _frontPiece.transform.position.x - _thePiece.transform.position.x;
                float _disY = _frontPiece.transform.position.y - _thePiece.transform.position.y;
                float _disZ = _frontPiece.transform.position.z - _thePiece.transform.position.z;

                //角度
                _thePiece.transform.LookAt(_frontPiece.transform);

                //追従させる
                Vector3 _thePos = _thePiece.transform.position;
                _thePos.x += _disX/8;
                _thePos.y += _disY/8;
                _thePos.z += _disZ/8;
                _thePiece.transform.position = _thePos;
            }
        }
    }
}
```

### ◇ 参照
・[Android アプリ版](https://github.com/mubirou/Unity3D/tree/master/introduction#013)  
・[HTML5 Canvas 版](https://mubirou.github.io/CanvasLite/examples/html/006.html)  

実行環境：Unity 2020.1.0a9、Oculus Quest 10.0、Oculus Integration 1.41（VRのみ）、[OQtouch](https://github.com/mubirou/Unity3D/tree/master/oqtouch) Alpha 5、Ubuntu 18.04.3 LTS  
作成者：夢寐郎  
作成日：2019年10月23日  

<a name="002"></a>

***

# 002 ドローン

### ◇ 解説
左右の Oculus Touch コントローラーの親指スティックを上下左右させることでドローン（GameObject）を操作するための基本スクリプト。このサンプルでは[モード2](https://viva-drone.com/drone-transmitter-mode1-mode2/)を採用。

### ◇ スクリプト（参考）
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private OQtouch _oqt;
    private GameObject _drone;

    void Start() {
        _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.R = GameObject.Find("OculusTouchR");
        _drone = GameObject.Find("drone");
    }

    void Update () {
        // 左用
        if (_oqt.IsLThumbstickUpDown) { //上昇（↑）
            _drone.transform.Translate(0, 0.01f, 0);
        } else if (_oqt.IsLThumbstickDownDown) { //下降（↓）
            _drone.transform.Translate(0, -0.01f, 0);
        } else if (_oqt.IsLThumbstickLeftDown) { //左回り（←）
            _drone.transform.Rotate(new Vector3(0, -1, 0));
        } else if (_oqt.IsLThumbstickRightDown) { //右回り（→）
            _drone.transform.Rotate(new Vector3(0, 1 ,0));
        }

        // 右用
        if (_oqt.IsRThumbstickUpDown) { //前進（↑）
            _drone.transform.Translate(0, 0, 0.01f);
        } else if (_oqt.IsRThumbstickDownDown) { //後退（↓）
            _drone.transform.Translate(0, 0, -0.01f);
        } else if (_oqt.IsRThumbstickLeftDown) { //左進（←）
            _drone.transform.Translate(-0.01f, 0, 0);
        } else if (_oqt.IsRThumbstickRightDown) { //右進（→）
            _drone.transform.Translate(0.01f, 0, 0);
        }
    }
}
```

実行環境：Unity 2020.1.0a9、Oculus Quest 10.0、Oculus Integration 1.41（VRのみ）、[OQtouch](https://github.com/mubirou/Unity3D/tree/master/oqtouch) Alpha 5、Ubuntu 18.04.3 LTS  
作成者：夢寐郎  
作成日：2019年10月24日  