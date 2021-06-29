using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Size : MonoBehaviour
{
    public float x_size;
    public float y_size;

    Vector2 screenBounds;
    RectTransform rt;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToViewportPoint(new Vector3(Screen.width, Camera.main.pixelHeight));
        this.transform.localScale = new Vector3(screenBounds.x, screenBounds.y, 0);
        rt = this.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(screenBounds.x, screenBounds.y);

        Debug.Log("Screen Width" + screenBounds.x + "\n" +
                  "Screen Height" + screenBounds.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
