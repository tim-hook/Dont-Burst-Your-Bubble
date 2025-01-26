using UnityEngine;

public class ChargeMeter : MonoBehaviour
{
    BubbleBlower blower;
    SpriteRenderer[] spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        blower = GetComponentInParent<BubbleBlower>();
        spriteRenderer = GetComponentsInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < spriteRenderer.Length; i++)
        {
            spriteRenderer[i].enabled = false;
        }


        if (blower.m_CurrentCharge == 100)
        {
            spriteRenderer[4].enabled = true;
        }
        else if (blower.m_CurrentCharge >= 75)
        {
            spriteRenderer[3].enabled = true;
        }
        else if (blower.m_CurrentCharge >= 50)
        {
            spriteRenderer[2].enabled = true;
        }
        else if (blower.m_CurrentCharge >= 25)
        {
            spriteRenderer[1].enabled = true;
        }
        else 
        {
            spriteRenderer[0].enabled = true;
        }
    }
}
