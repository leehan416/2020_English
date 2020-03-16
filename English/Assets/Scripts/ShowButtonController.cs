using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowButtonController : MonoBehaviour {

    public void Outval(int val) {
        Show.instance.value = val;
        SceneManager.LoadScene("Test9");
        

        
    }

}
