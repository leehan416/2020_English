using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonController : MonoBehaviour {

    public Image Y;
    public Image N;
    void Start() { 
        Y = ObjManager.instance.Obj_Y;
        N = ObjManager.instance.Obj_N;
    }
    public GameObject dest;


    public void Test5Button() {
        SceneManager.LoadScene("Test5");

    }
    public void Test6Button() {
        SceneManager.LoadScene("Test6");
    }
    public void Test7Button() {
        SceneManager.LoadScene("Test7");
    }
    public void Test8Button() {
        SceneManager.LoadScene("Test8");
    }
    public void Test9Button() {
        DestroyImmediate(dest);
        SceneManager.LoadScene("Test9");
    }
    public void BackButton() {
        SceneManager.LoadScene("Main");
    }
    public void Button1() {
        if ((Application.loadedLevelName == "Test9") ){

            Show.instance.before = true;
            NextButton();
        } else {
            if (Runner.instance.Checking(DataRead.instance.Check) == 1) { //정답시
                Check(true);
            } else if (Runner.instance.Checking(DataRead.instance.Check) == 2) { // 오답시
                Check(false);
            } else { // 에러

            }
        }
    }
    public void Button2() {
        if ((Application.loadedLevelName == "Test9") ){
            NextButton();
        } else {
            if (Runner.instance.Checking(DataRead.instance.Check) == 1) {// 오답시 
                Check(false);
            }
            else if (Runner.instance.Checking(DataRead.instance.Check) == 2) { //정답시
                Check(true);
            } else { // 에러

            }
        }
    }
    public void NextButton() {
        Runner.instance.Num++;
        if (Runner.instance.Num >= DataRead.instance.i.Length){ //나가기
            //Data_Exchange.instance.S[DataRead.instance.SceneCheck()] = Runner.instance.Score[DataRead.instance.SceneCheck()];
            SceneManager.LoadScene("Main");
            return;
        }
        #region
        if ((Application.loadedLevelName != "Test9")) {
            DataRead.instance.an.SetActive(false);
            Runner.instance.NextButton.SetActive(false);
            Runner.instance.Button1.SetActive(true);
            Runner.instance.Button2.SetActive(true);
        }
        #endregion
        DataRead.instance.SetText();
    }
    void Check(bool b = false) {//채점 효과 false 오답, true 정답
        if (b) {
            Data_Exchange.instance.S[DataRead.instance.SceneCheck()]++;
            Runner.instance.Change();
            Y.enabled = true;
            Y.CrossFadeAlpha(1f, 0f, true);
            Y.CrossFadeAlpha(0f, 0.5f, true);
        } else {
            Runner.instance.Change();
            N.enabled = true;
            N.CrossFadeAlpha(1f, 0f, true);
            N.CrossFadeAlpha(0f, 0.5f, true);
        }
    }
}


