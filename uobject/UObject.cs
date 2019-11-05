//UObject.cs
/******************************************************************
 * UObject Alpha 1 RC 20191105.2157
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

    public string Name {
        get { return _gameObject.name; }
        set {
            _gameObject = GameObject.Find(value); //value;
        }
    }

    public bool UseGravity {
        get { return _gameObject.GetComponent<Rigidbody>().useGravity; }
        set { _gameObject.GetComponent<Rigidbody>().useGravity = value; }
    }

    public GameObject GetChild(string arg) {
        return _gameObject.transform.Find(arg).gameObject;
    }

    public void MoveY(float arg) {
        _gameObject.transform.Translate(0, arg, 0);
    }
}