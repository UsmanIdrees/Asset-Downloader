using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Downloader : MonoBehaviour {

	public string URL;


	private string DestinationTosave;
	//private int datadownload = 0;

	void Start()
	{
		DestinationTosave = Path.Combine (Application.persistentDataPath, "Data.unity3d");
		Debug.Log (Directory.Exists(DestinationTosave) ? "true":"false");

	}
	public void download () {
		StartCoroutine (Download());
	}

	IEnumerator Download()
	{
		if (URL != null && PlayerPrefs.GetInt ("datadownloaded") != 1) 
		{
			// Link to url from where to download data
			WWW www = new WWW (URL);
			//Checking if still downloading
			while (!www.isDone)
			{
				//logging the progress 
				Debug.Log ("Downloading Assets " + www.progress);
				yield return null;
			}
			//Getting the asset bundle from downloaded data
			//AssetBundle AB = www.assetBundle;
			//if (AB != null) 
			//{
				//Checking if Loaded data has some values
				//TODO Load Objects here

			Debug.Log ("Download Completed now sabving at " + DestinationTosave);
				
			byte[] DownloadedData = www.bytes;

			File.WriteAllBytes (DestinationTosave, DownloadedData);
			PlayerPrefs.SetInt ("datadownloaded", 1);
			//GameObject GO = AB.LoadAsset("Bit Gun") as GameObject;
				//Instantiate (GO);
			//} else 
			//{
			//	Debug.Log ("Asset Does Not Found");
			//}
			yield return null;
		} 
		else 
		{
			Debug.Log ("You Did not provide URL to download data");
			LoadAsset ();
		}
	}
	public void LoadAsset()
	{
		
		var assetBundle = AssetBundle.LoadFromFile (DestinationTosave);
		if (assetBundle != null) 
		{
			GameObject GO = assetBundle.LoadAsset ("Bit Gun") as GameObject;
			Instantiate (GO);

		} else 
		{
			Debug.Log ("Asset Bundles is not found at " + DestinationTosave);
		}
	}
}