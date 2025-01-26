using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Gold : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    GameObject canvas;
    TextMeshProUGUI GoldText;
    public int m_Gold;
    void Start()
    {
        m_Gold = 0;

        canvas = GameObject.Find("PlayerCanvas");
        GoldText = canvas.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    private void Update()
    {
        GoldText.text = m_Gold.ToString();
    }

    public void addGold(int a)
    {
        m_Gold += a;
    }


}
