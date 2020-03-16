using UnityEngine;

public class Runner : MonoBehaviour {

    public static Runner instance;
    public int Num = 1;
    //public int[] Score = new int[3];

    public GameObject Button1;
    public GameObject Button2;
    public GameObject NextButton;

    void Start() {
        if (!instance)
            instance = this;
        else
            DestroyImmediate(this);

        if (Application.loadedLevelName != "Test9") {
            NextButton.SetActive(false);
        }
        Data_Exchange.instance.S[DataRead.instance.SceneCheck()] = 0;
    }
    public int Checking(int Value) { //정답 보네주는거
        if (Value == 1) {
            return 1;
        }
        else if (Value == 2) {
            return 2;
        } else {
            return 3;
        }
    }
    public void Change() {
            Button1.SetActive(false);
            Button2.SetActive(false);
            DataRead.instance.an.SetActive(true);
            NextButton.SetActive(true);
    }
}
