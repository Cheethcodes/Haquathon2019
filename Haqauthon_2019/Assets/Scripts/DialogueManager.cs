using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Scenefader sf;
    public Animator AdditionalAnimator;
    public bool NextScene = false;
    public bool initializeScene = false;
    public string nextScene;

    // 0 = Auto, 1 = AutoCut, 2 = OnClick
    public int DialogueOptions;
    public GameObject trans1Obj;
    public GameObject[] trans2Obj;

    private bool DialogueStartCounter = true;
    public int SpeakerCounter;
    Dialogues curGameObj;

    private Queue<string> _sentenceNPC, _sentencePlayer;
    public int turnsNPC, turnsPlayer;
    public bool talkNPC, talkPlayer;

    public GameObject[] speechObjects;
    public Text txtName;
    public Text txtDialogue;

    void Start()
    {
        _sentenceNPC = new Queue<string>();
        _sentencePlayer = new Queue<string>();

        _sentenceNPC.Clear();
        _sentencePlayer.Clear();

        StartCoroutine(Delay(1f));

        AdditionalAnimator.SetBool("FadeIn", true);
    }

    void Update()
    {
        if (DialogueOptions == 0)
        {
            if (initializeScene == false)
            {
                StartCoroutine(InitializeThisScene());
            }
            else if (initializeScene == true)
            {
                StartCoroutine(InitializeThisScene());

                if (DialogueStartCounter)
                {
                    StartDialogue(SpeakerCounter);
                    DialogueStartCounter = false;

                    if (turnsNPC == 0 && turnsPlayer == 0 && NextScene == false)
                    {
                        StartCoroutine(TransitionNextScene());
                    }
                }
            }
            else { }
        }

        else if (DialogueOptions == 1)
        {
            if (initializeScene == false)
            {
                StartCoroutine(InitializeThisScene());
            }
            else if (initializeScene == true)
            {
                if (DialogueStartCounter)
                {
                    StartDialogue(SpeakerCounter);
                    DialogueStartCounter = false;

                    if (turnsNPC == 0 && turnsPlayer == 0 && NextScene == false)
                    {
                        StartCoroutine(TransitionNextObject());
                    }
                }
            }
            else { }
        }
        else { }
    }

    public void StartDialogue(int _speaker)
    {
        StartCoroutine(Delay(1.5f));

        if (_speaker == 0)
        {
            if (talkNPC == true && !(turnsNPC - 1 < 0) && talkPlayer == false)
            {
                curGameObj = speechObjects[0].GetComponent<DialogueTrigger>().dg;

                foreach (string sen in curGameObj.sentences)
                {
                    _sentenceNPC.Enqueue(sen);
                }

                txtName.text = curGameObj.name;
                DisplayNextSentence(0);
            }
        }
        else if (_speaker == 1)
        {
            if (talkNPC == false && !(turnsPlayer - 1 < 0) && talkPlayer == true)
            {
                curGameObj = speechObjects[1].GetComponent<DialogueTrigger>().dg;

                foreach (string sen in curGameObj.sentences)
                {
                    _sentencePlayer.Enqueue(sen);
                }

                txtName.text = curGameObj.name;
                DisplayNextSentence(1);
            }
        }
        else { }
    }

    public void DisplayNextSentence(int _speaker)
    {
        if (_speaker == 0)
        {
            if (_sentenceNPC.Count == 0)
            {
                EndDialogue(_speaker);
                return;
            }

            string curSentence = _sentenceNPC.Dequeue();

            StopAllCoroutines();
            StartCoroutine(TypeSentence(curSentence, _speaker));
        }
        else if (_speaker == 1)
        {
            if (_sentencePlayer.Count == 0)
            {
                EndDialogue(_speaker);
                return;
            }

            string curSentence = _sentencePlayer.Dequeue();

            StopAllCoroutines();
            StartCoroutine(TypeSentence(curSentence, _speaker));
        }
        else { }
    }

    public void EndDialogue(int _speaker)
    {
        if (_speaker == 0)
        {
            //cturnNPC = "ShutUp";
            turnsNPC -= 1;
        }
        else if (_speaker == 1)
        {
            //cturnPlayer = "ShutUp";
            turnsPlayer -= 1;
        }
        else { }
    }

    IEnumerator TypeSentence(string txt, int _speaker)
    {
        txtDialogue.text = "";

        foreach (char letter in txt.ToCharArray())
        {
            txtDialogue.text += letter;
            yield return new WaitForSeconds(0.035f);
        }

        if (_speaker == 0)
        {
            turnsNPC -= 1;
            talkNPC = false;
            talkPlayer = true;
            SpeakerCounter = 1;
        }
        else if (_speaker == 1)
        {
            turnsPlayer -= 1;
            talkNPC = true;
            talkPlayer = false;
            SpeakerCounter = 0;
        }
        else { }

        StartCoroutine(Delay(1f));
    }

    IEnumerator Delay(float f)
    {
        yield return new WaitForSeconds(f);
        DialogueStartCounter = true;
    }

    IEnumerator InitializeThisScene()
    {
        yield return new WaitForSeconds(1f);
        initializeScene = true;
    }

    IEnumerator TransitionNextScene()
    {
        AdditionalAnimator.SetBool("FadeOut", true);
        NextScene = true;
        yield return new WaitForSeconds(2f);
        sf.FadeToScene(nextScene);
    }

    IEnumerator TransitionNextObject()
    {
        AdditionalAnimator.SetBool("FadeOut", true);
        NextScene = true;
        yield return new WaitForSeconds(2f);

        foreach (GameObject obj in trans2Obj)
        {
            obj.SetActive(true);
        }

        trans1Obj.SetActive(false);
    }
}
