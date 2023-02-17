using System.Collections.Generic;
using System.Reflection.Emit;

namespace cmdGame

{
    public class RenderInfos 
    {
        public List<RenderInfo> infos = new List<RenderInfo>();
        private List<object> extraInfos = new List<object>();
        public void AddExtraInfos<T>(IEnumerable<T> objs)
        {
            foreach(var item in objs)
            {
                extraInfos.Add(item);
            }
        }
        public List<object> GetExtraInfos()
        {
            return extraInfos;
        }
        public void AddInfo(RenderInfo info)
        {
            infos.Add(info);
        }
        public List<RenderInfo> GetInfos()
        { return infos; }
    }
    
}
