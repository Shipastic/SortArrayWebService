using System;
using System.Web.Services;

namespace SortArray
{
    /// <summary>
    /// Сводное описание для ArraySortService
    /// </summary>
    [WebService(Namespace = "ArraySort")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class ArraySortService : System.Web.Services.WebService
    {

        [WebMethod]
        public int[] ArraySort(int[] arr)
        {
            var items = new int[arr.Length];

            var min = int.MaxValue;
            var max = int.MinValue;
            foreach (var x in arr)
            {
                if (x > max) max = x;
                if (x < min) min = x;
            }

            var counts = new int[max - min + 1];

            foreach (var x in arr)
            {
                counts[x - min]++;
            }

            int total = 0;
            for (int i = min; i <= max; i++)
            {
                var oldCount = counts[i - min];
                counts[i - min] = total;
                total += oldCount;
            }

            foreach (var x in arr)
            {
                items[counts[x - min]] = x;
                counts[x - min]++;
            }
            return items;
        }      
        public void QuickSort(int[] arr, int left, int right)
        {
            if (left >= right)
                return;
            int i = left;
            int j = right;
            int x = arr[(left + right) / 2];

            while (i < j)
            {
                while (arr[i] < x) i++;
                while (arr[j] > x) j--;
                if (i <= j)
                {
                    int tmp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = tmp;
                    i++;
                    j--;
                }
            }
            QuickSort(arr, left, j);
            QuickSort(arr, i, right);
        }
        [WebMethod]
        public int[] Sort(int[] arr)
        {
            var items = new int[arr.Length];
            arr.CopyTo(items, 0);
            QuickSort(items, 0, items.Length - 1);
            return items;
        }
    }
}
