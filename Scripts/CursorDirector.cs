using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorDirector : MonoBehaviour
{
    [SerializeField]
    private Texture2D pointer;
    
    //カーソルにポインターマークを設定
    void Start()
    {
        Cursor.SetCursor(pointer, new Vector2(pointer.width / 2, pointer.height / 2), CursorMode.ForceSoftware);
    }
}
