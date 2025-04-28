public interface IEditableObject
{
    bool CanBeEdited();

    void OnPropertyChanged(string propertyName);
}