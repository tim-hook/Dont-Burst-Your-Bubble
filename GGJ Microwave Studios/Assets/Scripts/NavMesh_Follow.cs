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

            facingDirection = agent.destination - agent.transform.position;
            Debug.Log(facingDirection);

            if (facingDirection.magnitude != 0)
            {
                animator.SetFloat("Horizontal", facingDirection.x);

                if (tag.Contains("Boss"))
                {
                    animator.SetFloat("Vertical", facingDirection.y);
                }
            }
        }
    }
}
