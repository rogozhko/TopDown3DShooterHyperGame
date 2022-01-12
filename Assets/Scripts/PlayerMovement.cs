using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField] private float playerSpeed = 3f;


    public InputAction moveAction;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        moveAction.Enable();
    }

    private void Update()
    {
        Vector2 input = moveAction.ReadValue<Vector2>();
        Vector3 direction = new Vector3(input.x, 0, input.y);

        // if (direction != Vector3.zero) Debug.Log(direction);


        controller.Move(direction * playerSpeed * Time.deltaTime);

        // if (direction != Vector3.zero)
        // {
        //     gameObject.transform.forward = direction;
        // }

    }
}
