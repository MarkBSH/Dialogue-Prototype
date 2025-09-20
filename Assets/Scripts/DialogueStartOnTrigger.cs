using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueStartOnTrigger : MonoBehaviour
{
    void OnTriggerEnter()
    {
        GetComponent<DialogueTrigger>().TriggerDialogue();
        Destroy(this);
    }
}
