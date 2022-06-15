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
    public int num1;
    
    public Sprite game2img1;
    public Sprite game2img2;
    public Text game2;
    public Image Game2;
    public int num2;
    
    public Sprite game3img1;
    public Sprite game3img2;
    public Text game3;
    public Image Game3;
    public int num3;

    // Start is called before the first frame update
    void Start()
    {
        // Game1 = Game1.GetComponent<Image>();
        // Game2 = Game2.GetComponent<Image>();
        // Game3 = Game3.GetComponent<Image>();
        game1 = game1.GetComponent<Text>();
        game2 = game2.GetComponent<Text>();
        game3 = game3.GetComponent<Text>();
        num1 = 1;
        num2 = 1;
        num3 = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Game1Degree();
        Game2Degree();
        Game3Degree();
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
    // public void CanChange1()
    // {
    //     if(number == false)
    //     {
    //         Game1.sprite = game1img2;
    //         number = true;
    //     }
    //     else
    //     {
    //         Game1.sprite = game1img1;
    //         number = false;
    //     }
    // }
    // public void Hover1()
    // {
    //     Game1.sprite = game1img2;
    // }
    public void Num1add()
    {
        if(num1<3)
        {
            num1 += 1;
        }
    }
    public void Num1reduce()
    {
        if(num1>1)
        {
            num1 -= 1;
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
    
    public void Num2add()
    {
        if(num2<3)
        {
            num2 += 1;
        }
    }
    public void Num2reduce()
    {
        if(num2>1)
        {
            num2 -= 1;
        }
    }
    void Game3Degree()
    {
        if(num3 == 1)
        {
            game3.text = "簡單";
        }
        else if(num3 == 2)
        {
            game3.text = "普通";
        }
        else
        {
            game3.text = "困難";
        }
    }
    
    public void Num3add()
    {
        if(num3<3)
        {
            num3 += 1;
        }
    }
    public void Num3reduce()
    {
        if(num3>1)
        {
            num3 -= 1;
        }
    }
    public void GameStart()
    {
        Debug.Log("GoGo");
        SceneManager.LoadScene(scenename);
    }
}
