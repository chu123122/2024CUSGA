using C_.Qframework.Player.Dash._Model;
using QFramework;
using QFramework.Circle.CircleHit.System;
using QFramework.Player.Grab.System;
using QFramework.Player.NewPlayerAutoGrab._Model;
using QFramework.Player.NewPlayerGrab._Model;
using QFramework.Player.PlayerSelf.System;

public class GameObjects_App : Architecture<GameObjects_App>
{
    protected override void Init()
    {
        this.RegisterModel(new PlayerSelf_Model());
        this.RegisterModel(new PlayerMove_Model());
        this.RegisterModel(new PlayerLoad_Model());
        this.RegisterModel(new PlayerJump_Model());
        this.RegisterModel(new PlayerDash_Model());
        this.RegisterModel(new PlayerStateCheck_Model());
        this.RegisterModel(new Dash_0_Model());
        this.RegisterModel(new Dash_1_Model());
        this.RegisterModel(new CloneCircleHit_Model());
        this.RegisterModel(new NewAutoGrab_Model());
        this.RegisterModel(new NewGrab_Model());

        this.RegisterSystem(new Dash_0State_System());
        this.RegisterSystem(new Dash_1State_System());
        this.RegisterSystem(new NormalState_System());
        
        this.RegisterSystem(new PlayerMove_System());
        this.RegisterSystem(new PlayerJump_System());   
        this.RegisterSystem(new PlayerLoad_System());
        this.RegisterSystem(new PlayerDash_System());
        this.RegisterSystem(new PlayerGrab_System());
        this.RegisterSystem(new PlayerSelf_System());
        
        this.RegisterSystem(new Circle_System());

    }
}