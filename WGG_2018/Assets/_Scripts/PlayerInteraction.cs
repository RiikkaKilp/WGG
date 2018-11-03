using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    [SerializeField] List<GameObject> interactables = new List<GameObject>();
    [SerializeField] KeyCode actionKey;

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
        if(Input.GetKeyDown(actionKey) && interactables.Count != 0)
        {
            for (int i = 0; i < interactables.Count; i++)
            {
                Debug.Log(interactables[i].name);
            }
        }
    }

}
