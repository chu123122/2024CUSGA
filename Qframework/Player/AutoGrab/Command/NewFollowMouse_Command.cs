using UnityEngine;

namespace QFramework.Player.NewPlayerAutoGrab.Command
{
    public class NewFollowMouse_Command:AbstractCommand
    {
        private Transform _transform;
        public NewFollowMouse_Command(Transform transform)
        {
            _transform=transform;
        }
        protected override void OnExecute()
        { 
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            Vector2 direction = mousePosition - _transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            _transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
}