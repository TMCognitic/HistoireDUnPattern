using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DemoIOC.Tools.IOC
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
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

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
            //Recherche et appel de la méthode de création
            if (_builders.ContainsKey(type))
                return _builders[type].Invoke();

            //Recherche du type réel à instancier
            Type concreteType = type;
            if (_mappers.ContainsKey(type)) 
                concreteType = _mappers[type];

            //Recherche du constructeur sans paramètre et appel de ce dernier
            ConstructorInfo constructorInfo = concreteType.GetConstructors().SingleOrDefault();
            if(constructorInfo is not null) { // <- C# 9.0
                if (constructorInfo.GetParameters().Count() > 0)
                    throw new InvalidOperationException("Le constructeur doit être sans paramètre.");

                return constructorInfo.Invoke(null);
            }
            
            //recherche d'un singleton avec propriété et appel du get de la propriété
            PropertyInfo propertyInfo = concreteType.GetProperty("Instance", BindingFlags.Public | BindingFlags.Static);

            if(propertyInfo is not null)
                return propertyInfo.GetMethod.Invoke(null ,null);
            
            //recherche d'un singleton avec variable et récupération de la valeur
            FieldInfo fieldInfo = concreteType.GetField("Instance", BindingFlags.Public | BindingFlags.Static);

            if (fieldInfo is not null)
                return fieldInfo.GetValue(null);

            throw new InvalidOperationException($"Impossible de résoudre le type {type}");
        }
    }
}


