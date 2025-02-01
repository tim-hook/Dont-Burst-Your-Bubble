using System.IO.Pipes;
using UnityEngine;
using UnityEngine.AI;

public class NavMesh_Follow : MonoBehaviour
{
    GameObject player;
    [SerializeField] private Animator animator;
    Vector2 facingDirection;
    NavMeshAgent agent;

    float bossCooldown = 5.0f;
    [SerializeField] GameObject BulletPrefab;
    bool bossAttacking = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        player = FindAnyObjectByType<Advanced_Player_Movement>().gameObject;
    }

    // Update is called once per frame
    async void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.transform.position);

            facingDirection = agent.destination - agent.transform.position;
            Debug.Log(facingDirection);

            if (facingDirection.magnitude != 0)
            {
                animator.SetFloat("Horizontal", facingDirection.x);

                if (tag.Contains("Boss") && !tag.Contains("Mini"))
                {
                    if (bossAttacking == true)
                    {
                        agent.speed = 0.0f;
                    }
                    else
                    {
                        agent.speed = 0.5f;
                    }
                    animator.SetFloat("Vertical", facingDirection.y);

                    if (bossCooldown <= 0)
                    {
                        bossAttacking = true;                        
                        Instantiate(BulletPrefab, new Vector3(gameObject.transform.position.x + 0.5f, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.EulerRotation(0,0,0));
                        Instantiate(BulletPrefab, new Vector3(gameObject.transform.position.x - 0.5f, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.EulerRotation(0,0,0));
                        bossCooldown = 5.0f;
                    }
                    if (bossCooldown < 4.5f)
                    {
                        bossAttacking = false;
                    }
                    bossCooldown -= Time.deltaTime;
                }
            }
        }
    }
}
