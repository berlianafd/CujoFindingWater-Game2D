using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Lv2PlayerInventoryDisplay : MonoBehaviour
{
    public Image[] heartPlaceholders;
    public Sprite iconHeartRed;
    public Sprite iconHeartGrey;

    public void OnChangeHeartTotal(int heartTotal)
    {
        for (int i = 0; i < heartPlaceholders.Length; ++i)
        {
            if (i < heartTotal) heartPlaceholders[i].sprite = iconHeartGrey;
            else heartPlaceholders[i].sprite = iconHeartRed;
        }
    }
}
