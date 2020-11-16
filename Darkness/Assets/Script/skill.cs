using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skill : MonoBehaviour
{
    public float range = 200;
    // Start is called before the first frame update
    public GameObject sklray;
    [Header("Skill1")]
    public Image maskUI;
    public GameObject Rmask;
    public float cooldown = 5;
    bool IsCoolDown = false;
    public KeyCode skill1;

    private void Start()
    {
        maskUI.fillAmount = 0;
        Rmask.SetActive(false);
    }
    private void Update()
    {
        if (Rmask == true)
        {
            Skill1();
        }
    }
    void Skill1()
    {
       
        
            if (Input.GetKey(skill1) && IsCoolDown == false)
            {
                Rigidbody rb = Instantiate(sklray, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * 14f, ForceMode.Impulse);
                rb.AddForce(transform.up * 4f, ForceMode.Impulse);

                IsCoolDown = true;
                maskUI.fillAmount = 1;
            }
            if (IsCoolDown)
            {
                maskUI.fillAmount -= 2 / cooldown * Time.deltaTime;
                if (maskUI.fillAmount <= 0)
                {
                    maskUI.fillAmount = 0;
                    IsCoolDown = false;
                }
            }
        
    }

}
