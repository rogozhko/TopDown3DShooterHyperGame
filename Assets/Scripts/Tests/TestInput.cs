using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestInput : MonoBehaviour
{
    public PlayerControls playerControls;

    private void Awake()
    {
        playerControls = new PlayerControls();

    }


    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }




    private void Start()
    {
        playerControls.gameplay.move_player.performed += cxt => Move(cxt);
        playerControls.gameplay.touch.performed += cxt => SomeAnotherFunc();

    }

    private void Move(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValue<Vector2>());
    }

    void SomeAnotherFunc()
    {
        // Simple func without any value in enter
        Debug.Log("Some touch happens!");
    }

}
