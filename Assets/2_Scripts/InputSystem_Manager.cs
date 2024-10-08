using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem_Manager : MonoBehaviour
{
    public static InputSystem_Manager Instance;

    private List<KeyCode> keyCodeList;

    void Awake()
    {
        Instance = this;

        this.keyCodeList = new List<KeyCode>();
    }

    public void AddKeyCode_Func(KeyCode _keyCode)
    {
        this.keyCodeList.Add(_keyCode);
    }


    void Update()
    {
        if(GameSystem_Manager.Instance.IsGameDone == true)
        {
            return;
        }

        foreach(KeyCode _keyCode in this.keyCodeList)
        {
            if(Input.GetKeyDown(_keyCode) == true)
            {
                NoteSystem_Manager.Instance.OnInput_Func(_keyCode);
                break;
            }
        }
    }
}
