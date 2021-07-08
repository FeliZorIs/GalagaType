using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    public float ttk;

    // Start is called before the first frame update
    void Start()
    {
        //default timer
        if (ttk == 0)
        {
            ttk = 1f;
        }

        Destroy(this.gameObject, ttk);
    }
}
