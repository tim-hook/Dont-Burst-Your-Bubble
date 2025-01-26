using Unity.Burst;
using UnityEngine;

[BurstCompile]
public class Advanced_Player_Movement : MonoBehaviour
{
    private Rigidbody2D m_RB;
    private Animator m_Animator;
    public Vector2 m_PlayerDirection;

    [Header("Options:")]
    [Tooltip("Default is 1.0f")]
    [SerializeField] public float m_MoveSpeed = 1.0f;

    [Tooltip("Default is 1.0f")]
    [SerializeField] private float m_Drag = 1.0f;

    private void Awake()
    {
        m_RB = gameObject.GetComponent<Rigidbody2D>();

  


        if (!m_RB)
        {
            Debug.LogError("Rigidbody2D is missing!", this);
        }

          m_Animator = gameObject.GetComponent<Animator>();
    }

    // Floaty Bubble
    private void FixedUpdate()
    {
        m_RB.linearDamping = m_Drag;
        m_PlayerDirection.x = m_MoveSpeed * Input.GetAxis("Horizontal") * Time.fixedDeltaTime;
        m_PlayerDirection.y = m_MoveSpeed * Input.GetAxis("Vertical") * Time.fixedDeltaTime;
        m_RB.AddForce(m_PlayerDirection);
    }
        
    private void Update()
    {
    }
}