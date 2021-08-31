using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject subMenu_Background;
    public GameObject button_StartGame;
    public GameObject button_HowToPlay;
    public GameObject button_Options;
    public GameObject button_ExitGame;

    public GameObject[] Sub_menus;

    public Sprite[] blueButtons_sprite;
    public Sprite[] redButtons_sprite;

    bool held = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        subMenu_Background.SetActive(false);
        Sub_menus[0].SetActive(false);

    }

    //======================================== Button Pushes ================================
    //blue_square_h    = 1         red_square_h  = 1
    //blue_square_r    = 0         red_square_r  = 0
    //blue_rect_h      = 3         red_rect_h    = 3
    //blue_rect_r      = 2         red_rect_r    = 2

    //sub_menu[0]      = HowToPlay Menu

    //start button
    public void startGame() 
    {
        if (!held)
        {
            held = true;
            button_StartGame.GetComponent<Image>().sprite = blueButtons_sprite[3];
        }
        else
        {
            held = false;
            SceneManager.LoadScene("SampleScene");
            button_StartGame.GetComponent<Image>().sprite = blueButtons_sprite[2];
        }
    }

    //How to Play button
    public void HowToPlay()
    {
        if (!held)
        {
            held = true;
            button_HowToPlay.GetComponent<Image>().sprite = blueButtons_sprite[3];
        }
        else
        {
            held = false;
            subMenu_Background.SetActive(true);
            Sub_menus[0].SetActive(true);
            button_HowToPlay.GetComponent<Image>().sprite = blueButtons_sprite[2];
        }
    }
    public void close_HowToPlay()
    {
        subMenu_Background.SetActive(false);
        Sub_menus[0].SetActive(false);
    }

    //Options
    public void Options()
    {
        if (!held)
        {
            held = true;
            button_Options.GetComponent<Image>().sprite = blueButtons_sprite[3];
        }
        else
        {
            held = false;
            button_Options.GetComponent<Image>().sprite = blueButtons_sprite[2];
        }
    }

    //Exit Game
    public void ExitGame()
    {
        if (!held)
        {
            held = true;
            button_ExitGame.GetComponent<Image>().sprite = redButtons_sprite[3];
        }
        else
        {
            held = false;
            button_ExitGame.GetComponent<Image>().sprite = redButtons_sprite[2];
            Application.Quit();
        }
    }
}
