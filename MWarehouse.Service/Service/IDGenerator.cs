using MWarehouse.ModelViews.GoodsReceiptModelViews;
using MWarehouse.ModelViews.ProductModelViews;
using MWarehouse.ModelViews.ProductTypeModelViews;
using MWarehouse.ModelViews.SupplierModelViews;
using MWarehouse.ModelViews.UnitModelViews;
using MWarehouse.ModelViews.WarehouseModelViews;

namespace MWarehouse.Service.Service
{
    public class IDGenerator
    {
        private static Random random = new Random();

        public static string Generate(string prefix, int length)
        {
            string auto = Guid.NewGuid().ToString("N").Substring(0, length);
            return prefix + auto;
        }

        public static int GenerateID<T>(int length, IEnumerable<T> items, Func<T, int> idSelector)
        {
            int min = (int)Math.Pow(10, length - 1);
            int max = (int)Math.Pow(10, length) - 1;
            Random random = new Random();

            while (true)
            {
                int result = random.Next(min, max + 1);

                // Kiểm tra xem ID đã tồn tại chưa
                var existed = items.FirstOrDefault(item => idSelector(item) == result);
                if (existed == null)
                {
                    return result; 
                }
            }
        }

    }
}
