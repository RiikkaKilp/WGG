using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI textDisplay;
    public string[] sentences;
    public float typingSpeed;
    int index;

    [SerializeField] GameObject continueButton;

    void Start()
    {
        textDisplay.text = "";
    }

    public void StarType()
    {
        StartCoroutine(Type());
    }

    private void Update()
    {
        if(textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
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
        if(index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
        }
    }
}
