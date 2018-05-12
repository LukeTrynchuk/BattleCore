using UnityEngine;

namespace BattleCore.Services
{
    /// <summary>
    /// This is a concrete implementation of a input service.
    /// The keyboard input service listens for keyboard input
    /// and send events if a certain key has been pressed.
    /// </summary>
    public class Keyboard_InputService : MonoBehaviour, IInputService
    {
        public void DoStuff()
        {
            Debug.Log("Stuff");
        }
    }
}
