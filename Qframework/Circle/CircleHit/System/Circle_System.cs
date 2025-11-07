using QFramework.Player._Event_Behavior_;
using UnityEngine;

namespace QFramework.Circle.CircleHit.System
{
    public class Circle_System:AbstractSystem
    {
        protected override void OnInit()
        {
            this.RegisterEvent<MablessGet_Event>(e =>
            {
                AudioClip audioClip = Resources.Load<AudioClip>("Music/hoodle_get");
                AudioSource.PlayClipAtPoint(audioClip,e.GameObject.transform.position);
                //需要音效（弹珠获得）
            });
            this.RegisterEvent<MarblesCollsion>(e =>
            {
                AudioClip audioClip = Resources.Load<AudioClip>("Music/hoodle_bounce_2");
                AudioSource.PlayClipAtPoint(audioClip,e.GameObject.transform.position);
                //需要音效（弹珠碰撞）
            });
            this.RegisterEvent<MarblesBounce_Event>(e =>
            {
                AudioClip audioClip = Resources.Load<AudioClip>("Music/hoodle_bounce_2");
                AudioSource.PlayClipAtPoint(audioClip,e.GameObject.transform.position);
                //需要音效（弹珠反弹）
            });
            this.RegisterEvent<MarblesPlayer_Event>(e =>
            {
                AudioClip audioClip = Resources.Load<AudioClip>("Music/hoodle_bounce_1");
                AudioSource.PlayClipAtPoint(audioClip,e.GameObject.transform.position);
                //需要音效（弹珠弹走玩家）
            });
            this.RegisterEvent<Throw_Event>(e =>
            {
                AudioClip audioClip = Resources.Load<AudioClip>("Music/item_drop");
                AudioSource.PlayClipAtPoint(audioClip,e.GameObject.transform.position);
            });
        }
    }
}