using Entities.Enums;
namespace ViewModels;

public class AddPatientViewModel : BaseAddEntityViewModel<Patient>
{
    public Dictionary<RoleEnum, string> RolesList => TranslateRoleEnum.Roles;

    public IEnumerable<GenderEnum> GendersList => Enum.GetValues(typeof(GenderEnum)).Cast<GenderEnum>();


    /// <summary>
	/// Конструктор
	/// </summary>
	/// <param name="serviceProvider"></param>
	public AddPatientViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {

    }
}
