using UnityEngine;

public class Destory_PreFerbs_To_Destory : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        // Check if the object has a specific tag or component before destroying it
    }
}
