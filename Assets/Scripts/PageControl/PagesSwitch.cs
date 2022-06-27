using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PagesSwitch : MonoBehaviour
{
    [SerializeField] AudioData btnA;
    public string scenename;
    
    public GameObject pagesettings;
    public GameObject modalsignin;
    public GameObject modalKnowledgeReview;
    public GameObject modalMusic;
    public GameObject Day1seal;
    public GameObject Day1stamped;
    public GameObject Useteaching;
    public bool isNewbie;
    
    // Start is called before the first frame update
    void Start()
    {
        if(!GameManager.instance.isNewbie)
        {
            Useteaching.SetActive(false);
        }
        else
        {
            Useteaching.SetActive(true);
        }
        Invoke("Noviceteaching",10f);
        modalsignin.SetActive(false);
        modalKnowledgeReview.SetActive(false);
        modalMusic.SetActive(false);
        Day1seal.SetActive(false);
        pagesettings.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.Day1stamped)
        {
            Day1seal.SetActive(false);
            Day1stamped.SetActive(true);
        }
    }
    void Noviceteaching()
    {
        Useteaching.SetActive(false);
        GameManager.instance.isNewbie = false;
    }
    public void SwitchtoPages_GameList()
    {
        
    }
    public void SwitchtoPages_Setting()
    {
        AudioManager.Instance.PlaySFX(btnA);
        pagesettings.SetActive(true);
    }
    public void SwitchtoPages_SettingBac()
    {
        AudioManager.Instance.PlaySFX(btnA);
        pagesettings.SetActive(false);
    }
    public void SignIn()
    {
        AudioManager.Instance.PlaySFX(btnA);
        modalsignin.SetActive(true);
        if(GameManager.instance.Day1missioncompleted)
        {
            Day1seal.GetComponent<Seal>().stamp = true;
            Invoke("Stamp",1f);
        }
    }
    void Stamp()
    {
        Day1seal.SetActive(true);
    }
    public void SignInBac()
    {
        AudioManager.Instance.PlaySFX(btnA);
        modalsignin.SetActive(false);
    }
    public void KnowledgeReview()
    {
        AudioManager.Instance.PlaySFX(btnA);
        modalKnowledgeReview.SetActive(true);
    }
    public void KnowledgeReviewBac()
    {
        AudioManager.Instance.PlaySFX(btnA);
        modalKnowledgeReview.SetActive(false);
    }
    public void KnowledgeMusic()
    {
        AudioManager.Instance.PlaySFX(btnA);
        modalMusic.SetActive(true);
    }
    public void KnowledgeMusicBac()
    {
        AudioManager.Instance.PlaySFX(btnA);
        modalMusic.SetActive(false);
    }
    public void GoToGameScene()
    {
        SceneManager.LoadScene(scenename);
    }
}
