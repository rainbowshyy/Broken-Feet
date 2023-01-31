using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    public InputActions InputActions { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        this.InputActions = new InputActions();
        this.InputActions.Player.Enable();
    }

    public void EnableInputs(bool enable)
    {
        if (enable)
        {
            this.InputActions.Player.Enable();
        }
        else
        {
            this.InputActions.Player.Disable();
        }
    }
}
