using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;


public class CircleMenu : MonoBehaviour
{
    public List<MenuButton> buttons = new List<MenuButton>();
    public GameObject piemenu;
    private Vector2 Mouseposition;
    private Vector2 fromVector2M = new Vector2(0.3f, 1.0f);
    private Vector2 centercircle = new Vector2(0.5f,0.05f);
    private Vector2 toVector2M;

    public int menuItems;
    public int CurMenuItem;
    private int OldMeniItem;
    
    // Start is called before the first frame update
    void Start()
    {
        
        menuItems = buttons.Count;
        foreach(MenuButton button in buttons)
        {
            button.sceneimage.color = button.NormalColot;
        }
        CurMenuItem = 0;
        OldMeniItem = 0;
        piemenu.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
          

            GetCurrentMenuItem();


            if (Input.GetKeyDown(KeyCode.Mouse0))
            
                ButtonAction();
            
            
        
           
        
    }
    public void GetCurrentMenuItem()
    {
        Mouseposition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        toVector2M = new Vector2(Mouseposition.x / Screen.width, Mouseposition.y / Screen.height);

        float angle = (Mathf.Atan2(fromVector2M.y - centercircle.y, fromVector2M.x - centercircle.x) -Mathf.Atan2 (toVector2M.y - centercircle.y, toVector2M.x - centercircle.x))*Mathf.Rad2Deg;

        if (angle < 0)
            angle += 360;

        CurMenuItem = (int)(angle / (360 / menuItems));

        if (CurMenuItem != OldMeniItem)
        {
            buttons[OldMeniItem].sceneimage.color = buttons[OldMeniItem].NormalColot;
            OldMeniItem = CurMenuItem;
            buttons[OldMeniItem].sceneimage.color = buttons[CurMenuItem].HighlightedColor;

        }
    }
    public void ButtonAction()
    {
        buttons[OldMeniItem].sceneimage.color = buttons[OldMeniItem].Presscolor;
        // if (CurMenuItem == 0)
           // print("You have pressed the first button");

    }



}
[System.Serializable]
public class MenuButton
{
    public string name;
    public Image sceneimage;
    public Color NormalColot = Color.white;
    public Color HighlightedColor = Color.gray;
    public Color Presscolor = Color.gray;
}
