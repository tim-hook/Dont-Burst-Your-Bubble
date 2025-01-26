using UnityEngine;

public class ShieldPickup : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.gameObject.name == "Player")
        {

            PickupController PickupComponent = collision.collider.gameObject.GetComponent<PickupController>();
            PickupComponent.ApplyShield();
            Destroy(gameObject);
        }
    }
}