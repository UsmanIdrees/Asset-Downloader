using UnityEngine;
using UnityEditor;

public class AssetDownloader : ScriptableObject
{

	[MenuItem("Assets/Build Asset Bundles/Normal")]
	public static void BuildABsNone()
	{
		BuildPipeline.BuildAssetBundles("Assets/MyAssetBuilds", BuildAssetBundleOptions.None,BuildTarget.StandaloneWindows);
	}

	[MenuItem("Assets/Build Asset Bundles/Strict Mode ")]
	public static void BuildABsStrict()
	{
		BuildPipeline.BuildAssetBundles("Assets/MyAssetBuilds", BuildAssetBundleOptions.StrictMode, BuildTarget.Android);
	}
}