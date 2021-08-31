using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AYS_Restart : MonoBehaviour
{
    public GameObject menu;
    public GameObject button_restart;
    public GameObject button_continue;

    public Sprite[] button_sprites;
    bool held;

    // Start is called before the first frame update
    void Start()
    {
        held = false;
        
    }

    public void restart()
    {
        if (!held)
        {
            held = true;
            button_restart.GetComponent<Image>().sprite = button_sprites[3];
        }
        else
        {
            held = false;
            Application.LoadLevel("SampleScene");
            button_restart.GetComponent<Image>().sprite = button_sprites[2];
        }
    }

    public void continue_game()
    {
        if (!held)
        {
            held = true;
            button_continue.GetComponent<Image>().sprite = button_sprites[1];
        }
        else 
        {
            held = false;
            menu.SetActive(false);
            button_continue.GetComponent<Image>().sprite = button_sprites[0];
        }
    }
}
