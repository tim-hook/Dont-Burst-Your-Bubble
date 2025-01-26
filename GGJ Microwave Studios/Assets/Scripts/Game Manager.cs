using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject PurpleSlime;
    [SerializeField] GameObject GreenSlime;

    float delaySpawnMax = 25.0f;
    float delaySpawn = 25.0f;
    bool countdown = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    { 
        if (delaySpawn <= 0)
        {
            float randomEnemy = Random.value;
            if (randomEnemy > 0.5)
            {
                Instantiate(GreenSlime, new Vector3(Random.value * 8 - 4, Random.value * 8 - 1, 0), Quaternion.EulerRotation(0, 0, 0));
            }
            else if (randomEnemy <= 0.5)
            {
                Instantiate(PurpleSlime, new Vector3(Random.value * 8 - 4, Random.value * 8 - 1, 0), Quaternion.EulerRotation(0, 0, 0));
            }
            if (delaySpawnMax != 5)
            {
                delaySpawnMax -= 0.1f;
            }
            delaySpawn = delaySpawnMax;
        }
        delaySpawn -= Time.deltaTime;
    }
}
