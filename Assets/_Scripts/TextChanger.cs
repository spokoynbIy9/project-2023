using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour
{
    [SerializeField] private Text _heroText;
    [SerializeField] private Text _newtonText;
    [SerializeField] private Text _note;
    [SerializeField] private List<Dialogue> _dialogues;
    [SerializeField] private UnityEvent _onDialoguesEnd;
    private int index = 0;

    public bool IsActive;

    public void ChangeHeroText(string text)
    {
        _heroText.text = text;
    }

    public void ChangeNewtonText(string text)
    {
        _newtonText.text = text;
    }

    public void SetActive()
    {
        IsActive = true;
        _note.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsActive)
        {
            _note.gameObject.SetActive(false);
            if (index < _dialogues.Count)
            {
                if (_dialogues[index].IsNewtoonText)
                {
                    ChangeNewtonText(_dialogues[index].Text);
                }
                else
                {
                    ChangeHeroText(_dialogues[index].Text);
                }
                _dialogues[index].OnShow?.Invoke();
            }
            else
            {
                _onDialoguesEnd?.Invoke();
                IsActive = false;
            }

            index++;
        }
    }
}

[Serializable]
public class Dialogue
{
    public string Text;
    public bool IsNewtoonText;
    public UnityEvent OnShow;
}
