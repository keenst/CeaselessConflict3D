using UnityEngine;

public class GameController : MonoBehaviour
{
	public LevelGeneration levelGeneration;
	public LightController lightController;

	public void Start()
	{
		Vector3[] lights = levelGeneration.Generate();
		lightController.SetLights(lights);
	}
}
