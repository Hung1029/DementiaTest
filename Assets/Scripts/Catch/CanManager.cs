using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanManager : MonoBehaviour
{
    public UnitBase[] m_Clone = null;

    public Transform m_CanNode = null;

    private float m_Delay = 0;

    private void Start()
    {
        m_Delay = Time.time + 1;
    }

    private void Update()
    {
        if (m_Delay < Time.time)
        {
            m_Delay = Time.time + 1;
            CreateCan();
        }
    }

    private void CreateCan() 
    {
        int r = Random.Range(0, 18);
        UnitBase unit = null;
        if (r < 5)
        {
            unit = m_Clone[0];
        }
        else if (r > 5 && r < 10)
        {
            unit = m_Clone[1];
        }
        else {

            unit = m_Clone[2];
        }

        UnitBase createUnit = Instantiate<UnitBase>(unit, m_CanNode);
        unit.transform.localPosition = new Vector3(Random.Range(-1000f, 1000f), 1000, 0);

    }
}
