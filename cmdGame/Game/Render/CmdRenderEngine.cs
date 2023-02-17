
using System;
namespace cmdGame

{
    public class CmdRenderEngine:RenderEngine 
    {
        //0表示没有 >0正常显示 <0表示受伤
        int[,] mapData;
        public override void SetMapSize(int rowCount, int colCount)
        {
            base.SetMapSize(rowCount, colCount);//不懂意思，一会再看
            mapData = new int[rowCount, colCount];
        }
        public override void Render(RenderInfos info)
        {
            Console.Clear();
            Debug.Log($"{GetType().Name} Update");
            //清空地图
            for(int row =0;row<RowCount;row++)
            {
                for (int col = 0; col < ColCount; col++)
                {
                    mapData[row, col] = 0;
                }
            }
            var infos = info.GetInfos();//todo

            //遍历所有渲染信息
            foreach(var item in infos)
            {
                var halfColCount=(ColCount-1)/2;
                var col = item.pos.x + halfColCount;
                var halfRowCount =(RowCount-1)/2;
                var row = item.pos.y+ halfColCount;
                mapData[row, col] = item.color * item.type;//color为负数闪红
                //将角色坐标转换到地图中存储,中心坐标为(0,0)
            }
            //绘制
            const int CharSpaceCount = 2;//宽度问题：横向窄一点所以×2
            for(int row = 0; row < RowCount; row++)
            {                
                int lastIdx = -1;
                for(int col = 0; col < ColCount; col++)
                {
                    //从左上角打印
                    var val = mapData[RowCount - row - 1, col];
                    if (val == 0) continue;

                    //打印扫描到actor前的空白
                    var spaceCount = col - lastIdx - 1;//计算空格数量
                    lastIdx = col;
                    var spaceStr = new string(' ', spaceCount * CharSpaceCount);
                    Console.Write(spaceStr);
                    //判断是否受伤
                    var color = val <0? ConsoleColor.Red : ConsoleColor.White;
                    Console.ForegroundColor = color;
                    var ch = (Math.Abs(val)==1? "M":"P")+new string(' ', CharSpaceCount-1);
                    //打印自身
                    Console.Write(ch);
                    Console.ForegroundColor= ConsoleColor.White;
                }
                //获取剩余空格数量
                var endSpaceStr = new string(' ', (ColCount - lastIdx - 1) * CharSpaceCount);
                Console.Write(endSpaceStr);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write('|');
                Console.WriteLine();

            }
            var endLineStr = new string('-', ColCount * CharSpaceCount);
            Console.Write(endLineStr);
            Console.WriteLine();
            var extraInfos = info.GetExtraInfos();
            foreach (var item in extraInfos)
            {
                Console.WriteLine(item);
            }
        }
    }
    
}
