using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class ZombieManager : MonoBehaviour
    {
        public event Action onKill;
        
        public void KillZombie()
        {
            onKill?.Invoke();
        }
    }
}