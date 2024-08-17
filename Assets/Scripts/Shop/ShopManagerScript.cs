using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ShopManagerScript : MonoBehaviour
{
    public int[,] shopItems = new int[5, 5];
    public int gold;
    public TextMeshProUGUI GoldTxt;
    public GameObject shopCanvas;
    [SerializeField] private Player player;
    [SerializeField] private PlayerStatsUI playerStatsUI;
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] PlayerHealthText playerHealthText;
  
    private bool isGamePaused = false;

    void Start()
    {

        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;

        shopItems[2, 1] = 10;
        shopItems[2, 2] = 20;
        shopItems[2, 3] = 30;
        shopItems[2, 4] = 40;

        shopItems[3, 1] = 0;
        shopItems[3, 2] = 0;
        shopItems[3, 3] = 0;
        shopItems[3, 4] = 0;

        gold = player.GetGold();
        UpdateGoldText();


        shopCanvas.SetActive(false);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePauseGame();
        }
    }

    void TogglePauseGame()
    {
        isGamePaused = !isGamePaused;

        if (isGamePaused)
        {

            Time.timeScale = 0f;
            shopCanvas.SetActive(true);

            gold = player.GetGold();
            UpdateGoldText();
        }
        else
        {

            Time.timeScale = 1f;
            shopCanvas.SetActive(false);
        }
    }
    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        int itemID = ButtonRef.GetComponent<itemInfo>().itemID;

        if (gold >= shopItems[2, itemID])
        {
            gold -= shopItems[2, itemID];
            shopItems[3, itemID]++;
            UpdateGoldText();
            ButtonRef.GetComponent<itemInfo>().QuantityTxt.text = shopItems[3, itemID].ToString();


            player.SetGold(gold);


            playerStatsUI.SetGoldEarned(gold);


            ApplyItemEffect(itemID);
        }
    }
    private void ApplyItemEffect(int itemID)
    {
        switch (itemID)
        {
            case 1:
                //float newHealth = player.GetHealth() + 100f;
                //if (newHealth > player.GetHealth())
                //{
                //    newHealth = player.GetHealth();
                //}
                player.SetHealth(player.GetHealth() + 100f);
                if (player.GetHealth() > player.GetMaxHealth())
                {
                    player.SetHealth(player.GetMaxHealth());
                }
                playerHealth.SetHealth(player.GetHealth());
                playerHealthText.setHealthText(player.GetHealth(), player.GetMaxHealth(), 0.9f);
                break;
            case 2:
                player.SetBaseAttackDamage(player.GetBaseAttackDamage() + 10f);
                player.SetAttackDamage(player.GetBaseAttackDamage());
                playerStatsUI.SetAttackDamage(player.GetAttackDamage());
                break;
            case 3:
                float oldMaxHealth = player.GetMaxHealth();
                player.SetMaxHealth(player.GetMaxHealth() + 100f);
                if (player.GetHealth() == oldMaxHealth)
                {
                    player.SetHealth(player.GetMaxHealth());
                }
                playerHealth.SetMaxHealth(player.GetMaxHealth());
                playerHealthText.setHealthText(player.GetHealth(), player.GetMaxHealth(), 0.9f);
                break;
            case 4:
                player.SetBaseAttackSpeed(player.GetBaseAttackSpeed() * 2f);
                player.SetAttackSpeed(player.GetBaseAttackSpeed());
                playerStatsUI.SetAttackSpeed(player.GetAttackSpeed());
                break;
            default:
                Debug.LogWarning("Unkown Item ID: " + itemID);
                break;
        }
    }

    private void UpdateGoldText()
    {
        GoldTxt.text = "Gold: " + gold.ToString();
    }
}
