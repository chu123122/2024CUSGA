using UnityEngine;

namespace QFramework.Player.PlayerSelf.Data
{
    [CreateAssetMenu(fileName = "PlayerSelf_Data", menuName = "QFramework/Player")]
    public class PlayerSelf_Data:ScriptableObject
    {
        [Tooltip("是否显示跳跃次数")]  
        public bool ShowJumpMount;
        [Tooltip("是否显示冲刺次数")]  
        public bool ShowDashMount;
        [Tooltip("是否显示抓取次数")]  
        public bool ShowGrabMount;
        [Tooltip("是否显示人物当前状态")]  
        public bool ShowStateNumber;
    }
}