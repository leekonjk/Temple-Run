using UnityEngine;

public abstract class PICKUP_LOGIC : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameConstants.PlayerTag))
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
