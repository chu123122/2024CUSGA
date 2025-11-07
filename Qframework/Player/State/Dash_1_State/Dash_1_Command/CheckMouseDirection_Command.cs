using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
public class CheckMouseDirection_Command : AbstractCommand
{
    public Vector3 circleDirection;
    public Vector3 playerDirection;
    protected override void OnExecute()
    {
        GameObject Player = PlayerSingleton.Instance.gameObject1;
        Transform _transform = Player.transform;

        Vector3 mousePosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 mouseDirection = (mouseWorldPosition - _transform.position).normalized;
        circleDirection = -mouseDirection;

        Vector3 mousePosition_1 = Input.mousePosition;
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition_1.x, mousePosition_1.y, 10f));
        playerDirection = (targetPosition - _transform.position).normalized;
    }

}
