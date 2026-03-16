using UnityEngine;

public class TriggerScene : MonoBehaviour
{
    [SerializeField] Animator transitionAnim;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneController.instance.NextLevel();
            transitionAnim.gameObject.SetActive(true);
        }
    }
}
