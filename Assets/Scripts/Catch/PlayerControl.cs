using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool moveLeft;
    private bool moveRight;
    private float horizontalMove;
    public float speed = 5;

    public Transform m_BagObj = null;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveLeft = false;
        moveRight = false;
    }

    public void PointerDownLeft() {
        moveLeft = true;
        m_BagObj.localPosition = new Vector3(-70, 0, 0);
    }
    public void PointerUpLeft()
    {
        moveLeft = false;
    }

    public void PonterDownRight() {
        moveRight = true;
        m_BagObj.localPosition = new Vector3(70, 0, 0);
    }

    public void PonterUpRight()
    {
        moveRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        MovementPlayer();
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

    //add the movement force to the player
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
    }
}