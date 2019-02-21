// Copyright (c) 2019 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using AccelByte.Api;
using AccelByte.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Tools = SceneUtilities;

public class LoginPageSceneScript : MonoBehaviour
{
	private Canvas _canvas;
	private const string SceneMainMenuName = "MainMenu";
	private Button _buttonLoginAnonymously;
	private InputField _inputFieldEmail;
	private InputField _inputFieldPassword;
	private Button _buttonLoginEmail;
	private Text _textInfo;
	private User user;
	
	/// <summary>
	/// Find components in scene and attach them to this members.
	/// </summary>
	void AssignSceneComponent()
	{
		_buttonLoginAnonymously = GameObject.Find("ButtonLoginAnonymously").GetComponent<Button>();
		_buttonLoginEmail = GameObject.Find("ButtonLoginEmail").GetComponent<Button>();
		_inputFieldEmail = GameObject.Find("InputFieldEmail").GetComponent<InputField>();
		_inputFieldPassword = GameObject.Find("InputFieldPassword").GetComponent<InputField>();
		_textInfo = GameObject.Find("TextInfo").GetComponent<Text>();
		AssignButtonFunction();
	}

	/// <summary>
	/// Add function when this member buttons pressed.
	/// </summary>
	void AssignButtonFunction()
	{
		_buttonLoginAnonymously.onClick.AddListener(OnLoginAnonymouslyClicked);
		_buttonLoginEmail.onClick.AddListener(OnLoginEmailClicked);
	}
	
	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start ()
	{
		user = AccelBytePlugin.GetUser();
		AssignSceneComponent();
	}
	
	/// <summary>
	/// Login with device identifier.
	/// </summary>
	/// <param name="result">Result of the login.</param>
	void OnLoginWithDeviceId(Result result)
	{
		if (!result.IsError)
		{
			Tools.Log(_textInfo, "Logging you in...");
			SceneManager.LoadScene(SceneMainMenuName);
		}
		else
		{
			Tools.Log(_textInfo, "Failed to login anonymously.", result.Error);
		}
	}

	/// <summary>
	/// Called when user press anonymous login button.
	/// </summary>
	void OnLoginAnonymouslyClicked()
	{
		Tools.Log(_textInfo, "Logging you in...");
		user.LoginWithDeviceId(OnLoginWithDeviceId);
	}
	
	/// <summary>
	/// Login with email and password.
	/// </summary>
	/// <param name="result">Result of the login.</param>
	void OnLoginWithUserName(Result result)
	{
		if (!result.IsError)
		{
			Tools.Log(_textInfo, "Success!");
			SceneManager.LoadScene(SceneMainMenuName);
		}
		else
		{	
			Tools.Log(_textInfo, "Failed to login with username and password.", result.Error);
		}
	}
	
	/// <summary>
	/// Called when user press LoginWithUserName button.
	/// </summary>
	void OnLoginEmailClicked()
	{
		Tools.Log(_textInfo, "Logging you in...");
		user.LoginWithUserName(_inputFieldEmail.text, _inputFieldPassword.text, OnLoginWithUserName);
	}
}
