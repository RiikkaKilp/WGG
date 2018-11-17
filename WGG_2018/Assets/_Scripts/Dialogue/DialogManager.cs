﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{

    #region Variables

    public static DialogManager instance;
    public TextMeshProUGUI nameText, dialogueText;
    public Queue<string> sentences;
    public float typingSpeed = 0.02f;
    public bool sentenceReady;

    private float tempTypingSpeed;

    #endregion

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        tempTypingSpeed = typingSpeed;
        sentences = new Queue<string>();
    }

    public void StartConversation(Dialogue dialogue)
    {
        //make animation
        PlayerMovement.interacting = true;
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        NextSentence();
    }

    public void NextSentence()
    {

        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        sentenceReady = false;
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence, typingSpeed));
    }

    IEnumerator TypeSentence(string sentence, float typingSpeed)
    {
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        sentenceReady = true;

    }

    private void EndDialogue()
    {
        //make animation
        PlayerMovement.interacting = false;
        sentenceReady = false;
        Debug.Log("End of conversation");
        dialogueText.text = "";
        nameText.text = "";
    }
}