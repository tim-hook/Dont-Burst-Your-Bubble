using UnityEngine;

public class CoinPickupScript : MonoBehaviour
{
    CircleCollider2D circleCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

       if( collision.collider.gameObject.name == "Player")
        {

            Gold player = collision.collider.gameObject.GetComponent<Gold>();
            player.addGold(1);
            Destroy(gameObject);

        } 
    }
}
