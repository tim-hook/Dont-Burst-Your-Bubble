using UnityEngine;

public class Teleport_Back_Cave : MonoBehaviour
{
    GameObject player;
    AudioManagerScript audioManager;
    Vector2 housePos = new Vector2(0.0f, 9.0f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.transform.position = housePos;
            audioManager.FadeOut("BossTheme");
            audioManager.FadeIn("BackgroundMusic", 75.0f);
            audioManager.SetLoopingState("BackgroundMusic", true);
        }
    }
}
