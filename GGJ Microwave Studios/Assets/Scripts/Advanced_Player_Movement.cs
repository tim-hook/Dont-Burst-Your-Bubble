using Unity.Burst;
using UnityEngine;

[BurstCompile]
public class Advanced_Player_Movement : MonoBehaviour
{

    private Rigidbody2D m_RB;
    private Vector2 m_PlayerDirection;
    private Animator m_Animator;

    [Header("Options:")]
    [Tooltip("Defaults are 1.0f")]
    [SerializeField] private float m_MoveSpeed = 1.0f;
    [SerializeField] private float m_Drag = 1.0f;

    void Awake()
    {
        m_RB = gameObject.GetComponent<Rigidbody2D>();
        m_Animator = gameObject.GetComponent<Animator>();
    }

    // Floaty Bubble
    void FixedUpdate()
    {
        m_RB.linearDamping = m_Drag;
        m_PlayerDirection.x = m_MoveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        m_PlayerDirection.y = m_MoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        m_RB.AddForce(m_PlayerDirection);

        if (m_PlayerDirection.magnitude > 0)
        {
            m_Animator.speed = m_PlayerDirection.magnitude;
        }
        else
        {
            m_Animator.speed = 0.0f;
        }
    }
        
    private void Update()
    {
    }


}
