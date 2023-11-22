using UnityEngine;

public class StatusModule : MonoBehaviour
{
	public StatusBar hpBar;
	public StatusBar spBar;

	public void SetHP(float hp, float hpMax)
	{
		hpBar.SetValue(hp, hpMax);
	}

	public void SetSP(float sp, float spMax)
	{
		spBar.SetValue(sp, spMax);
	}
}
