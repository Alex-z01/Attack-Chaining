using TMPro;
using UnityEditor.Animations;
using UnityEngine;
using System;

public class AttackChaining : MonoBehaviour
{
    public TMP_Text displayText;

    public float attackDelay = 0.5f;
    public bool attackReady = true;
    [SerializeField] private float _attackTimer = 0.0f;

    public float chainTimeFrame = 1.5f;
    public int _chainCounter = 0;
    private const int _maxChain = 5;
    [SerializeField] private float _chainTimer = 0.0f;


    private void Update()
    {
        if(_attackTimer < attackDelay)
        {
            _attackTimer += Time.deltaTime;
        }
        else
        {
            attackReady = true;
        }

        if(_chainCounter > 0)
        {
            if (_chainTimer < chainTimeFrame)
            {
                _chainTimer += Time.deltaTime;
            }
            else
            {
                _chainTimer = 0.0f;
                _chainCounter = 0;
                displayText.text = "Idle";
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

        if(_chainCounter == _maxChain)
        {
            _chainCounter = 0;
        }

        Debug.Log(_chainCounter);

        if(_chainCounter == 0) { displayText.text = "Light Attack"; }
        else
        {
            displayText.text = $"Light Attack {_chainCounter}";
            _chainTimer = 0.0f;
        }

        // Reset the attack ready state
        attackReady = false;
        _attackTimer = 0.0f;

        _chainCounter++;
    }

    void HeavyAttack()
    {

    }
}
