using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Sample.Annotations;
using WPFF;

namespace Sample
{
  public class MainViewModel
  {
    private ICommand _saveCommand;
    private ICommand _saveOpenCommand;
    private ICommand _saveAsCommand;
    private ICommand _newCommand;
    private ICommand _exitCommand;
    private ICommand _startCommand;

    public ICommand SaveCommand
    {
      get { return _saveCommand ?? (_saveCommand = new UICommand(() => { }, ()=> !string.IsNullOrEmpty(Text), Key.S, ModifierKeys.Control)); }
    }

    public ICommand SaveOpenCommand
    {
      get { return _saveOpenCommand ?? (_saveOpenCommand = new UICommand(() => { }, Key.O, ModifierKeys.Control)); }
    }

    public ICommand SaveAsCommand
    {
      get { return _saveAsCommand ?? (_saveAsCommand = new UICommand(() => { }, () => !string.IsNullOrEmpty(Text), Key.S, ModifierKeys.Control | ModifierKeys.Alt)); }
    }

    public ICommand NewCommand
    {
      get { return _newCommand ?? (_newCommand = new UICommand(() => { }, Key.N)); }
    }

    public ICommand ExitCommand
    {
      get { return _exitCommand ?? (_exitCommand = new UICommand(() => { })); }
    }

    public ICommand StartCommand
    {
      get { return _startCommand ?? (_startCommand = new UICommand(() => { }, () => !string.IsNullOrEmpty(Text), Key.S, ModifierKeys.Control)); }
    }

    public string Text { get; set; }
  }
}
