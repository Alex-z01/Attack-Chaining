using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class AttackChaining : MonoBehaviour
{
    public Dictionary<string, Attack> Attacks;

    public AttackMeter attackMeter;

    public TMP_Text displayText;

    public GameObject chainBar;
    public GameObject fill;

    public float attackDelay = 0.5f;
    public bool attackReady = true;
    [SerializeField] private float _attackTimer = 0.0f;

    public float chainTimeFrame = 1.5f;
    public int _chainCounter = 0;
    private const int _maxChain = 5;
    [SerializeField] private float _chainTimer = 0.0f;

    public int _curr_Light = 0;
    public int _curr_Heavy = 0;

    private void Start()
    {
        //Attacks.Add("Light Attack", new Attack("Light Attack", 0.5f, 1.5f));
        
    }

    private void Update()
    {
        
        //attack speed counter
        if (_attackTimer < attackDelay)
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

                _curr_Light = 0;
                _curr_Heavy = 0;
            }
        }

        if(_chainCounter == 0 && attackReady)
        {
            displayText.text = "Idle";
            chainBar.SetActive(false);
        } 
        else { chainBar.SetActive(true); }

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

        fill.GetComponent<Image>().color = Color.blue;
        attackDelay = 0.5f;

        // When the last attack of the chain is reached, reset the counter and timer 
        if (_chainCounter == _maxChain)
        {
            _chainCounter = 0;
            _chainTimer = 0.0f;

            _curr_Light = 0;
            _curr_Heavy = 0;
        }

        //stuff that affects the last attack
        if (_chainCounter == _maxChain - 1) 
        { 
            fill.GetComponent<Image>().color = Color.red;
            attackDelay = 1.7f;
        }
        //first Light Attack
        if (_chainCounter == 0) 
        { 
            displayText.text = "Light Attack";
        }
        //Sequential Light Attacks
        else
        {
            displayText.text = $"Light Attack {_chainCounter + 1}";
            _chainTimer = 0.0f;
        }

        // Reset the attack ready state
        attackReady = false;
        _attackTimer = 0.0f;

        _chainCounter++;

        _curr_Light++;
        _curr_Heavy++;
        
        // Reset the slider to the max time
        attackMeter.SetSliderMax(chainTimeFrame);
    }

    void HeavyAttack()
    {

    }
}
