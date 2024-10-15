using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

public class PlayerShieldBookButton : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Progress _progressController;
    [SerializeField] private PlayerShieldBook _spellBook;
    [SerializeField] private TMP_Text _textCounter;
    [SerializeField] private Button _button;

    [SerializeField] private bool _isActivated;

    private Camera _cameraMain;
    private int _chargesPerLevel = 1;

    private const string MultiplierChar = "x";

    private void Start()
    {
        UpdateInfo();
        _cameraMain = Camera.main;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (TryActivateSpellBook())
        {
            _isActivated = true;
            _spellBook.gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        if (!_isActivated) return;
        
        MoveSpellBook();

        if (Input.GetMouseButtonUp(0))
        {
            UseSpellBook();
        }
    }

    private bool TryActivateSpellBook()
    {
        if (_progressController.GetPlayerShieldBookCount() > 0 && _chargesPerLevel > 0)
        {
            _chargesPerLevel--;
            _progressController.UpdatePlayerShieldBookCount(-1);
            UpdateInfo();
            return true;
        }

        return false;
    }

    private void MoveSpellBook()
    {
        Vector3 spritePosition =
            _cameraMain.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        spritePosition.z = 0;
        _spellBook.gameObject.SetActive(true);
        _spellBook.transform.position = spritePosition;
    }

    private void UseSpellBook()
    {
        _isActivated = false;
        _spellBook.IsActivated = true;
    }

    private void UpdateInfo()
    {
        _textCounter.text = MultiplierChar + _progressController.GetPlayerShieldBookCount();

        if (_chargesPerLevel <= 0 || _progressController.GetPlayerShieldBookCount() <= 0)
        {
            _button.interactable = false;
        }
    }
}