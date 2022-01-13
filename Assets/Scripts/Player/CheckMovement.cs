using UnityEngine;
using UnityEngine.InputSystem;

public class CheckMovement : MonoBehaviour
{
    [Space(20)]
    private Vector3 lastPosition;
    [Space(20)]
    public bool playerIsMoving;

    private void Update()
    {
        if (transform.position != lastPosition)
        {
            playerIsMoving = true;
        }
        else
        {
            playerIsMoving = false;
        }
        lastPosition = transform.position;
    }
}
