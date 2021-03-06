﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardController : SpriteController {
    public event Action OnClick;
    public Vector3 PinPos;
    public Vector2 DetailOffset;

    public GameObject DetailsPrefab;
    private GameObject _detail;

    public LocationType BelongingLocation;

    protected override void Awake() {
        base.Awake();
//        CreateDetails();
    }

    private void Update() {
        var shouldDisplay = StatusManager.Instance.Location == BelongingLocation;
        gameObject.GetComponent<Image>().enabled = shouldDisplay;
        gameObject.GetComponent<Button>().enabled = shouldDisplay;
        gameObject.GetComponentInChildren<TextMeshProUGUI>().enabled = shouldDisplay;
    }

    public void HandleClick() {
        OnClick?.Invoke();
    }

    private void CreateDetails() {
        _detail = Instantiate(DetailsPrefab, transform.parent, false);
        _detail.GetComponent<RectTransform>().sizeDelta = DetailOffset;
    }

//    public void MouseOver() {
//        if (_detail == null) {
//            CreateDetails();
//        }
//
//        _detail.transform.localPosition = DetailOffset;
//        _detail.GetComponent<SpriteController>().FadeIn();
//    }
//
//    private void MouseExit() {
//        _detail.GetComponent<SpriteController>().FadeOut();
//    }
}