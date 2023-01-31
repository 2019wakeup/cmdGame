using System;

namespace cmdGame

{
    public class RenderEngine:IAwake
    {
        public virtual void Awake()
        {
            Console.WriteLine($"{GetType().Name} Awake");
        }

        
        public virtual void Render(RenderInfos info)
        {

        }
    }
    
}
