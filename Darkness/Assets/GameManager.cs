using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject maskoff;
    public GameObject maskon;
    public GameObject shader;
    public GameObject enemy;
    public GameObject cam1;
    public GameObject cam2;
    public bool s;
    // Start is called before the first frame update
    void Start()
    {
        s = false;
        cam1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
            if (Input.GetKeyDown(KeyCode.E) && s == false && maskoff.activeInHierarchy == true)
            {
                shader.SetActive(true);
                enemy.SetActive(true);

                //enemy.SetActive(true);
                cam2.SetActive(true);
                cam1.SetActive(false);

                s = true;
            }
            else if (Input.GetKeyDown(KeyCode.E) && s == true)
            {
                shader.SetActive(false);
                s = false;
            }


        /*else if (Input.GetKeyDown(KeyCode.E)|| shader == true)
        {
            mask1.GetComponent<Image>().color = new Color(108f, 108f, 108f, 108f);
            shader.SetActive(false);
        }
    */
    }
}


