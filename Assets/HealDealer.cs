using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HealType
{
    SmallHeal,
    LargeHeal
}

public class HealDealer : MonoBehaviour
{
    public float smallHealAmount;
    public float largeHealAmount;

    void Start()
    {
        // Any initialization if necessary
    }

    void Update()
    {
        // Any updates if necessary
    }

    public void Heal(PlayerHealth target, HealType healType)
    {
        float healAmount = 0f;

        switch (healType)
        {
            case HealType.SmallHeal:
                healAmount = smallHealAmount;
                break;
            case HealType.LargeHeal:
                healAmount = largeHealAmount;
                break;
        }

        // Heal the target
        if (target != null)
        {
            target.Heal(healAmount);
        }
    }
}