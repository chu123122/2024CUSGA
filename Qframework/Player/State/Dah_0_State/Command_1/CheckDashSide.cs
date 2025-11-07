using QFramework;
using UnityEngine;

namespace C_.StateMachine.Player.State.Command_1
{
    public class CheckDashSide:AbstractCommand
    {
        private Dash_0_Model _model;
        protected override void OnExecute()
        {
            _model=this.GetModel<Dash_0_Model>();
            if (_model.DashMount > 0 )
            {
                if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
                {
                    _model.Side = 1;//右
                }
                else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
                {
                    _model.Side = 2;//右下
                }
                else if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                {
                    _model.Side = 3;//下
                }
                else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
                {
                    _model.Side = 4;//左下
                }
                else if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
                {
                    _model.Side = 5;//左
                }
                else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
                {
                    _model.Side = 6;//左上
                }
                else if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                {
                    _model.Side = 7;//上
                }
                else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
                {
                    _model. Side = 8;//右上
                }
            }
        }
    }
}