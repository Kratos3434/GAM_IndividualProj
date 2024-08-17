using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AbilityController : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] PlayerStatsUI playerStatsUI;
    [SerializeField] PlayerHealthText playerHealthText;
    [SerializeField] PlayerHealth playerHealth;

    [SerializeField] Image q_cooldown;
    [SerializeField] TextMeshProUGUI q_cdTimer;

    [SerializeField] Image w_cooldown;
    [SerializeField] TextMeshProUGUI w_cdTimer;

    [SerializeField] Image e_cooldown;
    [SerializeField] TextMeshProUGUI e_cdTimer;

    [SerializeField] Image r_cooldown;
    [SerializeField] TextMeshProUGUI r_cdTimer;

    private float q_cooldownTime = 0f;
    private float w_cooldownTime = 0f;
    private float e_cooldownTime = 0f;
    private float r_cooldownTime = 0f;
    private float r_duration = 0f;

    private float BONUS_DAMAGE = 50f;
    private float BONUS_MOVEMENT = .50f;
    private float BONUS_HEALTH = 100f;

    private bool q_isEnabled = false;
    private bool w_isEnabled = false;
    private bool e_isEnabled = false;
    private bool r_isEnabled = false;

    private void Awake()
    {
        q_cooldown.enabled = false;
        w_cooldown.enabled = false;
        e_cooldown.enabled = false;
        r_cooldown.enabled = false;

        q_cdTimer.enabled = false;
        w_cdTimer.enabled = false;
        e_cdTimer.enabled = false;
        r_cdTimer.enabled = false;
    }

    // Start is called before the first frame update
    //void Start()
    //{
    //    q_cooldown.enabled = false;
    //    w_cooldown.enabled = false;
    //    e_cooldown.enabled = false;
    //    r_cooldown.enabled = false;

    //    q_cdTimer.enabled = false;
    //    w_cdTimer.enabled = false;
    //    e_cdTimer.enabled = false;
    //    r_cdTimer.enabled = false;
    //}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) {
            Debug.Log(q_cooldownTime);
            if (q_cooldownTime == 0)
            {
                player.SetAttackDamage(player.GetAttackDamage() + BONUS_DAMAGE);
                playerStatsUI.SetAttackDamage(player.GetAttackDamage());
                q_cooldown.enabled = true;
                q_cdTimer.enabled = true;
                q_cooldownTime = 10f;
                q_cdTimer.SetText((int)q_cooldownTime + "s");
                q_isEnabled = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (w_cooldownTime == 0)
            {
                player.SetHealth(player.GetHealth() + BONUS_HEALTH);
                if (player.GetHealth() > player.GetMaxHealth())
                {
                    player.SetHealth(player.GetMaxHealth());
                }
                playerHealth.SetHealth(player.GetHealth());
                playerHealthText.setHealthText(player.GetHealth(), player.GetMaxHealth(), 0.9f);
                w_cooldown.enabled = true;
                w_cdTimer.enabled = true;
                w_cooldownTime = 20f;
                w_cdTimer.SetText((int)w_cooldownTime + "s");
                w_isEnabled = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E");
            if (e_cooldownTime == 0)
            {
                player.SetAttackSpeed(player.GetAttackSpeed() + (player.GetAttackSpeed() * BONUS_MOVEMENT));
                playerStatsUI.SetAttackSpeed(player.GetAttackSpeed());
                e_cooldown.enabled = true;
                e_cdTimer.enabled = true;
                e_cooldownTime = 15f;
                e_cdTimer.SetText((int)e_cooldownTime + "s");
                e_isEnabled = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (r_cooldownTime == 0)
            {
                r_cooldown.enabled = true;
                r_cdTimer.enabled = true;
                r_cooldownTime = 30f;
                r_cdTimer.SetText((int)r_cooldownTime + "s");
                r_isEnabled = true;
                r_duration = 5f;
            }
        }

        //Check the timers
        //Q
        if (q_cooldownTime > 0)
        {
            q_cooldownTime -= Time.deltaTime;
            q_cdTimer.SetText((int)q_cooldownTime + "s");
        } else if (q_cooldownTime <= 0 && q_isEnabled)
        {
            q_cooldown.enabled = false;
            q_cdTimer.enabled = false;
            player.SetAttackDamage(player.GetAttackDamage() - BONUS_DAMAGE);
            playerStatsUI.SetAttackDamage(player.GetAttackDamage());
            q_isEnabled = false;
            q_cooldownTime = 0;
        }
        //W
        if (w_cooldownTime > 0)
        {
            w_cooldownTime -= Time.deltaTime;
            w_cdTimer.SetText((int)w_cooldownTime + "s");
        } else if (w_cooldownTime <= 0 && w_isEnabled)
        {
            w_cooldown.enabled = false;
            w_cdTimer.enabled = false;
            w_isEnabled = false;
            w_cooldownTime = 0;
        }
        //E
        if (e_cooldownTime > 0)
        {
            e_cooldownTime -= Time.deltaTime;
            e_cdTimer.SetText((int)e_cooldownTime + "s");
        }
        else if (e_cooldownTime <= 0 && e_isEnabled)
        {
            e_cooldown.enabled = false;
            e_cdTimer.enabled = false;
            player.SetAttackSpeed(player.GetAttackSpeed() - (player.GetAttackSpeed() * BONUS_MOVEMENT));
            playerStatsUI.SetAttackSpeed(player.GetAttackSpeed());
            e_isEnabled = false;
            e_cooldownTime = 0;
        }
        //R
        if (r_duration > 0)
        {
            r_duration -= Time.deltaTime;
            if (player.GetHealth() <= 1f)
            {
                player.SetHealth(1f);
                playerHealth.SetHealth(player.GetHealth());
                playerHealthText.setHealthText(player.GetHealth(), player.GetMaxHealth(), 0.9f);
            }
        } else if (r_duration <= 0)
        {
            r_duration = 0;
        }

        if (r_cooldownTime > 0)
        {
            r_cooldownTime -= Time.deltaTime;
            r_cdTimer.SetText((int)r_cooldownTime + "s");
        } else if (r_cooldownTime <= 0 && r_isEnabled)
        {
            r_cooldown.enabled = false;
            r_cdTimer.enabled = false;
            r_isEnabled = false;
            r_cooldownTime = 0;
        }
    }
}
