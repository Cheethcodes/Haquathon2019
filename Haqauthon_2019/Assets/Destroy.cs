using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField]
    GameObject objectToDestroy;

    public void DestroyGameObject()
    {
        Destroy(objectToDestroy);
        GameObject.Find("GameManager").GetComponent<GameManager>().GarbageCounter += 1;
    }
}
