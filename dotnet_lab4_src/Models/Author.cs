using AudioLibrary.Utilities;
using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace AudioLibrary.Models;

public class Author : NotifyPropertyChanged
{
    struct AuthorData 
    {
        internal int id;
        internal string name;
        internal int year;
    }

    private AuthorData currentData;
    private AuthorData backupData;

    public int Id
    {
        get => currentData.id;
        set
        {
            currentData.id = value;
            OnPropertyChanged(nameof(Id));
        }
    }

    public string Name
    {
        get => currentData.name;
        set
        {
            currentData.name = value;
            OnPropertyChanged(nameof(Name));
        }
    }

    public int Year
    {
        get => currentData.year;
        set
        {
            if(value < 0 || value > DateTime.Today.Year) throw new ArgumentOutOfRangeException(nameof(Year));
            if (value == currentData.year) return;
            currentData.year = value;
            OnPropertyChanged(nameof(Year));
        }
    }

    [JsonConstructor]
    public Author() { }

    public Author(int id, string name, int year)
    {
        currentData = new AuthorData();
        Id = id;
        Name = name;
        Year = year;
    }

    public override string ToString()
    {
        return $"{Name},{Year}";
    }

    private bool _editInProcess;
    public void BeginEdit()
    {
        if (!_editInProcess)
        {
            backupData = currentData;
            _editInProcess = true;
        }
    }

    public void CancelEdit()
    {
        if (_editInProcess)
        {
            currentData = backupData;
            _editInProcess = false;
        }
    }

    public void EndEdit()
    {
        if (_editInProcess)
        {
            backupData = new AuthorData();
            _editInProcess = false;
        }
    }
}
