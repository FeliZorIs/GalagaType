using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float health;
    public float score;

    public GameObject edge;
    public GameObject box;
    public GameObject particle_effect;

    EdgeCollider2D edge_c;
    BoxCollider2D box_c;

    Vector2 screenBounds;

    Camera cam;

    float width;
    float height;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToViewportPoint(new Vector3(Screen.width,Screen.height));
        cam = Camera.main;

        edge_c = edge.GetComponent<EdgeCollider2D>();
        box_c = box.GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(this.GetComponent<PolygonCollider2D>(), edge_c, true);
        Physics2D.IgnoreCollision(this.GetComponent<PolygonCollider2D>(), box_c, true);
        findBoundries();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        if (this.transform.position.y <= -height/2)
        {
            Debug.Log(transform.position.y);
            Debug.Log(-height);
            Destroy(this.gameObject);
        }

        if (health <= 0)
        {
            playParticleEffect();
            Destroy(this.gameObject);
        }
    }

    void findBoundries()
    {
        width = 1 / (cam.WorldToViewportPoint(new Vector3(1, 1, 0)).x - .5f);
        height = 1 / (cam.WorldToViewportPoint(new Vector3(1, 1, 0)).y - .5f);
    }

    void playParticleEffect()
    { 
    
    }
}
