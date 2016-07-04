using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace WPFF
{
  public class UICommand : ICommand
  {
    private readonly static Dictionary<ModifierKeys, string> _modifiersKeys =
      new Dictionary<ModifierKeys, string>()
      {
        {ModifierKeys.None,""},
        {ModifierKeys.Control,"Ctrl+"},
        {ModifierKeys.Shift,"Shift+"},
        {ModifierKeys.Alt,"Alt+"},
        {ModifierKeys.Control|ModifierKeys.Shift,"Ctrl+Shift+"},
        {ModifierKeys.Control|ModifierKeys.Alt,"Ctrl+Alt+"},
        {ModifierKeys.Control|ModifierKeys.Shift|ModifierKeys.Alt,"Ctrl+Shift+Alt+"},
        {ModifierKeys.Windows,"Win+"}
      };

    private readonly Action _execute;
    private readonly Func<bool> _canExecute;
    private readonly Key _key;
    private readonly ModifierKeys _modifier;

    public Key Key => _key;
    public ModifierKeys Modifier => _modifier;

    public string GestureText
    {
      get
      {
        return _key == Key.None ? string.Empty : $"{_modifiersKeys[_modifier]}{_key}";
      }
    }

    private event EventHandler CanExecuteChangedInternal;

    public UICommand(Action execute)
    {
      if (execute == null)
        throw new ArgumentNullException(nameof(execute));

      _execute = execute;
      _canExecute = () => true;
    }

    public UICommand(Action execute, Func<bool> canExecute)
    {
      if (execute == null)
        throw new ArgumentNullException(nameof(execute));

      if (canExecute == null)
        throw new ArgumentNullException(nameof(canExecute));

      _execute = execute;
      _canExecute = canExecute;
    }

    public event EventHandler CanExecuteChanged;

    public bool CanExecute(object parameter)
    {
      return _canExecute();
    }

    public void Execute(object parameter)
    {
      _execute();
    }
  }
}
