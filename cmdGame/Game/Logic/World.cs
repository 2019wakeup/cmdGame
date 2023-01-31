using System;
using System.Collections.Generic;

namespace cmdGame
    
{
    public interface IAwake
    {
        void Awake();
    }
    public interface IUpdate
    {
        void Update();
    }



    public interface ILifeCycle:IAwake,IUpdate
    {

    }
    public class World:ILifeCycle
    {
        public Vector2 xRanege;
        public Vector2 yRanege;
        RenderEngine renderEngine;
        private List<Actor> allActor = new List<Actor> ();
        public void AddActor(Actor actor)
        {
            allActor.Add(actor);
            actor.Awake();

        }
        public void Awake() {
            Console.WriteLine($"{GetType().Name} Awake");
            renderEngine = new CmdRenderEngine();
            renderEngine.Awake();
        }
      
        public void Update() 
        {
            Console.WriteLine($"{GetType().Name} Update");
            //逻辑
            foreach (var item in allActor)
            {
                item.Update();
            }

            //渲染
            renderEngine.Render(null);//    TODO
        }
    }
    
}
