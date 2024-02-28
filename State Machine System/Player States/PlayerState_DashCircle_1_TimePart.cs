using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState_DashCircle_1_TimePart : MonoBehaviour
{

    public static PlayerState_DashCircle_1_TimePart instance; // ����

    private void Awake()
    {
        // ȷ��ֻ��һ��ʵ������
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
        yield return new WaitForSeconds(1.0f); // �ȴ�һ��ʱ��
        Physics2D.IgnoreCollision(cloneCollider, Player.PlayerCo.GetComponent<Collider2D>(), false); // �ָ���ײ
    }
}
