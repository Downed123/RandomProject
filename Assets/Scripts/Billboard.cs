using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Billboard : MonoBehaviour
{
    protected Animator _animator;

    protected void Init(GameObject obj)
    {
        _animator = obj.GetComponent<Animator>();
    }

    protected void LateUpdate()
    {
        SetAnimation();
    }

    protected abstract void SetAnimation();
}
