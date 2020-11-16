using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillbullet : MonoBehaviour
{
    public GameObject enemy1;
    private void Start()
    {
        enemy1 = GameObject.Find("enemy");

       
    }
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            enemy enemy = transform.GetComponent<enemy>();

            if (enemy != null)
            {
                enemy.charm();
            }


        }

    }
}
