using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerControls playerControls;

    // public CharacterController controller;

    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

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
        playerControls.gameplay.move_player.performed += cxt => StartTouching(cxt);
        playerControls.gameplay.touch.canceled += cxt => StopTouching();
    }

    private float horizontal;
    private float vertical;

    private void StartTouching(InputAction.CallbackContext context)
    {
        // Debug.Log(context.ReadValue<Vector2>());
        horizontal = context.ReadValue<Vector2>().x;
        vertical = context.ReadValue<Vector2>().y;
    }

    private void StopTouching()
    {
        // Debug.Log("Stop Touching");
        horizontal = 0f;
        vertical = 0f;
    }

    private void Update()
    {
        // float horizontal = Input.GetAxisRaw("Horizontal");
        // float vertical = Input.GetAxisRaw("Vertical");


        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        // Debug.Log(direction);

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // controller.Move(direction * speed * Time.deltaTime);
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
