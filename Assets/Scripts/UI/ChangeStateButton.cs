using UnityEngine;
using UnityEngine.EventSystems;

namespace CleanCity.UI
{
  public class ChangeStateButton : MonoBehaviour,IPointerClickHandler
  {
    public GameSystem.State changeTo;
    
    public void OnPointerClick(PointerEventData eventData)
    {
      GameSystem.Singleton.Status = changeTo;
    }
  }
}