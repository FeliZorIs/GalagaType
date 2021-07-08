using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float health;
    public float score;

    public GameObject particle_effect;

    Camera cam;

    float width;
    float height;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        findBoundries();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        if (this.transform.position.y <= -height/2)
        {
            Destroy(this.gameObject);
        }

        if (health <= 0)
        {
            Instantiate(particle_effect, this.transform.position, Quaternion.identity);
            cam.GetComponent<CameraShake>().shouldShake = true;
            Destroy(this.gameObject);
        }
    }

    void findBoundries()
    {
        width = 1 / (cam.WorldToViewportPoint(new Vector3(1, 1, 0)).x - .5f);
        height = 1 / (cam.WorldToViewportPoint(new Vector3(1, 1, 0)).y - .5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "GameScreen")
        {
            Physics2D.IgnoreCollision(this.GetComponent<PolygonCollider2D>(), collision.collider, true);
        }
    }
}
