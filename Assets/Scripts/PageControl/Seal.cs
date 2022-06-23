using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Seal : MonoBehaviour
{
    Image image;
    private float i;
    public float fadspeed = 0.1f;
    public float time;
    public float scale;
    public bool stamp;
    private bool stamped;
    public GameObject knowledgeMusic;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        i=30;
        stamped = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(stamp == true && stamped == false)
        {
            Invoke("Stamp",0.1f);
        }
    }
    void Stamp()
    {
        Invoke("FadeIn",time);
        ZoomOut();
        Invoke("KnowledgeMusic",1f);
    }
    void KnowledgeMusic()
    {
        knowledgeMusic.SetActive(true);
        stamp = false;
        GameManager.instance.Day1stamped = true;
        stamped = true;
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
    void ZoomOut()
    {
        if(gameObject.transform.localScale.x > 1)
        {
            this.gameObject.transform.localScale += new Vector3(-scale,-scale,0f);
        }
        if(gameObject.transform.localScale.x <=1)
        {
            this.gameObject.transform.localScale = new Vector3(1,1,1);
        }
    }
}
