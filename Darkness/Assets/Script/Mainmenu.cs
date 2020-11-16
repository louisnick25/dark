using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public GameObject missonchage;
    public GameObject missoncomplic;
    public GameObject misson1;
    // Start is called before the first frame update
    public void Playgame()
    {
        SceneManager.LoadScene(1);
    }
    public void Quitgame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
    public void backmenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Update()
    {
        if (missonchage == false&&misson1==true)
        {
            missoncomplic.SetActive(true);
        }
    }
}
