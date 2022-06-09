using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public bool canPush;
    // Start is called before the first frame update
    void Start()
    {
        CountGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CountGame()
    {
        Invoke("GameStart",3f);
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
        GameManager.instance.gameStart = true;
        Invoke("CanPush",3f);
    }
}
