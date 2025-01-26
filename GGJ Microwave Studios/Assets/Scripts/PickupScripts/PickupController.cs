using UnityEngine;

public class PickupController : MonoBehaviour
{

    GameObject ShieldUIElement;
    GameObject QuickChargeUIElement;
   public bool PickupShield;
    public bool QuickChargePickup;
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
