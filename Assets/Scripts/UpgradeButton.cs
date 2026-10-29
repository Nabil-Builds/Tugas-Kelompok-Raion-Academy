using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    public GameObject pistol;
    public GameObject rifle;
   public void upgradeWeapon()
    {
        pistol.SetActive(false);
        rifle.SetActive(true);
    }
}
