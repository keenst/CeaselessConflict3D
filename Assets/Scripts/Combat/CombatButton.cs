using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CombatButton : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public Image buttonImage;

	public string Title => textMeshPro.text;

    public void SetTitle(string title)
    {
        textMeshPro.text = title;
    }

    public void SetHighlighted(bool isHighlighted)
    {
        buttonImage.color = isHighlighted ? Color.white : Color.gray;
    }
}
