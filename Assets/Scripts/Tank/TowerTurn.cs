using UnityEngine;
using UnityEngine.InputSystem;

public class TowerTurn : MonoBehaviour
{
    private Vector2 turn;
    public float sensitivity;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
 
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, turn.x * Time.deltaTime);
        //transform.Rotate(transform.right, turn.y);
    }

    public void HandleTower(InputAction.CallbackContext context)
    {
        turn.x = context.ReadValue<Vector2>().x * sensitivity;
        turn.y = context.ReadValue<Vector2>().y * sensitivity;
    }
}
