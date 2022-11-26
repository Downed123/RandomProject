using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : AttackHandler
{
    public Target(Transform current):base(current) {}

    public override IEnumerator Attack(int bulletID, float attackSpeed) {
        Transform player = GameObject.Find("Spaceship").transform;

        yield return new WaitForSeconds(attackSpeed);

        Vector3 startPos = _current.position;

        float time = 1f;

        while(time > 0)
        {
            _current.RotateAround(startPos + new Vector3(1f, 0, 0), Vector3.forward, 5f);
            time -= Time.deltaTime;
            yield return null;
        }

        Vector3 playerStartPos = player.position;

        Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, (player.position - _current.position).normalized);

        _current.rotation = Quaternion.Euler(0, 0, lookRotation.eulerAngles.z + 180);

        while(true)
        {
            _current.position -= _current.up * Time.deltaTime * 10;
            yield return null;
        }
    }

    public void RotateToTarget(Transform targetTransform)
    {
        Vector3 vectorToTarget = targetTransform.position - _current.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        _current.rotation = Quaternion.Slerp(_current.rotation, q, Time.deltaTime * 5f);
    }
}
