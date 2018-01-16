using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog.AdditionalInfrastructure
{
    public class BlogDIContainer
    {
        public void Register<TKeyType, TConcreteType>()
            where TConcreteType : class, TKeyType
        {
            Register<TKeyType, TConcreteType>(false, null);
        }

        public void RegisterSingletonInstance<TKeyType, TConcreteType>(TConcreteType instance)
            where TConcreteType : class, TKeyType
        {
            Register<TKeyType, TConcreteType>(true, instance);
        }

        public object Resolve(Type type)
        {
            return ResolveObject(type);
        }

        private void Register<TType, TConcrete>(bool isSingleton, TConcrete instance)
        {
            Type type = typeof(TType);

            if (_registeredObjects.ContainsKey(type) && isSingleton)
                return;

            else if (!_registeredObjects.ContainsKey(type))
                _registeredObjects.Add(type, new RegisteredType(typeof(TConcrete), isSingleton, instance));

            else
                return; 
        }

        private object ResolveObject(Type type)
        {
            if (!_registeredObjects.ContainsKey(type))
            {
                throw new ArgumentNullException($"The type {type.Name} has not been registered");
            }

            var registeredObject = _registeredObjects[type];

            if (registeredObject.IsSinglton)
            {
                return  registeredObject.Instance;  
            }

            var parameters = ResolveConstructorParams(registeredObject);
            var instance = registeredObject.CreateInstance(parameters.ToArray());

            return instance;
        }

        private IEnumerable<object> ResolveConstructorParams(RegisteredType registeredType)
        {
            var constructorInfo = registeredType.ConcreteType.GetConstructors()
                .First();

            return constructorInfo.GetParameters()
                .Select(parameter => ResolveObject(parameter.ParameterType));
        }

        private readonly IDictionary<Type, RegisteredType> _registeredObjects = new Dictionary<Type, RegisteredType>();
    }
}