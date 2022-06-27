using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    [SerializeField] AudioData btnA;
    [SerializeField] AudioData mistakeA;
    [SerializeField] AudioData currentA;
    [SerializeField] AudioData finishA;

    public Sprite correct;
    public Sprite mistake;
    public Sprite normal;
    public Sprite selected;
    public Image[] G1Buttons;
    public Image[] G2Buttons;

    public GameObject CountGame;
    public GameObject OrderGame;
    public CanControl canControl;
    public GameControl gameControl;
    public int number1;
    public int number2;
    
    private bool P1countG1;
    private bool P2countG1;
    private bool P1countG2;
    private bool P2countG2;

    public bool P1orderG1, P2orderG1;
    public bool P1orderG2, P2orderG2;
    public bool p1button1, p2button1;
    public bool p1button2, p2button2;
    public bool p1button3, p2button3;

    private bool finiSh;
    public int order1;
    public int order2;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<6; i++)
        {
            G1Buttons[i] = G1Buttons[i].GetComponent<Image>();
        }
        for(int i=0; i<6; i++)
        {
            G2Buttons[i] = G2Buttons[i].GetComponent<Image>();
        }
        CountGame.SetActive(true);
        OrderGame.SetActive(false);
        canControl = canControl.GetComponent<CanControl>();
        gameControl = gameControl.GetComponent<GameControl>();
        P1orderG1 = true;
        P2orderG1 = true;
    }

    // Update is called once per frame
    void Update()
    {
        Game1Control();
        Game2Control();
        P1OrderGame();
        P2OrderGame();
        if(P1countG2 == true && P2countG2 == true && finiSh == false)
        {
            AudioManager2.Instance.PlaySFX(finishA);
            gameControl.gameOver = true;
            finiSh = true;
        }
    }

    //第一關
    void Game1Control()
    {
        if(number1 == 3 && number2 == 3 && P1countG1 == true)
        {
            Invoke("Game1GameOver",2f);
        }
    }
    void Game1GameOver()
    {
        CountGame.SetActive(false);
        OrderGame.SetActive(true);
        gameControl.canPush = false;

        gameControl.gameStart = false;

        gameControl.OrderGame();
        P1countG1 = false;
    }
    public void P1Num5()
    {
        if(gameControl.canPush == true)
        {
            number1 = 5;
            G1Buttons[0].GetComponent<Image>().sprite = mistake;
            AudioManager2.Instance.PlaySFX(mistakeA);
        }
    }
    public void P1Num2()
    {
        if(gameControl.canPush == true)
        {
            number1 = 2;
            G1Buttons[1].GetComponent<Image>().sprite = mistake;
            AudioManager2.Instance.PlaySFX(mistakeA);
        }
    }
    public void P1Num3()
    {
        if(gameControl.canPush == true)
        {
            number1 = 3;
            G1Buttons[2].GetComponent<Image>().sprite = correct;
            AudioManager2.Instance.PlaySFX(currentA);
            P1countG1 = true;
        }
    }
    public void P2Num5()
    {
        if(gameControl.canPush == true)
        {
            number2 = 5;
            G1Buttons[3].GetComponent<Image>().sprite = mistake;
            AudioManager2.Instance.PlaySFX(mistakeA);
        }
    }
    public void P2Num2()
    {
        if(gameControl.canPush == true)
        {
            number2 = 2;
            G1Buttons[4].GetComponent<Image>().sprite = mistake;
            AudioManager2.Instance.PlaySFX(mistakeA);
        }
    }
    public void P2Num3()
    {
        if(gameControl.canPush == true)
        {
            number2 = 3;
            G1Buttons[5].GetComponent<Image>().sprite = correct;
            AudioManager2.Instance.PlaySFX(currentA);
        }
    }

    // 第二關
    public void Game2Control()
    {
        if(P1orderG2 == true && P2orderG2 == true && gameControl.ordergame1Start == true)
        {
            Invoke("Game2GameOver",2f);
        }
    }
    void Game2GameOver()
    {
        gameControl.ordergame1Start = false;
        gameControl.ordergame2Start = true;

        canControl.GameRestart();
        for(int i=0; i<6; i++)
        {
            G2Buttons[i].sprite = normal;
        }
    }
    public void P1Button1()
    {
        if(P1orderG1 && gameControl.canPush)
        {
            if(p1button2 == true && p1button3 == false)
            {
                p1button1 = true;
            }
            AudioManager2.Instance.PlaySFX(btnA);
            G2Buttons[0].sprite = selected;
            order1 += 1;
        }
        if(P1orderG2 && gameControl.canPush)
        {
            if(p1button2 == false && p1button3 == true)
            {
                p1button1 = true;
            }
            AudioManager2.Instance.PlaySFX(btnA);
            G2Buttons[0].sprite = selected;
            order1 += 1;
        }
    }
    public void P1Button2()
    {
        if(P1orderG1 && gameControl.canPush)
        {
            if(p1button1 == false && p1button3 == false)
            {
                p1button2 = true;
            }
            AudioManager2.Instance.PlaySFX(btnA);
            G2Buttons[1].sprite = selected;
            order1 += 1;
        }
        if(P1orderG2 && gameControl.canPush)
        {
            p1button2 = true;
            AudioManager2.Instance.PlaySFX(btnA);
            G2Buttons[1].sprite = selected;
            order1 += 1;
        }
    }
    public void P1Button3()
    {
        if(P1orderG1 && gameControl.canPush)
        {
            if(p1button1 == true && p1button2 == true)
            {
                p1button3 = true;
            }
            AudioManager2.Instance.PlaySFX(btnA);
            G2Buttons[2].sprite = selected;
            order1 += 1;
        }
        if(P1orderG2 && gameControl.canPush)
        {
            if(p1button1 == false && p1button2 == false)
            {
                p1button3 = true;
            }
            AudioManager2.Instance.PlaySFX(btnA);
            G2Buttons[2].sprite = selected;
            order1 += 1;
        }
    }
    public void P1OrderGame()
    {
        if(P1orderG1 == true)
        {
            if(order1 == 3)
            {
                Invoke("P1GameOver",0.1f);
                order1 = 0;
            }
        }
        if(P1orderG2 == true)
        {
            if(order1 == 3)
            {
                Invoke("P1GameOver",0.1f);
                order1 = 0;
            }
        }
    }
    void P1Return()
    {
        for(int i=0; i<3; i++)
        {
            G2Buttons[i].sprite = normal;
        }
    }
    void P1GameOver()
    {
        if(P1orderG1)
        {
            if(p1button1 == true && p1button2 == true && p1button3 == true)
            {
                AudioManager2.Instance.PlaySFX(currentA);
                p1button1 = false;
                p1button2 = false;
                p1button3 = false;
                P1orderG1 = false;
                P1orderG2 = true;

                gameControl.gameStart = false;

                for(int i=0; i<3; i++)
                {
                    G2Buttons[i].sprite = correct;
                }
            }
            else
            {
                AudioManager2.Instance.PlaySFX(mistakeA);
                p1button1 = false;
                p1button2 = false;
                p1button3 = false;
                for(int i=0; i<3; i++)
                {
                    G2Buttons[i].sprite = mistake;
                }
                Invoke("P1Return",1f);
            }
        }
        else if(P1orderG2)
        {
            if(p1button1 == true && p1button2 == false && p1button3 == true)
            {
                // Debug.Log("正確");
                AudioManager2.Instance.PlaySFX(currentA);
                p1button1 = false;
                p1button2 = false;
                p1button3 = false;
                P1orderG2 = false;
                P1countG2 = true;

                gameControl.gameStart = false;

                for(int i=0; i<3; i++)
                {
                    G2Buttons[i].sprite = correct;
                }
            }
            else
            {
                AudioManager2.Instance.PlaySFX(mistakeA);
                // Debug.Log("錯誤");
                p1button1 = false;
                p1button2 = false;
                p1button3 = false;
                for(int i=0; i<3; i++)
                {
                    G2Buttons[i].sprite = mistake;
                }
                Invoke("P1Return",1f);
            }
        }
    }

    public void P2Button1()
    {
        if(P2orderG1 && gameControl.canPush)
        {
            if(p2button2 == true && p2button3 == false)
            {
                p2button1 = true;
            }
            AudioManager2.Instance.PlaySFX(btnA);
            G2Buttons[3].sprite = selected;
            order2 += 1;
        }
        if(P2orderG2 && gameControl.canPush)
        {
            if(p2button2 == false && p2button3 == true)
            {
                p2button1 = true;
            }
            AudioManager2.Instance.PlaySFX(btnA);
            G2Buttons[3].sprite = selected;
            order2 += 1;
        }
    }
    public void P2Button2()
    {
        if(P2orderG1 && gameControl.canPush)
        {
            if(p2button1 == false && p2button3 == false)
            {
                p2button2 = true;
            }
            AudioManager2.Instance.PlaySFX(btnA);
            G2Buttons[4].sprite = selected;
            order2 += 1;
        }
        if(P2orderG2 && gameControl.canPush)
        {
            p2button2 = true;
            AudioManager2.Instance.PlaySFX(btnA);
            G2Buttons[4].sprite = selected;
            order2 += 1;
        }
    }
    public void P2Button3()
    {
        if(P2orderG1 && gameControl.canPush)
        {
            if(p2button1 == true && p2button2 == true)
            {
                p2button3 = true;
            }
            AudioManager2.Instance.PlaySFX(btnA);
            G2Buttons[5].sprite = selected;
            order2 += 1;
        }
        if(P2orderG2 && gameControl.canPush)
        {
            if(p2button1 == false && p2button2 == false)
            {
                p2button3 = true;
            }
            AudioManager2.Instance.PlaySFX(btnA);
            G2Buttons[5].sprite = selected;
            order2 += 1;
        }
    }
    public void P2OrderGame()
    {
        if(P2orderG1 == true)
        {
            if(order2 == 3)
            {
                Invoke("P2GameOver",0.1f);
                order2 = 0;
            }
        }
        if(P2orderG2 == true)
        {
            if(order2 == 3)
            {
                Invoke("P2GameOver",0.1f);
                order2 = 0;
            }
        }
    }
    void P2Return()
    {
        for(int i=3; i<6; i++)
        {
            G2Buttons[i].sprite = normal;
        }
    }
    void P2GameOver()
    {
        if(P2orderG1)
        {
            if(p2button1 == true && p2button2 == true && p2button3 == true)
            {
                AudioManager2.Instance.PlaySFX(currentA);
                p2button1 = false;
                p2button2 = false;
                p2button3 = false;
                P2orderG1 = false;
                P2orderG2 = true;

                gameControl.gameStart = false;

                for(int i=3; i<6; i++)
                {
                    G2Buttons[i].sprite = correct;
                }
            }
            else
            {
                AudioManager2.Instance.PlaySFX(mistakeA);
                p2button1 = false;
                p2button2 = false;
                p2button3 = false;
                for(int i=3; i<6; i++)
                {
                    G2Buttons[i].sprite = mistake;
                }
                Invoke("P2Return",1f);
            }
        }
        else if(P2orderG2)
        {
            if(p2button1 == true && p2button2 == false && p2button3 == true)
            {
                AudioManager2.Instance.PlaySFX(currentA);
                p2button1 = false;
                p2button2 = false;
                p2button3 = false;
                P2orderG2 = false;
                P2countG2 = true;

                gameControl.gameStart = false;

                for(int i=3; i<6; i++)
                {
                    G2Buttons[i].sprite = correct;
                }
            }
            else
            {
                AudioManager2.Instance.PlaySFX(mistakeA);
                p2button1 = false;
                p2button2 = false;
                p2button3 = false;
                for(int i=3; i<6; i++)
                {
                    G2Buttons[i].sprite = mistake;
                }
                Invoke("P2Return",1f);
            }
        }
    }
}
