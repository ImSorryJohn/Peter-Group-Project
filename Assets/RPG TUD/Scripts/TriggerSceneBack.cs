using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerSceneBack : MonoBehaviour
{
    [SerializeField] Animator transitionAnim;

    private void OnDestroy()
    {
        SceneManager.LoadSceneAsync("RPG Level");
        transitionAnim.SetTrigger("Start");
    }
}
