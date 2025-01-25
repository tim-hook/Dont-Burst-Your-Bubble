using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public GameObject m_control_Settings_Panel;

    [SerializeField] private Animator animator;
    [SerializeField] private Image fadeImage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        fadeImage.gameObject.SetActive(false);

        if (Instance == null )
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void LoadGameScene()
    {
        StartCoroutine(LoadLevel("GameScene"));
    }

    public void LoadCreditsScene()
    {
        StartCoroutine(LoadLevel("CreditsScene"));
    }
    
    public void LoadMenuScene()
    {
        StartCoroutine(LoadLevel("MainMenu"));
    }


    private IEnumerator LoadLevel(string levelName)
    {
        fadeImage.gameObject.SetActive (true);
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadSceneAsync(levelName);
        yield return new WaitForSeconds(1.0f);
        animator.SetTrigger("End");
        yield return new WaitForSeconds(2.0f);
        fadeImage.gameObject.SetActive (false);

    }
}
