/***************************************************************************
 * OTouch Alpha1.201909242219 with Bug
 * © 2019 夢寐郎
 ***************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; //for Math

/******************************************************************************
 * OTouch Class
 *  <Public Method>
 *      AddTargetObjects(GameObject)
 *      RemoveTargetObjects(GameObject)
 *
 *  <Public Property>
 *      IsLHandTriggerDown（Read Only）
 *      IsLIndexTriggerDown（Read Only）
 *      IsLThumbstickMove（Read Only）
 *      IsRHandTriggerDown（Read Only）
 *      IsRIndexTriggerDown（Read Only）
 *      IsRThumbstickMove（Read Only）
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
 *      LLaserDown
 *      LLaserOut
 *      LLaserOver
 *      LLaserUp
 *      LLsserUpOutside
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
 *      RLaserDown
 *      RLaserOut
 *      RLaserOver
 *      RLaserUp
 *      RLsserUpOutside
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
 
public class OTouch : MonoBehaviour {
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
    public List<GameObject> _targetObjects = new List<GameObject>(); //本来はprivate

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
    public event LaserDelegate LLaserDown;
    public event LaserDelegate LLaserOut;
    public event LaserDelegate LLaserOver;
    public event LaserDelegate LLaserUp;
    public event LaserDelegate LLaserUpOutside;
    public event LaserDelegate RLaserDown;
    public event LaserDelegate RLaserOut;
    public event LaserDelegate RLaserOver;
    public event LaserDelegate RLaserUp;
    public event LaserDelegate RLaserUpOutside;

    //ヒットしたオブジェクト（レーザーがヒットしたオブジェクト）
    private GameObject _hitObjectL = null;
    private GameObject _hitObjectR = null;

    //レーザーで選択した（LaserMouseDown）したオブジェクト
    private GameObject _selectObjectL = null; //NEW
    private GameObject _selectObjectR = null; //NEW

    //レーザービーム用
    private Ray _rayL;
    private Ray _rayR;
    private RaycastHit _hitInfoL;
    private RaycastHit _hitInfoR;
    private float _lineWidth1 = 0.007f;
    private float _lineWidth2 = 0.0005f;
    //private bool _isLLaserDown = false;
    //private bool _isRLaserDown = false;
    
    void Start() {
        GameObject _ovrCameraRig = GameObject.Find("OVRCameraRig");
        GameObject _trackingSpace = _ovrCameraRig.transform.Find("TrackingSpace").gameObject;
        _leftHandAnchor = _trackingSpace.transform.Find("LeftHandAnchor").gameObject;
        _rightHandAnchor = _trackingSpace.transform.Find("RightHandAnchor").gameObject;
    }

    /*****************************************************************************
     * OculucTouch.Update()
     *****************************************************************************/
    void Update() {
        if (_oculusTouchL != null) { //左側
            //位置
            Vector3 _oculusTouchPosL = _leftHandAnchor.transform.position;
            _oculusTouchL.transform.position = _oculusTouchPosL;
            //角度
            Quaternion _oculusTouchRotationL = _leftHandAnchor.transform.rotation;
            _oculusTouchL.transform.rotation = _oculusTouchRotationL;
        }
        if (_oculusTouchR != null) { //右側
            //位置
            Vector3 _oculusTouchPosR = _rightHandAnchor.transform.position;
            _oculusTouchR.transform.position = _oculusTouchPosR;
            //角度
            Quaternion _oculusTouchRotationR = _rightHandAnchor.transform.rotation;
            _oculusTouchR.transform.rotation = _oculusTouchRotationR;
        }

        //===========================
        // イベントハンドラの呼出し
        //===========================
        //人差し指トリガー（Down）
        if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger)) {
            _isLIndexTriggerDown = true;
            _activeController = "left";
            if (_enabledLaserL) { //レーザービームを表示している場合
                if (_lineRendererR != null) { //Rを表示中の時
                    _lineRendererL.startWidth = _lineRendererL.endWidth = _lineWidth1;
                    _lineRendererR.startWidth = _lineRendererR.endWidth = _lineWidth2;
                }
                //_isRLaserDown = false; //逆（右）のレーザーの≒MouseDownを解除
                _hitObjectL = HitTestL(true); //ヒットテスト
                if (_hitObjectL != null) {
                    if (IsTargetObject(_hitObjectL)) {
                        LLaserDown(_hitObjectL); //イベント発生
                        _selectObjectL = _hitObjectL; //選択したオブジェクトを記録 NEW
                    }
                    //_isLLaserDown = true;
                }
            }
            LIndexTriggerDown(); //if文の後ろ?
        }
        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger)) {
            _isRIndexTriggerDown = true;
            _activeController = "right";
            if (_enabledLaserR) { //レーザービームを表示している場合
                if (_lineRendererL != null) { //Lを表示中の時
                    _lineRendererL.startWidth = _lineRendererL.endWidth = _lineWidth2;
                    _lineRendererR.startWidth = _lineRendererR.endWidth = _lineWidth1;
                }
                //_isLLaserDown = false; //逆（右）のレーザーの≒MouseDownを解除
                _hitObjectR = HitTestR(true); //ヒットテスト
                if (_hitObjectR != null) {
                    if (IsTargetObject(_hitObjectR)) {
                        RLaserDown(_hitObjectR); //イベント発生
                        _selectObjectR = _hitObjectR; //選択したオブジェクトを記録 NEW
                    }
                    //_isRLaserDown = true;
                }
            }
            RIndexTriggerDown(); //if文の後ろ?
        }
        //人差し指トリガー（Up）
        if (OVRInput.GetUp(OVRInput.RawButton.LIndexTrigger)) {
            _isLIndexTriggerDown = false;
            LIndexTriggerUp();
            if (HitTestL(false) == _selectObjectL) { //ヒットテスト NEW
                if (IsTargetObject(_hitObjectL)) {
                    LLaserUp(_selectObjectL); //≒MouseUp, Click
                }
            } else {
                LLaserUpOutside(_selectObjectL); //≒MouseUpOutside NEW
            }
            //_isLLaserDown = false;
            _selectObjectL = null;
        }
        if (OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger)) {
            _isRIndexTriggerDown = false;
            RIndexTriggerUp();
            if (HitTestR(false) == _selectObjectR) { //ヒットテスト NEW
                if (IsTargetObject(_hitObjectR)) {
                    RLaserUp(_selectObjectR); //≒MouseUp, Click
                }
            } else {
                RLaserUpOutside(_selectObjectR); //≒MouseUpOutside
            }
            //_isRLaserDown = false;
            _selectObjectR = null;
        }

        //中指トリガー
        if (OVRInput.GetDown(OVRInput.RawButton.LHandTrigger)) {
            _isLHandTriggerDown = true;
            LHandTriggerDown();
        }
        if (OVRInput.GetUp(OVRInput.RawButton.LHandTrigger)) {
            _isLHandTriggerDown = false;
            LHandTriggerUp();
        }
        if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger)) {
            _isRHandTriggerDown = true;
            RHandTriggerDown();
        }
        if (OVRInput.GetUp(OVRInput.RawButton.RHandTrigger)) {
            _isRHandTriggerDown = false;
            RHandTriggerUp();
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
        if (OVRInput.GetUp(OVRInput.RawButton.LThumbstick)) {
            // _isLThumbstickUpDown = false;
            // _isLThumbstickDownDown = false;
            // _isLThumbstickLeftDown = false;
            // _isLThumbstickRightDown = false;
            LThumbstickUp();
        }
        if (OVRInput.GetDown(OVRInput.RawButton.RThumbstick)) RThumbstickDown();
        if (OVRInput.GetUp(OVRInput.RawButton.RThumbstick)) {
            // _isRThumbstickUpDown = false;
            // _isRThumbstickDownDown = false;
            // _isRThumbstickLeftDown = false;
            // _isRThumbstickRightDown = false;
            RThumbstickUp();
        }

        //親指スティック上下左右（↓）
        if (OVRInput.GetDown(OVRInput.RawButton.LThumbstickUp)) {
            _isLThumbstickUpDown = true;
            LThumbstickUpDown();
        }
        if (OVRInput.GetDown(OVRInput.RawButton.LThumbstickDown)) {
            _isLThumbstickDownDown = true;
            LThumbstickDownDown();
        }
        if (OVRInput.GetDown(OVRInput.RawButton.LThumbstickLeft)) {
            _isLThumbstickLeftDown = true;
            LThumbstickLeftDown();
        }
        if (OVRInput.GetDown(OVRInput.RawButton.LThumbstickRight)) {
            _isLThumbstickRightDown = true;
            LThumbstickRightDown();
        }
        if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickUp)) {
            _isRThumbstickUpDown = true;
            RThumbstickUpDown();
        }
        if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickDown)) {
            _isRThumbstickDownDown = true;
            RThumbstickDownDown();
        }
        if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickLeft)) {
            _isRThumbstickLeftDown = true;
            RThumbstickLeftDown();
        }
        if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickRight)) {
            _isRThumbstickRightDown = true;
            RThumbstickRightDown();
        }

        //親指スティック上下左右（↑）
        if (OVRInput.GetUp(OVRInput.RawButton.LThumbstickUp)) {
            _isLThumbstickUpDown = false;
            LThumbstickUpUp();
        }
        if (OVRInput.GetUp(OVRInput.RawButton.LThumbstickDown)) {
            _isLThumbstickDownDown = false;
            LThumbstickDownUp();
        }
        if (OVRInput.GetUp(OVRInput.RawButton.LThumbstickLeft)) {
            _isLThumbstickLeftDown = false;
            LThumbstickLeftUp();
        }
        if (OVRInput.GetUp(OVRInput.RawButton.LThumbstickRight)) {
            _isLThumbstickRightDown = false;
            LThumbstickRightUp();
        }
        if (OVRInput.GetUp(OVRInput.RawButton.RThumbstickUp)) {
            _isRThumbstickUpDown = false;
            RThumbstickUpUp();
        }
        if (OVRInput.GetUp(OVRInput.RawButton.RThumbstickDown)) {
            _isRThumbstickDownDown = false;
            RThumbstickDownUp();
        }
        if (OVRInput.GetUp(OVRInput.RawButton.RThumbstickLeft)) {
            _isRThumbstickLeftDown = false;
            RThumbstickLeftUp();
        }
        if (OVRInput.GetUp(OVRInput.RawButton.RThumbstickRight)) {
            _isRThumbstickRightDown = false;
            RThumbstickRightUp();
        }

        //タッチ（RawTouch）
        if (OVRInput.GetDown(OVRInput.RawTouch.LIndexTrigger)) LIndexTriggerRawTouch();
        if (OVRInput.GetDown(OVRInput.RawTouch.RIndexTrigger)) RIndexTriggerRawTouch();
        if (OVRInput.GetDown(OVRInput.RawTouch.LThumbstick)) {
            LThumbstickRawTouch();
        }
        if (OVRInput.GetDown(OVRInput.RawTouch.RThumbstick)) {
            RThumbstickRawTouch();
        }
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
            _rayL = new Ray(_oculusTouchL.transform.position, _oculusTouchL.transform.forward);
            _lineRendererL.SetPosition(0, _rayL.origin);
            _lineRendererL.SetPosition(1, _rayL.origin + _rayL.direction * 500.0f);
            HitTestL(true); //ヒットテスト
            //選択オブジェクトの領域を外した時
            if (!Physics.Raycast(_rayL, out _hitInfoL, 500.0f)) {
                _isVibrationL = false;
                if (IsTargetObject(_hitObjectL)) {
                    LLaserOut(_hitObjectL); //イベント発生
                }
                _hitObjectL = null;
            }
        }

        //===========================================================
        //レーザー（右）表示
        //===========================================================
        if (_enabledLaserR) {
            _rayR = new Ray(_oculusTouchR.transform.position, _oculusTouchR.transform.forward);
            _lineRendererR.SetPosition(0, _rayR.origin);
            _lineRendererR.SetPosition(1, _rayR.origin + _rayR.direction * 500.0f);
            HitTestR(true); //ヒットテスト
            //選択オブジェクトの領域を外した時
            if (!Physics.Raycast(_rayR, out _hitInfoR, 500.0f)) { 
                _isVibrationR = false;
                if (IsTargetObject(_hitObjectR)) {
                    RLaserOut(_hitObjectR); //イベント発生
                }
                _hitObjectR = null;
            }
        }
    }

    //=====================================
    // Private Method
    //=====================================
    //指定のGameObjectがボタンとして反応するGameObjectか否か
    private bool IsTargetObject(GameObject arg) {
        foreach (GameObject _tmp in _targetObjects) {
            if (_tmp == arg) {
                return true;
            }
        }
        return false;
    }

    //ヒットテスト（左）
    private GameObject HitTestL(bool arg) {
        _hitInfoL = new RaycastHit(); //構造体
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
                            if (arg) {
                                //振動させる（周波数0〜1.0f,振幅0〜1.0f）
                                OVRInput.SetControllerVibration(1.0f, 0.3f, OVRInput.Controller.LTouch);
                                //0.05秒後に "StopVibration()" を実行
                                Invoke("StopVibrationL", 0.05f); 
                                _isVibrationL = true;
                            }
                        }
                    }
                }
                return _hitObjectL;
            }
        }
        return null;
    }

    //ヒットテスト（右）
    private GameObject HitTestR(bool arg) {
        _hitInfoR = new RaycastHit(); //構造体
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
                            if (arg) {
                                //振動させる（周波数0〜1.0f,振幅0〜1.0f）
                                OVRInput.SetControllerVibration(1.0f, 0.3f, OVRInput.Controller.RTouch);
                                //0.05秒後に "StopVibration()" を実行
                                Invoke("StopVibrationR", 0.05f); 
                                _isVibrationR = true;
                            }
                        }
                    }
                }
                return _hitObjectR;
            }
        }
        return null;
    }
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
        set {
            _oculusTouchL = value;
            //コントローラーのレーザーポイントを表示する
            _lineRendererL = _oculusTouchL.GetComponent<LineRenderer>();
            _lineRendererL.enabled = true;
            if (_oculusTouchR == null) { //Rを使わない場合
                _activeController = "left";
                _lineRendererL.startWidth = _lineRendererL.endWidth = _lineWidth1;
            } else { //Rを使う場合
                _lineRendererL.startWidth = _lineRendererL.endWidth = _lineWidth2;
            }
        }
    }
    public GameObject R {
        get { return _oculusTouchR; }
        set {
            _oculusTouchR = value;
            _activeController = "right";
            //コントローラーのレーザーポイントを表示する
            _lineRendererR = _oculusTouchR.GetComponent<LineRenderer>();
            _lineRendererR.enabled = true;
            if (_oculusTouchL != null) {
                _lineRendererL.startWidth = _lineRendererL.endWidth = _lineWidth2;
            }
            _lineRendererR.startWidth = _lineRendererR.endWidth = _lineWidth1;
        }
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
            if (LThumbstickRotate == 0) return false;
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
            if (RThumbstickRotate == 0) return false;
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