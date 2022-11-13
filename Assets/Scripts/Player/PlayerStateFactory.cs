using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateFactory : MonoBehaviour
{
    private PlayerStateManager _ctx;

    public PlayerStateFactory(PlayerStateManager ctx)
    {
        _ctx = ctx;
    }

    public PlayerNormalState Normal()
    {
        return new PlayerNormalState(_ctx, this);
    }

    public PlayerShootState Shoot()
    {
        return new PlayerShootState(_ctx, this);
    }
}
