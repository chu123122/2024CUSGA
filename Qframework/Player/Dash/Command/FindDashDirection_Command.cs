using System.Collections;
using System.Collections.Generic;
using C_.Qframework.Player.Dash._Model;
using UnityEngine;
using QFramework;
public class FindDashDirection_Command : AbstractCommand
{
    private PlayerDash_Model _model;

    protected override void OnExecute()
    {
        _model= this.GetModel<PlayerDash_Model>();
        GameObject Player = PlayerSingleton.Instance.gameObject1;
        Transform transform = Player.transform;
        Vector3 mousePosition = Input.mousePosition;
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10f));
        Vector3 direction = (targetPosition - transform.position).normalized;
        if(Input.GetMouseButtonDown(1)) _model.DashDirection = direction;

    }
}
