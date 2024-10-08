using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Note_Script : MonoBehaviour
{
    [SerializeField] private SpriteRenderer srdr;
    [SerializeField] private Sprite appleSprite;
    [SerializeField] private Sprite blueberrySprite;
    private bool isApple;
    public void Activate_Func(bool _isApple)
    {
        this.isApple = _isApple;

        this.srdr.sprite = _isApple == true ? this.appleSprite : this.blueberrySprite;
    }

    public void OnInput_Func(bool _isSelected)
    {
        if(_isSelected == true)
        {
            bool _isCorrect = this.isApple == true;
            GameSystem_Manager.Instance.OnScore_Func(_isCorrect);
        }

        this.Deactivate_Func();
    }

    public void Deactivate_Func()
    {
        GameObject.Destroy(this.gameObject);
    }
}