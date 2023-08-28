using UnityEngine;
using UnityEngine.EventSystems;

public class SoundHoverButton : MonoBehaviour, IPointerEnterHandler
{

    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioManager.instance.PlaySfx(0);
    }
}