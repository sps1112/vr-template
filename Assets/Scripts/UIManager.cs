using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI fpsCounter;

    public float timeSkip = 1;

    private float timer;

    void Start()
    {
        timer = 0;
        fpsCounter.text = ((int)(1 / Time.deltaTime)).ToString();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeSkip)
        {
            timer -= timeSkip;
            fpsCounter.text = ((int)(1 / Time.deltaTime)).ToString();
        }
    }


}
