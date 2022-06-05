using System;
using System.Globalization;
using UnityEngine;
using UnityEditor;

namespace Editor
{
    [CustomPropertyDrawer (typeof(RangeExAttribute))]
    internal sealed class RangeExDrawer : PropertyDrawer
    {
        public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
        {
            var rangeAttribute = (RangeExAttribute) attribute;

            if (property.propertyType == SerializedPropertyType.Float || property.propertyType == SerializedPropertyType.Integer)
            {
                EditorGUI.Slider(position, property, rangeAttribute.min, rangeAttribute.max, label);
                var s = rangeAttribute.step.ToString(CultureInfo.InvariantCulture);
                int charCount;
                float baseStep;
                if (s.Contains('.'))
                {
                    charCount = s.Substring(s.IndexOf(".", StringComparison.Ordinal)).Length - 1;
                    property.floatValue = (float) Math.Round(property.floatValue, charCount);
                    baseStep = 1 / Mathf.Pow(10, charCount);
                }
                else
                {
                    charCount = s.Length;
                    property.floatValue = Mathf.Round(property.floatValue);
                    baseStep = Mathf.Pow(10, charCount - 1);
                }

                if (property.floatValue % rangeAttribute.step != 0)
                {
                    property.floatValue += baseStep;
                }

                
            }
            else
            {
                EditorGUI.LabelField (position, label.text, "Use with float or int.");
            }
        }
    }

}