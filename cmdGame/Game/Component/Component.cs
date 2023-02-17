using System;
using System.ComponentModel.Design;

namespace cmdGame

{
    public class Component
    {
        protected Actor actor;

        public void Bind(Actor actor)
        {
            this.actor = actor;//将特定actor类型传入component
        }
        public virtual void Awake() 
        {
            Debug.Log($"{GetType().Name} Awake");
        }
        public virtual void Update(float dt) 
        {
            Debug.Log($"\t  \t  {GetType().Name} Update");
        }//由于子类要进行重写,用virtual
    }
    
}
