using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Program
{
    class CollageManagement
    {
        Dictionary<string, Dictionary<string, int>> studentRecords = new Dictionary<string, Dictionary<string, int>>();
        Dictionary<string, LinkedList<KeyValuePair<string, int>>> studentSubjectsOrder = new Dictionary<string, LinkedList<KeyValuePair<string, int>>>();

        Dictionary<string, Dictionary<string, int>> subjectsRecords = new Dictionary<string, Dictionary<string, int>>();
        Dictionary<string, LinkedList<KeyValuePair<string, int>>> subjectsStudentsOrder = new Dictionary<string, LinkedList<KeyValuePair<string, int>>>();

        public int AddStudent(string studentId, string subject, int marks)
        {
            if (!studentRecords.ContainsKey(studentId))
            {
                studentRecords[studentId] = new Dictionary<string, int>();
                studentSubjectsOrder[studentId] = new LinkedList<KeyValuePair<string, int>>();
            }

            if (!subjectsRecords.ContainsKey(subject))
            {
                subjectsRecords[subject] = new Dictionary<string, int>();
                subjectsStudentsOrder[subject] = new LinkedList<KeyValuePair<string, int>>();
            }

            if (studentRecords[studentId].ContainsKey(subject))
            {
                if (marks > studentRecords[studentId][subject])
                {
                    studentRecords[studentId][subject] = marks;
                    subjectsRecords[subject][studentId] = marks;

                    var node = studentSubjectsOrder[studentId].First;
                    while (node != null)
                    {
                        if (node.Value.Key == subject)
                        {
                            node.Value = new KeyValuePair<string, int>(subject, marks);
                            break;
                        }
                        node = node.Next;
                    }

                    var node2 = subjectsStudentsOrder[subject].First;
                    while (node2 != null)
                    {
                        if (node2.Value.Key == studentId)
                        {
                            node2.Value = new KeyValuePair<string, int>(studentId, marks);
                            break;
                        }
                        node2 = node2.Next;
                    }
                }
            }
            else
            {
                studentRecords[studentId][subject] = marks;
                subjectsRecords[subject][studentId] = marks;

                studentSubjectsOrder[studentId].AddLast(new KeyValuePair<string, int>(subject, marks));
                subjectsStudentsOrder[subject].AddLast(new KeyValuePair<string, int>(studentId, marks));
            }

            return 1;
        }

        public int RemoveStudent(string studentId)
        {
            if (!studentRecords.ContainsKey(studentId)) return 0;

            foreach (var subject in studentRecords[studentId].Keys)
            {
                subjectsRecords[subject].Remove(studentId);

                var list = subjectsStudentsOrder[subject];
                var node = list.First;
                while (node != null)
                {
                    if (node.Value.Key == studentId)
                    {
                        var temp = node;
                        node = node.Next;
                        list.Remove(temp);
                    }
                    else node = node.Next;
                }
            }

            studentRecords.Remove(studentId);
            studentSubjectsOrder.Remove(studentId);

            return 1;
        }

        public string TopStudent(string subject)
        {
            if (!subjectsStudentsOrder.ContainsKey(subject)) return "";

            int max = int.MinValue;
            foreach (var kv in subjectsRecords[subject])
            {
                max = Math.Max(max, kv.Value);
            }

            StringBuilder sb = new StringBuilder();
            foreach (var kv in subjectsStudentsOrder[subject])
            {
                if (kv.Value == max)
                {
                    sb.AppendLine($"{kv.Key} {kv.Value}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string Result()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var student in studentRecords)
            {
                double avg = student.Value.Values.Average();
                sb.AppendLine($"{student.Key} {avg:F2}");
            }

            return sb.ToString().TrimEnd();
        }
    }

    public static void Main()
    {
        var cm = new CollageManagement();

        cm.AddStudent("S1", "Math", 80);
        cm.AddStudent("S2", "Math", 90);
        cm.AddStudent("S3", "Math", 90);
        cm.AddStudent("S1", "Phy", 90);

        Console.WriteLine(cm.TopStudent("Math"));
        Console.WriteLine(cm.Result());

        cm.RemoveStudent("S1");
    }
}