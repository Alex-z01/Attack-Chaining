using TMPro;
using UnityEditor.Animations;
using UnityEngine;

public class AttackChaining : MonoBehaviour
{
    public TMP_Text displayText;

    public float attackDelay = 0.5f;
    public bool attackReady = true;
    private float attackTimer = 0.0f;

    public float chainTimeFrame = 1.5f;
    private float chainTimer = 0.0f;
    private int chainCounter = 0;


    private void Update()
    {
        if(attackTimer < attackDelay)
        {
            attackTimer += Time.deltaTime;
        }
        else
        {
            attackReady = true;
        }

        if(chainCounter > 0)
        {
            if (chainTimer < chainTimeFrame)
            {
                chainTimer += Time.deltaTime;
            }
            else
            {
                chainTimer = 0.0f;
                chainCounter = 0;
            }
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            LightAttack();
        }

        if(Input.GetKeyDown(KeyCode.T)) 
        {
            HeavyAttack();
        }
    }

    void LightAttack()
    {
        if(!attackReady) { return; }

        Debug.Log(chainCounter);

        if(chainCounter == 0) { displayText.text = "Light Attack"; }
        else
        {
            displayText.text = $"Light Attack {chainCounter}";
            chainTimer = 0.0f;
        }

        // Reset the attack ready state
        attackReady = false;
        attackTimer = 0.0f;

        chainCounter++;
    }

    void HeavyAttack()
    {

    }
}
