using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject objNPC, objPlayer, speechObject;
    public GameObject[] parent;
    public Button[] SavePhil;

    public void SavePhilippines()
    {
        int changeCounter = 2;

        objNPC.GetComponent<DialogueTrigger>().dg.sentences = new string[] { "Great! You see, I have already taken mark of the exact time and place where mistakes were committed. All we have to do is to go back to that event and fix whatever mistake happened. In that way, we can prevent this disaster. I'll act as your support. However, you will do all the talking and activities needed to be done. Don't worry, I'll be sure to guide you properly in this journey. Now, let’s go!" };

        foreach (Button btn in SavePhil)
        {
            btn.GetComponent<Animator>().SetBool("FadeOut", true);
        }

        foreach (GameObject obj in parent)
        {
            if (changeCounter > 0)
            {
                obj.GetComponent<ImageAnimation>().this_EndObject = true;
                changeCounter--;
                obj.SetActive(false);
            }
        }

        speechObject.SetActive(true);
    }

    public void DontSavePhilippines()
    {
        int changeCounter = 2;

        objNPC.GetComponent<DialogueTrigger>().dg.sentences = new string[] { "I see. I guess I'll look for other human to help me. Bye." };
        
        foreach (Button btn in SavePhil)
        {
            btn.GetComponent<Animator>().SetBool("FadeOut", true);
        }

        foreach (GameObject obj in parent)
        {
            if (changeCounter > 0)
            {
                obj.GetComponent<ImageAnimation>().this_EndObject = true;
                changeCounter--;
                obj.SetActive(false);
            }
        }

        speechObject.SetActive(true);
    }
}
