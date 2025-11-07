using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using UnityEditor;
public class Dash_1_Command : AbstractCommand
{
    private Vector3 _dashTarget;
    private float _speedModifier;
    private float _time = 0;
    public Dash_1_Command(Vector3 direction)
    {
        _dashTarget = direction;
        StartMove = true;
    }

    private PlayerSelf_Model _playerSelf_Model;
    private Dash_1_Model _dash_1_Model;

    private bool _startMove;

    public bool StartMove { get => _startMove; set => _startMove = value; }

    protected override void OnExecute()
    {
        _playerSelf_Model = this.GetModel<PlayerSelf_Model>();
        _dash_1_Model = this.GetModel<Dash_1_Model>();
        GameObject player = PlayerSingleton.Instance.gameObject1;
        Transform transform = player.GetComponent<Transform>();
        Rigidbody2D rigidbody2D = player.GetComponent<Rigidbody2D>();

        _time += Time.deltaTime;
        _speedModifier = _dash_1_Model.SpeedCurve.Evaluate(_time);
        if (_dash_1_Model.CanSeeTime) Debug.Log("PlayerStateTime:" + _time);
        if (StartMove)//开始冲刺
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0);//发送冲刺开始事件
            transform.position = Vector3.MoveTowards(transform.position, _dashTarget, _dash_1_Model.MoveSpeed * _speedModifier * Time.deltaTime);
        }


        if (Vector3.Distance(transform.position, _dashTarget) < 0.1f && StartMove)//冲刺结束
        {
            //发送冲刺结束事件
            rigidbody2D.gravityScale = 0;
            rigidbody2D.velocity = Vector2.zero;
            StartMove = false;

        }
    }

}
