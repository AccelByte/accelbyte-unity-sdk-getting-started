// Copyright (c) 2019 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using UnityEngine;
using UnityEngine.UI;
using AccelByte.Core;

public class SceneUtilities : MonoBehaviour 
{
	/// <summary>
	/// Show log on the user interface.
	/// If the error is not null and passed through the parameter – error code and message will be shown.
	/// </summary>
	/// <param name="textComponent">Text component in a scene that will show the message.</param>
	/// <param name="message">Message that will be shown,</param>
	/// <param name="error">Error information that will be shown.</param>
	public static void Log(Text textComponent, string message, Error error = null)
	{
		if (error == (null))
		{
			textComponent.text = message;
		}
		else
		{
			string format = string.Format(message + "\nCode:{0}\nMessage:{1}", error.Code, error.Message);
			textComponent.text = format;
		}
		Debug.Log(textComponent.text);
	}

}
