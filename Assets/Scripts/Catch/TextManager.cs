using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    [SerializeField] AudioData gameoverA;
    [SerializeField] AudioData wrong;
    public float m_TimeValue = 60;
    public float m_GoalValue = 100;
    public Text m_Score = null;
    public Text m_Time = null;

    private void Start()
    {
        m_TimeValue = 60;
        ScoreManager.m_ScoreValue = 0;
        m_Score.text = "分 數 : ";
        m_Time.text = "時 間 : " + m_TimeValue.ToString();
        Refrash();
    }
    public void Refrash() {
        m_Score.text = "分 數 : " + ScoreManager.m_ScoreValue.ToString();
    }

    void Update()
    {
        if(ScoreManager.gameStart)
        {
            m_TimeValue -= Time.deltaTime;
            m_Time.text = "時 間 : " + m_TimeValue.ToString("0");

            if (m_TimeValue <= 0)
            {
                AudioManager2.Instance.PlaySFX(wrong);
                ScoreManager.m_IsRestart = true;
                m_TimeValue = 60;

                // ScoreManager.m_IsGameOver = true;
            } 
            else if(ScoreManager.m_ScoreValue>=m_GoalValue)
            {
                AudioManager2.Instance.PlaySFX(gameoverA);
                ScoreManager.m_IsGameOver = true;
                ScoreManager.m_ScoreValue = 0;
            }
        }  
    }
}
