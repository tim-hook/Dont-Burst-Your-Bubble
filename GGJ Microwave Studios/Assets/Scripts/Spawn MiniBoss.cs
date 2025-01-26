using UnityEngine;

public class SpawnMiniBoss : MonoBehaviour
{
    GameObject player;
    [SerializeField] GameObject MiniBoss;
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
            Instantiate(MiniBoss, new Vector3(43.17f, -12.8f, 0), Quaternion.EulerRotation(0, 0, 0));
        }
    }
}
