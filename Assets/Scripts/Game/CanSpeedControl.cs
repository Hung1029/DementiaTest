using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanSpeedControl : MonoBehaviour
{
    GameControl gameControl;
    RectTransform rectTransform;
    public float speedX;
    public GameObject moveend;
    public bool gamestart;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        
        gameControl = GameObject.Find("GameControl").GetComponent<GameControl>();
    }

    // Update is called once per frame
    void Update()
    {
        CanMove();
    }

    void CanMove()
    {
        if(gameControl.gameStart == true)
        {
            gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, moveend.transform.localPosition,speedX*Time.deltaTime);
        }
    }
}
