using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
//5과 32
//6과 44
//7과 46
//8과 34
public class DataRead : MonoBehaviour {

    public static DataRead instance;
    public string storyPath = "Assets/Data/Text"; //폴더명 / 파일명 

    public int storyPhase; //파일  선택(Text1, Text2, Text3)
    //public int storyIndex; //줄 위치
    public int Check;
    public int random;
    public bool [] i;
    public int Max;

    public string tmp;


    public ArrayList story = new ArrayList();

    public Text Display; // 출력 Text 
    public Text Button_1; //버튼1 에 띄울 Text 
    public Text Button_2; // 버튼 2에 띄울 Text 
    public GameObject an;
    public Text answer;



    int k = 0;


    // 값 초기화
    void Start() {
        if (Application.loadedLevelName == "Test5") {
            i = new bool[32];
            Max = 32;
        }
        else if (Application.loadedLevelName == "Test6") {
            i = new bool[42];
            Max = 42;
        }
        else if (Application.loadedLevelName == "Test7") {
            i = new bool[46];
            Max = 46;
        }
        else if (Application.loadedLevelName == "Test8") {
            i = new bool[34];
            Max = 34;
        } else if (Application.loadedLevelName == "Test9") {
            switch (Show.instance.value) {
                case 5:
                    i = new bool[32];
                    Max = 32;
                    break;
                case 6:
                    i = new bool[42];
                    Max = 42;
                    break;
                case 7:
                    i = new bool[46];
                    Max = 46;
                    break;
                case 8:
                    i = new bool[34];
                    Max = 34;
                    break;
                default:
                    break;
            }
        }
        for (int a = 0; a < i.Length; a++) {
            i[a] = true;
        }
        //----------------------------------------------------------
        if (!instance)
            instance = this;
        else
            DestroyImmediate(this);
        //-----------------------------------------------------------
        if (PlayerPrefs.HasKey("storyPhase")) { //값 초기화
            storyPhase = PlayerPrefs.GetInt("storyPhase");
        } else {
            storyPhase = 0;
            //storyIndex = 0;
            //SetStory();
            SetText();
        }

    }
    public int SceneCheck() {
        if (Application.loadedLevelName == "Test5") {
            return 0;
        } else if (Application.loadedLevelName == "Test6") {
            return 1;
        } else if (Application.loadedLevelName == "Test7") {
            return 2;
        } else if (Application.loadedLevelName == "Test8") {
            return 3;
        } else if (Application.loadedLevelName == "Test9") {
            switch (Show.instance.value) {
                case 5:
                    return 0;
                case 6:
                    return 1;
                case 7:
                    return 2;
                case 8:
                    return 3;
                default:
                    return 10;
            }
        } else {
            return 10; // 에러
        }
    }
    //----------------------------------------------------------------------------------------------------
    public void SetText() { // 명령어 설정창
        #region
        if (Application.loadedLevelName == "Test5") {
            tmp = Lesson.instance.Data5[Ran()];
        }
        else if (Application.loadedLevelName == "Test6") {
            tmp = Lesson.instance.Data6[Ran()];
        }
        else if (Application.loadedLevelName == "Test7") {
            tmp = Lesson.instance.Data7[Ran()];
        }
        else if (Application.loadedLevelName == "Test8") {
            tmp = Lesson.instance.Data8[Ran()];
        }
        else if (Application.loadedLevelName == "Test9") {
            #endregion

            if (Runner.instance.Num <= 0) {
                Runner.instance.Num = 1;
            }
            if (Show.instance.before) {
                Runner.instance.Num -= 2;
                Show.instance.before = false;
            }  
            switch (Show.instance.value) {

                case 5:
                    tmp = Lesson.instance.Data5[Runner.instance.Num-1];
                    break;

                case 6:
                    tmp = Lesson.instance.Data6[Runner.instance.Num - 1];
                    break;

                case 7:
                    tmp = Lesson.instance.Data7[Runner.instance.Num - 1];
                    break;

                case 8:
                    tmp = Lesson.instance.Data8[Runner.instance.Num - 1];
                    break;

                default:
                    break;
            }



                k++;
            
        }//읽어오기  영단어 : 버튼1 : 버튼2 : 정답버튼숫자로 표현
        
        if (tmp.Contains(":")) {//뜻 있으면 
            if (Application.loadedLevelName != "Test9") {
                string[] tmps = tmp.Split(':');
                Display.text = tmps[0].Trim();
                Button_1.text = tmps[1].Trim();
                Button_2.text = tmps[2].Trim();
                Check = Convert.ToInt32(tmps[3].Trim());
                answer.text = tmps[Check];
            } else {
                string[] tmps = tmp.Split(':');
                Check = Convert.ToInt32(tmps[3].Trim());
                Display.text = tmps[0].Trim() +"\n"+ tmps[Check];
            }
        } else {
            Display.text = "Error!";
        }
    }
    //-------------------------------------------------------------------------------------------------------------------------
    public int Ran() {
        while(true) {
            random = UnityEngine.Random.Range(0, Max);
            if (i[random]) {
                break;
            }
        }
        i[random] = false;
        return random;
    }
}