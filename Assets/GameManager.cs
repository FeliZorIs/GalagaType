using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject GameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void summon_GameOver()
    {
        Debug.Log("GAME OVER, BITCH BOY");
        StartCoroutine("bringUpGameOver");
    }

    IEnumerator bringUpGameOver()
    {
        yield return new WaitForSeconds(1.5f);
        GameOver.SetActive(true);
        
    }
}
