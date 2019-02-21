// Copyright (c) 2019 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AccelByte.Api;
using AccelByte.Core;
using AccelByte.Models;
using Image = UnityEngine.UI.Image;
using System;
using Tools = SceneUtilities;

public class EntitlementList : MonoBehaviour {
    public GameObject prefab;
    private User user;
    private List<PagedEntitlements> entitlementList;
    private Entitlements entitlements;
    private Text _textInfo;
    private ScrollRect _scrollView;
    private Button _prev;
    private Button _next;
    private int pageNow;
    private int pageSize;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start () {
        AssignSceneComponents();
        user = AccelBytePlugin.GetUser();
        entitlements = AccelBytePlugin.GetEntitlements();
        entitlementList = new List<PagedEntitlements>();
        pageNow = 0;
        pageSize = 18;
        entitlements.GetUserEntitlements(pageNow, pageSize, OnGetUserEntitlements);
	}

    /// <summary>
    /// Find components in scene and attach them to this members.
    /// </summary>
    private void AssignSceneComponents()
    {
        _textInfo = GameObject.Find("TextInfo").GetComponent<Text>();
        _scrollView = FindObjectOfType<ScrollRect>();
        _prev = GameObject.Find("Prev").GetComponent<Button>();
        _next = GameObject.Find("Next").GetComponent<Button>();
        _prev.gameObject.SetActive(false);
        _next.gameObject.SetActive(false);
        AssignButtonFunction();
    }

    private void AssignButtonFunction()
    {
        _prev.onClick.AddListener(setPrevView);
        _next.onClick.AddListener(setNextView);
    }

    private void setNextView()
    {
        resetScrollView();
        generateEntitlement(++pageNow);
    }

    private void setPrevView()
    {
        resetScrollView();
        generateEntitlement(--pageNow);
    }

    /// <summary>
    /// Get user entitlements response
    /// </summary>
    /// <param name="result"></param>
    private void OnGetUserEntitlements(Result<PagedEntitlements> result)
    {
        if (!result.IsError)
        {
            Tools.Log(_textInfo, "Success getting user entitlements");
            entitlementList.Add(result.Value);
            generateEntitlement(pageNow);
            if(result.Value.paging.next != null)
            {
                entitlements.GetUserEntitlements(entitlementList.Count, pageSize, OnGetUserEntitlements);
            }
        }
        else
        {
            Tools.Log(_textInfo, "Failed to get user entitlements.", result.Error);
        }
    }

    /// <summary>
    /// Attaching an image to an entitlement
    /// </summary>
    /// <param name="bkgImage"></param>
    /// <param name="url"></param>
    /// <returns></returns>
    IEnumerator attachImage(GameObject bkgImage, string url)
    {
        WWW www = new WWW(url);
        yield return www;
        bkgImage.GetComponent<Image>().overrideSprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
    }

    /// <summary>
    /// generate entitlements to GUI
    /// </summary>
    /// <param name="page"></param>
    private void generateEntitlement(int page)
    {
        GameObject newObj;
        foreach (Entitlement entitlement in entitlementList[page].data)
        {
                newObj = (GameObject)Instantiate(prefab, transform);
                newObj.GetComponentInChildren<Image>().GetComponentsInChildren<Text>()[0].text = entitlement.name;
                newObj.GetComponentInChildren<Image>().GetComponentsInChildren<Text>()[1].text += entitlement.quantity;
                if (entitlement.itemSnapshot != null)
                    StartCoroutine(attachImage(newObj, entitlement.itemSnapshot.thumbnailImage.imageUrl));
        }
        if (entitlementList[page].paging.next != null)
            _next.gameObject.SetActive(true);
        else
            _next.gameObject.SetActive(false);
        if (entitlementList[page].paging.previous != null)
            _prev.gameObject.SetActive(true);
        else
            _prev.gameObject.SetActive(false);
    }

    /// <summary>
    /// clean entitlement from scrollview
    /// </summary>
    private void resetScrollView()
    {
        foreach (Transform child in _scrollView.content.transform)
        {
            Destroy(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
