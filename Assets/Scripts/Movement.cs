using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public InputActionReference leftGripReference;

    public InputActionReference leftMoveReference;

    public InputActionReference rightGripReference;

    public InputActionReference rightMoveReference;

    public InputActionReference rightTurnReference;

    private Vector3 lastLeftPosition;

    private Vector3 lastRightPosition;

    private bool leftPressed;

    private bool rightPressed;

    public float acceleration = 1;

    private Rigidbody rb;

    public float maxSpeed;

    public float friction;

    private Vector3 netMove;

    private UIManager ui;

    public float turnSpeed = 125;

    void Start()
    {
        ui = GameObject.Find("GameManager").GetComponent<UIManager>();
        rb = GetComponent<Rigidbody>();
        leftPressed = false;
        rightPressed = false;
        lastLeftPosition = leftMoveReference.action.ReadValue<Vector3>();
        lastRightPosition = rightMoveReference.action.ReadValue<Vector3>();
        netMove = Vector3.zero;
    }

    void Update()
    {
        netMove -= CheckControllerMove();
        RotateView(rightTurnReference.action.ReadValue<Vector2>().x);
    }

    void FixedUpdate()
    {
        MovePlayer(netMove);
        netMove = Vector3.zero;
    }

    private void MovePlayer(Vector3 diff)
    {
        Vector3 vel = rb.velocity;
        Vector3 dir = transform.forward * diff.z + transform.right * diff.x + transform.up * diff.y;
        vel += acceleration * Time.deltaTime * dir;
        if (vel.magnitude > maxSpeed)
        {
            vel = vel.normalized * maxSpeed;
        }
        vel = Vector3.Lerp(vel, Vector3.zero, friction);
        rb.velocity = vel;
    }

    private Vector3 CheckControllerMove()
    {
        Vector3 diff = Vector3.zero;
        if (leftGripReference.action.ReadValue<float>() > 0)
        {
            if (!leftPressed)
            {
                leftPressed = true;
                lastLeftPosition = leftMoveReference.action.ReadValue<Vector3>();
            }
            else
            {
                Vector3 pos = leftMoveReference.action.ReadValue<Vector3>();
                diff += (pos - lastLeftPosition) * leftGripReference.action.ReadValue<float>();
                lastLeftPosition = pos;
            }
        }
        else
        {
            leftPressed = false;
        }

        // Vector3 pos1 = leftMoveReference.action.ReadValue<Vector3>();
        // diff += (pos1 - lastLeftPosition);
        // lastLeftPosition = pos1;

        if (rightGripReference.action.ReadValue<float>() > 0)
        {
            if (!rightPressed)
            {
                rightPressed = true;
                lastRightPosition = rightMoveReference.action.ReadValue<Vector3>();
            }
            else
            {
                Vector3 pos = rightMoveReference.action.ReadValue<Vector3>();
                diff += (pos - lastRightPosition) * rightGripReference.action.ReadValue<float>();
                lastRightPosition = pos;
            }
        }
        else
        {
            rightPressed = false;
        }

        // Vector3 pos2 = rightMoveReference.action.ReadValue<Vector3>();
        // diff += (pos2 - lastRightPosition);
        // lastRightPosition = pos2;

        return diff;
    }

    private void RotateView(float input)
    {
        transform.Rotate(Vector3.up, input * turnSpeed * Time.deltaTime, Space.Self);
    }
}
