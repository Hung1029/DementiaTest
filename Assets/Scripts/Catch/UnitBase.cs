using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBase : MonoBehaviour
{
    public int m_Score= 0;
    public Rigidbody2D m_Rigidbody2D = null;

    // 0:normal  1:plus  2:reduce
    public int Player_State = 0;


    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerControl pc = collision.transform.parent.GetComponent<PlayerControl>();

        if (pc != null)
        {
            if (collision.gameObject.name == "Bag")
            {
                pc.SetState(Player_State);
                Destroy(gameObject);
                ScoreManager.AddScore(m_Score);
            }
        }
    }
    


}
