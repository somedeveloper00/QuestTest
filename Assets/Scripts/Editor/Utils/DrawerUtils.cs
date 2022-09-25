using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Editor.Utils
{
    public class DrawerUtils
    {
        static private Dictionary<Type, (Type[] types, string[] labels)> _cachedTypes =
            new Dictionary<Type, (Type[] types, string[] labels)>();

        /// <summary>
        /// Draws a dropdown for the type of the property with <see cref="UnityEngine.SerializeReference"/> attribute.
        /// </summary>
        /// <param name="property">the property with <see cref="UnityEngine.SerializeReference"/> attribute</param>
        /// <typeparam name="T">the type of the object</typeparam>
        public static void DrawTypeSerializeReferenceDropdown<T>(Rect position, SerializedProperty property)
        {
            // get or create types
            CacheSubTypes<T>();
            
            var types = _cachedTypes[typeof(T)].types;
            var labels = _cachedTypes[typeof(T)].labels;

            if (types.Length == 0)
            {
                EditorGUI.HelpBox(position, $"No valid sub-types found for {typeof(T)}", MessageType.Error);
                return;
            }
            
            // assign default type if none present
            if (property.managedReferenceValue == null)
            {
                var newVal = Activator.CreateInstance(types[0]);
                property.managedReferenceValue = newVal;
            }
            
            // find index
            int index = 0;
            var currentType = property.managedReferenceValue.GetType();
            for (int i = 1; i < types.Length; i++)
            {
                if (types[i] == currentType)
                    index = i;
            }
            
            // popup
            using (var check = new EditorGUI.ChangeCheckScope())
            {
                index = EditorGUI.Popup(position, "Type", index, labels);
                if (check.changed)
                {
                    var newVal = Activator.CreateInstance(types[index]);
                    property.managedReferenceValue = newVal;
                }
            }

        }

        private static void CacheSubTypes<T>()
        {
            if (!_cachedTypes.ContainsKey(typeof(T)))
            {
                // get all sub-types & labels
                var subTypes = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                    from type in assembly.GetTypes()
                    where type.IsSubclassOf(typeof(T))
                    select type).ToArray();
                var subLabels = subTypes.Select(t => ObjectNames.NicifyVariableName(t.Name)).ToArray();

                // creating cache
                _cachedTypes.Add(typeof(T), new ValueTuple<Type[], string[]>(subTypes, subLabels));
            }
        }
    }
}