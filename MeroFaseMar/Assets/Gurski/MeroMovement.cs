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
    private bool isStuck = false;
    private int escapeCount = 0;
    public GameObject gameMgr;
    private GameManager gameManager;
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
        gameManager = gameMgr.GetComponent<GameManager>();
    }

    void Update()
    {
        // Debug.Log(timer);
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
            Rede(false);
        }
        if(startMoving)
        {
            Movement();
        }
        if(isStuck)
        {
            timer += Time.deltaTime;
            codeBTime.MoveBarra(-Time.deltaTime);
            if(timer>5)
            {
                Rede(false);
                gameManager.GameOver();
            }
        }
    }

    void Movement()
    {
        mouseworld = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        direction = mouseworld - new Vector2(transform.position.x, transform.position.y);
        meroRotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, meroRotation - 90);
        if(!isStuck)
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
            Rede(true);
        }
    }

    void Rede(bool preso)
    {
        timer = 0;
        codeBTap.ResetBarra(0);
        codeBTime.ResetBarra(1);
        isStuck = preso;
        redeMero.SetActive(preso);
        barraTime.SetActive(preso);
        barraTap.SetActive(preso);
        escapeCount = 0;
    }
}
