using UnityEngine;

public class Castle_Teleport_Script : MonoBehaviour
{
    GameObject player;
    AudioManagerScript audioManager;    
    Vector2 housePos = new Vector2(45.1f, -16.33f);

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
            audioManager.FadeOut("BackgroundMusic");
            audioManager.FadeIn("MinibossMusic", 75);
            audioManager.SetLoopingState("MiniBossMusic", true);
            player.transform.position = housePos;
        }
    }
}
