using UnityEngine;

internal interface IInput
{
    public bool InputEnable { get; set; }

    void Setup(Transform playerTransform);
}