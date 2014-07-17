using Moq;

namespace System.Fluency.Tests
{
    public class Fake<T> : Mock<T> where T : class
    {
        private readonly Mock<T> _mock;

        public Fake(Mock<T> mock)
        {
            _mock = mock;
        }

        public Fake(MockRepository repository)
            : this(repository.Create<T>())
        {
        }

        public static implicit operator T(Fake<T> fake)
        {
            return fake._mock.Object;
        }

        public new T Object { get { return _mock.Object; } }
        public new MockBehavior Behavior { get { return _mock.Behavior; } }

        public new bool CallBase
        {
            get { return _mock.CallBase; }
            set { _mock.CallBase = value; }
        }

        public new DefaultValue DefaultValue
        {
            get { return _mock.DefaultValue; }
            set { _mock.DefaultValue = value; }
        }
    }
}