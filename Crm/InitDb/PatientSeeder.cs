using Entities.Enums;

namespace InitDb;

/// <summary>
/// Отдельный класс для создания 20 экземпляров Patient с конкретными данными
/// </summary>
public static class PatientSeeder
{
    /// <summary>
    /// Возвращает список из 20 пациентов с заранее определёнными данными.
    /// </summary>
    public static List<Patient> GetSamplePatients()
    {
        var patients = new List<Patient>();

        // Добавляем 20 пациентов, передавая данные непосредственно в конструктор
        patients.Add(new Patient(
            lastName: "Иванов",
            firstName: "Иван",
            middleName: "Иванович",
            birthDate: new DateTime(1980, 5, 15),
            gender: GenderEnum.мужской,
            phoneNumber: "+7 (123) 456-78-90",
            email: "ivanov@example.com",
            address: "г. Москва, ул. Ленина, д. 1, кв. 1",
            passportSeries: "4510",
            passportNumber: "123456",
            passportIssueDate: new DateTime(2000, 6, 20),
            passportIssuingAuthority: "ОВД г. Москвы"
        ));

        patients.Add(new Patient(
            
            lastName: "Петрова",
            firstName: "Мария",
            middleName: "Сергеевна",
            birthDate: new DateTime(1992, 8, 23),
            gender: GenderEnum.женский,
            phoneNumber: "+7 (987) 654-32-10",
            email: "petrova@example.com",
            address: "г. Санкт-Петербург, пр. Невский, д. 10, кв. 5",
            passportSeries: "4511",
            passportNumber: "789012",
            passportIssueDate: new DateTime(2010, 9, 10),
            passportIssuingAuthority: "УФМС г. Санкт-Петербурга"
        ));

        patients.Add(new Patient(
            
            lastName: "Сидоров",
            firstName: "Петр",
            middleName: "Алексеевич",
            birthDate: new DateTime(1975, 12, 1),
            gender: GenderEnum.мужской,
            phoneNumber: "+7 (111) 222-33-44",
            email: "sidorov@example.com",
            address: "г. Екатеринбург, ул. Мира, д. 15, кв. 7",
            passportSeries: "4512",
            passportNumber: "345678",
            passportIssueDate: new DateTime(1995, 3, 25),
            passportIssuingAuthority: "ОВД г. Екатеринбурга"
        ));

        patients.Add(new Patient(
            
            lastName: "Кузнецова",
            firstName: "Анна",
            middleName: "Владимировна",
            birthDate: new DateTime(1988, 2, 14),
            gender: GenderEnum.женский,
            phoneNumber: "+7 (222) 333-44-55",
            email: "kuznetsova@example.com",
            address: "г. Новосибирск, ул. Советская, д. 5, кв. 12",
            passportSeries: "4513",
            passportNumber: "567890",
            passportIssueDate: new DateTime(2005, 7, 5),
            passportIssuingAuthority: "УФМС г. Новосибирска"
        ));

        patients.Add(new Patient(
            
            lastName: "Смирнов",
            firstName: "Дмитрий",
            middleName: "Николаевич",
            birthDate: new DateTime(1983, 11, 30),
            gender: GenderEnum.мужской,
            phoneNumber: "+7 (333) 444-55-66",
            email: "smirnov@example.com",
            address: "г. Казань, ул. Баумана, д. 8, кв. 3",
            passportSeries: "4514",
            passportNumber: "901234",
            passportIssueDate: new DateTime(2002, 12, 18),
            passportIssuingAuthority: "ОВД г. Казани"
        ));

        patients.Add(new Patient(
            
            lastName: "Михайлова",
            firstName: "Елена",
            middleName: "Олеговна",
            birthDate: new DateTime(1990, 7, 19),
            gender: GenderEnum.женский,
            phoneNumber: "+7 (444) 555-66-77",
            email: "mikhailova@example.com",
            address: "г. Нижний Новгород, ул. Горького, д. 12, кв. 9",
            passportSeries: "4515",
            passportNumber: "112233",
            passportIssueDate: new DateTime(2008, 4, 22),
            passportIssuingAuthority: "УФМС г. Нижнего Новгорода"
        ));

        patients.Add(new Patient(
            
            lastName: "Федоров",
            firstName: "Алексей",
            middleName: "Викторович",
            birthDate: new DateTime(1979, 3, 8),
            gender: GenderEnum.мужской,
            phoneNumber: "+7 (555) 666-77-88",
            email: "fedorov@example.com",
            address: "г. Самара, ул. Куйбышева, д. 20, кв. 15",
            passportSeries: "4516",
            passportNumber: "445566",
            passportIssueDate: new DateTime(1999, 9, 9),
            passportIssuingAuthority: "ОВД г. Самары"
        ));

        patients.Add(new Patient(
            
            lastName: "Морозова",
            firstName: "Ольга",
            middleName: "Павловна",
            birthDate: new DateTime(1985, 10, 5),
            gender: GenderEnum.женский,
            phoneNumber: "+7 (666) 777-88-99",
            email: "morozova@example.com",
            address: "г. Омск, ул. Красный Путь, д. 3, кв. 6",
            passportSeries: "4517",
            passportNumber: "778899",
            passportIssueDate: new DateTime(2003, 11, 11),
            passportIssuingAuthority: "УФМС г. Омска"
        ));

        patients.Add(new Patient(
            
            lastName: "Волков",
            firstName: "Андрей",
            middleName: "Игоревич",
            birthDate: new DateTime(1995, 6, 25),
            gender: GenderEnum.мужской,
            phoneNumber: "+7 (777) 888-99-00",
            email: "volkov@example.com",
            address: "г. Ростов-на-Дону, ул. Большая Садовая, д. 7, кв. 4",
            passportSeries: "4518",
            passportNumber: "556677",
            passportIssueDate: new DateTime(2013, 2, 14),
            passportIssuingAuthority: "ОВД г. Ростова-на-Дону"
        ));

        patients.Add(new Patient(
            lastName: "Соколова",
            firstName: "Татьяна",
            middleName: "Анатольевна",
            birthDate: new DateTime(1982, 4, 17),
            gender: GenderEnum.женский,
            phoneNumber: "+7 (888) 999-00-11",
            email: "sokolova@example.com",
            address: "г. Уфа, ул. Октября, д. 9, кв. 10",
            passportSeries: "4519",
            passportNumber: "998877",
            passportIssueDate: new DateTime(2001, 5, 30),
            passportIssuingAuthority: "УФМС г. Уфы"
        ));

        patients.Add(new Patient(
            lastName: "Лебедев",
            firstName: "Николай",
            middleName: "Сергеевич",
            birthDate: new DateTime(1987, 9, 12),
            gender: GenderEnum.мужской,
            phoneNumber: "+7 (999) 000-11-22",
            email: "lebedev@example.com",
            address: "г. Красноярск, ул. Ленина, д. 25, кв. 8",
            passportSeries: "4520",
            passportNumber: "334455",
            passportIssueDate: new DateTime(2006, 8, 8),
            passportIssuingAuthority: "ОВД г. Красноярска"
        ));

        patients.Add(new Patient(
            lastName: "Козлова",
            firstName: "Светлана",
            middleName: "Дмитриевна",
            birthDate: new DateTime(1993, 1, 3),
            gender: GenderEnum.женский,
            phoneNumber: "+7 (111) 222-33-44",
            email: "kozlova@example.com",
            address: "г. Воронеж, ул. Плехановская, д. 14, кв. 2",
            passportSeries: "4521",
            passportNumber: "667788",
            passportIssueDate: new DateTime(2011, 10, 10),
            passportIssuingAuthority: "УФМС г. Воронежа"
        ));

        patients.Add(new Patient(
            lastName: "Новиков",
            firstName: "Максим",
            middleName: "Александрович",
            birthDate: new DateTime(1981, 7, 21),
            gender: GenderEnum.мужской,
            phoneNumber: "+7 (222) 333-44-55",
            email: "novikov@example.com",
            address: "г. Пермь, ул. Комсомольский пр., д. 6, кв. 11",
            passportSeries: "4522",
            passportNumber: "223344",
            passportIssueDate: new DateTime(2000, 12, 1),
            passportIssuingAuthority: "ОВД г. Перми"
        ));

        patients.Add(new Patient(
            lastName: "Зайцева",
            firstName: "Наталья",
            middleName: "Ивановна",
            birthDate: new DateTime(1989, 5, 28),
            gender: GenderEnum.женский,
            phoneNumber: "+7 (333) 444-55-66",
            email: "zaytseva@example.com",
            address: "г. Волгоград, ул. Мира, д. 11, кв. 3",
            passportSeries: "4523",
            passportNumber: "556644",
            passportIssueDate: new DateTime(2007, 6, 6),
            passportIssuingAuthority: "УФМС г. Волгограда"
        ));

        patients.Add(new Patient(
            lastName: "Павлов",
            firstName: "Михаил",
            middleName: "Геннадьевич",
            birthDate: new DateTime(1978, 2, 9),
            gender: GenderEnum.мужской,
            phoneNumber: "+7 (444) 555-66-77",
            email: "pavlov@example.com",
            address: "г. Саратов, ул. Московская, д. 17, кв. 5",
            passportSeries: "4524",
            passportNumber: "998822",
            passportIssueDate: new DateTime(1998, 4, 15),
            passportIssuingAuthority: "ОВД г. Саратова"
        ));

        patients.Add(new Patient(
            lastName: "Борисова",
            firstName: "Ирина",
            middleName: "Викторовна",
            birthDate: new DateTime(1991, 12, 11),
            gender: GenderEnum.женский,
            phoneNumber: "+7 (555) 666-77-88",
            email: "borisova@example.com",
            address: "г. Тюмень, ул. Республики, д. 22, кв. 9",
            passportSeries: "4525",
            passportNumber: "113366",
            passportIssueDate: new DateTime(2009, 9, 9),
            passportIssuingAuthority: "УФМС г. Тюмени"
        ));

        patients.Add(new Patient(
            lastName: "Соловьев",
            firstName: "Владимир",
            middleName: "Петрович",
            birthDate: new DateTime(1984, 3, 19),
            gender: GenderEnum.мужской,
            phoneNumber: "+7 (666) 777-88-99",
            email: "solovyev@example.com",
            address: "г. Барнаул, ул. Ленина, д. 13, кв. 6",
            passportSeries: "4526",
            passportNumber: "447788",
            passportIssueDate: new DateTime(2002, 11, 20),
            passportIssuingAuthority: "ОВД г. Барнаула"
        ));

        patients.Add(new Patient(
            lastName: "Васильева",
            firstName: "Екатерина",
            middleName: "Алексеевна",
            birthDate: new DateTime(1986, 8, 30),
            gender: GenderEnum.женский,
            phoneNumber: "+7 (777) 888-99-00",
            email: "vasilieva@example.com",
            address: "г. Ижевск, ул. Пушкинская, д. 4, кв. 7",
            passportSeries: "4527",
            passportNumber: "225588",
            passportIssueDate: new DateTime(2004, 5, 5),
            passportIssuingAuthority: "УФМС г. Ижевска"
        ));

        patients.Add(new Patient(
            lastName: "Попов",
            firstName: "Артем",
            middleName: "Валерьевич",
            birthDate: new DateTime(1994, 10, 2),
            gender: GenderEnum.мужской,
            phoneNumber: "+7 (888) 999-00-11",
            email: "popov@example.com",
            address: "г. Ульяновск, ул. Гончарова, д. 8, кв. 4",
            passportSeries: "4528",
            passportNumber: "669933",
            passportIssueDate: new DateTime(2012, 7, 12),
            passportIssuingAuthority: "ОВД г. Ульяновска"
        ));

        patients.Add(new Patient(
            lastName: "Алексеева",
            firstName: "Дарья",
            middleName: "Сергеевна",
            birthDate: new DateTime(1996, 4, 7),
            gender: GenderEnum.женский,
            phoneNumber: "+7 (999) 000-11-22",
            email: "alekseeva@example.com",
            address: "г. Ярославль, ул. Свободы, д. 21, кв. 8",
            passportSeries: "4529",
            passportNumber: "771122",
            passportIssueDate: new DateTime(2014, 3, 3),
            passportIssuingAuthority: "УФМС г. Ярославля"
        ));

        return patients;
    }
}