using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Image Dpad_sprite;
    SpriteRenderer blue_button_sprite;
    SpriteRenderer red_button_sprite;

    GameObject sprite;

    GameObject MuzzleFlash_blue;
    GameObject MuzzleFlash_red;
    [SerializeField]Transform bullet_pos_L;
    [SerializeField]Transform bullet_pos_R;
    public GameObject bullet_blue;
    public GameObject bullet_red;

    Vector3 lastFramePosition;

    public float speed;
    public float turn_angle;
    public float turn_speed;

    public GameObject Dpad_sr;
    public Sprite[] Dpad_sprites;

    bool up, down, left, right,
         upLeft, upRight, downLeft, downRight;

    bool moving;
    bool shot_blue, shot_red;

    public GameObject button_blue;
    public GameObject button_red;
    public Sprite[] Buttons;

    public float time_delay;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GameObject.Find("Player/Sprite");
        MuzzleFlash_blue = GameObject.Find("Player/Sprite/MuzzleFlash_Blue");
        MuzzleFlash_red = GameObject.Find("Player/Sprite/MuzzleFlash_Red");
        MuzzleFlash_blue.SetActive(false);
        MuzzleFlash_red.SetActive(false);

        bullet_pos_L = GameObject.Find("Player/Sprite/Bullet_Spawn_L").transform;
        bullet_pos_R = GameObject.Find("Player/Sprite/Bullet_Spawn_R").transform;

        rb = GetComponent<Rigidbody2D>();
        Dpad_sprite = Dpad_sr.gameObject.GetComponent<Image>();
        //neutral   = 0
        //up        = 1     upleft      = 5
        //down      = 2     upright     = 6
        //left      = 3     downleft    = 7
        //right     = 4     downright   = 8

        blue_button_sprite = button_blue.gameObject.GetComponent<SpriteRenderer>();
        red_button_sprite = button_red.gameObject.GetComponent<SpriteRenderer>();
        //Blue Button_UP    = 0     Red Button_UP   = 2
        //Blut Button_DOWN  = 1     Red Button_DOWN = 3

        up = false;
        moving = false;
        shot_blue = false;
        shot_red = false;
        lastFramePosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement_buttons();

        //rotates plane when you move left or right
        var delta = transform.position - lastFramePosition;
        if (left || upLeft || downLeft) //to the left
        {
            //sprite.transform.Rotate(new Vector3(0, 0, turn_speed * Time.deltaTime));
            sprite.transform.eulerAngles = new Vector3(0, 0, 15);
        }
        if(right || upRight || downRight) //to the right
        {
            //sprite.transform.Rotate(new Vector3(0, 0, -turn_speed * Time.deltaTime));
            sprite.transform.eulerAngles = new Vector3(0, 0, -15);
        }
        lastFramePosition = transform.position;

        shooting();
    }
    
    //dictates moving with the D-pad
    public void movement_buttons()
    {
        if (moving == false)
        {
            flightCorrections();
        }

        //base sprite for the D_pad. a simple '+'
        Dpad_sprite.sprite = Dpad_sprites[0];

        if (up)
        {
            Dpad_sprite.sprite = Dpad_sprites[1]; 
            this.transform.Translate(Vector2.up * speed * Time.deltaTime);
            flightCorrections();
        }

        if (down)
        {
            Dpad_sprite.sprite = Dpad_sprites[2];
            this.transform.Translate(Vector2.down * speed * Time.deltaTime);
            flightCorrections();
        }

        if (left)
        {
            Dpad_sprite.sprite = Dpad_sprites[3];
            this.transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if (right)
        { 
            Dpad_sprite.sprite = Dpad_sprites[4];
            this.transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        if (upLeft)
        {
            Dpad_sprite.sprite = Dpad_sprites[5];
            this.transform.Translate(Vector2.up * speed * Time.deltaTime);
            this.transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if (upRight)
        {
            Dpad_sprite.sprite = Dpad_sprites[6];
            this.transform.Translate(Vector2.up * speed * Time.deltaTime);
            this.transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        if (downLeft)
        {
            Dpad_sprite.sprite = Dpad_sprites[7];
            this.transform.Translate(Vector2.down * speed * Time.deltaTime);
            this.transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if (downRight)
        {
            Dpad_sprite.sprite = Dpad_sprites[8];
            this.transform.Translate(Vector2.down * speed * Time.deltaTime);
            this.transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    float timer = 0;
    bool Switch = false;
    public void shooting()
    {
        timer += Time.deltaTime;
        if (shot_blue && !shot_red) //blue shots
        {
            if (timer >= time_delay && Switch == false)
            {
                Instantiate(bullet_blue, bullet_pos_L.position, Quaternion.identity);
                Switch = true;
                timer = 0;
            }
            if (timer >= time_delay && Switch == true)
            {
                Instantiate(bullet_blue, bullet_pos_R.position, Quaternion.identity);
                Switch = false;
                timer = 0;
            }
        }

        else if (shot_red && !shot_blue) //red shots
        {
            if (timer >= time_delay && Switch == false)
            {
                Instantiate(bullet_red, bullet_pos_L.position, Quaternion.identity);
                Switch = true;
                timer = 0;
            }
            if (timer >= time_delay && Switch == true)
            {
                Instantiate(bullet_red, bullet_pos_R.position, Quaternion.identity);
                Switch = false;
                timer = 0;
            };
        }
    }

    //========================= Called By Buttons (Canvas > ButtonArea > D-pad > buttons...) =============================

    //up    = 1         upLeft      = 5         Blue Button_UP  = 0
    //down  = 2         upRight     = 6         Blue Button_Down= 1
    //left  = 3         downLeft    = 7         Red Button_UP   = 2
    //right = 4         downRight   = 8         Red Button_Down = 3
    public void MOVE(int direction)
    {
        switch (direction) 
        {
            case 1:
                up = move_bool(up);
                break;

            case 2:
                down = move_bool(down);
                break;

            case 3:
                left = move_bool(left);
                break;

            case 4:
                right = move_bool(right);
                break;

            case 5:
                upLeft = move_bool(upLeft);
                break;

            case 6:
                upRight = move_bool(upRight);
                break;

            case 7:
                downLeft = move_bool(downLeft);
                break;

            case 8:
                downRight = move_bool(downRight);
                break;
        }
    }

    bool move_bool(bool direction)
    {
        if (direction == false)
        {
            direction = true;
            moving = true;
        }
        else
        {
            direction = false;
            moving = false;
        }

        return direction;
    }

    //allows to shoot the blue bullets
    public void shoot_blue()
    {
        if (shot_blue == false)
        {
            shot_blue = true;
            blue_button_sprite.sprite = Buttons[1];
            MuzzleFlash_blue.SetActive(true);
        }
        else
        {
            shot_blue = false;
            blue_button_sprite.sprite = Buttons[0];
            MuzzleFlash_blue.SetActive(false);
        }
    }

    //allows to shoot the red bullets
    public void shoot_red()
    {
        if (shot_red == false)
        {
            shot_red = true;
            red_button_sprite.sprite = Buttons[3];
            MuzzleFlash_red.SetActive(true);
        }
        else
        {
            shot_red = false;
            red_button_sprite.sprite = Buttons[2];
            MuzzleFlash_red.SetActive(false);
        }
    }

    //================================================ Miscellaneous ===========================================

    //so the phone vibrates
    public void vibrate()
    {
        Vibration.Vibrate(50);
    }

    //when the plane rotates to the side, it straightens it back to neutral
    void flightCorrections()
    {
        float temp_speed = 7.5f * turn_speed;
        if (sprite.transform.rotation.z >= 0.01f)//from the left
        {
            sprite.transform.Rotate(new Vector3(0, 0, -temp_speed/2 * Time.deltaTime));
        }

        if (sprite.transform.rotation.z <= -0.01f)//from the right
        {
            sprite.transform.Rotate(new Vector3(0, 0, temp_speed/2 * Time.deltaTime));
        }
    }
}