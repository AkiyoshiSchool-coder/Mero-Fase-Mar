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
    private InputAction escapeAction;
    Vector2 direction;
    Vector2 mouseworld;
    private float meroRotation;
    private bool startMoving = false;
    private bool canMove = true;
    private int escapeCount = 0;
    public GameObject redeMero;
    public GameObject barraTime, barraTap;
    private MoveBarrinha codeBTime, codeBTap;
    private float timer = 0;
    
    void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        escapeAction = InputSystem.actions.FindAction("Escape");
        codeBTime = barraTime.GetComponent<MoveBarrinha>();
        codeBTap = barraTap.GetComponent<MoveBarrinha>();
    }

    void Update()
    {
        if(moveAction.WasPressedThisFrame())
        {
            startMoving = true;
        }
        if(escapeAction.WasPerformedThisFrame())
        {
            escapeCount++;
            codeBTap.MoveBarra(1);
            Debug.Log(escapeCount);
        }
        if(escapeCount >= 5)
        {
            EscapeReset();
        }
        if(startMoving)
        {
            Movement();
        }
        if(!canMove)
        {
            timer += Time.deltaTime;
            codeBTime.MoveBarra(-Time.deltaTime);
            if(timer>5)
            {
                EscapeReset();
                Debug.Log("MERO MORREU PRA REDE");
                timer = 0;
            }
        }
    }

    void EscapeReset()
    {
        canMove = true;
        redeMero.SetActive(false);
        codeBTap.ResetBarra(0);
        codeBTime.ResetBarra(1);
        barraTime.SetActive(false);
        barraTap.SetActive(false);
        escapeCount = 0;
    }

    void Movement()
    {
        mouseworld = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        direction = mouseworld - new Vector2(transform.position.x, transform.position.y);
        meroRotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, meroRotation - 90);
        if(canMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, mouseworld, speed*Time.deltaTime);
        }
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name.Contains("Rede"))
        {
            Destroy(other.gameObject);
            PresoNaRede();
        }
    }

    void PresoNaRede()
    {
        codeBTap.ResetBarra(0);
        codeBTime.ResetBarra(1);
        canMove = false;
        redeMero.SetActive(true);
        barraTime.SetActive(true);
        barraTap.SetActive(true);
        escapeCount = 0;
        Debug.Log("Pego na rede");
    }
}
