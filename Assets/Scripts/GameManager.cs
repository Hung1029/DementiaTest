using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool Day1missioncompleted;
    public bool Day1stamped;
    
    public static GameManager instance;
    public bool isNewbie;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
           DontDestroyOnLoad(this);

        }
        else if (this != instance)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
