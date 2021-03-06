using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DegreeOfDifficulty : MonoBehaviour
{
    [SerializeField] AudioData btnA;
    public string scenename;
    
    public Text game1;
    public int num1;
    
    public Text game2;
    public int num2;
    
    public Text game3;
    public int num3;

    // Start is called before the first frame update
    void Start()
    {
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
            game1.text = "簡易";
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
    public void Num1add()
    {
        if(num1<3)
        {
            num1 += 1;
        }
        AudioManager.Instance.PlaySFX(btnA);
    }
    public void Num1reduce()
    {
        if(num1>1)
        {
            num1 -= 1;
        }
        AudioManager.Instance.PlaySFX(btnA);
    }
    void Game2Degree()
    {
        if(num2 == 1)
        {
            game2.text = "簡易";
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
        AudioManager.Instance.PlaySFX(btnA);
    }
    public void Num2reduce()
    {
        if(num2>1)
        {
            num2 -= 1;
        }
        AudioManager.Instance.PlaySFX(btnA);
    }
    void Game3Degree()
    {
        if(num3 == 1)
        {
            game3.text = "簡易";
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
        AudioManager.Instance.PlaySFX(btnA);
    }
    public void Num3reduce()
    {
        if(num3>1)
        {
            num3 -= 1;
        }
        AudioManager.Instance.PlaySFX(btnA);
    }
    public void GameStart()
    {
        AudioManager.Instance.PlaySFX(btnA);
        SceneManager.LoadScene(scenename);
    }
}
