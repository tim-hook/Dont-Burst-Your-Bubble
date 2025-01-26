using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFix : MonoBehaviour
{
 
    

    public void LoadGameScene()
    {
    
        SceneManager.LoadSceneAsync("GameScene");
    }

    public void LoadCreditsScene()
    {
       
        SceneManager.LoadSceneAsync("CreditsScene");
    }

    public void LoadMenuScene()
    {
       
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
