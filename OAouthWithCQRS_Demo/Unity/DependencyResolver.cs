using CeremonyBazar.CQRS.Command.Contract;
using CeremonyBazar.CQRS.Command.Impelentation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Unity;
using Unity.Exceptions;

public class DependencyResolver : IDependencyResolver
{
    public static IUnityContainer UnityContainer;

    public DependencyResolver(IUnityContainer container)
    {
        if (UnityContainer == null)
        {
            lock (container)
            {
                UnityContainer = container;
            }
        }        
    }
   
    public object GetService(Type serviceType)
    {
        try
        {
            return UnityContainer.Resolve(serviceType);
        }
        catch (ResolutionFailedException)
        {
            return null;
        }
    }

    public IEnumerable<object> GetServices(Type serviceType)
    {
        try
        {
            return UnityContainer.ResolveAll(serviceType);
        }
        catch (ResolutionFailedException)
        {
            return new List<object>();
        }
    }

    public IDependencyScope BeginScope()
    {
        var child = UnityContainer.CreateChildContainer();
        return new DependencyResolver(child);
    }

    public void Dispose()
    {
        Dispose(true);
    }

    protected virtual void Dispose(bool disposing)
    {
        UnityContainer.Dispose();
    }
}