using System;
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;

public class Doctor : INotifyPropertyChanged
{
    private int _id;
    private string _name = "";
    private string _lastName = "";
    private string _middleName = "";
    private string _specialisation = "";
    private string _password = "";

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? propName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }

    public int Id
    {
        get => _id;
        set
        {
            if (_id != value)
            {
                _id = value;
                OnPropertyChanged();
            }
        }
    }

    public string Name
    {
        get => _name;
        set
        {
            if (_name != value)
            {
                _name = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            }
        }
    }

    public string LastName
    {
        get => _lastName;
        set
        {
            if (_lastName != value)
            {
                _lastName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            }
        }
    }

    public string MiddleName
    {
        get => _middleName;
        set
        {
            if (_middleName != value)
            {
                _middleName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            }
        }
    }

    public string Specialisation
    {
        get => _specialisation;
        set
        {
            if (_specialisation != value)
            {
                _specialisation = value;
                OnPropertyChanged();
            }
        }
    }

    public string Password
    {
        get => _password;
        set
        {
            if (_password != value)
            {
                _password = value;
                OnPropertyChanged();
            }
        }
    }

    public string FullName => $"{LastName} {Name} {MiddleName}".Trim();

    public int DoctorID()
    {
        Random random = new Random();
        return random.Next(10000, 100000);
    }

    public void SaveToFile()
    {
        string json = JsonSerializer.Serialize(this);
        File.WriteAllText($"D_{Id}.json", json);
    }

    public Doctor LoadFromFIle(int id)
    {
        string path = $"D_{id}.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<Doctor>(json);
        }
        return null;
    }
}