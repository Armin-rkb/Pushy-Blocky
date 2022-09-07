using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxForce;
    private Vector2 moveDir;
    private Vector2 baseMoveDir = new Vector2(0, 0.25f);

    public void OnMove(InputAction.CallbackContext context) 
    {
        moveDir = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector3 currentVelocity = rb.velocity;

        // Get our new direction.
        Vector2 newMoveDir = baseMoveDir + moveDir;
        Mathf.Clamp(moveDir.x, -1, 1);
        Mathf.Clamp(moveDir.y, -1, 1);

        // Set the target velocity to move towards.
        Vector3 targetVelocity = new Vector3(newMoveDir.x, 0, newMoveDir.y);
        targetVelocity *= speed;

        Vector3 velocityChange = (targetVelocity - currentVelocity);
        Vector3.ClampMagnitude(velocityChange, maxForce);

        // Add force to the changed velocity.
        rb.AddForce(velocityChange, ForceMode.Impulse);
    }

    private void HidePlayer()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
    }

    private void ShowPlayer()
    {
        gameObject.GetComponent<Renderer>().enabled = true;
    }

    private void StopPlayerMovement()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void ResetPlayer()
    {
        StopPlayerMovement();
        rb.position = Vector3.zero;
    }

    private void OnEnable()
    {
        GameController.OnStartGame += ResetPlayer;
    }

    private void OnDisable()
    {
        GameController.OnStartGame -= ResetPlayer;
    }
}
