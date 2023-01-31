using System;
using System.Collections.Generic;

namespace cmdGame

{
    public class Actor
    {
        public Vector2 pos;
        public int damage;
        public int health;
        private List<Component> components = new List<Component>();
        public void AddComponent(Component comp)
        {
            components.Add(comp);
            comp.Awake();
        }
        public void Awake() 
        {
            Console.WriteLine($"{GetType().Name}Awake");
        }
        public void Update() 
        {
            Console.WriteLine($"\t  {GetType().Name} Update");
            foreach (var item in components)//对每个components更新
            {
                item.Update(Time.deltaTime);
            }
        }
    }
    
}
