using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager Instance;

    [SerializeField] private Image scoreImg = null;
    [SerializeField] private TextMeshProUGUI scoreTmp = null;

    [SerializeField] private Image timerImg = null;
    [SerializeField] private TextMeshProUGUI timerTmp = null;
    void Awake()
    {
        Instance = this;
    }

    public void OnScore_Func(int _currentScore, int _maxScore)
    {
        this.scoreTmp.text = $"{_currentScore}/{_maxScore}";

        this.scoreImg.fillAmount = (float)_currentScore / _maxScore; ;
    }

    public void OnTimer_Func(float _currentTimer, float _maxTimer)
    {
        this.timerTmp.text = $"{_currentTimer.ToString_Func(1)}/{_maxTimer.ToString_Func(1)}";

        this.timerImg.fillAmount = (float)_currentTimer / _maxTimer; ;
    }
}