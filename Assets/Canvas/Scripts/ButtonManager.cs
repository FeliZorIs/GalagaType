using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    //Pause
    public GameObject PauseMenu;
    public GameObject pauseButton;
    public Sprite[] PauseB_sprites;
    Image PauseB_image;
    bool isPaused;

    //Menu Buttons
    public GameObject continue_game;
    public GameObject restart;
    public GameObject mainMenu;

    //AYS
    public GameObject AYS_mm;
    public GameObject AYS_button_MainMenu;
    public GameObject AYS_button_continueGame;
    public GameObject AYS_restart;

    public Sprite[] button_sprites;

    bool held;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        isPaused = false;
        held = false;
        PauseB_image = pauseButton.GetComponent<Image>();

        PauseMenu.SetActive(false);
        AYS_mm.SetActive(false);
        AYS_restart.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseGame();
        }
    }


    //=========================================== Pause Functions ==============================
    public void pauseGame()
    {
        if (!isPaused)
        { 
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
            isPaused = true;
        }
        else
        {
            Time.timeScale = 1;
            PauseMenu.SetActive(false);
            isPaused = false;
        }
    }

    public void pauseB()
    {
        if (!held)
        {
            held = true;
            PauseB_image.sprite = PauseB_sprites[1];
        }
        else 
        {
            held = false;
            PauseB_image.sprite = PauseB_sprites[0];
            pauseGame();
        }
    }

    //=========================================== Menu Functions ================================
    //continue
    public void Continue()
    {
        if (!held)
        {
            held = true;
            continue_game.GetComponent<Image>().sprite = button_sprites[1];
        }
        else 
        {
            held = false;
            pauseGame();
            continue_game.GetComponent<Image>().sprite = button_sprites[0];
        }
    }

    //restart
    public void restartB()
    {
        if (!held)
        {
            held = true;
            restart.GetComponent<Image>().sprite = button_sprites[1];
        }
        else
        {
            held = false;
            //Application.LoadLevel(Application.loadedLevel);
            AYS_restart.SetActive(true);
            restart.GetComponent<Image>().sprite = button_sprites[0];
        }
    }
    
    //main menu
    public void MainMenu()
    {
        if (!held)
        {
            held = true;
            mainMenu.GetComponent<Image>().sprite = button_sprites[1];
        }
        else
        {
            held = false;
            AYS_mm.SetActive(true);
            mainMenu.GetComponent<Image>().sprite = button_sprites[0];
        }
    }

    //AYS MainMenu
    public void AYS_continueGame()
    {
        if (!held)
        {
            held = true;
            AYS_button_continueGame.GetComponent<Image>().sprite = button_sprites[1];
        }
        else
        {
            held = false;
            AYS_button_continueGame.GetComponent<Image>().sprite = button_sprites[0];
            AYS_mm.SetActive(false);
        }
    }

    public void AYS_mainmenu()
    {
        if (!held)
        {
            held = true;
            AYS_button_MainMenu.GetComponent<Image>().sprite = button_sprites[3];
        }
        else
        {
            held = false;
            AYS_button_MainMenu.GetComponent<Image>().sprite = button_sprites[2];
            SceneManager.LoadScene("MainMenu");
        }
    }
}
