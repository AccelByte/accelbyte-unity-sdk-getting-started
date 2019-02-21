// Copyright (c) 2019 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using AccelByte.Api;
using AccelByte.Core;
using AccelByte.Models;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using WebSocketSharp;
using Tools = SceneUtilities;

public class AccountPageSceneScript : MonoBehaviour
{
	/// <summary>
	/// Consist of input fields in this scene.
	/// </summary>
	class InputFieldCollection
	{
		public InputField Email, Password, UserId;
	}
	
	/// <summary>
	/// Consist of buttons in this scene.
	/// </summary>
	class ButtonCollection
	{
		public Button Back, Add;
	}

	private User user;
	private ButtonCollection _buttons;
	private InputFieldCollection _inputFields;
	private Text _textInfo;

	/// <summary>
	/// Find components in scene and attach them to this members.
	/// </summary>
	void AssignSceneComponents()
	{
		_buttons = new ButtonCollection()
		{
			Back = GameObject.Find("ButtonBack").GetComponent<Button>(),
			Add = GameObject.Find("ButtonAdd").GetComponent<Button>()
		};
		_inputFields = new InputFieldCollection()
		{
			Email = GameObject.Find("InputFieldEmail").GetComponent<InputField>(),
			Password = GameObject.Find("InputFieldPassword").GetComponent<InputField>(),
			UserId = GameObject.Find("InputFieldUserId").GetComponent<InputField>()
		};
		_inputFields.UserId.text = user.UserId;
		_inputFields.UserId.interactable = false;
		_textInfo = GameObject.Find("TextInfo").GetComponent<Text>();
		AssignButtonFunction();
	}
	
	/// <summary>
	/// Add function when this member buttons pressed.
	/// </summary>
	void AssignButtonFunction()
	{
		_buttons.Back.onClick.AddListener(() => { SceneManager.LoadScene(SceneNames.MainMenu.ToString());});
		_buttons.Add.onClick.AddListener(OnAddEmailClicked);
	}

	/// <summary>
	/// Get player's data response.
	/// </summary>
	/// <param name="result">Get player's data result.</param>
	void OnGetUserData(Result<UserData> result)
	{
		if (!result.IsError)
		{
			Tools.Log(_textInfo, "Success get user data.");
			_inputFields.Email.text = result.Value.EmailAddress;
			if (result.Value.EmailAddress.IsNullOrEmpty())
			{
				ShowUpgradeComponent();
			}
			else
			{
				HideUpgradeComponent();
			}	
		}
		else
		{
			Tools.Log(_textInfo, "Failed to get user data.", result.Error);
		}
	}

	/// <summary>
	/// Called when user's account is not a full account (account with email), then show interfaces to upgrade.
	/// </summary>
	void ShowUpgradeComponent()
	{
		_buttons.Add.gameObject.SetActive(true);
		_inputFields.Password.interactable = true;
		_inputFields.Password.text = "";
		_inputFields.Email.interactable = true;
		_inputFields.Email.text = "";
	}

	/// <summary>
	/// Called when user's account is already a full account (account with email), then hide interfaces to upgrade.
	/// </summary>
	void HideUpgradeComponent()
	{
		_buttons.Add.gameObject.SetActive(false);
		_inputFields.Password.text = "*************";
		_inputFields.Password.interactable = false;
		_inputFields.Email.interactable = false;
	}
	
	/// <summary>
	/// Account upgrade response.
	/// </summary>
	/// <param name="result">Result of the account upgrade action.</param>
	void OnAccountUpgraded(Result<UserData> result)
	{
		if (!result.IsError)
		{
			Tools.Log(_textInfo, "Success upgrade account with email.");
			user.GetData(OnGetUserData);
		}
		else
		{
			Tools.Log(_textInfo, "Failed to upgrade account with email.", result.Error);
		}
	}

	/// <summary>
	/// When add email button clicked then upgrade email account.
	/// </summary>
	public void OnAddEmailClicked()
	{
		Tools.Log(_textInfo, "Upgrading your email...");
		user.Upgrade(_inputFields.Email.text, _inputFields.Password.text, OnAccountUpgraded);
	}

	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start ()
	{
		user = AccelBytePlugin.GetUser();
		AssignSceneComponents();
		user.GetData(OnGetUserData);
	}
}
