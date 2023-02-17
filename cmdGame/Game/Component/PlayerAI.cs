using System;

namespace cmdGame

{
    public class PlayerAI:AI
    {
        public override void Update(float dt)
        {
            base.Update(dt);
            actor.pos.y += 1;
        }

    }
    
}
