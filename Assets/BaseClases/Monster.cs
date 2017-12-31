using UnityEngine;
using System.Collections;

public class Monster : Unit
{
    public int RewardXP         { get; set; }
    public int RewardGold       { get; set; }

    public Monster(string name, int currentHealth, int maxHealth, int rewardXP, int rewardGold)
        : base (name, currentHealth, maxHealth)
    {
        RewardXP = rewardXP;
        RewardGold = rewardGold;
    }


}
