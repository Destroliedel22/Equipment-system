using UnityEngine;

public enum GearSlot
{
    Head,
    Body,
    Arms,
    Legs
}

public class GearItem : MonoBehaviour
{
    public GearSlot slot;
}
