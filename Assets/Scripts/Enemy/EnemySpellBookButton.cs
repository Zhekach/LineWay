using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

public class EnemySpellBookButton : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Progress _progressController;
    [SerializeField] private EnemySpellBook _spellBook;
    [SerializeField] private EnemyType _enemyType;
    [SerializeField] private TMP_Text _textCounter;

    [FormerlySerializedAs("_isPressed")] [SerializeField] private bool _isActivated;

    private Camera _cameraMain;
    private int _chargesPerLevel = 2;

    private const string MultiplierChar = "x";

    private void Start()
    {
        _textCounter.text = MultiplierChar + _progressController.GetEnemySpellBookCount(_enemyType);
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
        if (_progressController.GetEnemySpellBookCount(_enemyType) > 0 && _chargesPerLevel > 0)
        {
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
}