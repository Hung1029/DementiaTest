using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool moveLeft;
    private bool moveRight;
    private float horizontalMove;
    public float speed = 5;

    public Transform m_BagObj = null;

    public bool m_IsGameOver = false;

    public Sprite m_Image_normal = null;
    public Sprite m_Image_plus = null;
    public Sprite m_Image_reduce = null;

    public Image m_bag=null;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveLeft = false;
        moveRight = false;       
    }

    public void SetState(int state) {

        if (state == 1)
        {
            Debug.Log("1");
            m_bag.sprite = m_Image_plus;
            Invoke("ResetState", 0.5f);
        }
        else 
        {
            Debug.Log("2");
            m_bag.sprite = m_Image_reduce;
            Invoke("ResetState", 0.5f);
        }
    
    }
    private void ResetState() {
        m_bag.sprite = m_Image_normal;
    }

    public void PointerDownLeft() {
        moveLeft = true;
        // m_BagObj.localPosition = new Vector3(-70, 0, 0);
    }
    public void PointerUpLeft()
    {
        moveLeft = false;
    }

    public void PonterDownRight() {
        moveRight = true;
        // m_BagObj.localPosition = new Vector3(70, 0, 0);
    }

    public void PonterUpRight()
    {
        moveRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        MovementPlayer();
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
    }

    private void MovementPlayer()
    {
        // If press the left button
        if (moveLeft && transform.localPosition.x >-890)
        {
            horizontalMove = -speed;
        }
        // If press the right button
        else if (moveRight && transform.localPosition.x<890)
        {
            horizontalMove = speed;
        }
        // if not pressing any button
        else 
        {
            horizontalMove = 0;  
        }
    
    }
   
}
