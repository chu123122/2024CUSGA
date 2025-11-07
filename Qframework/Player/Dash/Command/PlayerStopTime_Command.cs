using System.Collections;
using System.Collections.Generic;
using C_.Qframework.Player.Dash._Model;
using UnityEngine;
using QFramework;
public class PlayerStopTime_Command : AbstractCommand
{
    private PlayerDash_Model _playerDash_Model;
    private PlayerSelf_Model _playerSelf_Model;
    private bool _isBulletTimeActive;
    public PlayerStopTime_Command()
    {
        IsBulletTimeActive = true;
    }
    public bool IsBulletTimeActive { get => _isBulletTimeActive; set => _isBulletTimeActive = value; }

    protected override void OnExecute()
    {
        _playerDash_Model = this.GetModel<PlayerDash_Model>();
        _playerSelf_Model= this.GetModel<PlayerSelf_Model>();
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        if(IsBulletTimeActive)
        {
            Time.timeScale = _playerDash_Model.TimeScale;
            _playerDash_Model.TimeControl -= Time.deltaTime;
        }
       if(IsBulletTimeActive && _playerDash_Model.TimeControl <= 0)
        {
            IsBulletTimeActive=false;
            Time.timeScale = 1.0f;
        }

    }
}
