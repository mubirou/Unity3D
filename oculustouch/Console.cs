/***************************************************************************
 * Console.cs (ver.2019-08-19T11:52)
 * © 2019 夢寐郎
 ***************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Console : MonoBehaviour {
    private bool _enabled = true;
    private List<string> _logList = new List<string>(); 

    void Start() {
        Reset();
    }

    public void Log(string arg) {
        _logList.Add(arg);
        if (_logList.Count > 50) { //100行まで表示
            _logList.RemoveAt(0);
        }
        GetComponent<TextMesh>().text = "";
        foreach (string _log in _logList) {
            GetComponent<TextMesh>().text += _log + "\n";
        }
    }

    public void Reset() {
        GetComponent<TextMesh>().text = "";
    }

    public bool Enabled {
        get { return _enabled; }
        set {
            _enabled = value;
            if (!_enabled) {
                gameObject.SetActive(false);
            } else {
                gameObject.SetActive(true);
            }
        }
    }
}
