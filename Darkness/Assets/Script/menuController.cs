using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class menuController : MonoBehaviour
{
    public GameObject Menu;
    public GameObject piemenu;
    public GameObject dialoguesystem;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Menu.SetActive(false);
        piemenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("menu")||Input.GetKeyDown(KeyCode.Q  ))
        {
            Menu.SetActive(true);
            if (Menu== true)
            {
                piemenu.SetActive(false);
                dialoguesystem.SetActive(false);
            }
            Cursor.lockState = CursorLockMode.None;


        }
        if (CrossPlatformInputManager.GetButtonDown("pie")|| Input.GetKeyDown(KeyCode.Tab))
        {
            piemenu.SetActive(true);
            if (piemenu==true)
            {
                Menu.SetActive(false);
                dialoguesystem.SetActive(false);

            }
            Cursor.lockState = CursorLockMode.None;


        }
       
        if (CrossPlatformInputManager.GetButtonDown("backgame")||Input.GetKeyDown(KeyCode.Escape))
        {
            piemenu.SetActive(false);
            Menu.SetActive(false);
            dialoguesystem.SetActive(false);

             Cursor.lockState = CursorLockMode.Locked;
        }
        /*else
        {
            Menu.SetActive(false);
        }
        
        /*if (CrossPlatformInputManager.GetButtonDown("backgame"))
        {
            Menu.active = false;
            piemenu.active = false;*/
    }
    }
    
    

