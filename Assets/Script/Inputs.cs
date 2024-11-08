using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inputs : MonoBehaviour
{
    public void MoveUp(InputAction.CallbackContext _ctx)
    {
        if(_ctx.started)
            MapManager.Instance.MovePlayer(Direction.Up);

    }
    public void MoveDown(InputAction.CallbackContext _ctx)
    {
        if (_ctx.started)
            MapManager.Instance.MovePlayer(Direction.Down);

    }
    public void MoveLeft(InputAction.CallbackContext _ctx)
    {
        if (_ctx.started)
            MapManager.Instance.MovePlayer(Direction.Left);

    }
    public void MoveRight(InputAction.CallbackContext _ctx)
    {
        if (_ctx.started)
            MapManager.Instance.MovePlayer(Direction.Right);

    }
}
