using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DemoDependencyInjection.Tools.IOC
{
    class SimpleIOC : ISimpleIOC
    {
        private IDictionary<Type, object> _instances;
        private IDictionary<Type, Type> _mappers;
        private IDictionary<Type, Func<object>> _builders;

        public SimpleIOC()
        {
            _instances = new Dictionary<Type, object>();
            _mappers = new Dictionary<Type, Type>();
            _builders = new Dictionary<Type, Func<object>>();
        }

        public void Register<TResource>()
        {
            _instances.Add(typeof(TResource), null);
        }

        public void Register<TResource>(Func<TResource> builder)
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            Register<TResource>();
            _builders.Add(typeof(TResource), () => builder());
        }

        public void Register<TResource, TConcrete>()
            where TConcrete : TResource
        {
            Register<TResource>();
            _mappers.Add(typeof(TResource), typeof(TConcrete));
        }

        public void Register<TResource, TConcrete>(Func<TResource> builder)
            where TConcrete : TResource
        {
            Register<TResource, TConcrete>();
            _builders.Add(typeof(TResource), () => builder());
        }

        public TResource GetResource<TResource>()
        {
            Type type = typeof(TResource);
            return (TResource)(_instances[type] ??= Resolve(type));
        }

        private object Resolve(Type type)
        {
            #region Récupération d'instance non null
            if (_instances[type] is not null)
            {
                return _instances[type];
            }
            #endregion
            #region Fonction de création
            if (_builders.ContainsKey(type))
            {
                return _builders[type].Invoke();
            }
            #endregion
            #region Constructeur
            Type concreteType = type;
            if (_mappers.ContainsKey(type))
            {
                concreteType = _mappers[type];
            }

            //Recherche du constructeur
            ConstructorInfo constructorInfo = concreteType.GetConstructors().SingleOrDefault();
            if(constructorInfo is not null) // <- C# 9.0
            {
                object[] constructorParameters = constructorInfo.GetParameters()
                                                                .Select(p => Resolve(p.ParameterType))
                                                                .ToArray();                
                return constructorInfo.Invoke(constructorParameters);
            }
            #endregion
            #region Singleton par propriété
            //recherche d'un singleton avec propriété
            PropertyInfo propertyInfo = concreteType.GetProperty("Instance", BindingFlags.Public | BindingFlags.Static);
            if(propertyInfo is not null)
            {
                return propertyInfo.GetMethod.Invoke(null ,null);
            }
            #endregion
            #region Singleton par variable
            //recherche d'un singleton avec variable
            FieldInfo fieldInfo = concreteType.GetField("Instance", BindingFlags.Public | BindingFlags.Static);
            if (fieldInfo is not null)
            {
                return fieldInfo.GetValue(null);
            }
            #endregion
            #region Throw InvalidOperationException

            throw new InvalidOperationException($"Impossible de résoudre le type {type}, assurez-vous qu'il ait été enregistré.");
            #endregion
        }
    }
}
