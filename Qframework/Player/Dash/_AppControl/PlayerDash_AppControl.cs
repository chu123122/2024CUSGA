using System.Collections;
using C_.Qframework.Player.Dash._Model;
using C_.Qframework.Player.Dash.Command;
using Cinemachine;
using QFramework;
using QFramework.Player._Event_Behavior_;
using UnityEditor;
using UnityEngine;

namespace C_.Qframework.Player.Dash._AppControl
{
    public class PlayerDash_AppControl : MonoBehaviour, IController, ICanSendEvent
    {
        private PlayerSelf_Model _model;
        private PlayerDash_Model _playerDash_Model;
        private Dash_0_Model _dash_0_Model;
        private Dash_1_Model _dash_1_Model;
        private Rigidbody2D _rb;
        private void Awake()
        {
            _model = this.GetModel<PlayerSelf_Model>();
            _playerDash_Model = this.GetModel<PlayerDash_Model>();
            _dash_0_Model=this.GetModel<Dash_0_Model>();
            _dash_1_Model=this.GetModel<Dash_1_Model>();
            _cinemachineImpulseSource=this.GetComponent<CinemachineImpulseSource>();
            _rb=PlayerSingleton.Instance.rigidbody2D;
            _lineRenderer = PlayerSingleton.Instance.shadowLine;
            //按下鼠标右键
            this.RegisterEvent<InputMouse1Down_Event>(e =>
            {
                _model.DashMount=0;
                this.SendCommand<CheckDashPosition_Command>();
                StartCoroutine(DashCoroutine());              //开始冲刺       
                _playerDash_Model.HaveDashDirection = false;         
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
            //冲刺开始
            this.RegisterEvent<PlayerDashStart_Event>(e =>
            {
                _model.IsDashing = true;
                _rb.gravityScale = 0;
                _rb.velocity = Vector2.zero;
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
            //冲刺结束
            this.RegisterEvent<PlayerDashEnd_Event>(e =>
            {
                _model.IsDashing = false;
                _rb.gravityScale = _model.OrginGravityScale;
            
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
            //时停开始
            this.RegisterEvent<BulletTimeStart_Event>(e =>
            {
                _rb.gravityScale = 0;
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
            //时停结束
            this.RegisterEvent<BulletTimeEnd_Event>(e =>
            {
                _rb.gravityScale = _model.OrginGravityScale;
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
        }
        private LineRenderer _lineRenderer;
        private void Update()
        {
            Debug.LogWarning(_haveLine);
            if (_dash_0_Model.InState) return;
            this.SendCommand(new FindDashDirection_Command());
            this.SendCommand(new FindRaycastHit_Command());
            bool notInDashState = !_dash_0_Model.InState && !_dash_1_Model.InState;
            if (Input.GetMouseButtonDown(1)&&_model.DashMount>0&&notInDashState)//不在冲刺状态中（为了只能通过丢球移动）
            {
                _lineRenderer.enabled = true;
                _lineRenderer.SetPosition(0,PlayerSingleton.Instance.character.position);
                _lineRenderer.SetPosition(1, PlayerSingleton.Instance.character.position);
                Instantiate(PlayerSingleton.Instance.shakeWave,transform.position,Quaternion.identity);
                StartCoroutine(WaitDashTime());
                StartCoroutine(WaitForLine());
            }
        }
        private bool _haveLine=true;
        IEnumerator WaitForLine()
        {
            while (_haveLine)
            {
                _lineRenderer.SetPosition(0,PlayerSingleton.Instance.character.position);
                yield return null;
            }
            _lineRenderer.enabled = false;
        }
       
        private GameObject _gameObject;
        private Transform _shadow;
        private CinemachineImpulseSource _cinemachineImpulseSource;
        IEnumerator WaitDashTime()
        {
            PlayerSingleton.Instance.CameraShake(_cinemachineImpulseSource);
            yield return new WaitForSeconds(_playerDash_Model.WaitTime);
            
            PlayerSingleton.FlipAll();
            StartCoroutine(WaitTime());
            this.SendEvent(new Dash_Event(gameObject));
            this.SendEvent<InputMouse1Down_Event>();
        }
        private int _shadowNumber = 0;
        IEnumerator WaitTime()
        {
            _shadowNumber = 0;
            for (int i = 0; i < _playerDash_Model.Mount; i++)
            {
                _shadowNumber++;
                _gameObject=PlayerSingleton.Instance.gameObject1;
                _shadow=PlayerSingleton.Instance.Shadow;
                GameObject shadow=Instantiate(_gameObject.transform.GetChild(1).gameObject,PlayerSingleton.Instance.transform.position
                    ,_gameObject.transform.rotation,_shadow);
                Destroy(shadow.GetComponent<Animator>());
                shadow.transform.position = new Vector2( shadow.transform.position.x, shadow.transform.position.y-1.2f);
                Collider2D[] collider2Ds=shadow.GetComponentsInChildren<Collider2D>();
                SpriteRenderer[] sprites =shadow.transform.GetComponentsInChildren<SpriteRenderer>();
                foreach (var collider in collider2Ds)
                {
                    Destroy(collider);
                }
                foreach (var sprite in sprites)
                {
                    sprite.material=PlayerSingleton.Instance.material;
                }
                Destroy(shadow,0.3f);
                if (_shadowNumber == 2)
                {
                    StartCoroutine(WaitLineDisapper());
                }
                    
                yield return new WaitForSeconds(_playerDash_Model.IntervalTime);
            }
            _haveLine = true;
        }

        IEnumerator WaitLineDisapper()
        {
            yield return new WaitForSeconds(0.01f);
            _haveLine = false;
        }
       
        private IEnumerator DashCoroutine()
        {
            this.SendEvent<PlayerDashStart_Event>();
            var playerTransPosition_Command = new PlayerTransPosition_Command();
            float dashTIme = 0;
            while (playerTransPosition_Command.IsDashing)
            {
                _rb.gravityScale = 0;
                this.SendCommand(playerTransPosition_Command);
                
                dashTIme+=Time.deltaTime;
                Time.captureDeltaTime = dashTIme < 0.02f ? 0.00065f : 0f;
                yield return null;
            }
            Time.captureDeltaTime = 0f;
            _rb.gravityScale=this.GetModel<PlayerSelf_Model>().OrginGravityScale;
            this.SendEvent<PlayerDashEnd_Event>();
        }
        public float distance =5;
        public float radius = 0.2f;
        private void OnDrawGizmos()
        {
            // 设置Gizmos颜色为红色
            Gizmos.color = Color.red;

            Vector3 mousePosition = Input.mousePosition;
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10f));
            if (PlayerSingleton.Instance != null)
            {
                Vector3 direction = (targetPosition - PlayerSingleton.Instance.character.position).normalized;
                // 计算碰撞检测圆形的中心位置
                Vector2 circleCenterPos = PlayerSingleton.Instance.character.position + direction * distance;// _playerDash_Model.DashDistance;

                // 绘制碰撞检测圆形
                Gizmos.DrawWireSphere(circleCenterPos, radius);
            }
        }
        public IArchitecture GetArchitecture()
        {
            return GameObjects_App.Interface;
        }

    }
}
