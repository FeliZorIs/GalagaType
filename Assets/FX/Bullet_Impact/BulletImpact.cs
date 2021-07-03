using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletImpact : MonoBehaviour
{
    Animator anim;
    int impact_int = 0;

    float timer = 0;
    public float ttk;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        impact_int = Random.Range(1, 3);
        anim.SetInteger("Impact", impact_int);
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= ttk)
        {
            Destroy(this.gameObject);
        }
    }
}
