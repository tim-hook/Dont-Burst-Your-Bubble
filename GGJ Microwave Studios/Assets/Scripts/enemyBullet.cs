using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    GameObject player;
    Vector3 direction;
    float lifeTime = 2.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindAnyObjectByType<Advanced_Player_Movement>().gameObject;
        direction = player.transform.position - gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += direction * Time.deltaTime * 2;
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
