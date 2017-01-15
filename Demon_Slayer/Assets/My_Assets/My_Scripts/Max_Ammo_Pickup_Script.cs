using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Max_Ammo_Pickup_Script : MonoBehaviour {

    public void MaxReload()
    {
        Debug.Log("Max Reload function called from ammo pick up");
        Player_Script.instance.MaxAmmoPickedUp();
    }
}
