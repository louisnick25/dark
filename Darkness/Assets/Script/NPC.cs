﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public string npcName;
    public DialogueManager dialogManger;
    public List<string> npcConvo = new List<string>();



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogManger.Start_Dialog(npcName, npcConvo);
        }
    }
}
