using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Initial : MonoBehaviour
{
    [SerializeField] AudioData projectileLaunchSFX;
  
    public string scenename;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GoToGameScene()
    {
        AudioManager.Instance.PlaySFX(projectileLaunchSFX);
        SceneManager.LoadScene(scenename);
    }
}
