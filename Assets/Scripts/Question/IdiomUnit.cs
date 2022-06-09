using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdiomUnit
{
    public string m_Idiom; //成語是什麼
    public TextUnit[] m_TextArray; //成語的每個字都拆成Unit，存入Array中

    public void Init()
    {
        int r = Random.Range(2, m_Idiom.Length); //1-5

        for (int i = r; i < m_TextArray.Length; i++)
        {
            m_TextArray[i].m_IsHide = true;
        }
    }
}
