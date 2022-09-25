using System.Linq;
using UnityEngine;


#if UNITY_EDITOR
using UnityEditor;
#endif

namespace QuestSystem
{
    /// <summary>
    /// Used for better control over quests
    /// </summary>
    [CreateAssetMenu(fileName = "Quests Holder", menuName = "SampleTest/Quests Holder", order = 0)]
    public class QuestsHolder : ScriptableObject
    {
        public Quest[] quests;

        private void OnValidate()
        {
#if UNITY_EDITOR
            // delete any sub-asset that isn't part of this object
            bool changed = false;
            var path = AssetDatabase.GetAssetPath(this);
            var subAssets = AssetDatabase.LoadAllAssetsAtPath(path);
            
            foreach (var subAsset in subAssets)
            {
                if (subAsset is Quest quest)
                {
                    if (quests.Contains(quest) == false)
                    {
                        DestroyImmediate(quest, true);
                        changed = true;
                    }
                }
            }

            if (changed)
                AssetDatabase.Refresh();
#endif
        }
    }
}