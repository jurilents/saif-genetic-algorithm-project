using System;

namespace Saif.Core
{
    public static class EventManager
    {
        public static event Action<bool> OnPlayStateSetEvent;


        public static void SetPlatState(bool isPlay)
        {
            OnPlayStateSetEvent?.Invoke(isPlay);
        }
    }
}