namespace Entities;

/// <summary>
/// Класс для хранения данных фильтров
/// </summary>
public class FilterData : BaseNotifyPropertyChanged
{
    /// <summary>
    /// От даты
    /// </summary>
    public DateTime? DateFrom
    {
        get => dateFrom;
        set
        {
            dateFrom = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsAnySelected));
        }
    }
    private DateTime? dateFrom;

    /// <summary>
    /// До даты
    /// </summary>
    public DateTime? DateTo
    {
        get => dateTo;
        set
        {
            dateTo = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsAnySelected));
        }
    }
    private DateTime? dateTo;

    /// <summary>
    /// Номер договора
    /// </summary>
    public string? ContractNumber
    {
        get => contractNumber;
        set
        {
            contractNumber = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsAnySelected));
        }
    }
    private string? contractNumber;

    /// <summary>
    /// Статус оплаты
    /// </summary>
    public PaymentStatusEnum? PaymentStatus
    {
        get => paymentStatus;
        set
        {
            paymentStatus = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsAnySelected));
        }
    }
    private PaymentStatusEnum? paymentStatus;

    /// <summary>
    /// Статус договора
    /// </summary>
    public ContractStatusEnum? ContractStatus
    {
        get => contractStatus;
        set
        {
            contractStatus = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsAnySelected));
        }
    }
    private ContractStatusEnum? contractStatus;

    /// <summary>
    /// Id ответственного
    /// </summary>
    public int? EmployeeId
    {
        get => employeeId;
        set
        {
            employeeId = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsAnySelected));
        }
    }
    private int? employeeId;

    /// <summary>
    /// Флаг показывает что есть введённые фильтры
    /// </summary>
    public bool IsAnySelected => (DateFrom != null
            || DateTo != null
            || ContractNumber != null
            || PaymentStatus != null
            || ContractStatus != null
            || EmployeeId != null) ? true : false;

    /// <summary>
    /// Условие Фильтрации
    /// </summary>
    public System.Linq.Expressions.Expression<Func<Contract, bool>>? GetFilter()
    {
        if (!IsAnySelected)
            return null;

        System.Linq.Expressions.Expression<Func<Contract, bool>> func = x =>
        (DateFrom.HasValue ? x.ContractDate >= DateFrom.Value : true)
        && (DateTo.HasValue ? x.ContractDate <= DateTo.Value : true)
        && (!string.IsNullOrEmpty(ContractNumber) ? x.ContractNumber.Contains(ContractNumber) : true)
        && (PaymentStatus != null ? x.PaymentStatus == PaymentStatus : true)
        && (ContractStatus != null ? x.ContractStatus == ContractStatus : true)
        && (EmployeeId != null ? x.EmployeeId == EmployeeId : true);

        return func;
    }
}