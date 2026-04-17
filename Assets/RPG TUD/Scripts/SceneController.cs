using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    [SerializeField] Animator transitionAnim;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        transitionAnim.gameObject.SetActive(false);
    }

    public void NextLevel()
    {
        //transitionAnim.enabled = true;
        StartCoroutine(LoadLevel1());
    }

    IEnumerator LoadLevel1()
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        ThirdPersonController controller = player.GetComponent<ThirdPersonController>();

        if (controller != null)
        {
            controller.enabled = false;
        }

        SceneManager.LoadSceneAsync("Combat Arena", LoadSceneMode.Additive);
        transitionAnim.SetTrigger("Start");
    }
}
