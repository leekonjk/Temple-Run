using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Vector2 movement;
    [SerializeField]  float horizontal = 3f;
    [SerializeField]  float vertical = 3f;
    [SerializeField]  float speed = 15f; // Speed of the player

    Rigidbody rigidBody;
    public void Move(InputAction.CallbackContext callback)
    {
        movement = callback.ReadValue<Vector2>();
    }
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        movePlayer();
    }

    private void movePlayer()
    {
        Vector3 new_position = findPosition();
        new_position = movePosition(new_position);
    }

    private Vector3 movePosition(Vector3 new_position)
    {
        new_position.x = Mathf.Clamp(new_position.x, -horizontal, horizontal);
        new_position.z = Mathf.Clamp(new_position.z, -vertical, vertical);
        rigidBody.MovePosition(new_position);
        return new_position;
    }

    private Vector3 findPosition()
    {
        Vector3 movement1 = rigidBody.position;
        Vector3 move_to_position = new Vector3(movement.x, 0, movement.y);
        Vector3 new_position = movement1 + move_to_position * (speed * Time.fixedDeltaTime);
        return new_position;
    }
}
