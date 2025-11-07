using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
public class AddForceInPlayer_Command : AbstractCommand
{
    private PlayerSelf_Model _playerModel;
    private Dash_1_Model _dash_1_Model;
    private Rigidbody2D _rigidbody2D;
    private Vector3 _forceDirection;
    public AddForceInPlayer_Command(Vector3 forceDirection)
    {
        _forceDirection=forceDirection;
    }
    protected override void OnExecute()
    {
        _playerModel = this.GetModel<PlayerSelf_Model>();
        _dash_1_Model=this.GetModel<Dash_1_Model>();
        GameObject Player = PlayerSingleton.Instance.gameObject1;
        _rigidbody2D=Player.GetComponent<Rigidbody2D>();

        _rigidbody2D.gravityScale = 0;
        _rigidbody2D.velocity = Vector2.zero;
        _rigidbody2D.AddForce(_forceDirection * _dash_1_Model.DashForce, ForceMode2D.Impulse);
        Debug.Log("NO.5");
        _rigidbody2D.gravityScale = _playerModel.OrginGravityScale;
    }
}
