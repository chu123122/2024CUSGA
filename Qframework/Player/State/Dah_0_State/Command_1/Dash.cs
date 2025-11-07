using QFramework;
using UnityEngine;

namespace C_.StateMachine.Player.State.Command_1
{
    public class Dash:AbstractCommand
    {
        private Dash_0_Model _dash_0_Model;
        private Transform _transform;
        private Rigidbody2D _rigidbody2D;
        private float _speedModifier;
        private float _dashTime=0;
        protected override void OnExecute()
        {
            _dash_0_Model=this.GetModel<Dash_0_Model>();
            _transform=PlayerSingleton.Instance.transform1;
            _rigidbody2D=PlayerSingleton.Instance.rigidbody2D;
            _dashTime+=Time.deltaTime;
            _speedModifier = _dash_0_Model.SpeedCurve.Evaluate(_dashTime);
            if (_dash_0_Model.IsDashing)
            {
                _rigidbody2D.velocity = Vector2.zero;
                _rigidbody2D.gravityScale = 0;
                _transform.position=Vector3.MoveTowards(_transform.position,
                    _dash_0_Model.DashPosiotn, _dash_0_Model.MoveSpeed *_speedModifier* Time.deltaTime);
                
                if(  _transform.position==_dash_0_Model.DashPosiotn)
                    _dash_0_Model.IsDashing = false;
            }
        }
    }
}