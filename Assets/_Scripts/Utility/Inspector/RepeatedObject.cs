using System;
using UnityEngine;

[ExecuteAlways]
[SelectionBase]
public class RepeatedObject : MonoBehaviour
{
    public Vector3 offset = Vector3.forward;
    [SerializeField] private Direction dir;
    
    [SerializeField] private bool autoX, autoY, autoZ;
    
    [Range(1,100)]
    public int count = 1;

    private enum Direction
    {
        Forward = 1,
        Backward = -1
    }
    private void Start()
    {
        if (Application.IsPlaying(this))
        {
            CorrectChildCount();
            Destroy(this);
        }
    }

    private void Update()
    {
        CorrectChildCount();
    }
    
    [ContextMenu("Reset")]
    public void ResetPos()
    {
        if (!autoX)
        {
            offset.x = 0;
        }
        if (!autoY)
        {
            offset.y = 0;
        }
        if (!autoZ)
        {
            offset.z = 0;
        }
    }
    private void CorrectChildCount()
    {
        count = Mathf.Clamp(count, 1, 1000);
        
        if (transform.childCount < count)
        {
            for (int i = transform.childCount; i < count; i++)
            {
                Transform instantiate = Instantiate(transform.GetChild(0), transform);
                if (instantiate.TryGetComponent<MeshRenderer>(out var meshRenderer))
                {
                    if (autoX)
                    {
                        offset.x = meshRenderer.bounds.size.x;
                    }
                    if (autoY)
                    {
                        offset.y = meshRenderer.bounds.size.y;
                    }
                    if (autoZ)
                    {
                        offset.z = meshRenderer.bounds.size.z;
                    }
                }
                else
                {
                    meshRenderer = instantiate.GetChild(0).GetComponent<MeshRenderer>();
                    if (autoX)
                    {
                        offset.x = meshRenderer.bounds.size.x;
                    }
                    if (autoY)
                    {
                        offset.y = meshRenderer.bounds.size.y;
                    }
                    if (autoZ)
                    {
                        offset.z = meshRenderer.bounds.size.z;
                    }
                }
                instantiate.Translate(offset * (i * (int)dir));
            }
        }
        else if (count < transform.childCount)
        {
            for (int i = transform.childCount-1; i >= count; i--)
            {
                DestroyImmediate(transform.GetChild(i).gameObject);
            }
        }
    }
}