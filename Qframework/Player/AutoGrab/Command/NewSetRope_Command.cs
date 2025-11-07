using UnityEngine;

namespace QFramework.Player.NewPlayerAutoGrab.Command
{
    public class NewSetRope_Command:AbstractCommand
    {
        private readonly Transform _player;
        private LineRenderer _lineRenderer;
        public NewSetRope_Command(Transform player)
        {
            _player = player;
        }
        protected override void OnExecute()
        {
            _lineRenderer= PlayerSingleton.Instance.lineRenderer;
            _lineRenderer.SetPosition(0, _player.position);
            _lineRenderer.SetPosition(1, _player.position);
            _lineRenderer.enabled = true;
        }
    }
}