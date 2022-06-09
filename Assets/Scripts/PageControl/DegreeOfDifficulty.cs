using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DegreeOfDifficulty : MonoBehaviour
{
    public string scenename;
    public Sprite game1img1;
    public Sprite game1img2;
    public Text game1;
    public Image Game1;
    int num1;
    public bool number;
    public Sprite game2img1;
    public Sprite game2img2;
    public Text game2;
    public Image Game2;
    int num2;
    public bool remember;
    public Sprite game3img1;
    public Sprite game3img2;
    public Text workout;
    public Image Game3;
    int num3;
    public bool gymnastics;

    public Sprite Amorimg1;
    public Sprite Amorimg2;
    public Image AmorStart;
    // Start is called before the first frame update
    void Start()
    {
        Game1 = Game1.GetComponent<Image>();
        Game2 = Game2.GetComponent<Image>();
        Game3 = Game3.GetComponent<Image>();
        AmorStart = AmorStart.GetComponent<Image>();
        game1 = game1.GetComponent<Text>();
        game2 = game2.GetComponent<Text>();
        workout = workout.GetComponent<Text>();
        num1 = 1;
        num2 = 1;
        num3 = 1;
        number = false;
        remember = false;
        gymnastics = false;
    }

    // Update is called once per frame
    void Update()
    {
        Game1Degree();
        Game2Degree();
        WorkOutDegree();
    }
    void Game1Degree()
    {
        if(num1 == 1)
        {
            game1.text = "簡單";
        }
        else if(num1 == 2)
        {
            game1.text = "普通";
        }
        else
        {
            game1.text = "困難";
        }
    }
    public void CanChange1()
    {
        if(number == false)
        {
            Game1.sprite = game1img2;
            number = true;
        }
        else
        {
            Game1.sprite = game1img1;
            number = false;
        }
    }
    public void Hover1()
    {
        Game1.sprite = game1img2;
    }
    public void Num1add()
    {
        if(number)
        {
            if(num1<3)
            {
                num1 += 1;
            }
        }
    }
    public void Num1reduce()
    {
        if(number)
        {
            if(num1>1)
            {
                num1 -= 1;
            }
        }
    }
    void Game2Degree()
    {
        if(num2 == 1)
        {
            game2.text = "簡單";
        }
        else if(num2 == 2)
        {
            game2.text = "普通";
        }
        else
        {
            game2.text = "困難";
        }
    }
    public void CanChange2()
    {
        if(remember == false)
        {
            Game2.sprite = game2img2;
            remember = true;
        }
        else
        {
            Game2.sprite = game2img1;
            remember = false;
        }
    }
    public void Hover2()
    {
        Game2.sprite = game2img2;
    }
    public void Num2add()
    {
        if(remember)
        {
            if(num2<3)
            {
                num2 += 1;
            }
        }
    }
    public void Num2reduce()
    {
        if(remember)
        {
            if(num2>1)
            {
                num2 -= 1;
            }
        }
    }
    void WorkOutDegree()
    {
        if(num3 == 1)
        {
            workout.text = "簡單";
        }
        else if(num3 == 2)
        {
            workout.text = "普通";
        }
        else
        {
            workout.text = "困難";
        }
    }
    public void CanChange3()
    {
        if(gymnastics == false)
        {
            Game3.sprite = game3img2;
            gymnastics = true;
        }
        else
        {
            Game3.sprite = game3img1;
            gymnastics = false;
        }
    }
    public void Hover3()
    {
        Game3.sprite = game3img2;
    }
    public void Num3add()
    {
        if(gymnastics)
        {
            if(num3<3)
            {
                num3 += 1;
            }
        }
    }
    public void Num3reduce()
    {
        if(gymnastics)
        {
            if(num3>1)
            {
                num3 -= 1;
            }
        }
    }
    public void GameStart()
    {
        Debug.Log("GoGo");
        SceneManager.LoadScene(scenename);
    }
    public void GameStartHover()
    {
        AmorStart.sprite = Amorimg2;
    }
}
