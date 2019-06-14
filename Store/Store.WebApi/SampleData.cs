using System.Linq;

namespace Store.WebApi
{
    public static class SampleData
    {
        public static void Initialize(Store.Abstract.ILogic logic)
        {
            logic.CreateData();
        }
    }
}
