using System;

namespace Blog.AdditionalInfrastructure
{
    internal class RegisteredType
    {
        public readonly bool IsSinglton;

        public Type ConcreteType { get; private set; }

        public object Instance { get; private set; }

        public RegisteredType(Type concreteType, bool isSingleton, object instance)
        {
            IsSinglton = isSingleton;
            ConcreteType = concreteType;
            Instance = instance;
        }

        public object CreateInstance(params object[] args)
        {
            object instance = Activator.CreateInstance(ConcreteType, args);
            if (IsSinglton)
            {
                Instance = instance;
            }

            return instance;
        }
    }
}