using UnityEngine;

public class Buy : MonoBehaviour
{
    GameObject player;
    AudioManagerScript audioManager;

    [SerializeField] GameObject priceText;
    [SerializeField] GameObject priceImage;
    [SerializeField] int price;

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
        if(collision.CompareTag("Player") && player.GetComponent<Gold>().m_Gold >= price)
        {
            audioManager.PlaySound("BuySFX");
            player.GetComponent<Gold>().m_Gold -= price;
            Destroy(priceImage);
            Destroy(priceText);
            Destroy(gameObject);
        }
    }
}
