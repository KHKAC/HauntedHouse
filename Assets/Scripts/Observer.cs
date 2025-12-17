using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    bool isPlayerInRange;

    void OnTriggerEnter(Collider other)
    {
        if(other.transform == player)
        {
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.transform == player)
        {
            isPlayerInRange = false;
        }
    }
}
