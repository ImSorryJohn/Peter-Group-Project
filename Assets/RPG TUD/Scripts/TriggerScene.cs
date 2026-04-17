using UnityEngine;
using System.Collections;

public class TriggerScene : MonoBehaviour
{
    [SerializeField] Animator transitionAnim;
    public GameObject Enemy;
    bool triggered = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player") && !triggered)
        {
            triggered = true;
            StartCoroutine(HandleTrigger());
        }
    }

    IEnumerator HandleTrigger()
    {
        SceneController.instance.NextLevel();

        transitionAnim.gameObject.SetActive(true);

        yield return new WaitForSeconds(1);

        Destroy(Enemy);
    }
}
