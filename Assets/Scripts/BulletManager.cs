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

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            GameObject ps = GameObject.Find("Particle System");
            ps.transform.position = other.transform.position;
            ps.GetComponent<ParticleSystem>().Play();
        }
    }
}
