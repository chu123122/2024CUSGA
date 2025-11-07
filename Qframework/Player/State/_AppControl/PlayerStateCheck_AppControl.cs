using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
public class PlayerStateCheck_AppControl: MonoBehaviour, IController,ICanRegisterEvent
{
    private PlayerStateCheck_Model _playerStateCheck_Model;
    private float _time;
    private bool _canTouch=true;
    private void Awake()
    {
        _playerStateCheck_Model = this.GetModel<PlayerStateCheck_Model>();
        this.RegisterEvent<LaunchCircle_Event>(e =>
        {
            _time=e.time;
            StartCoroutine(WaitTouch());
        }).UnRegisterWhenGameObjectDestroyed(gameObject);
        this.RegisterEvent<PLayerDead_Event>(e =>
        {
            _canTouch = true;
        }).UnRegisterWhenGameObjectDestroyed(gameObject);
    }
    private void Update()
    {
        if(_playerStateCheck_Model.TouchTime>0) _playerStateCheck_Model.TouchTime-=Time.deltaTime;
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Circle")&& _canTouch )
        { 
            _canTouch = false;      
            collision.gameObject.SetActive(false);
            _playerStateCheck_Model.StateNumber = 1;
            _playerStateCheck_Model.TouchTime = 0.1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Circle")&& _canTouch )
        {
            _canTouch = false;      
            other.gameObject.SetActive(false);
            _playerStateCheck_Model.StateNumber = 1;
            _playerStateCheck_Model.TouchTime = 0.1f;
        }
    }

    IEnumerator WaitTouch()
    {
        while (_time>0)
        {
            _time-=Time.deltaTime;
            yield return null;
        }
        _canTouch = true;
    }
    public IArchitecture GetArchitecture()
    {
        return GameObjects_App.Interface;
    }
}
