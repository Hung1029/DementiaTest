using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanControl : MonoBehaviour
{
    RectTransform rectTransform;
    private bool game2Start;
    public GameControl gameControl;
    public Sprite Ycan;
    public Sprite Rcan;
    public Sprite Bcan;


    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        GameManager.instance.ordergame1Start = true;
        gameControl = gameControl.GetComponent<GameControl>();
        GameManager.instance.Can[0].transform.localPosition = new Vector3(-1500,-32,0);
        GameManager.instance.Can[1].transform.localPosition = new Vector3(-1700,-32,0);
        GameManager.instance.Can[2].transform.localPosition = new Vector3(-1900,-32,0);
    }

    // Update is called once per frame
    void Update()
    {
        CanSpeedControl();
    }
    public void GameRestart()
    {
        if(game2Start == false)
        {
            GameManager.instance.Can[0].transform.localPosition = new Vector3(-1500,-32,0);
            GameManager.instance.Can[1].transform.localPosition = new Vector3(-1700,-32,0);
            GameManager.instance.Can[2].transform.localPosition = new Vector3(-1900,-32,0);

            gameControl.canPush = false;
            gameControl.OrderGame();
            game2Start = true;
        }
    }
    void CanSpeedControl()
    {
        if(GameManager.instance.ordergame1Start)
        {
            GameManager.instance.Can[0].GetComponent<CanSpeedControl>().speedX = 1500;
            GameManager.instance.Can[1].GetComponent<CanSpeedControl>().speedX = 1000;
            GameManager.instance.Can[2].GetComponent<CanSpeedControl>().speedX = 800;

            GameManager.instance.Can[0].GetComponent<Image>().sprite = Ycan;
            GameManager.instance.Can[1].GetComponent<Image>().sprite = Rcan;
            GameManager.instance.Can[2].GetComponent<Image>().sprite = Bcan;
        }
        if(GameManager.instance.ordergame2Start)
        {
            GameManager.instance.Can[0].GetComponent<CanSpeedControl>().speedX = 1500;
            GameManager.instance.Can[1].GetComponent<CanSpeedControl>().speedX = 1000;
            GameManager.instance.Can[2].GetComponent<CanSpeedControl>().speedX = 800;

            GameManager.instance.Can[0].GetComponent<Image>().sprite = Bcan;
            GameManager.instance.Can[1].GetComponent<Image>().sprite = Bcan;
            GameManager.instance.Can[2].GetComponent<Image>().sprite = Rcan;
        }
    }
}
