using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameSystem_Manager : MonoBehaviour
{
    public static GameSystem_Manager Instance;

    [SerializeField] private int maxScore;
    [SerializeField] private int noteGroupSpawnConditionScore = 10;
    [SerializeField] private GameObject gameClearObj = null;
    [SerializeField] private GameObject gameOverObj = null;

    private int nextNoteGroupUnlockCount;
    private int score;

    [SerializeField] private float maxTime = 30f;

    public bool IsGameDone => this.gameClearObj.activeSelf == true 
        || this.gameOverObj.activeSelf == true;  

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UI_Manager.Instance.OnScore_Func(this.score, this.maxScore);

        NoteSystem_Manager.Instance.Activate_Func();

        this.gameClearObj.SetActive(false);
        this.gameOverObj.SetActive(false);

        StartCoroutine(this.OnTimer_Cor());
    }

    IEnumerator OnTimer_Cor()
    {
        float _currentTime = 0f;

        while (_currentTime < this.maxTime)
        {
            _currentTime += Time.deltaTime;

            UI_Manager.Instance.OnTimer_Func(_currentTime, this.maxTime);

            yield return null;

            if(this.IsGameDone == true)
            {
                yield break;
            }
        }

        //game over
        this.gameOverObj.SetActive(true);

    }

    public void OnScore_Func(bool _isCorrect)
    {
        if(_isCorrect == true)
        {
            this.score++;
            this.nextNoteGroupUnlockCount++;

            if(this.noteGroupSpawnConditionScore <= this.nextNoteGroupUnlockCount)
            {
                this.nextNoteGroupUnlockCount = 0;

                NoteSystem_Manager.Instance.OnSpawnNoteGroup_Func();
            }

            if(this.maxScore <= this.score)
            {
                //game clear;
                this.gameClearObj.SetActive(true);
            }
        }
        else
        {
            this.score--;
        }

        UI_Manager.Instance.OnScore_Func(this.score, this.maxScore);
    }

    public void CallBtn_Restart_Func()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

}
