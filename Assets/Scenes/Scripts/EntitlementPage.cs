// Copyright (c) 2019 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EntitlementPage : MonoBehaviour {

    private Button _buttonBack;
    public Image prefab;

    /// <summary>
    /// Find components in scene and attach them to this members.
    /// </summary>
    private void AssignComponentScene()
    {
        _buttonBack = GameObject.Find("ButtonBack").GetComponent<Button>();
        AssignButtonFunction();
    }

    /// <summary>
    /// Add function when this member buttons pressed.
    /// </summary>
    private void AssignButtonFunction()
    {
        _buttonBack.onClick.AddListener(() => SceneManager.LoadScene(SceneNames.MainMenu.ToString()));
    }

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        AssignComponentScene();
    }
}
