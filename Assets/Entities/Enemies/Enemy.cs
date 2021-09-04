using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float health;
    public float score;

    public GameObject bulletImpact;
    public GameObject particle_effect;
    public GameObject sparks;

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
            death();
        }
    }

    //===================================== Functions ======================================
    void findBoundries()
    {
        width = 1 / (cam.WorldToViewportPoint(new Vector3(1, 1, 0)).x - .5f);
        height = 1 / (cam.WorldToViewportPoint(new Vector3(1, 1, 0)).y - .5f);
    }

    void randomExplosion()
    {
        int ranNum = Random.Range(1, 5);

        if (ranNum == 1)
            FindObjectOfType<AudioManager>().Play("explosion_1");
        else if (ranNum == 2)
            FindObjectOfType<AudioManager>().Play("explosion_2");
        else if (ranNum == 3)
            FindObjectOfType<AudioManager>().Play("explosion_3");
        else
            FindObjectOfType<AudioManager>().Play("explosion_4");
    }

    public void hitNoise()
    {
        int ranNum = Random.Range(1, 4);

        if (ranNum == 1)
            FindObjectOfType<AudioManager>().Play("hit_1");
        else if (ranNum == 2)
            FindObjectOfType<AudioManager>().Play("hit_2");
        else
            FindObjectOfType<AudioManager>().Play("hit_3");
    }

    public void deflectNoise()
    {
        int ranNum = Random.Range(1, 4);

        if(ranNum == 1)
            FindObjectOfType<AudioManager>().Play("deflect_1");
        if(ranNum == 2)
            FindObjectOfType<AudioManager>().Play("deflect_2");
        else
            FindObjectOfType<AudioManager>().Play("deflect_3");
    }

    void death()
    {
        Instantiate(particle_effect, this.transform.position, Quaternion.identity);
        cam.GetComponent<CameraShake>().shouldShake = true;
        randomExplosion();
        Destroy(this.gameObject);
    }

    public void impact(GameObject PE, Vector3 position)
    {
        Instantiate(PE, position, Quaternion.identity);
    }


    //===================================== Collisions ======================================
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "GameScreen")
        {
            Physics2D.IgnoreCollision(this.GetComponent<PolygonCollider2D>(), collision.collider, true);
        }

        if (collision.transform.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().health -= 1;
            death();
        }
    }
}
