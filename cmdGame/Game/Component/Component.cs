using System;
using System.ComponentModel.Design;

namespace cmdGame

{
    public class Component
    {
        public virtual void Awake() 
        {
            Console.WriteLine($"{GetType().Name} Awake");
        }
        public virtual void Update(float dt) 
        {
            Console.WriteLine($"\t\t{GetType().Name} Update");
        }//由于子类要进行重写,用virtual
    }
    
}
