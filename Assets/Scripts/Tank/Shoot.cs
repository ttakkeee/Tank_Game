using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    public float launchSpeed = 75.0f;
    public GameObject objectPrefab;

    void SpawnObject()
    {
        //direction dans laquelle le missile va 
        Vector3 localXDirection = transform.TransformDirection(Vector3.forward);
        Vector3 velocity = localXDirection * launchSpeed;

        //Instantiate object 
        GameObject newObject = Instantiate(objectPrefab, transform.position, Quaternion.identity);

        Rigidbody rb = newObject.GetComponent<Rigidbody>();
        rb.velocity = velocity;
        
        //ADD SOUND EFFECT
        AudioManager.Instance.PlaySFX("Shoot");
    }

    public void HandleShoot(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            SpawnObject();
        }
    }
}
