using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI fpsCounter;

    public int frameSkip = 10;

    private int frameCount;

    void Start()
    {
        frameCount = 0;
        fpsCounter.text = ((int)(1 / Time.deltaTime)).ToString();
    }

    void Update()
    {
        frameCount++;
        if (frameCount >= frameSkip)
        {
            frameCount -= frameSkip;
            fpsCounter.text = ((int)(1 / Time.deltaTime)).ToString();
        }
    }


}
