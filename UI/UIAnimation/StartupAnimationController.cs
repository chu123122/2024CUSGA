using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartupAnimationController : MonoBehaviour
{
    public void DestroyAfterAnimation() 
    {
        Destroy(this.gameObject);
    }
}
