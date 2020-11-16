using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogpanel;
    public Text npcNameText;
    public Text dialogText;

    private List<string> conversation;
    private int convoIndex;
    void Start()
    {
        dialogpanel.SetActive(false);
    }
    public void Start_Dialog(string _npcName, List<string> _convo)
    {
        npcNameText.text = _npcName;
        conversation = new List<string>(_convo);
        dialogpanel.SetActive(true);
        convoIndex = 0;
        showtext();
        
        
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;

    }
    public void stopdialog()
    {
        dialogpanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;

    }
    void showtext()
    {
        dialogText.text = conversation[convoIndex];
        Invoke("Start_Dialog", 1f);
        
    }
    public void next()
    {
        if (convoIndex < conversation.Count - 1)
        {
            convoIndex += 1;
            showtext();
        }
    }
    public void gamegoing()
    {
        Time.timeScale = 1f;
    }

}
