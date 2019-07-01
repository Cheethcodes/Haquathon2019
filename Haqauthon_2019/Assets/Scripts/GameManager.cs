using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int numberofGarbge, GarbageCounter;

    public bool execDone;
    public int ctChange;
    public float StartAlpha, FinAlpha;

    public Image SceneLoader;
    public AnimationCurve Curve;

    public GameObject canv;

    private void Update()
    {
        if (canv.transform.childCount == 0 && execDone == false)
        {
            execDone = true;
            StartCoroutine(NextObject());
        }
    }

    IEnumerator NextObject()
    {
        float IMGalpha = StartAlpha;

        while (IMGalpha < FinAlpha)
        {
            IMGalpha += Time.deltaTime * 1f;
            float a = Curve.Evaluate(IMGalpha);

            SceneLoader.color = new Color(0f, 0f, 0f, a);

            yield return 0;
        }
    }

}
