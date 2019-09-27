/*
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console;

    void Start() {
        OTouch _otouch = GetComponent<OTouch>();
        _otouch.L = GameObject.Find("OculusTouchL");

        _otouch.EnabledLaserL = true;
        
        _otouch.AddTargetObjects(GameObject.Find("Button1"));
        
        //"OVER"単独はオケ。"DOWN"単独はNG。
        //_otouch.LLaserOver += LLaserOverHandler;
        _otouch.LLaserDown += LLaserDownHandler;

        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>();
    }


    // private void LLaserOverHandler(GameObject arg) {
    //     _console.Log("左レーザーが" + arg.name + "にヒット");
    // }
    private void LLaserDownHandler(GameObject arg) {
        _console.Log("左レーザーが" + arg.name + "を↓");
    }
}
*/

//GameManager.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; //for Math

public class GameManager : MonoBehaviour {
    private GameObject _oculusTouchL;
    private GameObject _oculusTouchR;
    private OTouch _otouch;
    private Console _console; //Consoleクラス（Console.cs）のインスタンス
    
    //--------------------------------------------------------
    //Oculus Touch 各種ボタン類
    private GameObject _buttonA;
    private GameObject _buttonB;
    private GameObject _buttonX;
    private GameObject _buttonY;
    private GameObject _buttonStart;
    private GameObject _indexTriggerL;
    private GameObject _indexTriggerR;
    private GameObject _handTriggerL;
    private GameObject _handTriggerR;
    private GameObject _thumbstickL;
    private GameObject _thumbstickR;
    //トリガー用テキスト（3D Text）
    private GameObject _textIndexTriggerL;
    private GameObject _textIndexTriggerR;
    private GameObject _textHandTriggerL;
    private GameObject _textHandTriggerR;
    //StickR
    private GameObject _thumbstickR_Up;
    private GameObject _thumbstickR_Down;
    private GameObject _thumbstickR_Right;
    private GameObject _thumbstickR_Left;
    //StickL
    private GameObject _thumbstickL_Up;
    private GameObject _thumbstickL_Down;
    private GameObject _thumbstickL_Right;
    private GameObject _thumbstickL_Left;
    //親指スティックのマーク
    private GameObject _thumbstickMarkL;
    private GameObject _thumbstickMarkR;
    private float _currentThumbStickRotateL = 0.0f;
    private float _currentThumbStickRotateR = 0.0f;
    //--------------------------------------------------------

    void Start() {
        //左右のOculusTcouchに連動させるオブジェクト
        _oculusTouchL = GameObject.Find("OculusTouchL");
        _oculusTouchR = GameObject.Find("OculusTouchR");
        ForDummy(); //ダミーのあれこれ

        //OculusTcouchをコントロールするクラス（インスタンスの参照）
        _otouch = GetComponent<OTouch>();
        _otouch.L = _oculusTouchL; //OculusTouchの右用のGameObject
        _otouch.R = _oculusTouchR; //OculusTouchの左用のGameObject

        //=========================
        // イベントハンドラの登録
        //=========================
        //人差し指トリガー（Down、Up）
        _otouch.LIndexTriggerDown += LIndexTriggerDownHandler;
        _otouch.LIndexTriggerUp += LIndexTriggerUpHandler;
        _otouch.RIndexTriggerDown += RIndexTriggerDownHandler;
        _otouch.RIndexTriggerUp += RIndexTriggerUpHandler;
        //人差し指トリガー（RawTouch）

        //中指トリガー
        _otouch.LHandTriggerDown += LHandTriggerDownHandler;
        _otouch.LHandTriggerUp += LHandTriggerUpHandler;
        _otouch.RHandTriggerDown += RHandTriggerDownHandler;
        _otouch.RHandTriggerUp += RHandTriggerUpHandler;
        //Aボタン
        _otouch.ADown += ADownHandler;
        _otouch.AUp += AUpHandler;
        //Bボタン
        _otouch.BDown += BDownHandler;
        _otouch.BUp += BUpHandler;
        //Xボタン
        _otouch.XDown += XDownHandler;
        _otouch.XUp += XUpHandler;
        //Yボタン
        _otouch.YDown += YDownHandler;
        _otouch.YUp += YUpHandler;
        //Startボタン
        _otouch.StartDown += StartDownHandler;
        _otouch.StartUp += StartUpHandler;
        //親指スティック
        _otouch.LThumbstickDown += LThumbstickDownHandler;
        _otouch.LThumbstickUp += LThumbstickUpHandler;
        _otouch.RThumbstickDown += RThumbstickDownHandler;
        _otouch.RThumbstickUp += RThumbstickUpHandler;
        //親指スティック上下左右（Down）
        _otouch.LThumbstickUpDown += LThumbstickUpDownHandler;
        _otouch.LThumbstickDownDown += LThumbstickDownDownHandler;
        _otouch.LThumbstickLeftDown += LThumbstickLeftDownHandler;
        _otouch.LThumbstickRightDown += LThumbstickRightDownHandler;
        _otouch.RThumbstickUpDown += RThumbstickUpDownHandler;
        _otouch.RThumbstickDownDown += RThumbstickDownDownHandler;
        _otouch.RThumbstickLeftDown += RThumbstickLeftDownHandler;
        _otouch.RThumbstickRightDown += RThumbstickRightDownHandler;
        //親指スティック上下左右（Up）
        _otouch.LThumbstickUpUp += LThumbstickUpUpHandler;
        _otouch.LThumbstickDownUp += LThumbstickDownUpHandler;
        _otouch.LThumbstickLeftUp += LThumbstickLeftUpHandler;
        _otouch.LThumbstickRightUp += LThumbstickRightUpHandler;
        _otouch.RThumbstickUpUp += RThumbstickUpUpHandler;
        _otouch.RThumbstickDownUp += RThumbstickDownUpHandler;
        _otouch.RThumbstickLeftUp += RThumbstickLeftUpHandler;
        _otouch.RThumbstickRightUp += RThumbstickRightUpHandler;
        //タッチ（RawTouch）
        _otouch.LIndexTriggerRawTouch += LIndexTriggerRawTouchHandler;
        _otouch.RIndexTriggerRawTouch += RIndexTriggerRawTouchHandler;
        _otouch.LThumbstickRawTouch += LThumbstickRawTouchHandler;
        _otouch.RThumbstickRawTouch += RThumbstickRawTouchHandler;
        _otouch.ARawTouch += ARawTouchHandler;
        _otouch.BRawTouch += BRawTouchHandler;
        _otouch.XRawTouch += XRawTouchHandler;
        _otouch.YRawTouch += YRawTouchHandler;
        //近接（RawNearTouch）
        _otouch.LIndexTriggerRawNearTouch += LIndexTriggerRawNearTouchHandler;
        _otouch.RIndexTriggerRawNearTouch += RIndexTriggerRawNearTouchHandler;

        //選択オブジェクト
        GameObject _cube1 = GameObject.Find("Cube1");
        GameObject _cube2 = GameObject.Find("Cube2");
        GameObject _cube3 = GameObject.Find("Cube3");
        _otouch.AddTargetObjects(_cube1);
        _otouch.AddTargetObjects(_cube2);
        _otouch.AddTargetObjects(_cube3);
        //Debug.Log(_otouch.TargetObjects);

        //オブジェクト選択
        _otouch.LLaserOver += LLaserOverHandler;
        _otouch.RLaserOver += RLaserOverHandler;
        _otouch.LLaserOut += LLaserOutHandler;
        _otouch.RLaserOut += RLaserOutHandler;
        _otouch.LLaserDown += LLaserDownHandler;
        _otouch.RLaserDown += RLaserDownHandler;
        _otouch.LLaserUp += LLaserUpHandler;
        _otouch.RLaserUp += RLaserUpHandler;
        _otouch.LLaserUpOutside += LLaserUpOutsideHandler;
        _otouch.RLaserUpOutside += RLaserUpOutsideHandler;

        //レーザーの有効化（初期値は無効）
        _otouch.EnabledLaserL = true;
        _otouch.EnabledLaserR = true;

        //コンソールの参照（冗長すぎね？）
        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>();
        //_console = GameObject.Find("Console").gameObject.GetComponent<Console>();
    }

    //=========================
    // イベントハンドラ
    //=========================
    //人差し指トリガー
    private void LIndexTriggerDownHandler() {
        _console.Log("左人差し指トリガー↓");
        AllObjectClear();
        _indexTriggerL.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
    }
    private void LIndexTriggerUpHandler() {
        _console.Log("左人差し指トリガー↑");
        AllObjectClear();
        _indexTriggerL.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
    private void RIndexTriggerDownHandler() {
        _console.Log("右人差し指トリガー↓");
        _indexTriggerR.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
    }
    private void RIndexTriggerUpHandler() {
        _console.Log("右人差し指トリガー↑");
        _indexTriggerR.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
    //中指トリガー
    private void LHandTriggerDownHandler() {
        _console.Log("左中指トリガー↓");
        _handTriggerL.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
    }
    private void LHandTriggerUpHandler() {
        _console.Log("左中指トリガー↑");
        _handTriggerL.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
    private void RHandTriggerDownHandler() {
        _console.Log("右中指トリガー↓");
        _handTriggerR.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
    }
    private void RHandTriggerUpHandler() {
        _console.Log("右中指トリガー↑");
        _handTriggerR.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
    //Aボタン
    private void ADownHandler() {
        _console.Log("Aボタン↓");
        _buttonA.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
    }
    private void AUpHandler() {
        _console.Log("Aボタン↑");
        _buttonA.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
    //Bボタン
    private void BDownHandler() {
        _console.Log("Bボタン↓");
        _buttonB.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
    }
    private void BUpHandler() {
        _console.Log("Bボタン↑");
        _buttonB.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
    //Xボタン
    private void XDownHandler() {
        _console.Log("Xボタン↓");
        _buttonX.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
    }
    private void XUpHandler() {
        _console.Log("Xボタン↑");
        _buttonX.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
    //Yボタン
    private void YDownHandler() {
        _console.Log("Yボタン↓");
        _buttonY.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
    }
    private void YUpHandler() {
        _console.Log("Yボタン↑");
        _buttonY.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
    //Startボタン
    private void StartDownHandler() {
        _console.Log("Startボタン↓");
        _buttonStart.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
    }
    private void StartUpHandler() {
        _console.Log("Startボタン↑");
        _buttonStart.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
    //親指スティック
    private void LThumbstickDownHandler() {
        _console.Log("左親指スティック↓");
        _thumbstickL.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
    }
    private void LThumbstickUpHandler() {
        _console.Log("左親指スティック↑");
        _thumbstickL.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
    private void RThumbstickDownHandler() {
        _console.Log("右親指スティック↓");
        _thumbstickR.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
    }
    private void RThumbstickUpHandler() {
        _console.Log("右親指スティック↑");
        _thumbstickR.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
    //親指スティック上下左右（↓）
    private void LThumbstickUpDownHandler() {
        _console.Log("左親指スティック（上）↓");
        _thumbstickL_Up.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
    }
    private void LThumbstickDownDownHandler() {
        _console.Log("左親指スティック（下）↓");
        _thumbstickL_Down.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
    }
    private void LThumbstickLeftDownHandler() {
        _console.Log("左親指スティック（左）↓");
        _thumbstickL_Left.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
    }
    private void LThumbstickRightDownHandler() {
        _console.Log("左親指スティック（右）↓");
        _thumbstickL_Right.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
    }
    private void RThumbstickUpDownHandler() {
        _console.Log("右親指スティック（上）↓");
        _thumbstickR_Up.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
    }
    private void RThumbstickDownDownHandler() {
        _console.Log("右親指スティック（下）↓");
        _thumbstickR_Down.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
    }
    private void RThumbstickLeftDownHandler() {
        _console.Log("右親指スティック（左）↓");
        _thumbstickR_Left.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
    }
    private void RThumbstickRightDownHandler() {
        _console.Log("右親指スティック（右）↓");
        _thumbstickR_Right.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
    }

    //親指スティック上下左右（↑）
    private void LThumbstickUpUpHandler() {
        _console.Log("左親指スティック（上）↑");
        _thumbstickL_Up.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
    private void LThumbstickDownUpHandler() {
        _console.Log("左親指スティック（下）↑");
        _thumbstickL_Down.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
    private void LThumbstickLeftUpHandler() {
        _console.Log("左親指スティック（左）↑");
        _thumbstickL_Left.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
    private void LThumbstickRightUpHandler() {
        _console.Log("左親指スティック（右）↑");
        _thumbstickL_Right.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
    private void RThumbstickUpUpHandler() {
        _console.Log("右親指スティック（上）↑");
        _thumbstickR_Up.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
    private void RThumbstickDownUpHandler() {
        _console.Log("右親指スティック（下）↑");
        _thumbstickR_Down.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
    private void RThumbstickLeftUpHandler() {
        _console.Log("右親指スティック（左）↑");
        _thumbstickR_Left.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
    private void RThumbstickRightUpHandler() {
        _console.Log("右親指スティック（右）↑");
        _thumbstickR_Right.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }

    //タッチ（RawTouch）
    private void LIndexTriggerRawTouchHandler() {_console.Log("左人差し指トリガーにタッチ");}
    private void RIndexTriggerRawTouchHandler() {_console.Log("右人差し指トリガーにタッチ");}
    private void LThumbstickRawTouchHandler() {_console.Log("左親指スティックにタッチ");}
    private void RThumbstickRawTouchHandler() {_console.Log("右親指スティックにタッチ");}
    private void ARawTouchHandler() {_console.Log("Aボタンにタッチ");}
    private void BRawTouchHandler() {_console.Log("Bボタンにタッチ");}
    private void XRawTouchHandler() {_console.Log("Xボタンにタッチ");}
    private void YRawTouchHandler() {_console.Log("Yボタンにタッチ");}
    //近接（RawNearTouch）
    private void LIndexTriggerRawNearTouchHandler() {_console.Log("左人差し指トリガーに近接");}
    private void RIndexTriggerRawNearTouchHandler() {_console.Log("右人差し指トリガーに近接");}

    //オブジェクト選択
    private void LLaserOverHandler(GameObject arg) {
        _console.Log("左レーザーが" + arg.name + "にヒット");
        //選択したボタンの色を#FFFF00に変更
        arg.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 0.0f, 1.0f);
    }
    private void RLaserOverHandler(GameObject arg) {
        _console.Log("右レーザーが" + arg.name + "にヒット");
        //選択したボタンの色を#FFFF00に変更
        arg.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 0.0f, 1.0f);
    }
    private void LLaserOutHandler(GameObject arg) {
        _console.Log("左レーザーが" + arg.name + "をアウト");
        //選択したボタンの色を白に変更
        arg.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
    private void RLaserOutHandler(GameObject arg) {
        _console.Log("右レーザーが" + arg.name + "をアウト");
        //選択したボタンの色を白に変更
        arg.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f); 
    }
    private void LLaserDownHandler(GameObject arg) {
        _console.Log("左レーザーが" + arg.name + "を↓");
    }
    private void RLaserDownHandler(GameObject arg) {
        _console.Log("右レーザーが" + arg.name + "を↓");
    }
    private void LLaserUpHandler(GameObject arg) {
        _console.Log("左レーザーが" + arg.name + "を↑");
        AllObjectClear(); //一度全てのボタンの色を白にする
        //選択したボタンの色を赤に変更
        arg.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
    }
    private void RLaserUpHandler(GameObject arg) {
        _console.Log("右レーザーが" + arg.name + "を↑");
        AllObjectClear(); //一度全てのボタンの色を白にする
        //選択したボタンの色を赤に変更
        arg.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
    }
    private void LLaserUpOutsideHandler(GameObject arg) {
        _console.Log("左レーザーが" + arg.name + "の外で↑");
    }
    private void RLaserUpOutsideHandler(GameObject arg) {
        _console.Log("右レーザーが" + arg.name + "の外で↑");
    } 

    void Update() {
        //人差し指トリガー
        if (_otouch.IsLIndexTriggerDown) {
            //_console.Log(_otouch.LIndexTrigger.ToString()); //値を出力
            _textIndexTriggerL.GetComponent<TextMesh>().text = Math.Round((OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger)*100)).ToString(); //テキストに表示
        } else {
            _textIndexTriggerL.GetComponent<TextMesh>().text = "0";
        }
        if (_otouch.IsRIndexTriggerDown) {
            //_console.Log(_otouch.RIndexTrigger.ToString()); //値を出力
            _textIndexTriggerR.GetComponent<TextMesh>().text = Math.Round((OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger)*100)).ToString(); //テキストに表示
        } else {
            _textIndexTriggerR.GetComponent<TextMesh>().text = "0";
        }
        //中指トリガー
        if (_otouch.IsLHandTriggerDown) {
            //_console.Log(_otouch.LHandTrigger.ToString()); //値を出力
            _textHandTriggerL.GetComponent<TextMesh>().text = Math.Round((OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger)*100)).ToString(); //テキスト表示
        } else {
            _textHandTriggerL.GetComponent<TextMesh>().text = "0";
        }
        if (_otouch.IsRHandTriggerDown) {
            //_console.Log(_otouch.RHandTrigger.ToString()); //値を出力
            _textHandTriggerR.GetComponent<TextMesh>().text = Math.Round((OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger)*100)).ToString(); //テキスト表示
        } else {
            _textHandTriggerR.GetComponent<TextMesh>().text = "0";
        }

        //親指スティック
        if (_otouch.IsLThumbstickMove) {
            float _LThumbstickRotate = _otouch.LThumbstickRotate;
            _thumbstickL.transform.Rotate(0.0f, -_currentThumbStickRotateL, 0.0f);
            _thumbstickL.transform.Rotate(0.0f, _LThumbstickRotate, 0.0f);
            _currentThumbStickRotateL = _LThumbstickRotate;
            //_console.Log(_LThumbstickRotate.ToString()); //値を出力
            _thumbstickMarkL.SetActive(true);
        } else {
            _thumbstickMarkL.SetActive(false);
        }
        if (_otouch.IsRThumbstickMove) {
            float _RThumbstickRotate = _otouch.RThumbstickRotate;
            _thumbstickR.transform.Rotate(0.0f, -_currentThumbStickRotateR, 0.0f);
            _thumbstickR.transform.Rotate(0.0f, _RThumbstickRotate, 0.0f);
            _currentThumbStickRotateR = _RThumbstickRotate;
            //_console.Log(_RThumbstickRotate.ToString()); //値を出力
            _thumbstickMarkR.SetActive(true);
        } else {
            _thumbstickMarkR.SetActive(false);
        }
    }

    void ForDummy() {
        //OculusTouchL
        _buttonX = _oculusTouchL.transform.Find("ButtonX").gameObject;
        _buttonY = _oculusTouchL.transform.Find("ButtonY").gameObject;
        _buttonStart = _oculusTouchL.transform.Find("ButtonStart").gameObject;
        _indexTriggerL = _oculusTouchL.transform.Find("IndexTriggerL").gameObject;
        _handTriggerL = _oculusTouchL.transform.Find("HandTriggerL").gameObject;
        _thumbstickL = _oculusTouchL.transform.Find("ThumbstickL").gameObject;
        _thumbstickL_Up = _oculusTouchL.transform.Find("ThumbstickL_Up").gameObject;
        _thumbstickL_Down = _oculusTouchL.transform.Find("ThumbstickL_Down").gameObject;
        _thumbstickL_Right = _oculusTouchL.transform.Find("ThumbstickL_Right").gameObject;
        _thumbstickL_Left = _oculusTouchL.transform.Find("ThumbstickL_Left").gameObject;

        //OculusTouchR
        _buttonA = _oculusTouchR.transform.Find("ButtonA").gameObject;
        _buttonB = _oculusTouchR.transform.Find("ButtonB").gameObject;
        _indexTriggerR = _oculusTouchR.transform.Find("IndexTriggerR").gameObject;
        _handTriggerR = _oculusTouchR.transform.Find("HandTriggerR").gameObject;
        _thumbstickR = _oculusTouchR.transform.Find("ThumbstickR").gameObject;
        _thumbstickR_Up = _oculusTouchR.transform.Find("ThumbstickR_Up").gameObject;
        _thumbstickR_Down = _oculusTouchR.transform.Find("ThumbstickR_Down").gameObject;
        _thumbstickR_Right = _oculusTouchR.transform.Find("ThumbstickR_Right").gameObject;
        _thumbstickR_Left = _oculusTouchR.transform.Find("ThumbstickR_Left").gameObject;

        //親指スティックのマーク
        _thumbstickMarkL = _thumbstickL.transform.Find("MarkL").gameObject;
        _thumbstickMarkR = _thumbstickR.transform.Find("MarkR").gameObject;

        //トリガー用テキスト
        _textIndexTriggerL = _oculusTouchL.transform.Find("IndexTriggerLtext").gameObject;
        _textHandTriggerL = _oculusTouchL.transform.Find("HandTriggerLtext").gameObject;
        _textIndexTriggerR = _oculusTouchR.transform.Find("IndexTriggerRtext").gameObject;
        _textHandTriggerR = _oculusTouchR.transform.Find("HandTriggerRtext").gameObject;
    }

    private void AllObjectClear() { //選択オブジェクトの色を通常に戻す
        List<GameObject> _targetObjects = _otouch.TargetObjects;
        foreach (GameObject _tmp in _targetObjects) {
            _tmp.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
    }
}