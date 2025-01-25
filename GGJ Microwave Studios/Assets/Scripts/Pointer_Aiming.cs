using Unity.Burst;
using UnityEngine;

[BurstCompile]
public class Pointer_Aiming : MonoBehaviour
{
    
    [Header("Options:")]
    [Tooltip("Defaults are 300.0f")]
    [SerializeField] private float m_rotationSpeed = 300.0f;

    private Vector3 m_PointerRotation;

    private bool m_Left = false;

    private bool m_Right = false;

    Vector2 m_normalDirection;

    private void FixedUpdate()
    {
        if (m_Left)
        {
            m_PointerRotation = transform.parent.rotation.eulerAngles;

            m_PointerRotation.z = m_rotationSpeed * Time.deltaTime;

            transform.parent.Rotate(m_PointerRotation);
        }

        if (m_Right)
        {
            m_PointerRotation = transform.parent.rotation.eulerAngles;

            m_PointerRotation.z = -m_rotationSpeed * Time.deltaTime;

            transform.parent.Rotate(m_PointerRotation);
        }
    }

    void Update()
    {
        // Uncomment for debug ray
    // Debug.DrawRay(transform.position,transform.up,Color.red);
 
        m_normalDirection = transform.up;

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
