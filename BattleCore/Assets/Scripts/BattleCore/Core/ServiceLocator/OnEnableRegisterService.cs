using UnityEngine;
using System;
using System.Reflection;

namespace BattleCore.Core.ServiceLocator
{
    /// <summary>
    /// This component should be attached to any service
    /// game object. It will auto register the service
    /// to the service locator.
    /// </summary>
    public class OnEnableRegisterService : MonoBehaviour
    {
        #region Private Variables
        [SerializeField]
        private MonoBehaviour m_serviceToRegister;

        private readonly string m_name;
        //public string m_name { get; private set; }
        #endregion

        #region Main Methods
        private void OnEnable()
        {
            if (!ValidateInput()) return;

            Type[] interfaces = GetInterfaces(m_serviceToRegister);
            Type definition = GetServiceDefintionType(interfaces);
            if (definition == null) return;

            ServiceLocator.Instance.GetType()
                .GetMethod("Register").MakeGenericMethod(definition)
                .Invoke(m_serviceToRegister, new object[] { m_serviceToRegister });
        }
        #endregion

        #region Utility Methods
        private bool ValidateInput()
        {
            if (m_serviceToRegister == null)
            {
                Debug.LogError("Cannot register a null value");
                return false;
            }
            return true;
        }

        private Type[] GetInterfaces(object obj)
        {
            return obj.GetType().GetInterfaces();
        }

        private Type GetServiceDefintionType(Type[] types)
        {
            foreach(Type type in types)
            {
                MemberInfo info = type;
                object[] attributes = info.GetCustomAttributes(true);
                if (HasServiceDefinitionAttribute(attributes)) return type;
            }
            return null;
        }

        private bool HasServiceDefinitionAttribute(object[] attributes)
        {
            foreach(object attribute in attributes)
            {
                if(attribute is ServiceDefinition)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}
