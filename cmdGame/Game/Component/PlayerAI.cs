using System;

namespace cmdGame

{
    public class PlayerAI:AI
    {
        public override void Update(float dt)
        {
            base.Update(dt);
            var dir = InputManager.inputVec;
            var rawPos = actor.pos;
            rawPos.x += dir.x;
            rawPos.y += dir.y;
            actor.pos = rawPos;
            InputManager.inputVec = new Vector2(0, 0);
        }

    }
    
}
