using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Xml;
namespace Crm.ViewModels.Base;

internal class BaseAllEntitiesViewModel<TEntity, TAddView> : INotifyPropertyChanged
    where TEntity : class,  new()
    where TAddView : class
{
    public bool IsBusy { get; set; }

    private ObservableCollection<TEntity>? entities;

    /// <summary>
	/// Список сущностей из БД
	/// </summary>
	public ObservableCollection<TEntity>? Entities
    {
        get => entities;
        set
        {
            entities = value;
            OnPropertyChanged();
        }
    }

    private TEntity? selectedEntity;

    /// <summary>
	/// Выбранная сущность
	/// </summary>
	public TEntity? SelectedEntity
    {
        get => selectedEntity;
        set
        {
            selectedEntity = value;
            OnPropertyChanged();
        }
    }


    /// <summary>
	/// Команда "Добавить"
	/// </summary>
	public ICommand? AddCompanyCommand { private set; get; }

    /// <summary>
    /// Команда "Обновить"
    /// </summary>
    public ICommand? RefreshCommand { private set; get; }

    /// <summary>
    /// Команда "Удалить"
    /// </summary>
    public RelayCommand? DelCommand { private set; get; }

    /// <summary>
    /// Команда "Редактировать"
    /// </summary>
    public RelayCommand? EditCommand { private set; get; }

    /// <summary>
	/// Конструктор
	/// </summary>
	/// <param name="serviceProvider"></param>
	public BaseAllEntitiesViewModel()
    {
        //настраиваем команды
        AddCompanyCommand = new RelayCommand(ShowAddEntityWindow, CheckIsPossibleShowAddEntityWindow);
        RefreshCommand = new RelayCommand(RefreshEntities);
        DelCommand = new RelayCommand(DelEntity, CheckIsPossibleDeleAddEntity);
        EditCommand = new RelayCommand(EditEntity, CheckIsPossibleEditAddEntity);

        var task = Task.Run(() => LoadNecessaryDates());
        task.Wait();
    }

    protected virtual async void ShowAddEntityWindow(object? parametr)
    {
       
    }

    protected virtual bool CheckIsPossibleShowAddEntityWindow(object? parametr)
    {
        return true;
    }

    protected virtual async void RefreshEntities(object? parametr)
    {
        await LoadNecessaryDates();
    }

    protected virtual async void DelEntity(object? parametr)
    {
       
    }

    protected virtual bool CheckIsPossibleDeleAddEntity(object? parametr)
    {
        return SelectedEntity != null;
    }

    protected virtual async void EditEntity(object? parametr)
    {
        
    }

    protected virtual bool CheckIsPossibleEditAddEntity(object? parametr)
    {
        return SelectedEntity != null;
    }

    /// <summary>
	/// Загрузка сущностей из БД
	/// </summary>
	/// <returns></returns>
	protected virtual async Task LoadNecessaryDates()
    {
        IsBusy = true;

        try
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var allEntities = db.Set<TEntity>().AsSplitQuery();
                var result = await allEntities.ToListAsync();
                if (result == null)
                    Entities = null;
                else
                    Entities = new ObservableCollection<TEntity>(result);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка: " + ex.Message
                + Environment.NewLine + " InnerException:" + ex.InnerException?.Message);
        }
        IsBusy = false;
    }

    // реализация INotifyPropertyChanged
    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
            CheckCommands();
        }
    }

    /// <summary>
	/// Проверка можно ли выполнить команды
	/// </summary>
	protected virtual void CheckCommands()
    {
        DelCommand?.RaiseCanExecuteChanged();
        EditCommand?.RaiseCanExecuteChanged();
    }
}
