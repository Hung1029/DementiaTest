using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBase : MonoBehaviour
{
    public int m_Score= 1;
    public Rigidbody2D m_Rigidbody2D = null;

 


    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerControl pc = collision.transform.parent.GetComponent<PlayerControl>();

        if (pc != null)
        {
            if (collision.gameObject.name == "Bag")
            {
                Destroy(gameObject);
                ScoreManager.AddScore(m_Score);

            }
        }
    }
    


}
