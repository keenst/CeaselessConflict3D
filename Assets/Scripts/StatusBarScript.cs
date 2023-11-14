using UnityEngine;
using UnityEngine.UI;

public class StatusBarScript : MonoBehaviour
{
    public Color fillColor;
    
    [Range(0, 1)] 
    public float fillAmount;

    public Image full;
    public Image empty;

    public void SetValue(float value, float max)
    {
        
    }

    public void Update()
    {
        
    }
}
