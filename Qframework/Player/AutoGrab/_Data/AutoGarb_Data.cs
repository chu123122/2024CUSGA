using UnityEngine;

namespace QFramework.Player.NewPlayerAutoGrab._Data
{
    [CreateAssetMenu(menuName = "Data/Player/NewGrab",fileName = "NewGarb_Data")]
    public class AutoGarb_Data:ScriptableObject
    {
        [Tooltip("扇形的线段数（越多越接近一个真正的扇形）,半径越大推荐该数值越大" +
                 "（半径在PlayerController_Grab里改）")]
        public int _segments = 50;
        [Tooltip("初始方向")]
        public float _startAngle = 45f;
        [Tooltip("末尾方向")]
        public float _endAngle = -45f;
        [Tooltip("扇形判定半径")]
        public float _radius ;
        [Tooltip("鼠标位置判定半径")]
        public float _sphereRadius ;
        [Tooltip("判定轨道长度")]
        public float _distance ;

    }
}