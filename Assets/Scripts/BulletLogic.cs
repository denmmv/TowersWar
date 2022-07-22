using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    private Coroutine DestroyBullet;
    void Start()
    {
        DestroyBullet = StartCoroutine(destroyBullet());
    }
    IEnumerator destroyBullet()
    {
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }

}
