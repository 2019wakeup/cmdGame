using System;
using System.Collections.Generic;

namespace cmdGame

{
    public class Actor
    {
        public virtual int Type => 0;
        public Vector2 _pos;
        public Vector2 pos//访问pos的时候调用正确的位置
        {
            get => _pos;
            set
            {
                value=world.GetValidPos(value);
                _pos = value;
            }
        }
        public int damage;
        public int health;
        public World world;
        public bool isHurt;
        private List<Component> components = new List<Component>();
        public void AddComponent(Component comp)
        {
            components.Add(comp);
            //将actor绑定到component,获取此actor
            comp.Bind(this);
            comp.Awake();
        }
        public void Awake() 
        {
            Debug.Log($"{GetType().Name}Awake");
        }
        public void Update() 
        {
            Debug.Log($"\t  {GetType().Name} Update");
            foreach (var item in components)//对每个components更新
            {
                item.Update(Time.deltaTime);
            }
        }
        public override string ToString()
        {
            return $"pos {pos} h:{health} type:{Type} isHurt:{isHurt}";
        }
    }
    
}
