using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSystem_Manager : MonoBehaviour
{
    public static NoteSystem_Manager Instance;

    [SerializeField] private NoteGroup_Script baseNoteGroupClass = null;
    [SerializeField] private float noteGroupWidthInterval = 1f;
    [SerializeField] private KeyCode[] wholekeyCodeArr = new KeyCode[]
        {
            KeyCode.A,
            KeyCode.S,
            KeyCode.D,
            KeyCode.F,
            KeyCode.G,
            KeyCode.H,
            KeyCode.J,
            KeyCode.K,
            KeyCode.L,
        };
    [SerializeField] private int initNoteGroupNum = 2;

    private List<NoteGroup_Script> noteGroupClassList;

    void Awake()
    {
        Instance = this;
        this.noteGroupClassList = new List<NoteGroup_Script>();
    }

    public void Activate_Func()
    {
        for(int i = 0;i<this.initNoteGroupNum;i++)
        {
            KeyCode _keyCode = this.wholekeyCodeArr[i];
            this.OnSpawnNoteGroup_Func(_keyCode);
        }
    }

    public void OnSpawnNoteGroup_Func()
    {
        int _activatenoteGroupNum = this.noteGroupClassList.Count;
        KeyCode _keyCode = this.wholekeyCodeArr[_activatenoteGroupNum];
        this.OnSpawnNoteGroup_Func(_keyCode);
    }



    public void OnSpawnNoteGroup_Func(KeyCode _keyCode)
    {
        GameObject _noteGroupClassObj = GameObject.Instantiate(this.baseNoteGroupClass.gameObject);
        _noteGroupClassObj.transform.position
            = Vector3.right * this.noteGroupWidthInterval * this.noteGroupClassList.Count;

        NoteGroup_Script _noteGroupClass = _noteGroupClassObj.GetComponent<NoteGroup_Script>();
        _noteGroupClass.Activate_Func(_keyCode);

        this.noteGroupClassList.Add(_noteGroupClass);
    }

    public void OnInput_Func(KeyCode _keyCode)
    {
        int _randID = Random.Range(0, this.noteGroupClassList.Count);
        NoteGroup_Script _randNoteGroupClass = this.noteGroupClassList[_randID];

        NoteGroup_Script _correctNoteGroupClass = null;
        foreach (NoteGroup_Script _noteGroupClass in this.noteGroupClassList)
        {
            _noteGroupClass.OnSpawnNote_Func(_noteGroupClass == _randNoteGroupClass);

            if (_noteGroupClass.GetKeyCode != _keyCode)
            {
                _noteGroupClass.OnInput_Func(false);
            }
            else
            {
                _correctNoteGroupClass = _noteGroupClass;
            }

        }

        if (_correctNoteGroupClass != null)
        {
            _correctNoteGroupClass.OnInput_Func(true);
        }
    }
}
