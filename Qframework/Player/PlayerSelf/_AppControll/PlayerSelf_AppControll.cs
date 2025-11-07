using QFramework;
using System.Collections;
using System.Collections.Generic;
using C_.Qframework.Player.Dash._Model;
using QFramework.Player.PlayerSelf.Data;
using UnityEngine;

public class PlayerSelf_AppControll : MonoBehaviour,IController,ICanSendEvent
{
    private PlayerSelf_Data _playerData;
    private PlayerSelf_Model _playerSlefModel;
    private Dash_0_Model _dash_0_Model;
    private Rigidbody2D _rb;
    private void Awake()
    {
        _playerData=Resources.Load<PlayerSelf_Data>("Player_Data/PlayerSelf_Data");
        _playerSlefModel = this.GetModel<PlayerSelf_Model>();
        _dash_0_Model=this.GetModel<Dash_0_Model>();
        _rb = PlayerSingleton.Instance.rigidbody2D;
        _playerSlefModel.OrginGravityScale=_rb.gravityScale;
        Debug.Log("OrginGravityScale:" + _playerSlefModel.OrginGravityScale);
       
    }

   
    private void Update()
    {
        if (!_playerSlefModel.IsDashing &&! _playerSlefModel.IsJumping && !_playerSlefModel.IsStating&&! _playerSlefModel.IsGarbiing&&!_dash_0_Model.IsDashing)
        {
            _rb.gravityScale = _playerSlefModel.OrginGravityScale;
        }
        if(_playerSlefModel.IsGarbiing)
        {
            _rb.gravityScale = 0;
            _rb.velocity=Vector2.zero;   
        }
        else
        {
            //_rb.gravityScale = _playerSlefModel.OrginGravityScale;
        }
        
        if(_playerData.ShowJumpMount)
            Debug.LogWarning("JumpMount:"+_playerSlefModel.JumpMount);
        if (_playerData.ShowDashMount)
           Debug.LogWarning("DashMount:"+_playerSlefModel.DashMount);
        if(_playerData.ShowGrabMount)
            Debug.LogWarning("GrabMount:"+_playerSlefModel.GrabMount);
        if(_playerData.ShowStateNumber)
            Debug.LogWarning("JumpMount:"+_playerSlefModel.JumpMount);
            
            //Debug.Log("InState:"+this.GetModel<Dash_0_Model>().InState);
    }

    public IArchitecture GetArchitecture()
    {
        return GameObjects_App.Interface;
    }

}
