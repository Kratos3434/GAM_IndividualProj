using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStatsUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI minionsKilled;
    [SerializeField] TextMeshProUGUI goldEarned;
    [SerializeField] TextMeshProUGUI attackDamage;
    [SerializeField] TextMeshProUGUI attackSpeed;

    // Start is called before the first frame update
    public void setMinionsKilled(int minionsKilled)
    {
        this.minionsKilled.text = minionsKilled + " Minions Killed";
    }

    public void SetGoldEarned(int gold)
    {
        goldEarned.text = gold + " Gold";
    }

    public void SetAttackDamage(float ad)
    {
        attackDamage.text = (int)ad + " Attack Damage";
    }

    public void SetAttackSpeed(float aspeed)
    {
        attackSpeed.text = aspeed + " Attack Speed (per second)";
    }
}
