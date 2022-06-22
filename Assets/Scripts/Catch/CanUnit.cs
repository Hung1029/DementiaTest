using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanUnit : UnitBase
{
    private void Update()
    {
        if (transform.localPosition.y < -890)
        {
            Destroy(gameObject);
        }
    }
}
