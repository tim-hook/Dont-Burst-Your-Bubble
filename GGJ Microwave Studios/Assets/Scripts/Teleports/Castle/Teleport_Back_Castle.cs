using UnityEngine;

public class Teleport_Back_Castle : MonoBehaviour
{
    GameObject player;
    AudioManagerScript audioManager;
    Vector2 housePos = new Vector2(1.13f, 5.38f);

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
            audioManager.FadeOut("MinibossMusic");
            audioManager.FadeIn("BackgroundMusic", 75);
            player.transform.position = housePos;
        }
    }
}
