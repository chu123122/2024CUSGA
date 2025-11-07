using UnityEngine;
namespace QFramework.Player.NewPlayerGrab._Data
{
    [CreateAssetMenu(menuName = "Data/Player/NewGrab",fileName = "NewPlayerGrab_Data")]
    public class NewGrab_Data:ScriptableObject
    {
        [Tooltip("钩爪飞射速度")]
        [Range(0, 1000)]
        public float _continueSpeed;
        [Tooltip("人物飞射速度")]
        [Range(5, 1000)]
        public float _playerSpeed;
        [Tooltip("钩爪范围")]
        [Range(5, 50)]
        public float _maxDistance;

        public float _grabTimeController;
    }
}