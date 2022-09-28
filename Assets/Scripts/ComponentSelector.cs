using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComponentSelector : MonoBehaviour
{
    public ComponentBase Component
    {
        get => _component;
        set
        {
            _component = value;
            Render();
        }
    }
    public int Number
    {
        get => _number;
        set
        {
            _number = value;
            Render();
        }
    }

    private ComponentBase _component;
    private int _number;

    private Image _backgroundImage;
    private Image _componentImage;
    private TMP_Text _numberText;

    public void Render()
    {
        _componentImage.sprite = _component.Image;
        gameObject.name = _component.Name;
        _numberText.text = _number < 0 ? "" : _number.ToString();
    }

    // public void Show(bool instant = false)
    // {
    //     _backgroundImage.gameObject.LeanAlpha(1.0f, instant ? 0.0f : 0.5f).setDelay(instant ? 0.0f : 0.5f).setEaseOutBack();
    //     _componentImage.gameObject.LeanAlpha(1.0f, instant ? 0.0f : 0.5f).setEaseOutBack();
    //     _componentImage.gameObject.LeanScale(new Vector3(1.0f, 1.0f, 1.0f), instant ? 0.0f : 0.5f).setEaseOutBack();
    //     _numberText.gameObject.LeanAlpha(1.0f, instant ? 0.0f : 0.5f).setEaseOutBack();
    //     _numberText.gameObject.LeanScale(new Vector3(1.0f, 1.0f, 1.0f), instant ? 0.0f : 0.5f).setEaseOutBack();
    // }
    //
    // public void Hide(bool instant = false)
    // {
    //     _backgroundImage.gameObject.LeanAlpha(0.0f, instant ? 0.0f : 0.5f).setDelay(instant ? 0.0f : 0.5f).setEaseInBack();
    //     _componentImage.gameObject.LeanAlpha(0.0f, instant ? 0.0f : 0.5f).setEaseInBack();
    //     _componentImage.gameObject.LeanScale(new Vector3(0.9f, 0.9f, 1.0f), instant ? 0.0f : 0.5f).setEaseInBack();
    //     _numberText.gameObject.LeanAlpha(0.0f, instant ? 0.0f : 0.5f).setEaseInBack();
    //     _numberText.gameObject.LeanScale(new Vector3(0.5f, 0.5f, 1.0f), instant ? 0.0f : 0.5f).setEaseInBack();
    //     LeanTween.alp
    // }
    //
    // IEnumerator IntroCoroutine()
    // {
    //     Hide(true);
    //     yield return new WaitForSeconds(1.0f);
    //     Show();
    //     yield return new WaitForSeconds(5.0f);
    //     Hide();
    //     yield return new WaitForSeconds(5.0f);
    //     Show();
    // }
    
    public void OnEnable()
    {
        _backgroundImage = gameObject.GetComponent<Image>();
        _componentImage = Global.GetGameObjectOfNameInChildren(gameObject, "Image").GetComponent<Image>();
        _numberText = gameObject.GetComponentInChildren<TMP_Text>();
        
        // Hide(true);
        // StartCoroutine(IntroCoroutine());
    }
}
