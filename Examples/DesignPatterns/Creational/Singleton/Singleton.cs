namespace Singleton
{
    public class Singleton
    {
        private static Singleton _instance;

        protected Singleton()
        {
        }

        public static Singleton Instance()
        {
            return _instance ?? (_instance = new Singleton());
        }
    }
}