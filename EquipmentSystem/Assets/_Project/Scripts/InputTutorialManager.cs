using TMPro;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class InputTutorialManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI EquipInputText;
    [SerializeField] private TextMeshProUGUI DropInputText;
    [SerializeField] private TextMeshProUGUI ItemInteractInputText;

    private void Update()
    {
        if(PlayerActionsManager.Instance.LHandHasItem || PlayerActionsManager.Instance.RHandHasItem)
        {
            DropInputText.gameObject.SetActive(true);
            ItemInteractInputText.gameObject.SetActive(true);
        }
        else
        {
            DropInputText.gameObject.SetActive(false);
            ItemInteractInputText.gameObject.SetActive(false);
        }
    }
}
