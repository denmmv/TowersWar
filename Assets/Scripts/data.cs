using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Data", menuName = "Data", order = 51)]
public class data : ScriptableObject
{
    [SerializeField] private int _cooldownCount;
    [SerializeField] private int _countToDestroy;
    [SerializeField] private float _cooldownShoot;
    [SerializeField] private float _health;
    public int CooldownCount
    {
        get
        {
            return _cooldownCount;
        }
    }
    public float Health
    {
        get
        {
            return _health;
        }
    }
    public float CooldownShoot
    {
        get
        {
            return _cooldownShoot;
        }
    }
    public int CountToDestroy
    {
        get
        {
            return _countToDestroy;
        }
    }
}
