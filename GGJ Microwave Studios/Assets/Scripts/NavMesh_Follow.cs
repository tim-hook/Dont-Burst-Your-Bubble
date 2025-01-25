using System.IO.Pipes;
using UnityEngine;
using UnityEngine.AI;

public class NavMesh_Follow : MonoBehaviour
{
    GameObject player;
    [SerializeField] private Animator animator;
    Vector2 facingDirection;
    NavMeshAgent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        player = FindAnyObjectByType<Advanced_Player_Movement>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.transform.position);

            facingDirection = player.transform.position - agent.transform.position;

            if (facingDirection.magnitude != 0)
            {
                animator.SetFloat("Horizontal", facingDirection.x);
            }
        }
    }
}
