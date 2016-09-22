using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class splashfade : MonoBehaviour 
{


	public Image splashImage;
	public string loadLevel;

	IEnumerator Start()
	{
		splashImage.canvasRenderer.SetAlpha (0.0F);

		FadeIn ();
		yield return new WaitForSeconds (2.5F);
		FadeOut ();
		yield return new WaitForSeconds (2.5F);
		SceneManager.LoadScene (loadLevel);
	}

	void FadeIn ()
	{
		
		splashImage.CrossFadeAlpha (1.0F, 1.5F, false);
	}

	void FadeOut ()
	{
		splashImage.CrossFadeAlpha (0.0F, 2.5F, false);
	}
}
