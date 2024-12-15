

namespace MWarehouse.Service.Service
{
    public class IDGenerator
    {
        private static Random random = new Random();

        /// <summary>
        ///     Phát sinh id ngẫu nhiên
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Generate(string prefix, int length)
        {
            string auto = Guid.NewGuid().ToString("N").Substring(0, length);
            return prefix + auto;
        }

        /// <summary>
        ///     Phát sinh ID kiểm tra tồn tại kiểu Generic
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="length"></param>
        /// <param name="items"></param>
        /// <param name="idSelector"></param>
        /// <returns></returns>
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
