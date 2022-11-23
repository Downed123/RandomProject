using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementHandler
{
    protected Transform _current;

    public MovementHandler(Transform current)
    {
        _current = current;
    }

    public abstract IEnumerator Move(Vector3 range, float speed);
}
