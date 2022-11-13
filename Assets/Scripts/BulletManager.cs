using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _renderTime;

    public void Shoot()
    {
        StartCoroutine(ShootBullet());
        StartCoroutine(DestroyBullet());
    }

    private IEnumerator ShootBullet()
    {
        while(true)
        {
            transform.Translate(Vector2.up * Time.deltaTime * _speed);
            yield return null;
        }
    }

    private IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(_renderTime);
        Destroy(gameObject);
    }
}
