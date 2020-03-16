using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ObjManager : MonoBehaviour
{
    static public ObjManager instance;

    public Image Obj_Y;
    public Image Obj_N;


    private void Awake()
    {
        if (!instance)
            instance = this;
        else
            DestroyImmediate(this);
    }
}
