// Copyright (c) 2019 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using AccelByte.Api;
using UnityEngine;
using UnityEngine.SceneManagement;
using Button = UnityEngine.UI.Button;

enum SceneNames
{
	LoginPage,
	MainMenu,
	Game,
	ProfilePage,
    Entitlement,
	AccountPage
}

public class MainMenuSceneScript : MonoBehaviour
{
	/// <summary>
	/// Consist of buttons in this scene.
	/// </summary>
	class ButtonCollection
	{
		public Button Play, Profile, Entitlement, Account, Logout;
	}

	private Canvas _canvas;
	private ButtonCollection _buttons;

	/// <summary>
	/// Find components in scene and attach them to this members.
	/// </summary>
	void AssignSceneComponents()
	{
		_canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
		_buttons = new ButtonCollection()
		{
			Play = GameObject.Find("ButtonPlay").GetComponent<Button>(),
			Profile = GameObject.Find("ButtonProfile").GetComponent<Button>(),
            Entitlement = GameObject.Find("ButtonEntitlement").GetComponent<Button>(),
			Account = GameObject.Find("ButtonAccount").GetComponent<Button>(),
			Logout = GameObject.Find("ButtonLogout").GetComponent<Button>()
		};
		AssignButtonFunction();
	}

	/// <summary>
	/// Add function when this member buttons pressed.
	/// </summary>
	void AssignButtonFunction()
	{
		_buttons.Play.onClick.AddListener(OnPlayClicked);
		_buttons.Profile.onClick.AddListener(OnProfileClicked);
        _buttons.Entitlement.onClick.AddListener(OnEntitlementClicked);
		_buttons.Account.onClick.AddListener(OnAccountClicked);
		_buttons.Logout.onClick.AddListener(OnLogoutClicked);
	}
	
	/// <summary>
	/// When Play button pressed, redirect to Game scene.
	/// </summary>
	void OnPlayClicked()
	{
		SceneManager.LoadScene(SceneNames.Game.ToString());
	}

	/// <summary>
	/// When Profile button pressed, redirect to Profile scene.
	/// </summary>
	void OnProfileClicked()
	{
		SceneManager.LoadScene(SceneNames.ProfilePage.ToString());
	}

    /// <summary>
    /// When Entitlement button pressed, redirect to Entitlement scene.
    /// </summary>
    void OnEntitlementClicked()
    {
        SceneManager.LoadScene(SceneNames.Entitlement.ToString());
    }

	/// <summary>
	/// When Account button pressed, redirect to Account scene.
	/// </summary>
	void OnAccountClicked()
	{
		SceneManager.LoadScene(SceneNames.AccountPage.ToString());
	}

	/// <summary>
	/// When logout button pressed, redirect to LoginPage scene.
	/// </summary>
	void OnLogoutClicked()
	{
		User user = AccelBytePlugin.GetUser();
		user.Logout();
		SceneManager.LoadScene(SceneNames.LoginPage.ToString());
	}
	
	/// <summary>
	/// Use this for initialization
	/// </summary>
		void Start ()
	{
		AssignSceneComponents();
	}
}
