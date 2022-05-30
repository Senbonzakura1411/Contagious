using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ShowHideUI : MonoBehaviour
    {
        [SerializeField] private GameObject uiContainer;
        [SerializeField] private bool isActiveAtStart;

        private void Start()
        {
            uiContainer.SetActive(isActiveAtStart);
            
        }

        private void Update()
        {
            // Input Check
            if (InputManager.GetInstance().playerControls.UIControls.InventoryEquipmentUI.WasPressedThisFrame()) uiContainer.SetActive(!uiContainer.activeSelf);
        }
    }
}
