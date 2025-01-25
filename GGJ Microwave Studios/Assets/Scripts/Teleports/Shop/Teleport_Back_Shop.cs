using UnityEngine;

public class Teleport_Back_Shop : MonoBehaviour
{
    GameObject player;
    AudioManagerScript audioManager;
    Vector2 housePos = new Vector2(3.17f, 3.72f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManagerScript>();
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
            audioManager.FadeOut("ShopMusic ");
            audioManager.FadeIn("BackgroundMusic", 75.0f);
            audioManager.SetLoopingState("BackgroundMusic", true);

        }
    }
}
