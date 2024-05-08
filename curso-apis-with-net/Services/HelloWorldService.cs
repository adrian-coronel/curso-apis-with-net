namespace curso_apis_with_net.Services
{
    public class HelloWorldService : IHelloWorldService
    {

        public string GetHelloWorld()
        {
            return "Hello world!";
        }

    }


    public interface IHelloWorldService
    {
        string GetHelloWorld();
    }

}
