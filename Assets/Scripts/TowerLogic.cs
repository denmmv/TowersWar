using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TowerLogic : MonoBehaviour ,ITower
{
    [SerializeField] private data data;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _bulletPlace;
    [SerializeField] private Transform _bulletVector;
    [SerializeField] private GameObject _gun;
    [SerializeField] private Image _healthBar;
    private float cooldownShoot;
    private bool _isPlayer = false;
    private Coroutine Shooting;
    private bool _rotation = true;
    public UnityEvent PeopleWin;
    public UnityEvent AIWin;
    private bool _gameStarted = false;

    private float _health;
    public void IsPlayer()
    {
        _isPlayer = true;
    }
    public void GameStarted()
    {
        _gameStarted = true;
    }

    public void Lose()
    {
        if (_isPlayer)
        {
            AIWin.Invoke();
        }
        else
        {
            PeopleWin.Invoke();
        }
        throw new System.NotImplementedException();
    }
    public void Shoot()
    {
        if (Shooting ==null)
        {
            Shooting = StartCoroutine(shooting());
        }
        /*throw new System.NotImplementedException();*/
    }
    public void GunRotate()
    {
        if (_rotation)
        {
            _gun.transform.Rotate(0, 0, -0.1f, 0);
            if (_gun.transform.localRotation.z < -0.3)
            {
                _rotation = false;
            }
        }
        if (!_rotation)
        {
            _gun.transform.Rotate(0, 0, 0.1f, 0);
            if(_gun.transform.localRotation.z > 0.5)
            {
                _rotation = true;
            }
        }

        else
        {
            _gun.transform.Rotate(0, 0, -0.1f, 0);
        }
    }
    IEnumerator shooting()
    {
        GameObject bu = Instantiate(_bullet, _bulletPlace.position, Quaternion.identity);
        Rigidbody2D buf = bu.GetComponent<Rigidbody2D>();
        buf.AddForce((bu.transform.position - _bulletVector.position) * 380f);
        yield return new WaitForSeconds(cooldownShoot);
        StopCoroutine(Shooting);
        Shooting = null;
    }
    public void TakeDamage()
    {       
        _health--;
        _healthBar.fillAmount = _health / data.Health;
        if (_health == 0)
        {
            Lose();
        }
        /*throw new System.NotImplementedException();*/
    }
    void Start()
    {
        cooldownShoot = data.CooldownShoot;
        _health = data.Health;

    }
    private void Update()
    {
        if (_isPlayer||!_gameStarted)
        {
            return;
        }
        Shoot();
        GunRotate();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bomb")
        {
            TakeDamage();
        }
    }

}
