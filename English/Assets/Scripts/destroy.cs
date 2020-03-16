using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour {

    private void Update() {
        if (Application.loadedLevelName == "Test9") {
            DestroyImmediate(this.gameObject);
        } else {
        }
    }
    


}
