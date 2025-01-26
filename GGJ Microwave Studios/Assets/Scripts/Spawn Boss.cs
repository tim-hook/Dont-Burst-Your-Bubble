using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    GameObject player;
    [SerializeField] GameObject Boss;
    private bool bossSpawned = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && bossSpawned == false)
        {
            bossSpawned = true;
            Instantiate(Boss, new Vector3(7.3f, -17.3f, 0), Quaternion.EulerRotation(0, 0, 0));
        }
    }
}
