using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanManager : MonoBehaviour
{
    [SerializeField] AudioData btnA;
    public UnitBase[] m_Clone = null;

    public Transform m_CanNode = null;

    public GameObject OverObj = null;

    public Text EndScore = null;

    private float m_Delay = 0;

    public GameObject useteaching;

    private void Start()
    {
        ScoreManager.m_IsGameOver = false;
        ScoreManager.m_ScoreValue = 0;
        ScoreManager.gameStart = false;
        m_Delay = 0;
        EndScore.text = "";
        Invoke("Useteaching",12f);
    }



    private void Update()
    {
        if(ScoreManager.gameStart)
        {
            if (m_Delay < Time.time)
            {
                m_Delay = Time.time + 1;
                CreateCan();
            }

            if (ScoreManager.m_IsGameOver)
            {
                OverObj.SetActive(true);
                EndScore.text = "EndScore: " + ScoreManager.m_ScoreValue.ToString();
                Time.timeScale = 0;
            }
        }
    }
    public void GameOver()
    {
        GameManager.instance.Day1missioncompleted = true;
        Time.timeScale = 1;
        AudioManager2.Instance.PlaySFX(btnA);
        SceneManager.LoadScene("Main");
    }
    void Useteaching()
    {
        useteaching.SetActive(false);
        m_Delay = Time.time + 1;
        ScoreManager.gameStart = true;
    }
    private void CreateCan() 
    {
        int r = Random.Range(0, 10);
        UnitBase unit = null;
        if (r < 5)
        {
            unit = m_Clone[0];
        }
        else 
        {
            unit = m_Clone[1];
        }

        UnitBase createUnit = Instantiate<UnitBase>(unit, m_CanNode);
        createUnit.transform.localPosition = new Vector3(Random.Range(-800f, 800f), 1000, 0);

    }

}
