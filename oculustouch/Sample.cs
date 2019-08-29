//Main.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; //for Math

public class Main : MonoBehaviour {
    private GameObject _oculusTouchL;
    private GameObject _oculusTouchR;
    private OculusTouch _oculusTouch;
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
        _oculusTouch = GetComponent<OculusTouch>();
        _oculusTouch.L = _oculusTouchL; //OculusTouchの右用のGameObject
        _oculusTouch.R = _oculusTouchR; //OculusTouchの左用のGameObject

        //=========================
        // イベントハンドラの登録
        //=========================
        //人差し指トリガー（Down、Up）
        _oculusTouch.LIndexTriggerDown += LIndexTriggerDownHandler;
        _oculusTouch.LIndexTriggerUp += LIndexTriggerUpHandler;
        _oculusTouch.RIndexTriggerDown += RIndexTriggerDownHandler;
        _oculusTouch.RIndexTriggerUp += RIndexTriggerUpHandler;
        //人差し指トリガー（RawTouch）

        //中指トリガー
        _oculusTouch.LHandTriggerDown += LHandTriggerDownHandler;
        _oculusTouch.LHandTriggerUp += LHandTriggerUpHandler;
        _oculusTouch.RHandTriggerDown += RHandTriggerDownHandler;
        _oculusTouch.RHandTriggerUp += RHandTriggerUpHandler;
        //Aボタン
        _oculusTouch.ADown += ADownHandler;
        _oculusTouch.AUp += AUpHandler;
        //Bボタン
        _oculusTouch.BDown += BDownHandler;
        _oculusTouch.BUp += BUpHandler;
        //Xボタン
        _oculusTouch.XDown += XDownHandler;
        _oculusTouch.XUp += XUpHandler;
        //Yボタン
        _oculusTouch.YDown += YDownHandler;
        _oculusTouch.YUp += YUpHandler;
        //Startボタン
        _oculusTouch.StartDown += StartDownHandler;
        _oculusTouch.StartUp += StartUpHandler;
        //親指スティック
        _oculusTouch.LThumbstickDown += LThumbstickDownHandler;
        _oculusTouch.LThumbstickUp += LThumbstickUpHandler;
        _oculusTouch.RThumbstickDown += RThumbstickDownHandler;
        _oculusTouch.RThumbstickUp += RThumbstickUpHandler;
        //親指スティック上下左右（Down）
        _oculusTouch.LThumbstickUpDown += LThumbstickUpDownHandler;
        _oculusTouch.LThumbstickDownDown += LThumbstickDownDownHandler;
        _oculusTouch.LThumbstickLeftDown += LThumbstickLeftDownHandler;
        _oculusTouch.LThumbstickRightDown += LThumbstickRightDownHandler;
        _oculusTouch.RThumbstickUpDown += RThumbstickUpDownHandler;
        _oculusTouch.RThumbstickDownDown += RThumbstickDownDownHandler;
        _oculusTouch.RThumbstickLeftDown += RThumbstickLeftDownHandler;
        _oculusTouch.RThumbstickRightDown += RThumbstickRightDownHandler;
        //親指スティック上下左右（Up）
        _oculusTouch.LThumbstickUpUp += LThumbstickUpUpHandler;
        _oculusTouch.LThumbstickDownUp += LThumbstickDownUpHandler;
        _oculusTouch.LThumbstickLeftUp += LThumbstickLeftUpHandler;
        _oculusTouch.LThumbstickRightUp += LThumbstickRightUpHandler;
        _oculusTouch.RThumbstickUpUp += RThumbstickUpUpHandler;
        _oculusTouch.RThumbstickDownUp += RThumbstickDownUpHandler;
        _oculusTouch.RThumbstickLeftUp += RThumbstickLeftUpHandler;
        _oculusTouch.RThumbstickRightUp += RThumbstickRightUpHandler;
        //タッチ（RawTouch）
        _oculusTouch.LIndexTriggerRawTouch += LIndexTriggerRawTouchHandler;
        _oculusTouch.RIndexTriggerRawTouch += RIndexTriggerRawTouchHandler;
        _oculusTouch.LThumbstickRawTouch += LThumbstickRawTouchHandler;
        _oculusTouch.RThumbstickRawTouch += RThumbstickRawTouchHandler;
        _oculusTouch.ARawTouch += ARawTouchHandler;
        _oculusTouch.BRawTouch += BRawTouchHandler;
        _oculusTouch.XRawTouch += XRawTouchHandler;
        _oculusTouch.YRawTouch += YRawTouchHandler;
        //近接（RawNearTouch）
        _oculusTouch.LIndexTriggerRawNearTouch += LIndexTriggerRawNearTouchHandler;
        _oculusTouch.RIndexTriggerRawNearTouch += RIndexTriggerRawNearTouchHandler;

        //選択オブジェクト
        GameObject _cube1 = GameObject.Find("Cube1");
        GameObject _cube2 = GameObject.Find("Cube2");
        GameObject _cube3 = GameObject.Find("Cube3");
        _oculusTouch.AddTargetObjects(_cube1);
        _oculusTouch.AddTargetObjects(_cube2);
        _oculusTouch.AddTargetObjects(_cube3);
        //Debug.Log(_oculusTouch.TargetObjects);

        //オブジェクト選択
        _oculusTouch.LLaserOver += LLaserOverHandler;
        _oculusTouch.RLaserOver += RLaserOverHandler;
        _oculusTouch.LLaserOut += LLaserOutHandler;
        _oculusTouch.RLaserOut += RLaserOutHandler;
        _oculusTouch.LLaserDown += LLaserDownHandler;
        _oculusTouch.RLaserDown += RLaserDownHandler;

        //レーザーの有効化（初期値は無効）
        _oculusTouch.EnabledLaserL = true;
        _oculusTouch.EnabledLaserR = true;

        //コンソールの参照（冗長すぎね？）
        _console = _oculusTouch.L.transform.Find("Console").gameObject.GetComponent<Console>();
        //_console = GameObject.Find("Console").gameObject.GetComponent<Console>();
    }

    //=========================
    // イベントハンドラ
    //=========================
    //人差し指トリガー
    private void LIndexTriggerDownHandler() {
        _console.Log("左人差し指トリガー↓");
        _indexTriggerL.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
    }
    private void LIndexTriggerUpHandler() {
        _console.Log("左人差し指トリガー↑");
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
    }
    private void RLaserOverHandler(GameObject arg) {
        _console.Log("右レーザーが" + arg.name + "にヒット");
    }
    private void LLaserOutHandler(GameObject arg) {
        _console.Log("左レーザーが" + arg.name + "をアウト");
    }
    private void RLaserOutHandler(GameObject arg) {
        _console.Log("右レーザーが" + arg.name + "をアウト");
    }
    private void LLaserDownHandler(GameObject arg) {
        _console.Log("左レーザーが" + arg.name + "を↓");
    }
    private void RLaserDownHandler(GameObject arg) {
        _console.Log("右レーザーが" + arg.name + "を↓");
    }

    void Update() {
        //人差し指トリガー
        if (_oculusTouch.IsLIndexTriggerDown) {
            _console.Log(_oculusTouch.LIndexTrigger.ToString());
            _textIndexTriggerL.GetComponent<TextMesh>().text = Math.Round((OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger)*100)).ToString(); //テキストに表示
        } else {
            _textIndexTriggerL.GetComponent<TextMesh>().text = "0";
        }
        if (_oculusTouch.IsRIndexTriggerDown) {
            _console.Log(_oculusTouch.RIndexTrigger.ToString());
            _textIndexTriggerR.GetComponent<TextMesh>().text = Math.Round((OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger)*100)).ToString(); //テキストに表示
        } else {
            _textIndexTriggerR.GetComponent<TextMesh>().text = "0";
        }
        //中指トリガー
        if (_oculusTouch.IsLHandTriggerDown) {
            _console.Log(_oculusTouch.LHandTrigger.ToString());
            _textHandTriggerL.GetComponent<TextMesh>().text = Math.Round((OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger)*100)).ToString(); //テキスト表示
        } else {
            _textHandTriggerL.GetComponent<TextMesh>().text = "0";
        }
        if (_oculusTouch.IsRHandTriggerDown) {
            _console.Log(_oculusTouch.RHandTrigger.ToString());
            _textHandTriggerR.GetComponent<TextMesh>().text = Math.Round((OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger)*100)).ToString(); //テキスト表示
        } else {
            _textHandTriggerR.GetComponent<TextMesh>().text = "0";
        }

        //親指スティック
        if (_oculusTouch.IsLThumbstickMove) {
            float _LThumbstickRotate = _oculusTouch.LThumbstickRotate;
            _thumbstickL.transform.Rotate(0.0f, -_currentThumbStickRotateL, 0.0f);
            _thumbstickL.transform.Rotate(0.0f, _LThumbstickRotate, 0.0f);
            _currentThumbStickRotateL = _LThumbstickRotate;
            _console.Log(_LThumbstickRotate.ToString()); //Console
            _thumbstickMarkL.SetActive(true);
        } else {
            _thumbstickMarkL.SetActive(false);
        }
        if (_oculusTouch.IsRThumbstickMove) {
            float _RThumbstickRotate = _oculusTouch.RThumbstickRotate;
            _thumbstickR.transform.Rotate(0.0f, -_currentThumbStickRotateR, 0.0f);
            _thumbstickR.transform.Rotate(0.0f, _RThumbstickRotate, 0.0f);
            _currentThumbStickRotateR = _RThumbstickRotate;
            _console.Log(_RThumbstickRotate.ToString()); //Console
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
}