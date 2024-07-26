using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;

    public bool syncPosition;

    public Vector3 positionOffset;

    public bool syncRotation;

    public Vector3 rotationOffset;

    void Update()
    {
        if (syncPosition)
        {
            transform.position = target.transform.position + positionOffset;
        }
    }
}
