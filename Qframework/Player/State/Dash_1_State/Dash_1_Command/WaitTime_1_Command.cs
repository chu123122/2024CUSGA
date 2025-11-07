using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
public class WaitTime_1_Command : AbstractCommand
{
    private Dash_1_Model _dash_1_Model;
    private bool _isBulletTimeActive;
    private float _timeScale;
    public WaitTime_1_Command(float timeScale)
    {
        IsBulletTimeActive = true;
        _timeScale = timeScale;
    }
    public bool IsBulletTimeActive { get => _isBulletTimeActive; set => _isBulletTimeActive = value; }
    protected override void OnExecute()
    {
        _dash_1_Model = this.GetModel<Dash_1_Model>();

        if (IsBulletTimeActive)
        {
            Time.timeScale = _timeScale;
            _dash_1_Model.TimeCounter_0 -= Time.deltaTime;
        }
        if (IsBulletTimeActive &&_dash_1_Model.TimeCounter_0 <= 0 )
        {
            IsBulletTimeActive = false;
            Time.timeScale = 1.0f;
        }

    }

}
