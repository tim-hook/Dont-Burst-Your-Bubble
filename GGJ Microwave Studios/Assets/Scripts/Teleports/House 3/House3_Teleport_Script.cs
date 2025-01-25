using UnityEngine;

public class House3_Teleport_Script : MonoBehaviour
{
    GameObject player;
    Vector2 housePos = new Vector2(39.85f, 4.3f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
        }
    }
}
