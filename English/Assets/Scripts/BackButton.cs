using UnityEngine.SceneManagement;
using UnityEngine;

public class BackButton : MonoBehaviour {
    void Update() {
        if (Input.GetKey(KeyCode.Escape)) {
            if (Application.loadedLevelName == "Main") {
                Application.Quit();
            } else {
                SceneManager.LoadScene("Main");
            }
        }
    }
}
