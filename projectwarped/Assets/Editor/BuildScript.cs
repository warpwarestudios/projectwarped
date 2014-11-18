using UnityEditor;
using System;

public class BuildScript{

	public static void BuildWindows64Player()
		{
            string buildTarget = System.Environment.GetEnvironmentVariable("UNITY_BUILD_TARGET");
				if (buildTarget == null || buildTarget.Length == 0) {
                    throw new Exception("UNITY_BUILD_TARGET -system property not defined, aborting.");
				}
			
				string[] scenes = { "Assets/GameLobby.unity", "Assets/GameSetting.unity", "Assets/MainGame.unity", "Assets/MainMenu.unity" };
			
				string error = BuildPipeline.BuildPlayer (scenes, buildTarget, BuildTarget.StandaloneWindows64, BuildOptions.None);
			
				if (error != null && error.Length > 0) {
						throw new Exception ("Build failed: " + error);
				}
		}

	}

