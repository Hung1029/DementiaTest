using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PagesSwitch : MonoBehaviour
{
    public string scenename;
    public GameObject pageinit;
    public GameObject pageMain;
    public GameObject pageNoviceTeaching;
    public GameObject[] page2;
    public bool isNewbie;
    public bool pMain;
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
        for(int i=0; i<4; i++)
        {
            page2[i].SetActive(false);
        }
        pMain = false;
        pNewbie = false;
        p2 = false;
        // Time();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameStart()
    {
        pageinit.SetActive(false);
        page2[0].SetActive(true);
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
            pageMain.SetActive(true);
            pageNoviceTeaching.SetActive(false);
            pMain = true;
        }
        else
        {
            pageMain.SetActive(false);
            pageNoviceTeaching.SetActive(true);
            pNewbie = true;
        }
    }
    public void SwitchtoPages_GameList()
    {
        pageMain.SetActive(false);
        for(int i=0; i<4; i++)
        {
            page2[i].SetActive(false);
        }
        page2[0].SetActive(true);
    }
    public void SwitchtoPages_TasksList()
    {
        pageMain.SetActive(false);
        for(int i=0; i<4; i++)
        {
            page2[i].SetActive(false);
        }
        page2[1].SetActive(true);
    }
    public void SwitchtoPages_Reward()
    {
        pageMain.SetActive(false);
        for(int i=0; i<4; i++)
        {
            page2[i].SetActive(false);
        }
        page2[2].SetActive(true);
    }
    public void SwitchtoPages_Setting()
    {
        //第一頁去第二頁
        pageMain.SetActive(false);
        for(int i=0; i<4; i++)
        {
            page2[i].SetActive(false);
        }
        page2[3].SetActive(true);
    }
    public void SwitchtoMain()
    {
        //第二頁去第一頁
        pageMain.SetActive(true);
        for(int i=0; i<4; i++)
        {
            page2[i].SetActive(false);
        }
    }
    public void GoToGameScene()
    {
        SceneManager.LoadScene(scenename);
    }
}
