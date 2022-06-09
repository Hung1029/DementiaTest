using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiUnit : MonoBehaviour
{
    public TextUnit m_TextData = null;

    public bool m_IsMenu = false;
    public Text m_Text = null;
    public Image m_Image = null;
    public bool m_IsSelect = false;

    private void Awake()
    {
        RefrashColor();
    }

    public void OnSelect(bool isSelect)
    {
        m_IsSelect = isSelect;
        RefrashColor();
    }

    private void RefrashColor()
    {
        if (m_IsSelect)
        {
            //m_Image.color = Color.cyan;
            m_Image.sprite = Resources.Load<Sprite>("Unit_click");
        }
        else
        {
            if (m_TextData == null)
            {
                m_Image.color = Color.gray;
                m_Image.enabled = false;
            }
            else
            {
                m_Image.color = Color.white;
                m_Image.sprite = Resources.Load<Sprite>("Unit");
                m_Image.enabled = true;
            }
        }

       
    }
    public void Refrash()
    {
        if (m_TextData == null)
        {
            return;
        }
        RefrashColor();

        if (m_TextData.m_IsHide && m_IsMenu == false)
        {
            m_Text.text = "";
        }
        else
        {
            m_Text.text = m_TextData.m_Text.ToString();
        }
    }
}
