using QFramework;
using System.Collections;
using QFramework.Player._Event_Behavior_;
using UnityEditor;
using UnityEngine;

public class Circle_AppControl : MonoBehaviour, IController,ICanSendEvent
{
    private PlayerSelf_Model _model;
    private PlayerStateCheck_Model _playerStateCheck_Model;
    private CloneCircleHit_Model _circleModel;

    private Rigidbody2D rb;
    private Vector2 initialPosition;
    private bool _isMoving;
    private Vector3 inDirection;
    private bool _touchPlayer;

    private float _time;
    private bool _canTouch = true;
    private void Awake()
    {
        _model=this.GetModel<PlayerSelf_Model>();
        _playerStateCheck_Model= this.GetModel<PlayerStateCheck_Model>();
        _circleModel = this.GetModel<CloneCircleHit_Model>();
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;

        this.RegisterEvent<LaunchCircle_Event>(e =>
        {
            _time = e.time;
            if (gameObject.activeInHierarchy) StartCoroutine(WaitTouch());
        }).UnRegisterWhenGameObjectDestroyed(gameObject);
        this.RegisterEvent<CloneCircleStop_Event>(e =>
        {
            gameObject.SetActive(true);
        }).UnRegisterWhenGameObjectDestroyed(gameObject);
    }
    private void Update()
    {
        inDirection = rb.velocity.normalized;
        if (rb.velocity.magnitude > 0.5f&& !_touchPlayer)
        {
            rb.AddForce(-inDirection * _circleModel.Firection, ForceMode2D.Force);
            _isMoving = true;
        }
        else
        {
            rb.velocity = Vector2.zero;
            _isMoving = false;
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
    private Vector2 _repelDirection;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_isMoving)
        {
            if (collision.gameObject.CompareTag("Circle") || collision.gameObject.CompareTag("FixtedObjects"))
            {
                Debug.LogWarning("1");
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
                Debug.LogWarning("2");
                Vector3 inNormal = collision.contacts[0].normal;
                Vector3 reflectDirection = Vector3.Reflect(inDirection, inNormal).normalized;
                //给自己的反弹力
                rb.AddForce(reflectDirection * _circleModel.Force, ForceMode2D.Impulse);

                Rigidbody2D marbleRb = collision.gameObject.GetComponent<Rigidbody2D>();
                Transform player = collision.gameObject.GetComponent<Transform>();
                Vector3 direction= player.position - transform.position;
                //给玩家的弹力
                marbleRb.AddForce(direction * _circleModel.HitPlayerForce_Move, ForceMode2D.Impulse);
            }
        }
        else
        {
            if (collision.gameObject.CompareTag("Player") && _playerStateCheck_Model.TouchTime <= 0&&_canAddForce)
            {
                Debug.LogWarning("3");
                StartCoroutine(WaitAddForce());
                StartCoroutine(WaitTime());
                if (_canUpdate)
                {
                    initialPosition = transform.position;
                    _canUpdate =false;
                }
                _touchPlayer = true;
                if (collision.gameObject.CompareTag("Player"))
                {
                    _repelDirection= (PlayerSingleton.Instance.character.position - transform.position).normalized;
                }
                Rigidbody2D marbleRb = collision.gameObject.GetComponent<Rigidbody2D>();
                //给碰撞物的弹力
                if (this.GetModel<Dash_0_Model>().InDashState)
                {
                    Debug.LogWarning("4");
                    Debug.LogWarning(collision.gameObject.name);
                    this.SendEvent(new MarblesPlayer_Event(gameObject));
                    marbleRb.AddForce(_repelDirection * _circleModel.HitPlayerForce, ForceMode2D.Impulse);
                }
            }
        }
    }
    private bool _canAddForce=true;
    IEnumerator WaitAddForce()
    {
        _canAddForce = false;
        yield return new WaitForSeconds(0.1f);
        _canAddForce = true;
    }

    IEnumerator WaitTime()
    {
        float timeControl=5f;
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