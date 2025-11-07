using UnityEngine;
using QFramework;
using System;
public class LaunchCircle_Command : AbstractCommand
{
    private Dash_1_Model _dash_1_model;
    private Vector3 _positon;
    public LaunchCircle_Command(Vector3 position)
    {
        _positon=position;
    }
    protected override void OnExecute()
    {
        _dash_1_model=this.GetModel<Dash_1_Model>();
        Transform transform = PlayerSingleton.Instance.transform1;
        CapsuleCollider2D capsuleCollider2D = PlayerSingleton.Instance.capsuleCollider2D;
        
        Bounds bounds = capsuleCollider2D.bounds;// ±ﬂ‘µŒª÷√  
        Vector3 edgePosition = bounds.center - Vector3.Scale(bounds.extents, _positon);
        Vector3 direction = (edgePosition - transform.position).normalized;
        Vector3 offsetPosition = edgePosition -direction * _dash_1_model.Distance;//∂ÓÕ‚¡Ùµƒæ‡¿Î
        GameObject cloneSphereHit = UnityEngine.Object.Instantiate
            (_dash_1_model.SpherePrefab, offsetPosition, Quaternion.identity);
        cloneSphereHit.tag = "Circle";

        Rigidbody2D cloneSphereRb = cloneSphereHit.GetComponent<Rigidbody2D>();
        cloneSphereRb.AddForce(_positon * _dash_1_model.CircleHitForce, ForceMode2D.Impulse);
    }
}
