using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameObject _firstGun;
    [SerializeField] private GameObject _secondGun;
    [SerializeField] private Camera _camera;
    private GameObject _gun;
    private Vector2 startPos;
    private float _targetPos;
    private Vector3 pos;
    private GameObject _target;
    public UnityEvent Shoot;
    public UnityEvent ShootFirstEvent;
    public UnityEvent ShootSecondEvent;
    public void SelectFirstGun()
    {
        _gun = _firstGun;
        _target = _secondGun;
        Shoot.AddListener(ShootFirst);
    }
    private void ShootFirst()
    {
        ShootFirstEvent.Invoke();
    }
    private void ShootSecond()
    {
        ShootSecondEvent.Invoke();
    }
    public void SelectSecondGun()
    {
        _gun = _secondGun;
        _target = _firstGun;
        Shoot.AddListener(ShootSecond);
    }
    private void Update()
    {
        if (_gun == null) return;
        if (Input.GetMouseButtonDown(0)) startPos = _camera.ScreenToWorldPoint(Input.mousePosition);
        else if (Input.GetMouseButton(0))
        {
            pos = new Vector3(0, 0, _camera.ScreenToWorldPoint(Input.mousePosition).y - startPos.y);
            Shoot.Invoke();
        }     
        _gun.transform.rotation = new Quaternion(0, 0, Mathf.Clamp(pos.z, -1f, 1f)/2.5f, _gun.transform.rotation.w);
    }
}
