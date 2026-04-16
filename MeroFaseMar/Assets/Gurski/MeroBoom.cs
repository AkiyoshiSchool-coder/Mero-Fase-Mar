using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class MeroBoom : MonoBehaviour
{
    public GameObject boom;
    public List<GameObject> Sounds = new List<GameObject>();
    public InputActionAsset InputActions;
    private InputAction boomAction;
    [SerializeField] private bool noAbrigo;
    private float timer = 0;
    void Awake()
    {
        boomAction = InputSystem.actions.FindAction("Attack");
    }

    void Update()
    {
        if(noAbrigo && timer <= 0)
        {
            if(boomAction.WasPressedThisFrame())
            {
                Instantiate(boom, transform.position, Quaternion.identity);
                int decider = Random.Range(0,4);
                Instantiate(Sounds[decider], transform.position, Quaternion.identity);
                timer = 0.5f;
            }
        }
    }

    void FixedUpdate()
    {
        timer -= Time.deltaTime;
    }

    public void Abrigo(bool estanoabrigo)
    {
        noAbrigo = estanoabrigo;
    }
}
