using Unity.VisualScripting;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    public GameObject pistol;
    public GameObject rifle;
    [SerializeField] LevelManager managerRef;
    [SerializeField] int coinNeeded;

   public void upgradeWeapon()
    {
        if(managerRef.coinCount >= coinNeeded)
        {
            pistol.SetActive(false);
            rifle.SetActive(true);
        }
        
    }
}
