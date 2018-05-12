using System;

namespace BattleCore.Core.ServiceLocator
{
    /// <summary>
    /// A service reference is the middle man
    /// in which a third party class interacts
    /// with a registered service.
    /// </summary>
    /// <typeparam name="T"></typeparam>
	public class ServiceReference<T> where T: class
	{
		#region Public Variables
		public T Reference
		{
			get
			{
				return ServiceLocator.GetService<T> ();
			}
		}
		#endregion

		#region Private Variables
		private T instance;
		#endregion

		#region Main Methods
		public void AddRegistrationHandle(Action Handle)
		{
			ServiceLocator.AddOnRegisterHandle<T> (Handle);
		}

		public bool isRegistered()
		{
			if (Reference == null)
				return false;
			return true;
		}
		#endregion
	}
}
