using UnityEditor.ShaderGraph.Internal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MeroMovement : MonoBehaviour
{
    float speed = 5f;
    public InputActionAsset InputActions;
    private InputAction moveAction;
    Vector2 direction;
    Vector2 mouseworld;
    private float meroRotation;
    private bool startMoving = false;
    void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        
    }

    void Update()
    {
        if(moveAction.WasPressedThisFrame())
        {
            startMoving = true;
        }
        if(startMoving)
        {
            Movement();
        }
    }

    void Movement()
    {
        mouseworld = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        direction = mouseworld - new Vector2(transform.position.x, transform.position.y);
        meroRotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, meroRotation - 90);
        transform.position = Vector2.MoveTowards(transform.position, mouseworld, speed*Time.deltaTime);
        if(transform.position.x > 34.3f)
        {
            transform.position = new Vector3(34.3f, transform.position.y, transform.position.z);
        }
        else if(transform.position.x < -34.3f)
        {
            transform.position = new Vector3(-34.3f, transform.position.y, transform.position.z);
        }
        if(transform.position.y > 18.8f)
        {
            transform.position = new Vector3(transform.position.x, 18.8f, transform.position.z);
        }
        else if(transform.position.y < -18.8f)
        {
            transform.position = new Vector3(transform.position.x, -18.8f, transform.position.z);
        }
    }
}
