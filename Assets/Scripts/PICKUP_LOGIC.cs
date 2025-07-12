using UnityEngine;

public abstract class PICKUP_LOGIC : MonoBehaviour
{

    const string PlayerTag = "Player"; // Tag for the player object
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PlayerTag))
        {
            OnPickupCollected();
            Destroy(this.gameObject);
        }
    }
    void Update()
    {
        transform.Rotate(Vector3.up, 100 * Time.deltaTime);
    }
    
    protected abstract void OnPickupCollected();
}
