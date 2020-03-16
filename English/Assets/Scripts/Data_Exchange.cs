using UnityEngine;

public class Data_Exchange : MonoBehaviour {
    public static Data_Exchange instance;
    public int[] S = new int[4];

    void Start() {
        if (!instance)
            instance = this;
        else
            DestroyImmediate(this);
    }


}
