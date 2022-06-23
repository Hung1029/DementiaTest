using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public bool canPush;

    public bool gameStart;
    public bool ordergameStart;
    public bool ordergame1Start;
    public bool ordergame2Start;

    public GameObject Useteaching;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("CountGame",5f);
    }

    // Update is called once per frame
    void Update()
    {
        
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
