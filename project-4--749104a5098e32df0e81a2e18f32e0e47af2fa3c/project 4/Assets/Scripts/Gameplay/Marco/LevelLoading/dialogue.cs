using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialogue : MonoBehaviour
{
    public LevelLoader LoadNExtLVL;
    [SerializeField] float typingSpeed = 0.02f;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] string[] sentences;
    private int index;
    private void Start()
    {
        StartCoroutine(typing());
    }
    IEnumerator typing()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            text.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            index++;
            text.text = "";
            StartCoroutine(typing());
        }
        if (index >= sentences.Length)
        {
            LoadNExtLVL.LoadNextLevel();
        }
    }
}
