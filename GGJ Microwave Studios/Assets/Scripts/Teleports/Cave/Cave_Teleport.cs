using UnityEngine;

public class Cave_Teleport_Script : MonoBehaviour
{
    GameObject player;
    Vector2 housePos = new Vector2(7.37f, -20.66f);

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
