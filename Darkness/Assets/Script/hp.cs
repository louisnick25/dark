using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class hp : MonoBehaviour
{
    [SerializeField] public float TotalHp;
    [SerializeField] public float CurrentHp;
    public GameObject player;
    public GameObject MUD;
    public Image hpbar;
    // Start is called before the first frame update
    void Start()
    {
        CurrentHp = TotalHp;
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("attack"))
        {
            //Debug.Log("hit");

            TakeDamage();
        }
        if (collision.gameObject.CompareTag("plushealth"))
        {
            plushp();
        }
        void TakeDamage()
        {


            CurrentHp -= 10;
            hpbar.transform.localScale = new Vector3((CurrentHp/TotalHp) * 8f, 0.3f, 0.9f);
           if(CurrentHp / TotalHp == 0)
            {
                SceneManager.LoadScene(2);
            }
        }
        void plushp()
        {
            CurrentHp += 10;
            hpbar.transform.localScale = new Vector3((CurrentHp / TotalHp) * 8f, 0.3f, 0.9f);
            
        }
    }
}
