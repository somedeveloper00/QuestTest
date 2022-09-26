using UnityEngine;

namespace QuestSystem
{
    public class CollectibleManager : MonoBehaviour
    {
        public Collectible[] collectibles;

        public void Collect(string name)
        {
            foreach (var collectible in collectibles)
            {
                if (collectible.name == name)
                {
                    collectible.Collect();
                    return;
                }
            }
        }
    }
}