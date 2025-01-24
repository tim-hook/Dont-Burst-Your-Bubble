using UnityEngine;

public class Advanced_Player_Movement : MonoBehaviour
{

    private Rigidbody2D m_RB;
    private Vector2 m_PlayerDirection;

    [Header("Options:")]
    [Tooltip("Defaults are 1.0f")]
    [SerializeField] private float m_MoveSpeed = 1.0f;
    [SerializeField] private float m_Drag = 1.0f;
    

 
    void Awake()
    {
        m_RB = gameObject.GetComponent<Rigidbody2D>();
    }

    // Floaty Bubble
    void FixedUpdate()
    {
        m_RB.linearDamping = m_Drag;
        m_PlayerDirection.x = m_MoveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        m_PlayerDirection.y = m_MoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        m_RB.AddForce(m_PlayerDirection);
    }


}
