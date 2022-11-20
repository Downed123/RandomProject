using UnityEngine;

[CreateAssetMenu(fileName = "MovementScriptableObject", menuName = "ScriptableObjects/MovementScriptableObject", order = 0)]
public class MovementScriptableObject : ScriptableObject
{
    [SerializeField] private MovementType _movementType;

    enum MovementType
    {
        Horizontal
    }
}