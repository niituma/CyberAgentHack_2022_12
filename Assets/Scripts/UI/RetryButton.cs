using UnityEngine;
using UnityEngine.EventSystems;

namespace CleanCity.UI
{
  public class RetryButton : MonoBehaviour,IPointerClickHandler
  {
    public void OnPointerClick(PointerEventData eventData)
    {
      GameSystem.RestartGame();
    }
  }
}