﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    Dialog dialog;
    [SerializeField] GameObject dialogManager;
    [SerializeField] List<GameObject> interactables = new List<GameObject>();
    [SerializeField] KeyCode actionKey;
    
    private void Start()
    {
        dialog = dialogManager.GetComponent<Dialog>();    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!interactables.Contains(other.gameObject) && other.gameObject.tag != "Player")
        {
            interactables.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (interactables.Contains(other.gameObject))
        {
            interactables.Remove(other.gameObject);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(actionKey) && interactables.Count != 0 && !PlayerMovement.interacting)
        {
            for (int i = 0; i < interactables.Count; i++)
            {
                PlayerMovement.interacting = true;
                dialog.sentences = interactables[i].GetComponent<Npc>().sentences;
                dialog.StarType();
            }
        }
        else if(Input.GetKeyDown(actionKey) && PlayerMovement.interacting)
        {
            if (!dialog.sentenceReady)
            {
                dialog.typingSpeed = dialog.skipTypeSpeed;
            }
            else
            {
                dialog.NextSentence();
            }
        }
    }

}
