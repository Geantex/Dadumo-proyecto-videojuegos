using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public static class FadeToBlack
{
    private static Coroutine fadeCoroutine;
    private static Image fadeImage;
    private static Canvas fadeCanvas;

    public static void QuickFade(float fadeDuration = 0.2f)
    {
        StartFade(false, fadeDuration);
    }

    public static void QuickReverseFade(float fadeDuration = 0.2f)
    {
        StartFade(true, fadeDuration);
    }

    public static void StartFade(bool reverseFade, float fadeDuration)
    {
        if (fadeCoroutine != null)
            MonoBehaivourHelper.Instance.StopCoroutine(fadeCoroutine);

        if (fadeImage == null)
            fadeImage = CreateFadeImage();

        fadeCoroutine = MonoBehaivourHelper.Instance.StartCoroutine(FadeCoroutine(reverseFade, fadeDuration));
    }

    private static IEnumerator FadeCoroutine(bool reverseFade, float fadeDuration)
    {
        float timer = 0.0f;
        Color startColor = fadeImage.color;
        Color endColor = reverseFade ? Color.clear : Color.black;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            fadeImage.color = Color.Lerp(startColor, endColor, timer / fadeDuration);
            yield return null;
        }

        fadeImage.color = endColor;

        if (reverseFade)
        {
            fadeImage.enabled = false;
            if (fadeCanvas != null)
                Object.Destroy(fadeCanvas.gameObject);
        }
    }


    private static Image CreateFadeImage()
    {
        Canvas canvas = CreateFadeCanvas();
        GameObject imageGO = new GameObject("FadeImage");
        imageGO.transform.SetParent(canvas.transform, false);
        Image image = imageGO.AddComponent<Image>();
        image.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
        image.color = Color.clear;

        // Set the sorting order to be higher than other canvas elements
        Canvas canvasComponent = canvas.GetComponent<Canvas>();
        image.canvas.sortingOrder = canvasComponent.sortingOrder + 1;

        return image;
    }

    private static Canvas CreateFadeCanvas()
    {
        GameObject canvasGO = new GameObject("FadeCanvas");
        fadeCanvas = canvasGO.AddComponent<Canvas>();
        fadeCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasGO.AddComponent<CanvasScaler>();
        canvasGO.AddComponent<GraphicRaycaster>();

        // Set the Ignore Raycast layer to the fade canvas
        fadeCanvas.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");

        Object.DontDestroyOnLoad(canvasGO);

        return fadeCanvas;
    }

    public static IEnumerator WaitForFade(float delay)
    {
        float timer = 0.0f;

        while (timer < delay)
        {
            timer += Time.deltaTime;
            yield return null;
        }
    }

    private class MonoBehaivourHelper : MonoBehaviour
    {
        private static MonoBehaivourHelper instance;
        public static MonoBehaivourHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    GameObject gameObject = new GameObject("FadeToBlackHelper");
                    instance = gameObject.AddComponent<MonoBehaivourHelper>();
                    Object.DontDestroyOnLoad(gameObject);
                }
                return instance;
            }
        }
    }
}
