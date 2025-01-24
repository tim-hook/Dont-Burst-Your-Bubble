using UnityEngine;

public class Pointer_Aiming : MonoBehaviour
{

    [SerializeField] private float m_PointerRotation = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_PointerRotation > 360.0f)
        {
            m_PointerRotation = 0.0f;
        }
    }
}
