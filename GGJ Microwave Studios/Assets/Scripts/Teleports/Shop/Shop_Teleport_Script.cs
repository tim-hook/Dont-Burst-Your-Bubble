using UnityEngine;

public class Shop_Teleport_Script : MonoBehaviour
{
    GameObject player;
    AudioManagerScript audioManager;
    Vector2 housePos = new Vector2(41.72f, -2.32f);

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
            audioManager.FadeOut("BackgroundMusic");
            audioManager.FadeIn("ShopMusic ", 55.0f);
            audioManager.SetVolume("ShopMusic ", 45.0f);
            
        }
    }
}
