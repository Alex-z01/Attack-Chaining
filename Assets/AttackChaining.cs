using TMPro;
using UnityEngine;

public class AttackChaining : MonoBehaviour
{
    public AttackMeter attackMeter;

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
            }
        }

        if(_chainCounter == 0 && attackReady)
        {
            displayText.text = "Idle";
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

        // When the last attack of the chain is reached, reset the counter and timer 
        if(_chainCounter == _maxChain)
        {
            _chainCounter = 0;
            _chainTimer = 0.0f;
        }

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
        
        // Reset the slider to the max time
        attackMeter.SetSliderMax(chainTimeFrame);
    }

    void HeavyAttack()
    {

    }
}
