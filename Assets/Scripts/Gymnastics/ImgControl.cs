using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImgControl : MonoBehaviour
{
    [SerializeField] AudioData btnA;
    public GameObject SportImg;
    public GameObject sport1;
    public GameObject sport1_start;
    Image image1;
    Image image1_start;
    private float i;
    private float a;
    public float fadspeed = 0.1f;
    public int time;
    public bool img1;
    public bool sportStart;
    // Start is called before the first frame update
    void Start()
    {
        image1 = sport1.GetComponent<Image>();
        image1_start = sport1_start.GetComponent<Image>();
        i=0;
        a=0;
        SportImg.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // FadeIn();
        if(img1 == true)
        {
            sport1.SetActive(true);
            // FadeIn();
            Invoke("FadeIn1",time);
            Invoke("Sport1_start_imgControl",3f);
        }
        else
        {
            i=0;
            sport1.SetActive(false);
        }
        if(sportStart == true)
        {
            sport1_start.SetActive(true);
            // FadeIn();
            Invoke("FadeIn2",time);
        }
        else
        {
            a=0;
            sport1_start.SetActive(false);
        }
    }
    void Sport1_start_imgControl()
    {
        img1 = false;
        sportStart = true;
    }
    void FadeIn1()
    {
        i += fadspeed*Time.deltaTime;
        if(i>=255)
        {
            i=255;
        }
        image1.color = new Color(image1.color.r, image1.color.g, image1.color.b, i);
    }
    void FadeIn2()
    {
        a += fadspeed*Time.deltaTime;
        if(a>=255)
        {
            a=255;
        }
        image1_start.color = new Color(image1_start.color.r, image1_start.color.g, image1_start.color.b, a);
    }
    public void Sport_start()
    {
        AudioManager.Instance.PlaySFX(btnA);
        SportImg.SetActive(true);
        img1 = true;
    }
    public void SportBac()
    {
        AudioManager.Instance.PlaySFX(btnA);
        img1 = false;
        sportStart = false;
        SportImg.SetActive(false);
    }
}
