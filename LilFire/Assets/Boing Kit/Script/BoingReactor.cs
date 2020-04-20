/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

/*
  Project   - Boing Kit
  Publisher - Long Bunny Labs
              http://LongBunnyLabs.com
  Author    - Ming-Lun "Allen" Chou
              http://AllenChou.net
*/
/******************************************************************************/

namespace BoingKit
{
  public class BoingReactor : BoingBehavior
  {
    protected override void Register()
    {
      BoingManager.Register(this);
    }

    protected override void Unregister()
    {
      BoingManager.Unregister(this);
    }

    public override void PrepareExecute()
    {
      PrepareExecute(true);
    }
  }
}
