using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager m_Instance;
    public static DialogueManager Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = FindObjectOfType<DialogueManager>();
                if (m_Instance == null)
                {
                    GameObject _obj = new()
                    {
                        name = typeof(DialogueManager).Name
                    };
                    m_Instance = _obj.AddComponent<DialogueManager>();
                }
            }
            return m_Instance;
        }
    }

    [SerializeField] private TextMeshProUGUI dialogueText;

    private Queue<String> sentences;
    private List<float> timerTargets = new();

    private float timerTarget;
    private float timerTimer;


    void Start()
    {
        sentences = new Queue<String>();
    }

    void Update()
    {
        NextTextTimer();
    }

    void NextTextTimer()
    {
        if (timerTimer <= timerTarget)
        {
            timerTimer += Time.deltaTime;
        }
        else
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        sentences.Clear();
        foreach (string sentence in dialogue.sentenses)
        {
            sentences.Enqueue(sentence);
        }

        timerTargets.Clear();
        for (int i = 0; i < dialogue.timePerSentence.Length; i++)
        {
            timerTargets.Add(dialogue.timePerSentence[i]);
        }

        DisplayNextSentence();
    }

    void DisplayNextSentence()
    {
        timerTimer = 0;

        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        timerTarget = timerTargets[0];
        timerTargets.RemoveAt(0);

        dialogueText.text = sentence;
    }

    void EndDialogue()
    {

    }
}
