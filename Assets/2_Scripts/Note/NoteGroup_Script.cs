using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NoteGroup_Script : MonoBehaviour
{
    [SerializeField] private int noteMaxNum = 5;
    [SerializeField] private Note_Script baseNoteClass = null;
    [SerializeField] private float noteGapInterval = 6.5f;
    [SerializeField] private Transform noteSpawnTrf = null;
    [SerializeField] private SpriteRenderer btnSrdr = null;
    [SerializeField] private Sprite normalBtnSprite = null;
    [SerializeField] private Sprite selectBtnSprite = null;
    [SerializeField] private Animation anim = null;
    [SerializeField] private TextMeshPro keycodeTmp = null;

    private KeyCode keyCode;
    private List<Note_Script> noteClassList;

    public KeyCode GetKeyCode => this.keyCode;

    private void Awake()
    {
        this.noteClassList = new List<Note_Script>();
    }
    public void Activate_Func(KeyCode _keyCode)
    {
        this.keyCode = _keyCode;

        this.keycodeTmp.text = _keyCode.ToString();

        for (int i = 0; i < this.noteMaxNum; i++)
        {
            this.OnSpawnNote_Func(true);
        }

        InputSystem_Manager.Instance.AddKeyCode_Func(_keyCode);
    }
    public void OnSpawnNote_Func(bool _isApple)
    {
        GameObject _noteClassObj = GameObject.Instantiate(this.baseNoteClass.gameObject);
        _noteClassObj.transform.SetParent(this.noteSpawnTrf);
        _noteClassObj.transform.localPosition
            = Vector3.up * this.noteClassList.Count * this.noteGapInterval;

        Note_Script _noteClass = _noteClassObj.GetComponent<Note_Script>();
        _noteClass.Activate_Func(_isApple);

        this.noteClassList.Add(_noteClass);
    }

    void Update()
    {
        
    }

    public void OnInput_Func(bool _isSelected)
    {
        Note_Script _noteClass = this.noteClassList[0];
        _noteClass.OnInput_Func(_isSelected);

        this.noteClassList.RemoveAt(0);

        for(int i = 0; i < this.noteClassList.Count; i++)
        {
            this.noteClassList[i].transform.localPosition
                = Vector3.up * i * this.noteGapInterval;
        }

        if (_isSelected == true)
        {
            this.btnSrdr.sprite = this.selectBtnSprite;
            this.anim.Play();
        }
    }    

    public void CallAni_Done_Func()
    {
        this.btnSrdr.sprite = this.normalBtnSprite;
    }
}
