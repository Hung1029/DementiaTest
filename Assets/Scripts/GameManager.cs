using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gameStart;
    public bool ordergameStart;
    public bool ordergame1Start;
    public bool ordergame2Start;
    public GameObject[] Can;
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
