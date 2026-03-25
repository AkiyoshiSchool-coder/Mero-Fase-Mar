using UnityEngine;
using UnityEngine.InputSystem;

public class MeroBoom : MonoBehaviour
{
    public GameObject boom;
    public InputActionAsset InputActions;
    private InputAction boomAction;
    void Awake()
    {
        boomAction = InputSystem.actions.FindAction("Attack");
    }

    void Update()
    {
        if(boomAction.WasPressedThisFrame())
        {
            Instantiate(boom, transform.position, Quaternion.identity);
        }
    }
}
