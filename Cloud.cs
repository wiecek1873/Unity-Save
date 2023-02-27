using System.Threading.Tasks;

namespace MW.Save
{
    //Mock class
    public static class Cloud
    {
        public static Task Save(object _data)
        {
            return Task.CompletedTask;
        }

        public static Task<T> Load<T>()
        {
            return Task.FromResult<T>(default);
        }
    }
}