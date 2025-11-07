using QFramework;
using System.Collections;
using QFramework.Player._Event_Behavior_;
using UnityEngine;

public class CloneCircle_AppControl : MonoBehaviour, IController,ICanSendEvent
{
    private PlayerStateCheck_Model _playerStateCheck_Model;
    private CloneCircleHit_Model _circleModel;

    private Rigidbody2D rb;
    private Vector2 initialPosition;
    private bool _isMoving;
    private Vector3 inDirection;
    private bool _touchPlayer;

    private float _time;
    private float _checkStopTime=0;
    private bool _canTouch = true;
    private void Awake()
    {
        _playerStateCheck_Model= this.GetModel<PlayerStateCheck_Model>();
        _circleModel = this.GetModel<CloneCircleHit_Model>();
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;

        this.RegisterEvent<LaunchCircle_Event>(e =>
        {
            _time = e.time;
            if (gameObject.activeInHierarchy) StartCoroutine(WaitTouch());
        }).UnRegisterWhenGameObjectDestroyed(gameObject);
    }
    private void Update()
    {
        inDirection = rb.velocity.normalized;
        if (rb.velocity.magnitude > _circleModel .StopSpeed&& !_touchPlayer)
        {
            rb.AddForce(-inDirection * _circleModel.Firection, ForceMode2D.Force);
            _isMoving = true;
        }
        else
        {
            rb.velocity = Vector2.zero;
            _isMoving = false;
        }
        //静止一段时间后球回到原来位置
        if (!_isMoving)//球停止运动时
        {
            _checkStopTime += Time.deltaTime;
        }
        if (_checkStopTime >= _circleModel.StopTime)
        {
            _checkStopTime = 0;
            this.SendEvent<CloneCircleStop_Event>();
            gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (_touchPlayer)
        {
            transform.position = initialPosition;
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }
    private bool _canUpdate;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_isMoving)
        {
            if (collision.gameObject.CompareTag("Circle") || collision.gameObject.CompareTag("FixtedObjects"))
            {
                this.SendEvent(new MarblesCollsion(gameObject));
                this.SendEvent(new MarblesBounce_Event(gameObject));
                Vector3 inNormal = collision.contacts[0].normal;
                Vector3 reflectDirection = Vector3.Reflect(inDirection, inNormal).normalized;
                //给自己的反弹力
                rb.AddForce(reflectDirection * _circleModel.Force, ForceMode2D.Impulse);

                Rigidbody2D marbleRb = collision.gameObject.GetComponent<Rigidbody2D>();
                //给碰撞物的弹力
                marbleRb.AddForce(inDirection * _circleModel.HitCircleForce, ForceMode2D.Impulse);
            }
            else if (collision.gameObject.CompareTag("Player") && _playerStateCheck_Model.TouchTime<= 0)
            {
                Vector3 inNormal = collision.contacts[0].normal;
                Vector3 reflectDirection = Vector3.Reflect(inDirection, inNormal).normalized;
                //给自己的反弹力
                rb.AddForce(reflectDirection * _circleModel.Force, ForceMode2D.Impulse);

                Rigidbody2D marbleRb = collision.gameObject.GetComponent<Rigidbody2D>();
                Transform player = collision.gameObject.GetComponent<Transform>();
                Vector3 direction= player.position - transform.position;
                //给玩家的弹力
                marbleRb.AddForce(direction * _circleModel.HitPlayerForce, ForceMode2D.Impulse);
            }
        }
        else
        {
            Debug.LogWarning("StateNumber:" + _playerStateCheck_Model.StateNumber);
            if (collision.gameObject.CompareTag("Player") && _playerStateCheck_Model.TouchTime <= 0)
            {
                StartCoroutine(WaitTime());
                if (_canUpdate)
                {
                    initialPosition = transform.position;
                    _canUpdate =false;
                }
                _touchPlayer = true;
                Vector2 repelDirection = (collision.gameObject.transform.position - transform.position).normalized;
                Rigidbody2D marbleRb = collision.gameObject.GetComponent<Rigidbody2D>();
                //给碰撞物的弹力
                if (this.GetModel<Dash_0_Model>().InDashState)
                {
                    this.SendEvent(new MarblesPlayer_Event(gameObject));
                    marbleRb.AddForce(repelDirection * _circleModel.Force* marbleRb.velocity.magnitude, ForceMode2D.Impulse);
                }
                   
            }
        }
    }
    IEnumerator WaitTime()
    {
        float timeControl=20f;
        while (!_canUpdate)
        {
            timeControl-= Time.deltaTime;
            yield return null;
            if (timeControl <= 0f)
            {
                _canUpdate = true;
            }
        }
    }

  
    IEnumerator WaitTouch()
    {
        while (_time > 0)
        {
            _time -= Time.deltaTime;
            yield return null;
        }
        _canTouch = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _touchPlayer = false;
        }
    }
    public IArchitecture GetArchitecture()
    {
        return GameObjects_App.Interface;
    }
}