using UnityEngine;
using System;
using UnityEngine.UI;
public class Score : MonoBehaviour {
    public Text score1, score2, score3, score4;
    void Start() {
        if (Data_Exchange.instance.S[0] != 0) {
            score1.text = Convert.ToString(Data_Exchange.instance.S[0]);
        } else {
            score1.text = "";
        }

        if (Data_Exchange.instance.S[1] != 0) {
            score2.text = Convert.ToString(Data_Exchange.instance.S[1]);
        } else {
            score2.text = "";
        }
        if (Data_Exchange.instance.S[2] != 0) {
            score3.text = Convert.ToString(Data_Exchange.instance.S[2]);
        } else {
            score3.text = "";
        }
        if (Data_Exchange.instance.S[3] != 0) {
            score4.text = Convert.ToString(Data_Exchange.instance.S[3]);
        } else {
            score4.text = "";
        }
    }
}
