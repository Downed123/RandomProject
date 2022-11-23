using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horizontal : MovementHandler
{
    public Horizontal(Transform current):base(current) {}

    public override IEnumerator Move(Vector3 range, float speed)
    {
        Vector3 newRange = range;
        Vector3 center = _current.position;

        while(true)
        {
            while(_current.position != (center + newRange))
            {
                _current.position = Vector3.MoveTowards(_current.position, center + newRange, Time.deltaTime * speed);
                yield return null;
            }

            newRange = new Vector3(-newRange.x, newRange.y, newRange.z);
        }
    }
}
// position + 5 15
// position - 5 5
