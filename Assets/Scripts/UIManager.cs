using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI fpsCounter;

    public float timeSkip = 1;

    private float timer;

    private float delta;

    bool toRefresh = false;

    void Start()
    {
        timer = 0;
        delta = 0;
        fpsCounter.text = ((int)(1 / Time.deltaTime)).ToString();
        toRefresh = true;
    }

    void Update()
    {
        timer += Time.unscaledDeltaTime;
        delta += (Time.unscaledDeltaTime - delta) * 0.1f;
        if (timer >= timeSkip)
        {
            timer -= timeSkip;
            if (toRefresh)
            {
                fpsCounter.text = "Checking..";
            }
            else
            {
                fpsCounter.text = ((int)(1 / delta)).ToString();
            }
            toRefresh = !toRefresh;
        }
    }
}
