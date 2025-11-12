using UnityEngine;

//Where the gear can be placed
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
