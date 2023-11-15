using UnityEngine;
using UnityEngine.UI;

public class StatusBarScript : MonoBehaviour
{
    [Range(0, 1)] 
    public float fillAmount;
    
    public Color fillColor;
    public Image full;

    private float _defaultX;
    
    public void Start()
    {
        _defaultX = full.rectTransform.position.x;
        full.color = fillColor;
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
