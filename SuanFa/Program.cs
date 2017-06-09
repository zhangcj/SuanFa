using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuanFa
{
    class Program
    {
        static int[] arr = { 6, 1, 2, 7, 9, 3, 4, 5, 10, 8 };
        static void Main(string[] args)
        {
            string str = "1234567";
            //全排列
            //quanpailie(str.ToArray(),0,str.Length-1);

            //反转
            //char[] arr = str.ToArray();
            //int start = 0;
            //int index = 3;
            //int end = arr.Length-1;
            //fanzhuan(arr, start, index);
            //fanzhuan(arr, index + 1, end);
            //fanzhuan(arr, start, end);

            //判断回文
            //string huiwen = "abcdcea";
            //checkHuiWen(huiwen);

            //最大回文
            //string huiwen = "abcdedcocde";
            //maxHuiWenString(huiwen);

            //strSon 是 strFather的真子集
            //string strFather = "abcdefs";
            //string strSon = "bbds";
            //bool result = checkIsSon(strFather, strSon);
            //if (result) System.Console.WriteLine("是真子集");
            //else System.Console.WriteLine("非真子集");

            //int[] arr = { 1, 3, 5, 7, 9, 15 };
            //findDiff2(arr, 10);

            ////最大和子数组
            //int[] arr = { 3,-6,1,2,3,-1,2,-5,1,2};
            //maxSubArr(arr);

            ////负左正右
            //int[] arr = { 1, -2, -4, 5, 6, -3, -8, 6 };
            //leftOrRight2(arr);

            ////数组中出现最多的元素
            //int[] arr = { 0, 2, 2, 1, 2, 0, 2, 0 };
            //findMaxDisplay(arr);

            //快速排序
            quickSort(0,arr.Length-1);
            for (int i = 0; i < arr.Length; i++)
            {
                System.Console.WriteLine(arr[i]);
            }

            System.Console.Read();
        }

        #region 全排列
        static void quanpailie(char[] arr, int start, int end)
        {
            if (start == end)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    System.Console.Write(arr[i]);
                }
                System.Console.Write("\n");
            }
            else
            {
                /**
                * 试想，我们要对123进行全排列。
                * 我们可以采用将1固定，“23”进行全排列，
                * 将“2”固定，对“13”进行全排列，
                * 将“3”固定，对“12”进行全排列。
                * */
                for (int i = start; i <= end; i++)
                {
                    swap(arr, i, start);//将某一位置换到第一位固定
                    quanpailie(arr, start + 1, end);
                    swap(arr, i, start);//还原上面置换
                }
            }
        }

        static void swap(char[] arr, int left, int right)
        {
            char temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;
        }
        #endregion

        #region 反转
        static void fanzhuan(char[] arr, int start, int end)
        {
            /**
            * 分成两部分看：排列完成，待排列
            *
            * start和end部分为排列完成，start+1之后为待排列，最后end和start置换。
            */
            while (end > start)//排列次数，是整个数组的长度
            {
                char temp = arr[start];
                for (int i = start + 1; i <= end; i++)
                {
                    arr[i - 1] = arr[i];
                }
                arr[end] = temp;
                end--;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                System.Console.Write(arr[i]);
            }
            System.Console.Write("\n");
        }
        #endregion

        #region 判断回文
        static void checkHuiWen(string str)
        {
            bool result = true;
            char[] arr = str.ToArray();
            /**
            * 回文对比中心索引两边值，依次做比较；
            * */
            int index = arr.Length - 1 / 2;
            int end = arr.Length - 1;
            for (int i = 0; i < index; i++)
            {
                if (arr[i] != arr[end - i])
                {
                    result = false;
                    break;
                }
            }
            if (result)
                System.Console.Write("say yes");
            else
                System.Console.Write("say no");
        }
        #endregion

        #region 最大回文字符串
        static void maxHuiWenString(string str)
        {
            char[] arr = str.ToArray();
            string tempStr = "";
            string result = "";
            /**
            * 以数组每个数字为中心，前后比较，如果前值等于后值则记录；
            * 循环体结束之后，进行多个回文比较，长度最大的保留；
            * */
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    if ((i - j) > 0 && (i + j) < arr.Length && arr[i - j] == arr[i + j])
                    {
                        if (tempStr == "")
                            tempStr = arr[i].ToString();
                        tempStr = arr[i - j] + tempStr + arr[i + j];
                    }
                    else
                        break;
                }
                if (tempStr.Length >= result.Length)
                {
                    result = tempStr;
                    tempStr = "";
                }
            }
            System.Console.WriteLine(result);
        }
        #endregion

        #region 字符串是否是另一个字符串的真子集
        static bool checkIsSon(string strFather, string strSon)
        {
            int finalCount = 0;
            char[] arrFather = strFather.ToArray();
            char[] arrSon = strSon.ToArray();
            for (int i = 0; i < arrSon.Length; i++)
            {
                int son = arrSon[i];
                int father = arrFather[i];
                if (son == father)
                {
                    finalCount += 1;
                }
                else if (son >= father)//向后找
                {
                    for (int j = i; j < arrFather.Length; j++)
                    {
                        if (son == arrFather[j])
                        {
                            finalCount += 1;
                            break;
                        }
                        if (arrFather[j] > son)
                        {
                            return false;
                        }
                    }
                }
                else if (son < father)//向前找
                {
                    for (int j = i; j > i; j--)
                    {
                        if (son == arrFather[j])
                        {
                            finalCount += 1;
                            break;
                        }
                        if (arrFather[j] < son)
                        {
                            return false;
                        }
                    }
                }
            }
            return finalCount == arrSon.Length;
        }
        #endregion

        #region 数组中找出和为指定值的两个数
        /*
        假设是有序数组
        */
        static void findDiff(int[] arr, int sum)
        {
            int[] arr2 = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr2[i] = sum - arr[i];
            }

            int start = 0;
            int end = arr2.Length - 1;

            while (start < end)
            {
                if (arr[start] == arr2[end])
                {
                    System.Console.WriteLine("start:" + arr[start] + ",end:" + arr[end]);
                    return;
                }
                else if (arr[start] < arr2[end])
                {
                    while (start < end && arr[start] < arr2[end])
                    {
                        start++;
                    }
                }
                else
                {
                    while (start < end && arr[start] > arr2[end])
                    {
                        end--;
                    }
                }
            }
        }

        static void findDiff2(int[] arr, int sum)
        {
            int start = 0;
            int end = arr.Length - 1;
            while (start < end)
            {
                if (arr[start] + arr[end] == sum)
                {
                    System.Console.WriteLine("start:" + arr[start] + ",end:" + arr[end]);
                    start++;
                }
                else if (arr[start] + arr[end] > sum)
                {
                    end--;
                }
                else
                {
                    start++;
                }
            }
        }
        #endregion

        #region 找出最大加值子数组
        static void maxSubArr(int[] arr)
        {
            int sum = 0;
            int start = 0;
            int end = 0;
            int temp = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (temp < 0)
                {
                    start = i;
                    temp = arr[i];
                }
                else
                {
                    temp += arr[i];
                }
                if (sum < temp)
                {
                    sum = temp;
                    end = i;
                }
            }
        }
        #endregion

        #region 负左正右
        static void leftOrRight1(int[] arr)
        {
            int index = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                {
                    for (int j = i; j > index; j--)
                    {
                        int temp = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = temp;
                    }
                    index++;
                }
            }
        }

        static void leftOrRight2(int[] arr)
        {
            int start = 0;
            int end = arr.Length - 1;
            while (start != end)
            {
                while (start < end && arr[start] < 0)
                {
                    start++;
                }
                while (start < end && arr[end] >= 0)
                {
                    end--;
                }
                if (start < end)
                {
                    int temp = arr[start];
                    arr[start] = arr[end];
                    arr[end] = temp;
                }
            }
        }
        #endregion

        #region 找到数组中出现最多的元素
        static void findMaxDisplay(int[] arr)
        {
            int v = arr[0];
            int c = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (v == arr[i])
                {
                    c++;
                }
                else
                {
                    c--;
                }
                if (c == 0)
                {
                    v = arr[i];
                    c = 1;
                }
            }

            System.Console.WriteLine(v);
        }
        #endregion

        #region 快速排序
        static void quickSort(int left,int righ)
        {
            if (left > righ) {
                return;
            }

            int k = arr[left];
            int i = left;
            int j = righ;

            while (i!=j)
            {
                while (arr[j] >= k && i < j)
                {
                    j--;
                }
                while (arr[i] <= k && i<j)
                {
                    i++;
                }
                if(i<j)
                {
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            if (i == j)
            {
                arr[left] = arr[i];
                arr[i] = k;
            }

            quickSort(left,i-1);
            quickSort(i+1,righ);
        }
        #endregion
    }
}
