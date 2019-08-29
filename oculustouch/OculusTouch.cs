/***************************************************************************
 * OculusTouch.cs (ver.2019-08-29T15:04)
 * © 2019 夢寐郎
 ***************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; //Mathに必要

/******************************************************************************
 * OculusTouch Class
 *  <Public Method>
 *      AddTargetObjects(GameObject)
 *      RemoveTargetObjects(GameObject)
 *
 *  <Public Property>
 *      IsLHandTriggerDown（Read Only）
 *      IsLIndexTriggerDown（Read Only）
 *      IsRHandTriggerDown（Read Only）
 *      IsRIndexTriggerDown（Read Only）
 *      L
 *      LHandTrigger（Read Only）
 *      LIndexTrigger（Read Only）
 *      LThumbstickRotate（Read Only）
 *      R
 *      RHandTrigger（Read Only）
 *      RIndexTrigger（Read Only）
 *      RThumbstickRotate（Read Only）
 *      TargetObjects
 *
 *  <Event>
 *      ADown
 *      ARawTouch
 *      AUp
 *      BDown
 *      BRawTouch
 *      BUp
 *      LHandTriggerDown
 *      LHandTriggerUp
 *      LIndexTriggerDown
 *      LIndexTriggerRawNearTouch
 *      LIndexTriggerRawTouch
 *      LIndexTriggerUp
 *      LLaserDown //<-----NEW
 *      LLaserOut //<-----NEW
 *      LLaserOver //<-----NEW
 *      LLaserUp //<-----NEW
 *      LLsserUpOutside //<-----NEW
 *      LThumbstickDown
 *      LThumbstickDownDown
 *      LThumbstickDownUp
 *      LThumbstickLeftDown
 *      LThumbstickLeftUp
 *      LThumbstickRawTouch
 *      LThumbstickRightDown
 *      LThumbstickRightUp
 *      LThumbstickUp
 *      LThumbstickUpUp
 *      LThumbstickUpDown
 *      RHandTriggerDown
 *      RHandTriggerUp
 *      RIndexTriggerDown
 *      RIndexTriggerRawNearTouch
 *      RIndexTriggerRawTouch
 *      RIndexTriggerUp
 *      RLaserDown //<-----NEW
 *      RLaserOut //<-----NEW
 *      RLaserOver //<-----NEW
 *      RLaserUp //<-----NEW
 *      RLsserUpOutside //<-----NEW
 *      RThumbstickDown
 *      RThumbstickDownDown
 *      RThumbstickDownUp
 *      RThumbstickLeftDown
 *      RThumbstickLeftUp
 *      RThumbstickRawTouch
 *      RThumbstickRightDown
 *      RThumbstickRightUp
 *      RThumbstickUp
 *      RThumbstickUpUp
 *      RThumbstickUpDown
 *      StartDown
 *      StartUp
 *      XDown
 *      XRawTouch
 *      XUp
 *      YDown
 *      YRawTouch
 *      YUp
 *
 *****************************************************************************/
 
public class OculusTouch : MonoBehaviour {
    private GameObject _oculusTouchL = null;
    private GameObject _oculusTouchR = null;
    private GameObject _leftHandAnchor;
    private GameObject _rightHandAnchor;
    private bool _isLIndexTriggerDown = false; //左人差し指トリガー
    private bool _isRIndexTriggerDown = false; //右人差し指トリガー
    private bool _isLHandTriggerDown = false; //左中指トリガー
    private bool _isRHandTriggerDown = false; //右中指トリガー
    
    //親指スティック上下左右（↓）しているか
    private bool _isLThumbstickUpDown = false;
    private bool _isLThumbstickDownDown = false;
    private bool _isLThumbstickLeftDown = false;
    private bool _isLThumbstickRightDown = false;
    private bool _isRThumbstickUpDown = false;
    private bool _isRThumbstickDownDown = false;
    private bool _isRThumbstickLeftDown = false;
    private bool _isRThumbstickRightDown = false;

    //レーザーを表示するか否か
    private bool _enabledLaserL = false;
    private bool _enabledLaserR = false;
    //レーザーポインタ用
    private LineRenderer _lineRendererL = null;
    private LineRenderer _lineRendererR = null;

    //アクティブなコントローラ
    private string _activeController = "right";
    //バイブレーション
    private bool _isVibrationL = false;
    private bool _isVibrationR = false;

    //レーザーポインタが反応するGameObjectのリスト
    private List<GameObject> _targetObjects = new List<GameObject>();

    //①デリゲート宣言
    public delegate void BodyDelegate(); //OculusTouch本体ボタン用
    public delegate void LaserDelegate(GameObject arg); //レーザーポイント用

    //===================================================
    // イベントハンドラを格納するデリゲート（現在48個）
    //===================================================
    //人差し指トリガー（Down、Up）
    public event BodyDelegate LIndexTriggerDown;
    public event BodyDelegate LIndexTriggerUp;
    public event BodyDelegate RIndexTriggerDown;
    public event BodyDelegate RIndexTriggerUp;
    //中指トリガー
    public event BodyDelegate LHandTriggerDown;
    public event BodyDelegate LHandTriggerUp;
    public event BodyDelegate RHandTriggerDown;
    public event BodyDelegate RHandTriggerUp;
    //Aボタン
    public event BodyDelegate ADown;
    public event BodyDelegate AUp;
    //Bボタン
    public event BodyDelegate BDown;
    public event BodyDelegate BUp;
    //Xボタン
    public event BodyDelegate XDown;
    public event BodyDelegate XUp;
    //Yボタン
    public event BodyDelegate YDown;
    public event BodyDelegate YUp;
    //Startボタン
    public event BodyDelegate StartDown;
    public event BodyDelegate StartUp;
    //親指スティック
    public event BodyDelegate LThumbstickDown;
    public event BodyDelegate LThumbstickUp;
    public event BodyDelegate RThumbstickDown;
    public event BodyDelegate RThumbstickUp;
    //親指スティック上下左右（↓）
    public event BodyDelegate LThumbstickUpDown;
    public event BodyDelegate LThumbstickDownDown;
    public event BodyDelegate LThumbstickLeftDown;
    public event BodyDelegate LThumbstickRightDown;
    public event BodyDelegate RThumbstickUpDown;
    public event BodyDelegate RThumbstickDownDown;
    public event BodyDelegate RThumbstickLeftDown;
    public event BodyDelegate RThumbstickRightDown;
    //親指スティック上下左右（↑）
    public event BodyDelegate LThumbstickUpUp;
    public event BodyDelegate LThumbstickDownUp;
    public event BodyDelegate LThumbstickLeftUp;
    public event BodyDelegate LThumbstickRightUp;
    public event BodyDelegate RThumbstickUpUp;
    public event BodyDelegate RThumbstickDownUp;
    public event BodyDelegate RThumbstickLeftUp;
    public event BodyDelegate RThumbstickRightUp;
    //タッチ（RawTouch）
    public event BodyDelegate LIndexTriggerRawTouch;
    public event BodyDelegate RIndexTriggerRawTouch;
    public event BodyDelegate LThumbstickRawTouch;
    public event BodyDelegate RThumbstickRawTouch;
    public event BodyDelegate ARawTouch;
    public event BodyDelegate BRawTouch;
    public event BodyDelegate XRawTouch;
    public event BodyDelegate YRawTouch;
    //近接（RawNearTouch）
    public event BodyDelegate LIndexTriggerRawNearTouch;
    public event BodyDelegate RIndexTriggerRawNearTouch;

    //オブジェクト選択
    public event LaserDelegate LLaserDown; //<-----NEW
    public event LaserDelegate LLaserOut; //<-----NEW
    public event LaserDelegate LLaserOver; //<-----NEW
    public event LaserDelegate LLaserUp; //<-----NEW
    public event LaserDelegate LLsserUpOutside; //<-----NEW
    public event LaserDelegate RLaserDown; //<-----NEW
    public event LaserDelegate RLaserOut; //<-----NEW
    public event LaserDelegate RLaserOver; //<-----NEW
    public event LaserDelegate RLaserUp; //<-----NEW
    public event LaserDelegate RLsserUpOutside; //<-----NEW

    //ヒットしたオブジェクト
    private GameObject _hitObjectL = null;
    private GameObject _hitObjectR = null;
    
    void Start() {
        GameObject _ovrCameraRig = GameObject.Find("OVRCameraRig");
        GameObject _trackingSpace = _ovrCameraRig.transform.Find("TrackingSpace").gameObject;
        _leftHandAnchor = _trackingSpace.transform.Find("LeftHandAnchor").gameObject;
        _rightHandAnchor = _trackingSpace.transform.Find("RightHandAnchor").gameObject;

        //コントローラーのレーザーポイントを表示する
        _lineRendererL = _oculusTouchL.GetComponent<LineRenderer>();
        _lineRendererL.enabled = true;
        _lineRendererL.startWidth = _lineRendererL.endWidth = 0.0005f;
        _lineRendererR = _oculusTouchR.GetComponent<LineRenderer>();
        _lineRendererR.enabled = true;
        _lineRendererR.startWidth = _lineRendererR.endWidth = 0.007f;
    }

    /*****************************************************************************
     * OculucTouch.Update()
     *****************************************************************************/
    void Update() {
        //位置
        Vector3 _oculusTouchPosL = _leftHandAnchor.transform.position;
        Vector3 _oculusTouchPosR = _rightHandAnchor.transform.position;
        _oculusTouchL.transform.position = _oculusTouchPosL;
        _oculusTouchR.transform.position = _oculusTouchPosR;

        //角度
        Quaternion _oculusTouchRotationL = _leftHandAnchor.transform.rotation;
        Quaternion _oculusTouchRotationR = _rightHandAnchor.transform.rotation;
        _oculusTouchL.transform.rotation = _oculusTouchRotationL;
        _oculusTouchR.transform.rotation = _oculusTouchRotationR;

        //===========================
        // イベントハンドラの呼出し
        //===========================
        //人差し指トリガー
        if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger)) {
            LIndexTriggerDown();
            if (_hitObjectL != null) LLaserDown(_hitObjectL); //イベント発生
            _isLIndexTriggerDown = true;
            _activeController = "left";
            _lineRendererL.startWidth = _lineRendererL.endWidth = 0.007f;
            _lineRendererR.startWidth = _lineRendererR.endWidth = 0.001f;
        }
        if (OVRInput.GetUp(OVRInput.RawButton.LIndexTrigger)) {
            LIndexTriggerUp();
            _isLIndexTriggerDown = false;
        }
        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger)) {
            RIndexTriggerDown();
            if (_hitObjectR != null) RLaserDown(_hitObjectR); //イベント発生
            _isRIndexTriggerDown = true;
            _activeController = "right";
            _lineRendererL.startWidth = _lineRendererL.endWidth = 0.001f;
            _lineRendererR.startWidth = _lineRendererR.endWidth = 0.007f;
        }
        if (OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger)) {
            RIndexTriggerUp();
            _isRIndexTriggerDown = false;
        }
        //中指トリガー
        if (OVRInput.GetDown(OVRInput.RawButton.LHandTrigger)) {
            LHandTriggerDown();
            _isLHandTriggerDown = true;
        }
        if (OVRInput.GetUp(OVRInput.RawButton.LHandTrigger)) {
            LHandTriggerUp();
            _isLHandTriggerDown = false;
        }
        if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger)) {
            RHandTriggerDown();
            _isRHandTriggerDown = true;
        }
        if (OVRInput.GetUp(OVRInput.RawButton.RHandTrigger)) {
            RHandTriggerUp();
            _isRHandTriggerDown = false;
        }
        //Aボタン
        if (OVRInput.GetDown(OVRInput.RawButton.A)) ADown();
        if (OVRInput.GetUp(OVRInput.RawButton.A)) AUp();
        //Bボタン
        if (OVRInput.GetDown(OVRInput.RawButton.B)) BDown();
        if (OVRInput.GetUp(OVRInput.RawButton.B)) BUp();
        //Xボタン
        if (OVRInput.GetDown(OVRInput.RawButton.X)) XDown();
        if (OVRInput.GetUp(OVRInput.RawButton.X)) XUp();
        //Yボタン
        if (OVRInput.GetDown(OVRInput.RawButton.Y)) YDown();
        if (OVRInput.GetUp(OVRInput.RawButton.Y)) YUp();
        //Startボタン
        if (OVRInput.GetDown(OVRInput.RawButton.Start)) StartDown();
        if (OVRInput.GetUp(OVRInput.RawButton.Start)) StartUp();
        //親指スティック
        if (OVRInput.GetDown(OVRInput.RawButton.LThumbstick)) LThumbstickDown();
        if (OVRInput.GetUp(OVRInput.RawButton.LThumbstick)) LThumbstickUp();
        if (OVRInput.GetDown(OVRInput.RawButton.RThumbstick)) RThumbstickDown();
        if (OVRInput.GetUp(OVRInput.RawButton.RThumbstick)) RThumbstickUp();
        //親指スティック上下左右（↓）
        if (OVRInput.GetDown(OVRInput.RawButton.LThumbstickUp)) {
            LThumbstickUpDown();
            _isLThumbstickUpDown = true;
        }
        if (OVRInput.GetDown(OVRInput.RawButton.LThumbstickDown)) {
            LThumbstickDownDown();
            _isLThumbstickDownDown = true;
        }
        if (OVRInput.GetDown(OVRInput.RawButton.LThumbstickLeft)) {
            LThumbstickLeftDown();
            _isLThumbstickLeftDown = true;
        }
        if (OVRInput.GetDown(OVRInput.RawButton.LThumbstickRight)) {
            LThumbstickRightDown();
            _isLThumbstickRightDown = true;
        }
        if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickUp)) {
            RThumbstickUpDown();
            _isRThumbstickUpDown = true;
        }
        if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickDown)) {
            RThumbstickDownDown();
            _isRThumbstickDownDown = true;
        }
        if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickLeft)) {
            RThumbstickLeftDown();
            _isRThumbstickLeftDown = true;
        }
        if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickRight)) {
            RThumbstickRightDown();
            _isRThumbstickRightDown = true;
        }
        //親指スティック上下左右（↑）
        if (OVRInput.GetUp(OVRInput.RawButton.LThumbstickUp)) {
            LThumbstickUpUp();
            _isLThumbstickUpDown = false;
        }
        if (OVRInput.GetUp(OVRInput.RawButton.LThumbstickDown)) {
            LThumbstickDownUp();
            _isLThumbstickDownDown = false;
        }
        if (OVRInput.GetUp(OVRInput.RawButton.LThumbstickLeft)) {
            LThumbstickLeftUp();
            _isLThumbstickLeftDown = false;
        }
        if (OVRInput.GetUp(OVRInput.RawButton.LThumbstickRight)) {
            LThumbstickRightUp();
            _isLThumbstickRightDown = false;
        }
        if (OVRInput.GetUp(OVRInput.RawButton.RThumbstickUp)) {
            RThumbstickUpUp();
            _isRThumbstickUpDown = false;
        }
        if (OVRInput.GetUp(OVRInput.RawButton.RThumbstickDown)) {
            RThumbstickDownUp();
            _isRThumbstickDownDown = false;
        }
        if (OVRInput.GetUp(OVRInput.RawButton.RThumbstickLeft)) {
            RThumbstickLeftUp();
            _isRThumbstickLeftDown = false;
        }
        if (OVRInput.GetUp(OVRInput.RawButton.RThumbstickRight)) {
            RThumbstickRightUp();
            _isRThumbstickRightDown = false;
        }
        //タッチ（RawTouch）
        if (OVRInput.GetDown(OVRInput.RawTouch.LIndexTrigger)) LIndexTriggerRawTouch();
        if (OVRInput.GetDown(OVRInput.RawTouch.RIndexTrigger)) RIndexTriggerRawTouch();
        if (OVRInput.GetDown(OVRInput.RawTouch.LThumbstick)) LThumbstickRawTouch();
        if (OVRInput.GetDown(OVRInput.RawTouch.RThumbstick)) RThumbstickRawTouch();
        if (OVRInput.GetDown(OVRInput.RawTouch.A)) ARawTouch();
        if (OVRInput.GetDown(OVRInput.RawTouch.B)) BRawTouch();
        if (OVRInput.GetDown(OVRInput.RawTouch.X)) XRawTouch();
        if (OVRInput.GetDown(OVRInput.RawTouch.Y)) YRawTouch();
        //近接（RawNearTouch）
        if (OVRInput.GetDown(OVRInput.RawNearTouch.LIndexTrigger)) LIndexTriggerRawNearTouch();
        if (OVRInput.GetDown(OVRInput.RawNearTouch.RIndexTrigger)) RIndexTriggerRawNearTouch();

        //===========================================================
        //レーザー（左）表示
        //===========================================================
        if (_enabledLaserL) {
            Ray _rayL = new Ray(_oculusTouchL.transform.position, _oculusTouchL.transform.forward);
            _lineRendererL.SetPosition(0, _rayL.origin);
            _lineRendererL.SetPosition(1, _rayL.origin + _rayL.direction * 500.0f);
            //オブジェクトにヒット
            RaycastHit _hitInfoL = new RaycastHit(); //構造体
            if (Physics.Raycast(_rayL, out _hitInfoL, 500.0f)) {
                //ヒットしたらレーザをそこまでで止める
                _lineRendererL.SetPosition(1, _hitInfoL.point);
                if (_activeController == "left") { //非アクティブの場合振動なし
                    _hitObjectL = _hitInfoL.collider.gameObject; //ヒットしたGameObject
                    foreach (GameObject _tmp in _targetObjects) {
                        //ヒットしたGameObjectが登録済オブジェクトであれば
                        if (_tmp == _hitObjectL) {
                            if (!_isVibrationL) {
                                LLaserOver(_hitObjectL); //イベント発生
                                //振動させる（周波数0〜1.0f,振幅0〜1.0f）
                                OVRInput.SetControllerVibration(1.0f, 0.2f, OVRInput.Controller.LTouch);
                                //0.05秒後に "StopVibration()" を実行
                                Invoke("StopVibrationL", 0.05f); 
                                _isVibrationL = true;
                            }
                        }
                    }
                }
            } else { //選択オブジェクトの領域を外した時
                _isVibrationL = false;
                LLaserOut(_hitObjectL); //イベント発生
                _hitObjectL = null;
            }
        }

        //===========================================================
        //レーザー（右）表示
        //===========================================================
        if (_enabledLaserR) {
            Ray _rayR = new Ray(_oculusTouchR.transform.position, _oculusTouchR.transform.forward);
            _lineRendererR.SetPosition(0, _rayR.origin);
            _lineRendererR.SetPosition(1, _rayR.origin + _rayR.direction * 500.0f);
            //オブジェクトにヒット
            RaycastHit _hitInfoR = new RaycastHit(); //構造体
            if (Physics.Raycast(_rayR, out _hitInfoR, 500.0f)) {
                //ヒットしたらレーザをそこまでで止める
                _lineRendererR.SetPosition(1, _hitInfoR.point);
                if (_activeController == "right") { //非アクティブの場合振動なし
                    _hitObjectR = _hitInfoR.collider.gameObject; //ヒットしたGameObject
                    foreach (GameObject _tmp in _targetObjects) {
                        //ヒットしたGameObjectが登録済オブジェクトであれば
                        if (_tmp == _hitObjectR) {
                            if (!_isVibrationR) {
                                RLaserOver(_hitObjectR); //イベント発生
                                //振動させる（周波数0〜1.0f,振幅0〜1.0f）
                                OVRInput.SetControllerVibration(1.0f, 0.2f, OVRInput.Controller.RTouch);
                                //0.05秒後に "StopVibration()" を実行
                                Invoke("StopVibrationR", 0.05f); 
                                _isVibrationR = true;
                            }
                        }
                    }
                }
            } else { //選択オブジェクトの領域を外した時
                _isVibrationR = false;
                RLaserOut(_hitObjectR); //イベント発生
                _hitObjectR = null;
            }
        }
    }

    //=====================================
    // Private Method
    //=====================================
    private void StopVibrationL() {
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch); //END
    }
    private void StopVibrationR() {
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch); //END
    }

    //=====================================
    // Public Method
    //=====================================
    public List<GameObject> AddTargetObjects(GameObject arg) {
        if (_targetObjects.IndexOf(arg) == -1) { //複数登録の回避
            _targetObjects.Add(arg);
        }
        return _targetObjects;
    }
    public List<GameObject> RemoveTargetObjects(GameObject arg) {
        _targetObjects.Add(arg);
        return _targetObjects;
    }

    //=====================================
    // Public Variables
    //=====================================
    public GameObject L {
        get { return _oculusTouchL; }
        set { _oculusTouchL = value; }
    }
    public GameObject R {
        get { return _oculusTouchR; }
        set { _oculusTouchR = value; }
    }
    public double LIndexTrigger {
        get { return OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger); }
        private set {} //Read Only
    }
    public double RIndexTrigger {
        get { return OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger); }
        private set {} //Read Only
    }
    public double LHandTrigger {
        get { return OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger); }
        private set {} //Read Only
    }
    public double RHandTrigger {
        get { return OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger); }
        private set {} //Read Only
    }
    public bool IsLIndexTriggerDown {
        get { return _isLIndexTriggerDown; }
        private set {} //Read Only
    }
    public bool IsRIndexTriggerDown {
        get { return _isRIndexTriggerDown; }
        private set {} //Read Only
    }
    public bool IsLHandTriggerDown {
        get { return _isLHandTriggerDown; }
        private set {} //Read Only
    }
    public bool IsRHandTriggerDown {
        get { return _isRHandTriggerDown; }
        private set {} //Read Only
    }

    //親指スティックを動かしているか
    public bool IsLThumbstickMove {
        get {
            if (_isLThumbstickUpDown) {
                return true;
            } else if (_isLThumbstickDownDown) {
                return true;
            } else if (_isLThumbstickLeftDown) {
                return true;
            } else if (_isLThumbstickRightDown) {
                return true;
            } else {
                return false;
            }
        }
        private set {} //Read Only
    }
    public bool IsRThumbstickMove {
        get {
            if (_isRThumbstickUpDown) {
                return true;
            } else if (_isRThumbstickDownDown) {
                return true;
            } else if (_isRThumbstickLeftDown) {
                return true;
            } else if (_isRThumbstickRightDown) {
                return true;
            } else {
                return false;
            }
        }
        private set {} //Read Only
    }

    //親指スティックの角度
    public float LThumbstickRotate {
        get {
            Vector2 _vectorLThumbstick = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);
            double _radianLThumbstick = Math.Atan2(_vectorLThumbstick.y, _vectorLThumbstick.x);
            double _kakudoLThumbstick = - _radianLThumbstick * Mathf.Rad2Deg; //孤度法→度数法に変換
            return (float)_kakudoLThumbstick;
        }
        private set {} //Read Only
    }
    public float RThumbstickRotate {
        get {
            Vector2 _vectorRThumbstick = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick);
            double _radianRThumbstick = Math.Atan2(_vectorRThumbstick.y, _vectorRThumbstick.x);
            double _kakudoRThumbstick = - _radianRThumbstick * Mathf.Rad2Deg; //孤度法→度数法に変換
            return (float)_kakudoRThumbstick;
        }
        private set {} //Read Only
    }

    //レーザーを表示するか
    public bool EnabledLaserL {
        get { return _enabledLaserL; }
        set { _enabledLaserL = value; }
    }
    public bool EnabledLaserR {
        get { return _enabledLaserR; }
        set { _enabledLaserR = value; }
    }

    //レーザーポインタが反応するGameObjectのリスト
    public List<GameObject> TargetObjects {
        get { return _targetObjects; }
        set { _targetObjects = value; }
    }
}