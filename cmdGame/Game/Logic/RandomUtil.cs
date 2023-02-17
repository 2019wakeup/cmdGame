using System;

namespace cmdGame

{
    public class RandomUtil
    {
        public static Random random = new Random();

        public static int Range(int minVal,int maxVal)
        {
            return random.Next(minVal,maxVal+1);//小于等于，minval 大于maxval所以加1
        }
    }
    
}
