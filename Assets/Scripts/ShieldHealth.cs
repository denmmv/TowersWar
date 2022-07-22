using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldHealth : MonoBehaviour
{
    [SerializeField] private data data;
    private int _countToDestroy;
    // Start is called before the first frame update
    void Start()
    {
        _countToDestroy = data.CountToDestroy;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bomb")
        {
            _countToDestroy--;
            if (_countToDestroy == 0)
            {
                this.gameObject.SetActive(false);
                _countToDestroy = data.CountToDestroy;
            }
        }
    }
}
