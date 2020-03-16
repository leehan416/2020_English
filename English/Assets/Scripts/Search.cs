using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Search : MonoBehaviour {

    const int amount = 300;
    public string[] List = new string[amount];
    public string[] List_Temp = new string[amount];
    
    public GameObject Prefabs_Button;
    public GameObject Prefabs_Content;
    public RectTransform Content;
    public RectTransform Viewport;
    public RectTransform ScrollView;
    public InputField IF;
	void Start () {
        
        IF = GetComponent<InputField>();
        Content = GameObject.Find("SearchContent").GetComponent<RectTransform>();
        Viewport = GameObject.Find("SearchViewport").GetComponent<RectTransform>();
        ScrollView = GameObject.Find("SearchScrollView").GetComponent<RectTransform>();
        int temp = 0;
        for( int i = 0; i < Lesson.instance.Data5.Length; i++)
        {
            List_Temp[temp] = Lesson.instance.Data5[i];
            temp++;
        }
        for (int i = 0; i < Lesson.instance.Data6.Length; i++)
        {
            List_Temp[temp] = Lesson.instance.Data6[i];
            temp++;
        }
        for (int i = 0; i < Lesson.instance.Data7.Length; i++)
        {
            List_Temp[temp] = Lesson.instance.Data7[i];
            temp++;
        }
        for (int i = 0; i < Lesson.instance.Data8.Length; i++)
        {
            List_Temp[temp] = Lesson.instance.Data8[i];
            temp++;
        }
        ScrollView.gameObject.SetActive(false);

        



    }

    int N_temp = 0;
    public void OnValueChange()
    {

        //string Buffer;
        string txt = IF.text;
        Debug.Log(txt);
        //Buffer = IF.text.Substring(Level-1, Level);
        if (!ScrollView.gameObject.active)
        { 
            ScrollView.gameObject.SetActive(true);
        }
        Reset_Temp();
        N_temp = 0;
        for ( int i = 0; i < List_Temp.Length; i++)
        {
            if ( !List_Temp[i].Contains( txt  ) )
            {
                List_Temp[i] = "!Destroyed";
            }   
        }
        for( int i = 0; i < List_Temp.Length; i++)
        {
            if (List_Temp[i] != "!Destroyed")
            {
                List[N_temp] = List_Temp[i];
                N_temp++;
            }
        }
        SyncButtonList();
    }


    void SyncButtonList()
    {
        DestroyImmediate(Content.gameObject);
        Content = Instantiate(Prefabs_Content, Viewport).GetComponent<RectTransform>();
        for ( int i = 0; i < N_temp; i++)
        {

            string[] temps = List[i].Split(':');
            List[i] = temps[0] + "  " + temps[Convert.ToInt16(temps[3])];

            Instantiate(Prefabs_Button, Content.transform ).GetComponent<Search_Button>().txt.text = List[i];
        }
    }

    void Reset_Temp()
    {
        int temp = 0;
        for (int i = 0; i < Lesson.instance.Data5.Length; i++)
        {
            List_Temp[temp] = Lesson.instance.Data5[i];
            temp++;
        }
        for (int i = 0; i < Lesson.instance.Data6.Length; i++)
        {
            List_Temp[temp] = Lesson.instance.Data6[i];
            temp++;
        }
        for (int i = 0; i < Lesson.instance.Data7.Length; i++)
        {
            List_Temp[temp] = Lesson.instance.Data7[i];
            temp++;
        }
        for (int i = 0; i < Lesson.instance.Data8.Length; i++)
        {
            List_Temp[temp] = Lesson.instance.Data8[i];
            temp++;
        }
    }

   // public void  PointerEventData eventData)
    //{
     //   
   // }
    public void OnDeselect()
    {
        ScrollView.gameObject.SetActive(false);
    }
}
