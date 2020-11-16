using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warn : MonoBehaviour
{
    public Color colorin;
    public Color colorout;
    public Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();       
    }

    private void OnTriggerEnter(Collider other)
    {
        rend.material.color = colorin;
    }
    private void OnTriggerExit(Collider other)
    {
        rend.material.color = colorout;
    }
}
