using System.Collections.Generic;
// See https://aka.ms/new-console-template for more information

bool isNullOrEmpty(string? value) {
    return (value == null || value.Length == 0);
}

void displayError(string error = "") {
    if(error.Length == 0)Console.WriteLine("Invalid input! pls try again");
    else {
        Console.WriteLine(error);
    }
}

double computeAverage(Dictionary<string, double> data) {
     double average = 0.0;
     foreach(var info in data) {
        average += info.Value;
    }
    return average/(double)data.Count;
}

string? name = "";
int subjects = -1;

Console.Write("Enter your Name: ");
name = Console.ReadLine();

Console.Write("How many subjects are you offering? ");
subjects = Convert.ToInt32(Console.ReadLine());

if(!isNullOrEmpty(name) && subjects != -1) {

    double grade;
    string? subjectName;
    Dictionary<string, double> data = new Dictionary<string, double>();

    Console.WriteLine("\nEnter the subject name and grade. Each inputs should be on a newline \n");
    
    Console.WriteLine(""" 
    for example:   Math
                   100
                   physics
                   50
    """);

    int subject = 0;

    while(subject < subjects) {

        subjectName = Console.ReadLine();
        
        if(isNullOrEmpty(subjectName)) {
            displayError("Subject name cannot be empty. Please try again.");
            continue;
        }
        else if (data.ContainsKey(subjectName!)) {
            displayError("Subjects can't be taken twice. Please retry.");
            continue;
        }
        else if (!double.TryParse(Console.ReadLine(), out grade) && grade >= 0 && grade <= 100 ) {
            displayError("Invalid grade format. Please enter a valid number.");
            continue;
        }
        else {
            data.Add(subjectName!, grade);
            subject += 1;
        }
    }
    Console.WriteLine("\n\n              ---------Result--------                 \n");

    foreach(var info in data) {
        Console.WriteLine($"{info.Key} : {info.Value}");
    }
    
    Console.WriteLine($"Average sum: {computeAverage(data)}");
}
else {
    displayError();
}
