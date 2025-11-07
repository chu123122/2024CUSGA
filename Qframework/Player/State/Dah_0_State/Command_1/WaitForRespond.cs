using QFramework;
using QFramework.Player.State.Dah_0_State.NewEvent;
using UnityEngine;

namespace C_.StateMachine.Player.State.Command_1
{
    public class WaitForRespond:AbstractCommand
    {
        private Dash_0_Model _dash_0_Model;
        private Rigidbody2D _rigidbody2D;
        
        protected override void OnExecute()
        {
            _dash_0_Model=this.GetModel<Dash_0_Model>();
            _rigidbody2D=PlayerSingleton.Instance.rigidbody2D;
            if (_dash_0_Model.IsWaiting)
            {
                _dash_0_Model.WaitTimer-=Time.deltaTime;
                _rigidbody2D.gravityScale = 0;
                _rigidbody2D.velocity = Vector2.zero;//重力速度为0

                //打断反应时间进入冲刺
                if (Input.GetKeyDown(KeyCode.W) ||Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.S)||Input.GetKeyDown(KeyCode.D))
                {
                    //重力重置
                    _rigidbody2D.gravityScale=this.GetModel<PlayerSelf_Model>().OrginGravityScale;
                    _dash_0_Model.IsWaiting = false;
                }
                
                //反应时间耗尽，退出状态
                if (_dash_0_Model.WaitTimer <= 0)//
                {
                    _dash_0_Model.DashMount = 0;
                    //重力重置
                    _rigidbody2D.gravityScale=this.GetModel<PlayerSelf_Model>().OrginGravityScale;
                    _dash_0_Model.IsWaiting = false;
                    this.SendEvent<ExitDash_0_Event>();
                }

                
            }
        }
    }
}