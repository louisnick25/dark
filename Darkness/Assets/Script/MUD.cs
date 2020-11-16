using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MUD : MonoBehaviour
{

    public GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        Destroy(gameObject, 3f);
    }

    /* void OnCollisionEnter(Collision collision)
     {
         if (collision.gameObject.name == "Player")
         {
             player.GetComponent<hp>().CurrentHp -= 10;

             Destroy(gameObject);
         }
     }*/
    private void Update()
    {
       
    }

}
