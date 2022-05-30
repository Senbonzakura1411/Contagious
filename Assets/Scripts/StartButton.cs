using UnityEngine;

public class StartButton : MonoBehaviour
{
  [SerializeField] private GameObject panel;
  
  public void OnStartButtonPressed()
  {
    panel.SetActive(false);
    InputManager.GetInstance().playerControls.Controls.Enable();
    InputManager.GetInstance().playerControls.UIControls.Enable();
  }
}
