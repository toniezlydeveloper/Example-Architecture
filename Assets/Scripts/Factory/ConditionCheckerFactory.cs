using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Factory
{
    public static class ConditionCheckerFactory
    {
        #region Private Fields

        private static bool isInitialized;
        private static Dictionary<ConditionType, IConditionChecker> conditionCheckersByType;

        #endregion

        #region Public Methods

        public static IConditionChecker ConditionCheckerByType(ConditionType conditionType)
        {
            if (!isInitialized)
            {
                Initialize();
            }

            if (conditionCheckersByType.TryGetValue(conditionType, out IConditionChecker conditionChecker))
            {
                return conditionChecker;
            }

            return null;
        }

        #endregion

        #region Private Methods

        private static void Initialize()
        {
            IEnumerable<Type> checkerTypes = Assembly.GetAssembly(typeof(IConditionChecker)).GetTypes().Where(ImplementsInterface);
            conditionCheckersByType = new Dictionary<ConditionType, IConditionChecker>();

            foreach (Type checkerType in checkerTypes)
            {
                IConditionChecker conditionChecker = Activator.CreateInstance(checkerType) as IConditionChecker;
                conditionCheckersByType.Add(conditionChecker.Type, conditionChecker);
            }

            isInitialized = true;
        }

        private static bool ImplementsInterface(Type type)
        {
            return type.IsClass && !type.IsAbstract && type.IsInterface;
        }

        #endregion
    }
}