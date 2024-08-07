using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandController : MonoBehaviour
{
    public InputActionReference gripReference;

    public InputActionReference triggerReference;

    private Animator handAnimator;

    private float gripValue;

    private float triggerValue;

    void Start()
    {
        handAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        AnimateGrip();
        AnimateTrigger();
    }

    private void AnimateGrip()
    {
        gripValue = gripReference.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", gripValue);
    }

    private void AnimateTrigger()
    {
        triggerValue = triggerReference.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", triggerValue);
    }
}
