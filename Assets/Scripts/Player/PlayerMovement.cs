using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField] private float playerSpeed = 3f;

    public InputAction moveAction;

    [Space(20)]
    private Vector3 lastPosition;
    [Space(20)]
    public bool playerIsMoving;


    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        moveAction.Enable();


    }

    private void Update()
    {
        Vector2 input = moveAction.ReadValue<Vector2>();
        Vector3 direction = new Vector3(input.x, 0, input.y);
        controller.Move(direction * playerSpeed * Time.deltaTime);

        if (transform.position != lastPosition)
        {
            playerIsMoving = true;
        }
        else
        {
            playerIsMoving = false;
        }
        lastPosition = transform.position;


        // if (direction != Vector3.zero) Debug.Log(direction);

        // if (direction != Vector3.zero)
        // {
        //     gameObject.transform.forward = direction;
        // }

    }
}
