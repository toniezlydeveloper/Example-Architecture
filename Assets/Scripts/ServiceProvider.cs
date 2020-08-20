using System;
using System.Collections.Generic;
using UnityEngine;

public class ServiceProvider : MonoBehaviour
{
    #region Private Fields

    private static List<GameObject> servicesParents = new List<GameObject>();
    private static Dictionary<Type, object> services = new Dictionary<Type, object>();

    #endregion

    #region Unity Callbacks

    private void Awake()
    {
        servicesParents.Add(gameObject);
    }

    #endregion

    #region Public Methods

    public static T GetService<T>()
    {
        if (services.TryGetValue(typeof(T), out object storedService))
        {
            return (T) storedService;
        }

        foreach (GameObject servicesParent in servicesParents)
        {
            if (!servicesParent.TryGetComponent(out T service))
            {
                continue;
            }

            services.Add(typeof(T), service);
            return service;
        }

        return default;
    }

    public static T GetService<T, TU>(TU nullService) where TU : T
    {
        T service = GetService<T>();
        
        if (service.Equals(default))
        {
            Debug.LogWarning($"There is no {typeof(T)}!");
            services.Add(typeof(T), nullService);
            return nullService;
        }

        return service;
    }

    #endregion
}