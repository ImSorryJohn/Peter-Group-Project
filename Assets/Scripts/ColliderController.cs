using UnityEngine;
using StarterAssets;

public class ColliderController : MonoBehaviour
{
    private ThirdPersonController playerController;

    void Start()
    {
        playerController = GetComponentInParent<ThirdPersonController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.name);
        if (other.CompareTag("Interactable"))
        {
            playerController.mostRecentTrigger = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == playerController.mostRecentTrigger)
            playerController.mostRecentTrigger = null;
    }
}
