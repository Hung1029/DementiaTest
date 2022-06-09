using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ImageFaded : MonoBehaviour
{
    Image image;
    private float i;
    public float fadspeed = 0.1f;
    public int time;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        i=0;
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("FadeIn",time);
        // Fade();
    }
    void FadeIn()
    {
        i += fadspeed*Time.deltaTime;
        if(i>=255)
        {
            i=255;
        }
        image.color = new Color(image.color.r, image.color.g, image.color.b, i);
    }
}
