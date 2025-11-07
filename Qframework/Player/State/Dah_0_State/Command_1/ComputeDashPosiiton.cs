using QFramework;
using QFramework.Player.State.Dah_0_State.NewEvent;
using UnityEngine;

namespace C_.StateMachine.Player.State.Command_1
{
    public class ComputeDashPosiiton:AbstractCommand
    {
        private Dash_0_Model _dash_0_Model;

        protected override void OnExecute()
        {
            _dash_0_Model=this.GetModel<Dash_0_Model>();
            Transform transform = PlayerSingleton.Instance.transform1;
            if (_dash_0_Model.DashMount > 0 && _dash_0_Model.Side > 0)
            {
                Vector3[] directions =
                {
                    Vector3.zero, // side = 0 (无方向)
                    Vector3.right, // side = 1 (右)
                    new Vector3(1, -1), // side = 2 (右下)
                    Vector3.down, // side = 3 (下)
                    new Vector3(-1, -1), // side = 4 (左下)
                    Vector3.left, // side = 5 (左)
                    new Vector3(-1, 1), // side = 6 (左上)
                    Vector3.up, // side = 7 (上)
                    new Vector3(1, 1), // side = 8 (右上)
                };
                // 取得当前方向
                Vector3 direction = directions[_dash_0_Model.Side];
                // 计算冲刺目标
                Vector3 dashTarget = transform.position + direction.normalized * _dash_0_Model.DashDistance;
            
                _dash_0_Model.DashMount = 0;
                _dash_0_Model.DashPosiotn = dashTarget;
                
                this.SendEvent<HaveDashPosition_Event>();
            }
        }
    }
}