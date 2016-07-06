# WPFF

[![license](https://img.shields.io/packagist/l/doctrine/orm.svg?maxAge=2592000)](https://raw.githubusercontent.com/IASamoylov/WPFF/master/LICENSE) [![nuget](https://img.shields.io/badge/nuget-v1.0.0-blue.svg )](https://www.nuget.org/packages/WPFF/1.0.0) 

###what is it?
This implementation is designed for its own needs, its features is the ability to specify the command key and modifier keys.

##Sample

[link](https://github.com/IASamoylov/WPFF/tree/master/Sample)

Example of marking
```xaml
<Window x:Class="Sample.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:Sample"
        mc:Ignorable="d"
        Title="MainWindow" Height="350" Width="525">
  <Window.InputBindings>
    <KeyBinding Command="{Binding NewCommand}" Key="{Binding NewCommand.Key}" Modifiers="{Binding NewCommand.Modifier}"></KeyBinding>
    <KeyBinding Command="{Binding OpenCommand}" Key="{Binding OpenCommand.Key}" Modifiers="{Binding OpenCommand.Modifier}"></KeyBinding>
    <KeyBinding Command="{Binding SaveCommand}" Key="{Binding SaveCommand.Key}" Modifiers="{Binding SaveCommand.Modifier}"></KeyBinding>
    <KeyBinding Command="{Binding SaveAsCommand}" Key="{Binding SaveAsCommand.Key}" Modifiers="{Binding SaveAsCommand.Modifier}"></KeyBinding>
    <KeyBinding Command="{Binding StartCommand}" Key="{Binding StartCommand.Key}" Modifiers="{Binding StartCommand.Modifier}"></KeyBinding>
  </Window.InputBindings>
  <StackPanel>
    <Menu>
      <MenuItem Header="File">
        <MenuItem Header="New" Command="{Binding NewCommand}" InputGestureText="{Binding NewCommand.GestureText}"></MenuItem>
        <MenuItem Header="Open" Command="{Binding OpenCommand}" InputGestureText="{Binding OpenCommand.GestureText}"></MenuItem>
        <MenuItem Header="Save" Command="{Binding SaveCommand}" InputGestureText="{Binding SaveCommand.GestureText}"></MenuItem>
        <MenuItem Header="Save as..." Command="{Binding SaveAsCommand}" InputGestureText="{Binding SaveAsCommand.GestureText}"></MenuItem>
        <Separator></Separator>
        <MenuItem Header="Exit" Command="{Binding ExitCommand}"></MenuItem>
      </MenuItem>
    </Menu>
    <TextBox Margin="10 5" Height="30" Text="{Binding Text, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"></TextBox>
    <Button Margin="10 5" Height="30" Content="Start" Command="{Binding StartCommand}"></Button>
  </StackPanel>
</Window>
```
Example of code
```C#
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
```

![Sample img](http://s8.hostingkartinok.com/uploads/images/2016/07/c716b9e9cdf2e958db355986c2d1cecd.jpg)
