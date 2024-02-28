using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState_DashCircle_1_TimePart : MonoBehaviour
{

    public static PlayerState_DashCircle_1_TimePart instance; // 单例

    private void Awake()
    {
        // 确保只有一个实例存在
        if (instance == null)
        {
            instance = this;
        }
    }

    public void StartEnableCollisionAfterDelay(Collider2D cloneCollider)
    {
        StartCoroutine(EnableCollisionAfterDelay(cloneCollider));
    }

    private IEnumerator EnableCollisionAfterDelay(Collider2D cloneCollider)
    {
        yield return new WaitForSeconds(1.0f); // 等待一段时间
        Physics2D.IgnoreCollision(cloneCollider, Player.PlayerCo.GetComponent<Collider2D>(), false); // 恢复碰撞
    }
}
