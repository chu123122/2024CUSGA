using QFramework;
using System.Collections;
using System.Collections.Generic;
using QFramework.Player._Event_Behavior_;
using UnityEditor;
using UnityEngine;
public class PlayerLoad_AppContrrol : MonoBehaviour,IController,ICanSendEvent
{
    private PlayerSelf_Model _playerSelf_Model;
    private Rigidbody2D rb;
    private bool _isFalling;
    private void Awake()
    {
        _playerSelf_Model = this.GetModel<PlayerSelf_Model>();
        rb = PlayerSingleton.Instance.rigidbody2D;

        this.RegisterEvent<PlayerLoad_Event>(e =>
        {
            _playerSelf_Model.JumpMount = 1;
            _playerSelf_Model.DashMount = 1;
            _playerSelf_Model.GrabMount = 1;
            _playerSelf_Model.HasLoading=true;
            this.SendEvent<PlayerLoad_1_Event>();
        }).UnRegisterWhenGameObjectDestroyed(gameObject);
        this.RegisterEvent<PlayerLoad_1_Event>(e =>
        {
            _playerSelf_Model.HasLoading = false;
        }).UnRegisterWhenGameObjectDestroyed(gameObject);
        this.RegisterEvent<Jump_Event>(e =>
        {
            _canFall = true;
        }).UnRegisterWhenGameObjectDestroyed(gameObject);
    }

    private bool _canFall=true;
    private void Update()
    {
        // Debug.Log("InGround:"+_playerSelf_Model.InGround);
        // Debug.Log("_hasLanded:"+_hasLanded);
        if (rb.velocity.y <0&&_canFall)
        {
            _isFalling = true;
        }
        if (_playerSelf_Model.InGround && _isFalling)
        {
            _isFalling = false;
            _canFall = false;
            this.SendEvent<PlayerLoad_Event>();
            this.SendEvent(new Load_Event(gameObject));
        }
        if (_playerSelf_Model.InGround)
        {
            rb.gravityScale=_playerSelf_Model.OrginGravityScale;
        }

        if (_playerSelf_Model.LayIsGround)
        {
            // _playerSelf_Model.JumpMount = 1;
            // _playerSelf_Model.DashMount = 1;
            // _playerSelf_Model.GrabMount = 1;
        }


    }
    public IArchitecture GetArchitecture()
    {
        return GameObjects_App.Interface;
    }

}
