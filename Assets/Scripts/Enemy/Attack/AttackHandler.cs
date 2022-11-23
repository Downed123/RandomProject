using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackHandler : MonoBehaviour
{
    protected Transform _current;

    public AttackHandler(Transform current)
    {
        _current = current;
    }

    public abstract IEnumerator Attack(int bulletID, float attackSpeed);
}
