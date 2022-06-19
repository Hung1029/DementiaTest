using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PagesSwitch : MonoBehaviour
{
    public string scenename;
    public GameObject pageinit;
    public GameObject pageNoviceTeaching;
    public GameObject pagesettings;
    public GameObject modalsignin;
    public GameObject modalKnowledge;
    public GameObject Day1seal;
    public bool isNewbie;
    public bool pNewbie;
    public bool p2;
    public int time;
    // Start is called before the first frame update
    void Start()
    {
        // if(!isNewbie)
        // {
        //     pageMain.SetActive(true);
        //     pageNoviceTeaching.SetActive(false);
        // }
        // else
        // {
        //     pageMain.SetActive(false);
        //     pageNoviceTeaching.SetActive(true);
        // }
        pNewbie = false;
        p2 = false;
        modalsignin.SetActive(false);
        modalKnowledge.SetActive(false);
        // Time();
    }
    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.Day1missioncompleted)
        {
            Day1seal.SetActive(true);
        }
        else
        {
            Day1seal.SetActive(false);
        }
    }
    public void GameStart()
    {
        pageinit.SetActive(false);
    }
    void Time()
    {
        Invoke("InitPageToPageMain",time);
    }
    void InitPageToPageMain()
    {
        pageinit.SetActive(false);
        if(!isNewbie)
        {
            pageNoviceTeaching.SetActive(false);
        }
        else
        {
            pageNoviceTeaching.SetActive(true);
            pNewbie = true;
        }
    }
    public void SwitchtoPages_GameList()
    {
        
    }
    public void SwitchtoPages_Setting()
    {
         pagesettings.SetActive(true);
    }
    public void SignIn()
    {
        modalsignin.SetActive(true);
    }
    public void SignInBac()
    {
        modalsignin.SetActive(false);
    }
    public void Knowledge()
    {
        modalKnowledge.SetActive(true);
    }
    public void KnowledgeBac()
    {
        modalKnowledge.SetActive(false);
    }
    public void GoToGameScene()
    {
        SceneManager.LoadScene(scenename);
    }
}
