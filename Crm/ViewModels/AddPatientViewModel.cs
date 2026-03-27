using Entities.Enums;
namespace ViewModels;

public class AddPatientViewModel : BaseAddEntityViewModel<Patient>
{
    //public Dictionary<RoleEnum, string> RolesList => TranslateRoleEnum.Roles;

    public IEnumerable<GenderEnum> GendersList => Enum.GetValues(typeof(GenderEnum)).Cast<GenderEnum>();


    /// <summary>
	/// Конструктор
	/// </summary>
	public AddPatientViewModel(IServiceProvider serviceProvider, IDialogService dialogService) : base(serviceProvider, dialogService)
    {

    }
}
