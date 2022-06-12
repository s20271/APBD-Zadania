static async Task Main(string[] args)
{
    //1 opcja
    List<string> list = new List<string>();
    using (StreamReader stream = new StreamReader(@"C:\Users\mpazio\Downloads\OneDrive_2022-03-20\2. Æwiczenia 2\Zadanie 1\dane.csv"))
    {
        string line;
        while ((line = stream.ReadLine()) != null)
        {
            list.Add(line);
        }
    }
    using (StreamWriter stream = new StreamWriter("opcja1.txt"))
    {
        foreach (var item in list)
        {
            stream.WriteLine(item);
        }
    }
    //2 opcja
    string[] result2 = await File.ReadAllLinesAsync(@"C:\Users\mpazio\Downloads\OneDrive_2022-03-20\2. Æwiczenia 2\Zadanie 1\dane.csv");
    await File.WriteAllLinesAsync("opcja2.txt", result2);
    string a = "";
    string[] b = a.Split(',');
    new Student { };
    //var jObject = new JObject();
    // { }
    var jArray = new JArray();
    // []
    var jProperty = new JProperty("property", jArray);
    // nazwaProperty: ""
    var jObject = new JObject(
        new JProperty("uczelnia", new JObject(
            new JProperty("createdAt", DateTime.Today.ToString("dd.MM.yyyy")),
            new JProperty("author", "Micha³ Pazio")
        ))
    );
    Console.WriteLine(jObject);
}

//1. Jako, ¿e konstruktor nie mo¿e byæ asynchroniczny, poni¿ej jest przyk³ad metody statycznej inicjalizuj¹c¹ klasê
class StudentParser
{
    private HashSet<Student> _students;
    public static async Task<StudentParser> Parse(List<string> studentDataList)
    {
        var students = new HashSet<Student>(new StudentComparer());
        foreach (var student in studentDataList)
        {
            await ParseStudentAsync(student, students);
        }
        return new StudentParser { _students = students };
    }
}
//2. Comparator, który mo¿emy u¿yæ w kolekcji np. HashSet
var set = new HashSet<Student>(new StudentComparer());
public class StudentComparer : IEqualityComparer<Student>
{
    public bool Equals(Student x, Student y)
    {
        return (x.Imie == y.Imie)
            && (x.Nazwisko == y.Nazwisko)
            && (x.NrIndeksu == y.NrIndeksu);
    }
    public int GetHashCode(Student obj)
    {
        return obj.NrIndeksu.GetHashCode();
    }
}

static async void Log(string s)
{
    using (StreamWriter streamWriter = new("log.txt"))
    {
        streamWriter.WriteLine(s);
    }
}