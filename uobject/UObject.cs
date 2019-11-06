//UObject.cs
/******************************************************************
 * UObject Alpha 1 RC 20191106.1837
 * © 2019 夢寐郎
 ****************************************************************/
using System.Collections.Generic; //for List
using UnityEngine;
using System; //for Math

public class UObject : MonoBehaviour {
    private GameObject _gameObject = null;

    void Start() {
    }

    void Update() {
    }

    //==================
    // Public Property
    //==================
    public string Name {
        get { return _gameObject.name; }
        set { _gameObject = GameObject.Find(value); }
    }

    public bool UseGravity {
        get { return _gameObject.GetComponent<Rigidbody>().useGravity; }
        set { _gameObject.GetComponent<Rigidbody>().useGravity = value; }
    }

    public float Y {
        get { return _gameObject.transform.position.y; }
        set {
            Vector3 _pos = _gameObject.transform.position;
            _gameObject.transform.position = new Vector3(_pos.x, value, _pos.z);
        }
    }

    //================
    // Public Method
    //================
    public GameObject GetChild(string arg) {
        return _gameObject.transform.Find(arg).gameObject;
    }

    public void MoveY(float arg) {
        _gameObject.transform.Translate(0, arg, 0);
    }
}