using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_start : MonoBehaviour
{
    [SerializeField]Text text_starting;
    public float fadeSpeed;
    // Start is called before the first frame update
    void Start()
    {
        text_starting = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text_starting.color = new Vector4(text_starting.color.r, text_starting.color.g, text_starting.color.b, text_starting.color.a - fadeSpeed * Time.deltaTime);
    }
}
