using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleController : MonoBehaviour
{
    public float waitTime;
    private float timer = 0.0f;
    private float timeScale = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = timeScale;
    }

    // Update is called once per frame
    void Update()
    {
        updateTimer();
    }

    private void updateTimer()
    {
        CanvasGroup cg = GetComponent<CanvasGroup>();
        timer += Time.deltaTime;
        // print(timer);

        if (timer > waitTime)
        {
            if (cg.alpha == 1f)
            {
                Hide();
                timer = timer - waitTime;
                Time.timeScale = timeScale;
                // print("Timer: " + timer);
            }
            else
            {
                Show();
                timer = timer - waitTime;
                Time.timeScale = timeScale;
                // print("Timer: " + timer);
            }
        }
    }

    void Hide ()
    {
        CanvasGroup cg = GetComponent<CanvasGroup>();
        cg.alpha = 0f; // this makes everything transparent
        cg.interactable = false; // this prevents the UI element from being interacted with
    }

    void Show ()
    {
        CanvasGroup cg = GetComponent<CanvasGroup>();
        cg.alpha = 1f;
        cg.interactable = true;
    }
}
