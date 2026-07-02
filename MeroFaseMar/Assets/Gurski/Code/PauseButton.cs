using UnityEngine;
using UnityEngine.InputSystem;

public class PauseButton : MonoBehaviour
{
    public InputActionAsset InputActions;
    public GameObject pauseMenu;
    private InputActionMap playerMap;
    private InputAction pauseAction, unpauseAction;

    void Start()
    {
        pauseAction = InputSystem.actions.FindAction("Pause");
        unpauseAction = InputSystem.actions.FindAction("Unpause");
    }

    void Update()
    {
        if(pauseAction.WasPressedThisFrame())
        {
            Pause(true);
        }
        else if(unpauseAction.WasPressedThisFrame())
        {
            Pause(false);
        }
    }

    public void Pause(bool pause)
    {
        pauseMenu.SetActive(pause);
        if(pause)
        {
            Time.timeScale = 0;
            InputActions.FindActionMap("Player").Disable();
            InputActions.FindActionMap("UI").Enable();
        }
        else
        {
            Time.timeScale = 1;
            InputActions.FindActionMap("UI").Disable();
            InputActions.FindActionMap("Player").Enable();
        }
    }
}
