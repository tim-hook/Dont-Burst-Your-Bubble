using Unity.Burst;
using UnityEngine;

[BurstCompile]
public class Pointer_Aiming : MonoBehaviour
{
    [Header("Options:")]
    [Tooltip("Default is 300.0f")]
    [SerializeField] private float m_RotationSpeed = 300.0f;

    [Header("Normal Vector:")]
    [Tooltip("Use when spawning projectiles")]
    public Vector2 m_NormalDirection;

    [Header("Debug:")]
    [Tooltip("Use to see the normal direction")]
    [SerializeField] private bool DrawRay = false;

    // Uhhhhh
    private bool m_Left = false;

    private bool m_Right = false;

    private void FixedUpdate()
    {
        // Forgor about time.fixedDeltaTime
        var rotationAmount = m_RotationSpeed * Time.fixedDeltaTime;

        if (m_Left)
        {
            transform.parent.Rotate(0, 0, rotationAmount);
        }
        else if (m_Right)
        {
            transform.parent.Rotate(0, 0, -rotationAmount);
        }
    }

    private void Update()
    {
        if (DrawRay) Debug.DrawRay(transform.position, transform.up, Color.red);

        m_NormalDirection = transform.up;

        // This fucking is the worst - Ryan
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            m_Left = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            m_Left = false;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            m_Right = true;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            m_Right = false;
        }
    }
}