using System;
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;

public class Patient : INotifyPropertyChanged
{
    private int _id;
    private string _name = "";
    private string _lastName = "";
    private string _middleName = "";
    private DateTime? _birthday;
    private DateTime? _lastAppointment;
    private int _lastDoctor;
    private string _diagnosis = "";
    private string _recomendations = "";

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

    public DateTime? Birthday
    {
        get => _birthday;
        set
        {
            if (_birthday != value)
            {
                _birthday = value;
                OnPropertyChanged();
            }
        }
    }

    public DateTime? LastAppointment
    {
        get => _lastAppointment;
        set
        {
            if (_lastAppointment != value)
            {
                _lastAppointment = value;
                OnPropertyChanged();
            }
        }
    }

    public int LastDoctor
    {
        get => _lastDoctor;
        set
        {
            if (_lastDoctor != value)
            {
                _lastDoctor = value;
                OnPropertyChanged();
            }
        }
    }

    public string Diagnosis
    {
        get => _diagnosis;
        set
        {
            if (_diagnosis != value)
            {
                _diagnosis = value;
                OnPropertyChanged();
            }
        }
    }

    public string Recomendations
    {
        get => _recomendations;
        set
        {
            if (_recomendations != value)
            {
                _recomendations = value;
                OnPropertyChanged();
            }
        }
    }

    public string FullName => $"{LastName} {Name} {MiddleName}".Trim();

    public int PatientID()
    {
        Random random = new Random();
        return random.Next(1000000, 9999999);
    }

    public void SaveToFile()
    {
        string json = JsonSerializer.Serialize(this);
        File.WriteAllText($"P_{Id}.json", json);
    }

    public Patient LoadFromFIle(int id)
    {
        string path = $"P_{id}.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<Patient>(json);
        }
        return null;
    }
}