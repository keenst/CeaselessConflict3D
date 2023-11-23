using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
	[Range(0, 1)]
		public float fillAmount;

	public Color fillColor;
	public Image full;

	private float _startingXLoc;

	public void Start()
	{
		_startingXLoc = full.rectTransform.position.x;
		full.color = fillColor;
	}

	public void SetValue(float value, float max)
	{
		fillAmount = value / max;

		UpdateFill();
	}

	private void UpdateFill()
	{
		RectTransform rect = full.rectTransform;
		rect.localScale = new Vector3(fillAmount, 1);
		rect.position = new Vector3(_startingXLoc + fillAmount * 180 - 180, rect.position.y);
	}
}
