using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public float m_TimeValue = 60;
    public float m_GoalValue = 100;
    public Text m_Score = null;
    public Text m_Time = null;

    private void Start()
    {
        m_Score.text = "Score: ";
        m_Time.text = m_TimeValue.ToString();
        Refrash();
    }
    public void Refrash() {
        m_Score.text = "Score: " + ScoreManager.m_ScoreValue.ToString();
    }

    void Update()
    {
        m_TimeValue -= Time.deltaTime;
        m_Time.text = "Time: " + m_TimeValue.ToString("0");

        if (m_TimeValue <= 0)
        {
            ScoreManager.m_IsGameOver = true;
        } 
        else if(ScoreManager.m_ScoreValue>=m_GoalValue)
        {
            ScoreManager.m_IsGameOver = true;
        }
    }

}
