// Copyright (c) 2019 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using System.Collections;
using AccelByte.Api;
using AccelByte.Core;
using AccelByte.Models;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using WebSocketSharp;
using Image = UnityEngine.UI.Image;
using Tools = SceneUtilities;

public class ProfilePageSceneScript : MonoBehaviour
{
	private InputFieldCollection _inputFields;
	private Image _imageAvatar;
	private Button _buttonSave;
	private Button _buttonBack;
	private Text _textInfo;
	UserProfiles userProfiles;

	/// <summary>
	/// Consist of input fields in this scene.
	/// </summary>
	private class InputFieldCollection
	{
		public InputField firstName, lastName, dateOfBirth, timeZone, language, avatarUrl;
	}
	
	/// <summary>
	/// Find components in scene and attach them to this members.
	/// </summary>
	private void AssignSceneComponents()
	{
		_inputFields = new InputFieldCollection
		{
			firstName = GameObject.Find("InputFieldFirstName").GetComponent<InputField>(),
			lastName = GameObject.Find("InputFieldLastName").GetComponent<InputField>(),
			dateOfBirth = GameObject.Find("InputFieldDOB").GetComponent<InputField>(),
			timeZone = GameObject.Find("InputFieldTimeZone").GetComponent<InputField>(),
			language = GameObject.Find("InputFieldLanguage").GetComponent<InputField>(),
			avatarUrl = GameObject.Find("InputFieldAvatarUrl").GetComponent<InputField>()
		};
		_imageAvatar = GameObject.Find("ImageAvatar").GetComponent<Image>();
		_textInfo = GameObject.Find("TextInfo").GetComponent<Text>();
		_buttonSave = GameObject.Find("ButtonSave").GetComponent<Button>();
		_buttonBack = GameObject.Find("ButtonBack").GetComponent<Button>();
		AssignButtonFunction();
	}

	/// <summary>
	/// Add function when this member buttons pressed.
	/// </summary>
	private void AssignButtonFunction()
	{
		_buttonSave.onClick.AddListener(OnButtonSaveClicked);
		_buttonBack.onClick.AddListener(() => { SceneManager.LoadScene(SceneNames.MainMenu.ToString());});		
	}

	/// <summary>
	/// Update user profile response.
	/// </summary>
	/// <param name="result">Result of update user profile.</param>
	private void OnUpdateUserProfile(Result<UserProfile> result)
	{
		if (result.IsError)
		{
			Tools.Log(_textInfo, "Failed to update user profile.", result.Error);
		}
		else
		{
			Tools.Log(_textInfo, "Success update your profile.");
			AssignUserProfileToUI(result.Value);
		}
	}

	/// <summary>
	/// When button save clicked.
	/// </summary>
	private void OnButtonSaveClicked()
	{
		UpdateUserProfileRequest request = GetUserProfileRequestFromUI();
		userProfiles.UpdateUserProfile(request, OnUpdateUserProfile);
	}

	/// <summary>
	/// Get user profile response
	/// </summary>
	/// <param name="result">Result of get user profile.</param>
	private void OnGetUserProfile(Result<UserProfile> result)
	{
		if (result.IsError)
		{
			if (result.Error.Code != ErrorCode.UserProfileNotFound)
			{	
				Tools.Log(_textInfo, "Failed to get user profile.", result.Error);
			}
			// IF user doesn't have any profile, we'll create a default empty user profile
			// so the user can update it any time
			else
			{
				Tools.Log(_textInfo, "Default user profile created.");
				CreateUserProfileRequest userProfileRequest = new CreateUserProfileRequest {language = ""};
				userProfiles.CreateUserProfile(userProfileRequest, createResult => { });
			}
		}
		else
		{
			Tools.Log(_textInfo, "User profile obtained.");
			AssignUserProfileToUI(result.Value);	
		}
	}
	
	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start ()
	{
		AssignSceneComponents();
		userProfiles = AccelBytePlugin.GetUserProfiles();
		userProfiles.GetUserProfile(OnGetUserProfile);
	}

	/// <summary>
	/// Assign user profile fields to the UI that consists of input fields.
	/// </summary>
	/// <param name="profile">User profile that will be shown to the UI.</param>
	void AssignUserProfileToUI(UserProfile profile)
	{
		_inputFields.firstName.text = profile.firstName;
		_inputFields.lastName.text = profile.lastName;
		_inputFields.language.text = profile.language;
		_inputFields.timeZone.text = profile.timeZone;
		_inputFields.dateOfBirth.text = profile.dateOfBirth;
		_inputFields.avatarUrl.text = profile.avatarUrl;
		StartCoroutine(LoadAvatar(profile.avatarUrl));
	}

	/// <summary>
	/// Obtain user profile information from the user interface.
	/// </summary>
	/// <returns> User profile request from user interfaces.</returns>
	UpdateUserProfileRequest GetUserProfileRequestFromUI()
	{
		UpdateUserProfileRequest request = new UpdateUserProfileRequest
		{
			firstName = _inputFields.firstName.text,
			lastName = _inputFields.lastName.text,
			dateOfBirth = _inputFields.dateOfBirth.text,
			timeZone = _inputFields.timeZone.text,
			language = _inputFields.language.text,
			avatarUrl = _inputFields.avatarUrl.text
		};
		return request;
	}
	
	/// <summary>
	/// Download avatar from the URL and show it to the image component.
	/// </summary>
	/// <param name="Url">Link of the image.</param>
	/// <returns></returns>
	private IEnumerator LoadAvatar(string Url)
	{
		if (Url.IsNullOrEmpty())
		{
			yield return null;
		}
		
		WWW www = new WWW(Url);
		yield return www;
		_imageAvatar.overrideSprite = Sprite.Create
		(www.texture, 
			new Rect(0, 0, www.texture.width, www.texture.height), 
			new Vector2(0, 0));
	}
}
