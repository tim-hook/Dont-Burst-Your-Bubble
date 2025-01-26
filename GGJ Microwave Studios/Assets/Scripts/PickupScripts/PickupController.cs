using TMPro;
using UnityEngine;

public class PickupController : MonoBehaviour
{

    GameObject ShieldUIElement;
    GameObject QuickChargeUIElement;
    public bool PickupShield;
    public bool QuickChargePickup;
    float QuickChargeTimer = 0.0f;
    int minutes;
    int seconds;
    string textTimer;
    [SerializeField] TextMeshProUGUI timerText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ShieldUIElement = GameObject.Find("PlayerCanvas/Shield");
        ShieldUIElement.SetActive(false);
        QuickChargeUIElement = GameObject.Find("PlayerCanvas/QuickCharge");
        QuickChargeUIElement.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        QuickChargeTimer -= Time.deltaTime;
        minutes = (int)QuickChargeTimer / 60;
        seconds = (int)QuickChargeTimer % 60;
        if (seconds < 10)
        {
            textTimer = minutes.ToString() + ":0" + seconds.ToString();
        }
        else
        {
            textTimer = minutes.ToString() + ":" + seconds.ToString();
        }

        if (minutes <= 0 &&  seconds <= 0)
        {
            RemoveChargeMushroom();
        }
        timerText.text = textTimer;
    }
    public void ApplyShield()
    {
        PickupShield = true;
        ShieldUIElement.SetActive(true);
    }
    public void AddChargeMushroom()
    {
        if (!QuickChargePickup)
        {
            QuickChargePickup = true;
            QuickChargeUIElement.SetActive(true);
        }
        QuickChargeTimer += 60;
       

    }

    public void RemoveChargeMushroom()
    {
        QuickChargePickup = false;
        QuickChargeUIElement.SetActive(false);
    }

    public void RemoveShield()
    {
        PickupShield = false;
        ShieldUIElement.SetActive(false);  
    }
}
