using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _renderTime;

    private string _target;

    public string Target { get { return _target; } set { _target = value; } }

    public void Shoot(Vector3 direction)
    {
        StartCoroutine(ShootBullet(direction));
        StartCoroutine(DestroyBullet());
    }

    private IEnumerator ShootBullet(Vector3 direction)
    {
        while(true)
        {
            transform.Translate(direction * Time.deltaTime * _speed);
            yield return null;
        }
    }

    private IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(_renderTime);
        ObjectPool.Instance.Deactivate(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == _target)
        {
            Destroy(other.gameObject);
            ObjectPool.Instance.Deactivate(gameObject);
            GameObject ps = GameObject.Find("Particle System");
            ps.transform.position = other.transform.position;
            ps.GetComponent<ParticleSystem>().Play();
            _target = "";
        }
    }
}
