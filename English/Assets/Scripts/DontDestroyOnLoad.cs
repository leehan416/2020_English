using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour {
    public static DontDestroyOnLoad instance;

    void Awake() {
        if (instance) {
            DestroyImmediate(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}