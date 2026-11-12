using UnityEngine;
using UnityEngine.InputSystem;

public class PauseButton : MonoBehaviour
{
    public InputActionAsset InputActions;
    public GameObject pauseMenu;
    private InputActionMap playerMap, uiMap;
    private InputAction pauseAction, unpauseAction;

    void Start()
    {
        pauseAction = InputSystem.actions.FindAction("Pause");
        unpauseAction = InputSystem.actions.FindAction("Unpause");
        playerMap = InputActions.FindActionMap("Player");
        uiMap = InputActions.FindActionMap("UI");
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
            Debug.Log("pauseGM");
            playerMap.Disable();
            uiMap.Enable();
        }
        else
        {
            Debug.Log("unpauseGM");
            uiMap.Disable();
            playerMap.Enable();
            Time.timeScale = 1;
        }
    }
}