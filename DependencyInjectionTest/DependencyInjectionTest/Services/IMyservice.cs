namespace DependencyInjectionTest.Services
{
    public interface IMyService
    {
        Guid GetOperationID();
    }

    public interface ITransientService : IMyService { }
    public interface IScopedService : IMyService { }
    public interface ISingletonService : IMyService { }

    public class MyService : ITransientService, IScopedService, ISingletonService
    {
        private readonly Guid _id;

        public MyService()
        {
            _id = Guid.NewGuid(); // Mỗi khi khởi tạo, một mã ID mới sẽ được tạo ra
        }

        public Guid GetOperationID() => _id;
    }
}
