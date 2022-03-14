namespace BasicWebApplication.Model
{
    public class HelloWorldService
    {
        public string Now { get; }

        public HelloWorldService()
        {
            Now = $"Hello World {System.DateTime.Now.Ticks}";
        }

    }
}