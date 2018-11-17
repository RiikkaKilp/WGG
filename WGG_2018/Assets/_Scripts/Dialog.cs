using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{

    [HideInInspector] public TextMeshProUGUI textDisplay;

    public bool sentenceReady = false;
    public List<string> sentences = new List<string>();

    private float normalTypeSpeed;
    public float skipTypeSpeed;
    public float typingSpeed;
    int index;

    [SerializeField] GameObject continueButton;

    void Start()
    {
        textDisplay.text = "";
        normalTypeSpeed = typingSpeed;
    }

    public void StarType()
    {
        StartCoroutine(Type());
    }

    private void Update()
    {
        if(PlayerMovement.interacting)
        {
            if(textDisplay.text == sentences[index])
            {
                sentenceReady = true;
                continueButton.SetActive(true);
            }
            else
            {
                sentenceReady = false;
                continueButton.SetActive(false);
            }
        }
    }

    public IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        typingSpeed = normalTypeSpeed;

        if(index < sentences.Count - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            PlayerMovement.interacting = false;
            index = 0;
        }
    }
}
