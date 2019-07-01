using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scenefader : MonoBehaviour
{
    public Image SceneLoader;
    public AnimationCurve Curve;
    public float StartAlpha, FinAlpha;

    // 0 = black > transparent, 1 = white > black
    public int FadeOptions;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        if (FadeOptions == 0)
        {
            float IMGalpha = StartAlpha;

            while (IMGalpha > FinAlpha)
            {
                IMGalpha -= Time.deltaTime * 1f;
                float a = Curve.Evaluate(IMGalpha);

                SceneLoader.color = new Color(0f, 0f, 0f, a);

                yield return 0;
            }
        }
        else { }
    }

    public void FadeToScene(string x)
    {
        StartCoroutine(FadeOut(x));
    }

    IEnumerator FadeOut(string x)
    {
        if (FadeOptions == 0)
        {
            float IMGalpha = FinAlpha;

            while (IMGalpha < StartAlpha)
            {
                IMGalpha += Time.deltaTime * 1f;
                float a = Curve.Evaluate(IMGalpha);

                SceneLoader.color = new Color(0f, 0f, 0f, a);

                yield return 0;
            }
        }
        else if (FadeOptions == 1)
        {
            float IMGred = 0f, IMGgreen = 0f, IMGblue = 0f;

            while (IMGred < 1f && IMGgreen < 1f && IMGblue < 1f)
            {
                IMGred += Time.deltaTime * 1f;
                IMGgreen += Time.deltaTime * 1f;
                IMGblue += Time.deltaTime * 1f;

                float r = Curve.Evaluate(IMGred);
                float g = Curve.Evaluate(IMGgreen);
                float b = Curve.Evaluate(IMGblue);

                SceneLoader.color = new Color(r, b, g, 1f);

                yield return 0;
            }
        }
        else { }

        SceneManager.LoadScene(x);
    }
}
