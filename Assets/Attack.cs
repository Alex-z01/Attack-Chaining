using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack 
{
    private string attackName;
    private float attackDelay;
    private float chainTimeFrame;
    
    public Attack(string atkName, float atkDelay, float chainTime)
    {
        attackName = atkName;
        attackDelay = atkDelay;
        chainTimeFrame = chainTime;

    }

    public string GetAttackName() { return attackName; }
    public float GetAttackDelay() { return attackDelay; }
    public float GetChainTimeFrame() { return chainTimeFrame; }
}
