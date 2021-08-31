using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver_buttons : MonoBehaviour
{
    public GameObject button_restart;
    public GameObject button_mainMenu;

    Image image_restart;
    Image image_mainMenu;

    public Sprite[] sprite_buttons;

    bool held;

    // Start is called before the first frame update
    void Start()
    {
        held = false;
        image_restart = button_restart.GetComponent<Image>();
        image_mainMenu = button_mainMenu.GetComponent<Image>();
    }

    public void restart()
    {
        if (!held)
        {
            held = true;
            image_restart.sprite = sprite_buttons[1];
        }
        else
        {
            held = false;
            image_restart.sprite = sprite_buttons[0];
            Application.LoadLevel("sampleScene");
        }
    }

    public void mainMenu()
    {
        if (!held)
        {
            held = true;
            image_mainMenu.sprite = sprite_buttons[3];
        }
        else
        {
            held = false;
            image_mainMenu.sprite = sprite_buttons[2];
            Application.LoadLevel("MainMenu");
        }
    }
}
