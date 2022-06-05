using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Player
{
    public class HuggyHairPainter : MonoBehaviour
    {
        [SerializeField] private Material hairMat;
        [Space]
        [SerializeField] private Colors hairColor;
        [Space]
        [Header("Если че цвета надо добавлять в enum, чтобы нормально отображалось")]
        [SerializeField] private List<ColorInfo> colors;
    
        [Header("Debug")]
        [SerializeField] private bool applyInEditor;

        private enum Colors
        {
            Blue,
            Red,
            Green,
            Yellow,
        }

        private void Start()
        {
            switch (hairColor)
            {
                case Colors.Blue:
                    SetColor(Colors.Blue);
                    break;
                case Colors.Red:
                    SetColor(Colors.Red);
                    break;
                case Colors.Green:
                    SetColor(Colors.Green);
                    break;
            }
        }
    
        private Color GetColor(Colors color)
        {
            return colors[(int)color].color;
        }
        private void SetColor(Colors color)
        {
            hairMat.color = GetColor(color);
        }
    
        private void OnValidate()
        {
            var dif = Mathf.Abs(Enum.GetNames(typeof(Colors)).Length - colors.Count);
            
            for (var i = dif - 1; i >= 0; i--)
            {
                if (Enum.GetNames(typeof(Colors)).Length > colors.Count)
                {
                    colors.Add(new ColorInfo
                    {
                        name = Enum.GetName(typeof(Colors), i),
                        color = Color.black
                    });
                }
                else
                {
                    colors.RemoveAt(colors.Count-1);
                }
                
            }

            if (applyInEditor)
            {
                SetColor(hairColor);
            }
        }
        private void OnDrawGizmosSelected()
        {
            
            for (var i = 0; i < colors.Count; ++i)
            {
                colors[i].name = Enum.GetName(typeof(Colors), i);
            }
        }
    }

    [Serializable]
    public class ColorInfo
    {
        [HideInInspector]
        public string name;
        public Color color;
    }
}