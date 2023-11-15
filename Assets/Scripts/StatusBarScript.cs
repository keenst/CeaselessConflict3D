using UnityEngine;
using UnityEngine.UI;

public class StatusBarScript : MonoBehaviour
{
    public Color fillColor;

    [Range(0, 1)] 
    public float fillAmount;

    public Image full;
    public Image empty;

    private float _defaultX;
    
    public void Start()
    {
        _defaultX = full.rectTransform.position.x;
    }
    
    public void Update()
    {
        RectTransform rect = full.rectTransform;
        rect.localScale = new Vector3(fillAmount, 1);
        rect.position = new Vector3(_defaultX + fillAmount * 180 - 180, rect.position.y);
    }
    
    public void SetValue(float value, float max)
    {
        
    }
}
