using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageAnimation : MonoBehaviour
{
    public bool this_EndObject;
    public Image targetIMG;
    public AnimationCurve Curve;
    public float StartAlpha, FinAlpha;

    void Start()
    {
        StartCoroutine(StartObject());
    }

    void Update()
    {
        if (this_EndObject == true)
        {
            StartCoroutine(EndObject());
            this_EndObject = false;
        }
    }

    IEnumerator StartObject()
    {
        float IMGalpha = StartAlpha;

        while (IMGalpha < FinAlpha)
        {
            IMGalpha += Time.deltaTime * 1f;
            float a = Curve.Evaluate(IMGalpha);

            targetIMG.color = new Color(1f, 1f, 1f, a);

            yield return 0;
        }
    }

    IEnumerator EndObject()
    {
        float IMGalpha = FinAlpha;

        while (IMGalpha > StartAlpha)
        {
            IMGalpha -= Time.deltaTime * 1f;
            float a = Curve.Evaluate(IMGalpha);

            targetIMG.color = new Color(0f, 0f, 0f, a);

            yield return 0;
        }
    }
}
