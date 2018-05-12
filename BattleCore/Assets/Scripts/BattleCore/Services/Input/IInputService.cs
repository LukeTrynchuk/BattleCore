using BattleCore.Core.ServiceLocator;

namespace BattleCore.Services
{
    /// <summary>
    /// The IInputService describes the contract that
    /// all concrete implementations of a Input Service
    /// must include.
    /// </summary>
    [ServiceDefinition]
    public interface IInputService
    {
        void DoStuff();
    }
}
