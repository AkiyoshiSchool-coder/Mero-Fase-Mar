using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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

    private bool isStuck = false;
    private int escapeCount = 0;

    public GameObject gameMgr;
    private GameManager gameManager;

    public GameObject redeMero;
    public GameObject barraTime, barraTap;
    private MoveBarrinha codeBarraTime, codeBarraTap;
    public GameObject RedeVerifier;
    private float timer = 0;

    [SerializeField] private float horizontalLimit, verticalLimit;
    
    void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        escapeAction = InputSystem.actions.FindAction("Escape");
        codeBarraTime = barraTime.GetComponent<MoveBarrinha>();
        codeBarraTap = barraTap.GetComponent<MoveBarrinha>();
        gameManager = gameMgr.GetComponent<GameManager>();
    }

    void Update()
    {
        if(escapeAction.WasPerformedThisFrame())
        {
            escapeCount++;
            codeBarraTap.MoveBarra(1);
            Debug.Log(escapeCount);
        }
        if(escapeCount >= 5)
        {
            if(RedeVerifier != null)
            {
                Destroy(RedeVerifier);
            }
            Rede(false);
        }
        if(isStuck)
        {
            timer += Time.deltaTime;
            codeBarraTime.MoveBarra(-Time.deltaTime);
            if(timer>5)
            {
                Rede(false);
                gameManager.GameOver();
            }
        }

        Movement();
    }

    void Movement()
    {
        if(Application.platform == RuntimePlatform.WindowsEditor)
        {
            mouseworld = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        }
        else if(Application.platform == RuntimePlatform.Android)
        {
            if(moveAction.IsPressed())
            {
                Vector2 mov = moveAction.ReadValue<Vector2>();
                mouseworld = transform.position + new Vector3(mov.x, mov.y, 0);
            }
        }

        direction = mouseworld - new Vector2(transform.position.x, transform.position.y);
        meroRotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg * Time.timeScale;
        transform.rotation = Quaternion.Euler(0, 0, meroRotation - 90);

        if(!isStuck)
        {
            transform.position = Vector2.MoveTowards(transform.position, mouseworld, speed*Time.deltaTime);
        }

        if(transform.position.x > horizontalLimit)
        {
            transform.position = new Vector3(horizontalLimit, transform.position.y, transform.position.z);
        }
        else if(transform.position.x < -horizontalLimit)
        {
            transform.position = new Vector3(-horizontalLimit, transform.position.y, transform.position.z);
        }
        if(transform.position.y > verticalLimit)
        {
            transform.position = new Vector3(transform.position.x, verticalLimit, transform.position.z);
        }
        else if(transform.position.y < -verticalLimit)
        {
            transform.position = new Vector3(transform.position.x, -verticalLimit, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Rede"))
        {
            Destroy(other.gameObject);
            Rede(true);
        }
    }

    void Rede(bool preso)
    {
        timer = 0;
        codeBarraTap.ResetBarra(0);
        codeBarraTime.ResetBarra(1);
        isStuck = preso;
        redeMero.SetActive(preso);
        barraTime.SetActive(preso);
        barraTap.SetActive(preso);
        escapeCount = 0;
    }
}