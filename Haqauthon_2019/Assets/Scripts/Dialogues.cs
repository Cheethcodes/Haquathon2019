using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogues
{
    public string name;

    [TextArea(3, 25)]
    public string[] sentences;
}
