using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class ShieldLogic : MonoBehaviour
{
    [SerializeField] data data;
    [SerializeField] private Button _shieldButton;
    [SerializeField] private GameObject _shieldLeft;
    [SerializeField] private GameObject _shieldRight;
    [SerializeField] private TextMeshProUGUI _timer;
    [SerializeField] private GameObject _timerBack;
    private GameObject _enemyShield;
    private int _cooldownTimer;
    private Coroutine Cooldown;
    private Coroutine EnemyCooldown;
    private GameObject _shield;
    private bool _enemyShieldReady;
    private bool _shieldIsActive = false;
    private bool _shieldButtonIsActive = true;
    private void Start()
    {
        _shieldButton.onClick.AddListener(ActivateShield);
        _cooldownTimer = data.CooldownCount;
        _enemyShieldReady = true;
    }
    private void Update()
    {
        if (!_shield.activeInHierarchy && !_timerBack.activeInHierarchy)
        {
            ActivateShieldButton();
        }
        if (!_enemyShield.activeInHierarchy&& _enemyShieldReady)
        {
            EnemyCooldown = StartCoroutine(enemyCooldown());
            _enemyShieldReady = false;
            _enemyShield.SetActive(true);
        }
    }
    public void ChoiceFirstPlayer(int x)
    {
            _shield = _shieldLeft;
        _enemyShield = _shieldRight;
    }
    public void ChoiceSecondPlayer(int x)
    {
        _shield = _shieldRight;
        _enemyShield = _shieldLeft;
    }
    private void ActivateShield()
    {
        _shield.SetActive(true);
        _shieldButton.enabled = false;
        _timerBack.SetActive(true);
        _shieldIsActive = true;
        Cooldown = StartCoroutine(cooldown());
        ShieldButtonActive();
    }
    IEnumerator enemyCooldown()
    {
        for (int x = _cooldownTimer; x >= 0; x--)
        {
            yield return new WaitForSeconds(1);
        }
        _enemyShieldReady = true;
    }
    private void ShieldButtonActive()
    {
        if (_shieldButtonIsActive)
        {
            _shieldButtonIsActive = false;
        }
        else
        {
            _shieldButtonIsActive = true;
        }       
    }
    IEnumerator cooldown()
    {
        _timer.text = _cooldownTimer.ToString();
        for(int x = _cooldownTimer; x >=0; x--)
        {
            _timer.text = x.ToString();
            yield return new WaitForSeconds(1);
        }
        _timer.text = null;
        if (!_shieldIsActive)
        {
            _shieldButton.enabled = true;
            ShieldButtonActive();
        }       
        _timerBack.SetActive(false);
    }
    public void ActivateShieldButton()
    {
        _shieldButton.enabled = true;
        ShieldButtonActive();
    }
}
