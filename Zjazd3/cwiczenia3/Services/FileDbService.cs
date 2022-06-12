using Cw3.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace Cw3.Services
{
    public class FileDbService : IFileDbService
    {

        private static readonly string outputFile = "students.csv";

        public static IEnumerable<Student> studendsList = new List<Student>{};

        private static List<Student> ModifiableList = GetTempList();

        public static void Write(List<Student> studentList)
        {
           try
            {
                TextWriter tw = new StreamWriter(outputFile);
                foreach (Student stu in studentList)
                {
                    string s = stu.FirstName + "," + stu.LastName + "," + stu.IndexNumber + "," + stu.DateOfBirth + "," + stu.Department + "," + stu.LearningMode
                        + "," + stu.Email + "," + stu.MotherName + "," + stu.FatherName;
                    tw.WriteLine(s);
                }
                tw.Close();
            }
            catch(Exception)
            {
                throw new IOException();
            }
        }

        public static void Read()
        {
            ModifiableList = new List<Student>();
            try
            {
                var lines = System.IO.File.ReadAllLines(outputFile);
                foreach (string s in lines)
                {
                    var line = s.Split(',');
                    ModifiableList.Add(new Student()
                    {
                        FirstName = line[0],
                        LastName = line[1],
                        IndexNumber = line[2],
                        DateOfBirth = line[3],
                        Department = line[4],
                        LearningMode = line[5],
                        Email = line[6],
                        MotherName = line[7],
                        FatherName = line[8]
                    });
                }
                studendsList = ModifiableList;
            }
            catch(FileNotFoundException)
            {
               throw new FileNotFoundException(); 
            }
            catch(IOException)
            {
                throw new IOException();
            }
            catch(IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException();
            }
        }


        public static List<Student> GetTempList()
        {
            List<Student> tempList = new List<Student> { };
            foreach (Student s in studendsList)
            {
                tempList.Add(s);
            }
            return tempList;
        }
        public static bool IsIndexNumberExists(string indexNumber)
        {
            List<string> tempList = new() { };
            foreach (Student s in studendsList)
            {
                tempList.Add(s.IndexNumber);
            }
            if (tempList.Contains(indexNumber)) return true;
            else return false;

        }
        public bool AddStudent(Student student)
        {
            if (student != null)
            {
                List<Student> tempList = GetTempList();
                tempList.Add(student);
                studendsList = tempList;
                Write(tempList);
                return true;
            }
            else
            {
                return false;
            }

        }

        public Student GetStudent(string indexNumber)
        {

            foreach (Student s in ModifiableList)
            {
                if (s.IndexNumber == indexNumber)
                {
                    return s;
                }
            }
            return null;
        }

        public IEnumerable<Student> GetStudents()
        {
            Read();
            return studendsList;
        }

        public void SetStudent(string indexNumber, Student student)
        {
            List<Student> tempList = GetTempList();
            foreach (Student s in tempList)
            {
                if (s.IndexNumber == indexNumber)
                {
                    s.FirstName = student.FirstName;
                    s.LastName = student.LastName;
                    s.IndexNumber = student.IndexNumber;
                    s.DateOfBirth = student.DateOfBirth;
                    s.Department = student.Department;
                    s.LearningMode = student.LearningMode;
                    s.Email = student.Email;
                    s.MotherName = student.MotherName;
                    s.FatherName = student.FatherName;
                }
            }
            Write(tempList);
        }

        public void DeleteStudent(Student student)
        {
            List<Student> tempList = GetTempList();
            tempList.Remove(student);
            Write(tempList);
        }

        public static string CheckData(Student student)
        {
            if (!Regex.IsMatch(student.IndexNumber, @"s[0-9]+"))
            {
                return "Format numeru indeksowego jest niepoprawny";
            }
            else
            {
                string[] tabStudentField = new string[8];
                tabStudentField[0] = student.FirstName;
                tabStudentField[1] = student.LastName;
                tabStudentField[2] = student.MotherName;
                tabStudentField[3] = student.FatherName;

                tabStudentField[4] = student.DateOfBirth;
                tabStudentField[5] = student.Department;
                tabStudentField[6] = student.LearningMode;
                tabStudentField[7] = student.Email;
                for(int i = 0; i < tabStudentField.Length; i++)
                {
                    if(i < 4)
                    {
                        if(!CheckEmptyString(tabStudentField[i]).Equals("OK"))
                        {
                            return CheckEmptyString(tabStudentField[i]);
                        }
                        if(!CheckCorrectName(tabStudentField[i]).Equals("OK"))
                        {
                            return CheckCorrectName(tabStudentField[i]);
                        }
                    }
                    if(i == 4)
                    {
                        if (!Regex.IsMatch(tabStudentField[i], @"\b(((0?[469]|11)/(0?[1-9]|[12]\d|30)|(0?[13578]|1[02])/(0?[1-9]|[12]\d|3[01])|0?2/(0?[1-9]|1\d|2[0-8]))/([1-9]\d{3}|\d{2})|0?2/29/([1-9]\d)?([02468][048]|[13579][26]))\b"))
                        {
                            return "Nieprawidlowy format daty. Poprawny format: mm/dd/rrrr";
                        }
                    }
                    if(i>4 && i < 7)
                    {
                        if (!CheckEmptyString(tabStudentField[i]).Equals("OK"))
                        {
                            return CheckEmptyString(tabStudentField[i]);
                        }
                    }
                    if(i == 7)
                    {
                        if(!Regex.IsMatch(tabStudentField[i], @".+@.+\..+"))
                        {
                            return "Nieprawidlowy adres e-mail";
                        }
                    }
                }
                return "OK";
            }         
        }

        private static string CheckEmptyString(string name) 
        {
            if (name.Trim().Equals(""))
            {
                return "Pole nie moze byc puste";
            }
            else 
            {
                return "OK";
            }
        }

        private static string CheckCorrectName(string name)
        {
            if(!Regex.IsMatch(name, @"[A-Z][a-z]+"))
            {
                return "Imie i nazwisko musza zaczynac sie z duzej litery i skladac sie z minimum dwoch liter";
            }
            else
            {
                return "OK";
            }
        }

        public static bool ChechFileExists() 
        {
            if (File.Exists(outputFile)) return true;
            else return false;
        }

    }
}