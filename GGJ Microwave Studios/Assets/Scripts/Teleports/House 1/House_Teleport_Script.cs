using UnityEngine;

public class House_Teleport_Script : MonoBehaviour
{
    GameObject player;
  
    Camera camera;
    Vector2 housePos = new Vector2(22.4f, 4.4f);

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
