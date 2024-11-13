using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageType
{
    Attack,
    SkillAttack
}

public class DamageDealer : MonoBehaviour
{
    public float AttackDamage;
    public float SkillAttackDamage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DealDamage(PlayerHealth target, DamageType damageType)
    {
        float damageAmount = 0f;

        switch (damageType)
        {
            case DamageType.Attack:
                damageAmount = AttackDamage;
                break;
            case DamageType.SkillAttack:
                damageAmount = SkillAttackDamage;
                break;
        }
        //deal damage
        if (target != null)
        {
            target.TakeDamage(damageAmount);
        }
    }
}

