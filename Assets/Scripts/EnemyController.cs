using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public void StartAi()
    {
        StartCoroutine(Movement());
    }

    private IEnumerator Movement()
    {
        bool right = true;
        Vector3 target;

        while(true)
        {
            if(right)
            {
                target = transform.position + new Vector3(5f, 0f, 0f);
            } else
            {
                target = transform.position - new Vector3(5f, 0f, 0f);
            }

            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * 5f);

            if(transform.position == target)
            {
                right = !right;
            }
            yield return null;
        }
    }
}
