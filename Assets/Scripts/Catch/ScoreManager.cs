using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class ScoreManager
{
    public static int m_ScoreValue = 0;
    public static bool m_IsGameOver;
    public static bool gameStart = false;


    public static void AddScore(int add) {

        m_ScoreValue += add;
        GameObject.Find("CatchManager").SendMessage("Refrash");
    }




}
