using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aboutus : MonoBehaviour
{
    public void OnResume()
    {
        this.transform.parent.GetComponent<CanvasGroup>().DOFade(0, 2f).OnComplete(() =>
        {
            this.transform.parent.gameObject.SetActive(false);
        });
        EventCenter.Broadcast(EventType.resume);
    }
}
