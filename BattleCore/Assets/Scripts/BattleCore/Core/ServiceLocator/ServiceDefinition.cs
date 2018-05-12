using System;

namespace BattleCore.Core.ServiceLocator
{
    /// <summary>
    /// This attribute should be applied to any
    /// service class. It will be used to help the 
    /// OnEnableRegisterService component determine 
    /// which type the class is implementing as a 
    /// service.
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface)]
    public class ServiceDefinition : Attribute{}
}
