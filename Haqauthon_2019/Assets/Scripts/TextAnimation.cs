using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAnimation : MonoBehaviour
{
    public string txt;
    public Text sentence;

    void Start()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        sentence.text = "";

        foreach (char letter in txt.ToCharArray())
        {
            sentence.text += letter;
            yield return new WaitForSeconds(0.05f);
        }

        StartCoroutine(Delay(1f));
    }

    IEnumerator Delay(float f)
    {
        yield return new WaitForSeconds(f);
    }
}
