using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Game_Controller_Script : MonoBehaviour
{
    public static Game_Controller_Script instance;          // Ensures there is only 1 instance of this object

    public GameObject playerGO;                             // Get the player GO from prefabs folder

    public GameObject enemyGO;

    [SerializeField]
    private Text AmmoText;                                  // Assign AmmoText from scene

    [SerializeField]
    private Scrollbar healthScrollbar;

    void Awake()                                            // First function to run in scene
    {
        instance = this;                                    // This object is the only instance of Game_Controller_Script
    }

    void Start()                                            // Sceond function to run in scene
    {
        if (AmmoText == null)                               // Check if the AmmoText has been assigned already
            AmmoText = GameObject.Find("Ammo_Text").GetComponent<Text>();       // If the AmmoText hasn't been assigned assign it

        if (healthScrollbar == null)
            healthScrollbar = GameObject.Find("Health_Scrollbar").GetComponent<Scrollbar>();

        Instantiate(playerGO, new Vector3(1, 1, 1), Quaternion.Euler(0, 0, 0));         // Create player in scene

        SpawnEnemy(enemyGO);                    // Spawn Enemy
    }

    private void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, new Vector3(10, 0, 10), Quaternion.Euler(0, 0, 0));
    }

    public void UpdateAmmoText(string message)
    {
        AmmoText.text = message;
    }

    public void UpdateHealthScrollbar(int health)
    {
        Player_Script.instance.DecreaseHealth(health);
        healthScrollbar.size = (float)Player_Script.instance.Health() / (float)Player_Script.instance.MaxHealth();
    }
}
