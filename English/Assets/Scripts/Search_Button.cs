using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Search_Button : MonoBehaviour {


    Button btn;
    public Text txt;
	// Use this for initialization
	void Start () {
        btn = GetComponent<Button>();
        txt = GetComponent<Text>();
	}
	
}
