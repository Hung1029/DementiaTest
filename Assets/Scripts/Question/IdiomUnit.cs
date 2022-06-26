using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdiomUnit
{
    public string m_Idiom; //題目是什麼
    public TextUnit[] m_TextArray; //題目的每個字都拆成Unit，存入Array中

    public void ResetData()
    {
        for (int i = 0; i < m_TextArray.Length; i++)
        {
            m_TextArray[i].m_IsHide = false;
        }
    }
    
    public void Init()
    {
        int r = Random.Range(2, m_Idiom.Length); //1-5

        for (int i = r; i < m_TextArray.Length; i++)
        {
            m_TextArray[i].m_IsHide = true;
        }
    }

    public bool CheckSuccess()
    {
        bool isSuccess = true;
        for (int i = 0; i < m_TextArray.Length; i++)
        {
            if (m_TextArray[i].m_IsHide == true)
            {
                isSuccess = false;
                break;
            }
        }
        return isSuccess;
    }
}
