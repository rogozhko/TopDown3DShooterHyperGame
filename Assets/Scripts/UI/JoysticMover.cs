using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class JoysticMover : MonoBehaviour
{
    public InputAction touchStart;
    public InputAction touchPosition;
    public InputAction touchEnd;

    [Space(20)]

    public Image image;
    public Image imageChild;

    private void Start()
    {
        touchStart.Enable();
        touchPosition.Enable();
        touchEnd.Enable();

        touchStart.performed += MoveToTouch;
        touchEnd.canceled += EndTouch;

        HideJoystick();
    }

    private void MoveToTouch(InputAction.CallbackContext context)
    {
        ShowJoystick();
        Vector2 touchPos = touchPosition.ReadValue<Vector2>();
        transform.position = touchPos;
    }

    private void ShowJoystick()
    {
        image.color = new Color(1.0f, 1.0f, 1.0f, 0.3f);
        imageChild.color = new Color(1.0f, 1.0f, 1.0f, 1f);
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        // Debug.Log("Hide");
        HideJoystick();
    }

    private void HideJoystick()
    {
        image.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        imageChild.color = new Color(1.0f, 1.0f, 1.0f, 0f);
    }



}
