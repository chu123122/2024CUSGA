using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
public class PlayerStateCheck_Model : AbstractModel
{
    private float _stateNumber;
    private float _touchTime;
    public float StateNumber { get => _stateNumber; set => _stateNumber = value; }
    public float TouchTime { get => _touchTime; set => _touchTime = value; }

    protected override void OnInit()
    {
        StateNumber = 0;
    }
}
