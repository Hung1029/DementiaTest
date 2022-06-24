using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public bool canPush;

    public bool gameStart;
    public bool ordergameStart;
    public bool ordergame1Start;
    public bool ordergame2Start;
    public bool gameOver;

    public GameObject Useteaching;
    public GameObject Gameover;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("CountGame",5f);
        Gameover.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver)
        {
            Gameover.SetActive(true);
            Invoke("GameOver",5f);
        }
    }
    void GameOver()
    {
        SceneManager.LoadScene("Catch");
    }
    public void CountGame()
    {
        Invoke("GameStart",3f);
        Useteaching.SetActive(false);
    }
    public void OrderGame()
    {
        Invoke("GameStart",3f);
    }
    void CanPush()
    {
        canPush = true;
    }
    void GameStart()
    {
        gameStart = true;
        Invoke("CanPush",3f);
    }
}
