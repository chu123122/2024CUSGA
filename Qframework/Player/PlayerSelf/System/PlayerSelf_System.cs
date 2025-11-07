using QFramework.Player._Event_Behavior_;
using UnityEngine;

namespace QFramework.Player.PlayerSelf.System
{
    public class PlayerSelf_System:AbstractSystem
    {
        protected override void OnInit()
        {
            this.RegisterEvent<Dead_Event>(e =>
            {
                AudioClip audioClip = Resources.Load<AudioClip>("Music/dead");
                AudioSource.PlayClipAtPoint(audioClip,e.GameObject.transform.position);
                //–Ë“™“Ù–ß£®À¿Õˆ£©
            });
        }
    }
}