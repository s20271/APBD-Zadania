using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;

namespace XYZExporter
{
    internal class Program
    {
        static string outputDirectory;
        static string inputFile;
        static string fileFormat;
        static string errorMessage;
        static int errorCounter = 1;
        static bool isRepeat = false;

        static async Task Main(string[] args)
        {
            try
            {
                outputDirectory = args[0];
                inputFile = args[1];
                fileFormat = args[2];
                String outputFile = outputDirectory + "resault." + fileFormat;

                if (!Directory.Exists(outputDirectory))
                {
                    errorMessage = "Podana ścieżka jest niepoprawna";
                    Log(errorMessage);
                    throw new ArgumentException(errorMessage);
                }
                if (!File.Exists(inputFile))
                {
                    errorMessage = "Plik " + inputFile + " nie istnieje";
                    Log(errorMessage);
                    throw new FileNotFoundException(errorMessage);
                }
                if (!fileFormat.Equals("json")) 
                {
                    errorMessage = "Wprowadzono bledny format pliku";
                    Log(errorMessage);
                    throw new Exception(errorMessage);
                }

                int recordCounter = 1;
                HashSet<Student> listOfStudents = new HashSet<Student>();
                using (StreamReader stream = new StreamReader(inputFile))
                {
                    string line = "";
                    while((line = stream.ReadLine()) != null)
                    {
                        string[] students = line.Split(',');
                        if(students.Length == 9)
                        {
                            if (students.Any(x => x.Equals("")))
                            {
                                Log("Student z rekordu numer " + recordCounter + " zostal pominiety ze wgledu na zerowa wartosc jednego z pol");
                                recordCounter++;
                            }
                            else
                            {
                                Student student = new Student
                                {
                                    FirstName = students[0],
                                    LastName = students[1],
                                    Department = students[2],
                                    LearningMode = students[3],
                                    IndexNumber = students[4],
                                    DateOfBirth = students[5],
                                    Email = students[6],
                                    MotherName = students[7],
                                    FatherName = students[8]
                                };
                                foreach(Student s in listOfStudents)
                                {
                                    if(s.Equals(student, s))
                                    {
                                        Log("Student z rekordu numer " + recordCounter + " zostal pominiety ze wgledu na powtorzenie");
                                        isRepeat = true;
                                    }
                                }
                                if(!isRepeat)
                                {
                                    listOfStudents.Add(student);
                                }
                                else
                                {
                                    isRepeat = false;
                                }
                                    
                            }
                        }
                        else
                        {
                            Log("Student z rekordu numer "+recordCounter+" zostal pominiety ze wgledu na niewystarczajaca liczbe danych.");
                        }
                        recordCounter++;
                    }
                        File.WriteAllText(outputFile, JsonConvert.SerializeObject(listOfStudents));
                }
            }
            catch (IndexOutOfRangeException i)
            {
                errorMessage = "Wprowadzono niepoprawna liczbe argumentow";
                Log(errorMessage);
                Console.WriteLine(errorMessage);
            }
            catch(ArgumentException a)
            {
                Console.WriteLine(a);
            }
            catch(FileNotFoundException f)
            {
                Console.WriteLine(f);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
              
        }

        static async void Log(string s) 
        {
            string logFileName = "log.txt"
;
                using (StreamWriter stream = new(logFileName, true))
                {
                    stream.WriteLine(errorCounter+") "+s);
                errorCounter++;
                }
        }
    }
}
   

