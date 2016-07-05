using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace WPFF
{
  public class UICommand : ICommand
  {
    private static readonly Dictionary<ModifierKeys, string> ModifiersKeys =
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

    private readonly Action<object> _execute;
    private readonly Func<object, bool> _canExecute = (parameter) => true;

    public UICommand(Action execute) : this(execute, Key.None)
    {
    }
    public UICommand(Action execute, Key key) : this(execute, key, ModifierKeys.None)
    {
    }
    public UICommand(Action execute, Key key, ModifierKeys modifierKeys) : this(execute, null, key, modifierKeys)
    {
    }
    public UICommand(Action execute, Func<bool> canExecute): this(execute, canExecute, Key.None, ModifierKeys.None)
    {
    }
    public UICommand(Action execute, Func<bool> canExecute, Key key, ModifierKeys modifierKeys) 
    {
      if (execute == null)
        throw new ArgumentNullException(nameof(execute));

      _execute = (parameter) => execute();

      if (canExecute != null)
        _canExecute = (parameter) => canExecute();

      Key = key;
      Modifier = modifierKeys;
    }
  
    public UICommand(Action<object> execute) : this(execute, Key.None)
    {
    }
    public UICommand(Action<object> execute, Key key) : this(execute, key, ModifierKeys.None)
    {
    }
    public UICommand(Action<object> execute, Key key, ModifierKeys modifierKeys) : this(execute, null, key, modifierKeys)
    {
    }
    public UICommand(Action<object> execute, Func<object, bool> canExecute) : this(execute, canExecute, Key.None, ModifierKeys.None)
    {
    }
    public UICommand(Action<object> execute, Func<object, bool> canExecute, Key key, ModifierKeys modifierKeys)
    {
      if (execute == null)
        throw new ArgumentNullException(nameof(execute));

      _execute = execute;

      if (canExecute != null)
        _canExecute = canExecute;

      Key = key;
      Modifier = modifierKeys;
    }
 

    public event EventHandler CanExecuteChanged
    {
      add
      {
        CommandManager.RequerySuggested += value;
      }

      remove
      {
        CommandManager.RequerySuggested -= value;
      }
    }

    public Key Key { get; }

    public ModifierKeys Modifier { get; }

    public string GestureText
    {
      get
      {
        return Key == Key.None ? string.Empty : $"{ModifiersKeys[Modifier]}{Key}";
      }
    }

    public bool CanExecute(object parameter)
    {
      return _canExecute(parameter);
    }

    public void Execute(object parameter)
    {
      _execute(parameter);
    }
  }
}
