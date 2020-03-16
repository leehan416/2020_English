using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Show : MonoBehaviour {
    public static Show instance;

    public int[] Stack = { 0, 0 };
    public bool before = false;

    

    public int value=5;

    public Text valueChecker;

    void Start() {
        if (!instance) {
            instance = this;
        } else {
            DestroyImmediate(this);
        }
        if (Application.loadedLevelName != "Test9") {
            DestroyImmediate(this);
        }
    }
    public void Changer() {
        valueChecker.text = System.Convert.ToString(value) + " 과";
    }

}
