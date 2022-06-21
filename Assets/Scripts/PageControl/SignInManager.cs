using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignInManager : MonoBehaviour
{
    public GameObject K_music;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.Day1missioncompleted)
        {
            K_music.SetActive(true);
        }
        else
        {
            K_music.SetActive(false);
        }
    }
}
