using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class add_SceneFader : MonoBehaviour
{
    public GameObject BaseImage, NextImage;
    private bool changeTransition;

    void Start()
    {
        changeTransition = false;
    }

    void Update()
    {
        if (BaseImage.GetComponent<Image>().color.a <= 0f && changeTransition == false)
        {
            NextImage.SetActive(true);
            changeTransition = true;
        }
    }
}
